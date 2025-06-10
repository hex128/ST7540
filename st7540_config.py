#!/usr/bin/env python3
import argparse
import serial
import sys
import time

stop_bit_map = {"1": 0, "1.5": 1, "2": 2}
check_bit_map = {"none": 0, "odd": 1, "even": 2}


def send_and_expect(ser, command, expect_start):
    ser.write((command + "\n").encode())
    while True:
        line = ser.readline().decode(errors="ignore").strip()
        if line.startswith(expect_start):
            return line
        elif not line:
            raise RuntimeError("No response or unexpected format")

def read_params(ser):
    ser.write(b"\nstat\n")
    params = {
        "com baud": None,
        "pwr freque": None,
        "pwr baud": None,
        "com stop bit": None,
        "com check bit": None,
    }

    while None in params.values():
        line = ser.readline().decode(errors="ignore").strip()
        for key in params:
            if line.startswith(f"{key}:"):
                value = line.split(":", 1)[1].strip()
                if key == "com stop bit":
                    params[key] = {str(v): k for k, v in stop_bit_map.items()}[value]
                elif key == "com check bit":
                    params[key] = {str(v): k for k, v in check_bit_map.items()}[value]
                else:
                    params[key] = value
            elif not line:
                raise RuntimeError("No response or unexpected format")

    for k, v in params.items():
        print(f"{k}: {v}")

def write_param(ser, name, value, expected_response):
    if value is None:
        return
    response = send_and_expect(ser, f"{name} {value}", expected_response)
    print(response)

def main():
    parser = argparse.ArgumentParser(description="ST7540 UART Device Configurator")
    parser.add_argument("port", help="Serial port (e.g. COM3 or /dev/ttyUSB0)")
    parser.add_argument("command", choices=["read", "write", "help"], help="Operation mode")
    parser.add_argument("-u", "--uart-baud", choices=[1200, 2400, 4800, 9600, 14400, 19200, 28800, 38400, 57600, 115200, 230400, 460800], type=int, help="UART baud rate")
    parser.add_argument("-s", "--stop-bit", choices=["1", "1.5", "2"], help="UART stop bit")
    parser.add_argument("-c", "--check-bit", choices=["0", "1", "2", "none", "odd", "even"], help="UART parity check bit")
    parser.add_argument("-p", "--plc-baud", type=int, choices=[600, 1200, 2400, 4800], help="PLC baud rate")
    parser.add_argument("-f", "--plc-freq", type=int, choices=[60000, 66000, 72000, 76000, 82050, 86000, 110000, 132500], help="PLC frequency")

    args = parser.parse_args()

    if args.command == "help":
        parser.print_help()
        exit(0)

    try:
        with serial.Serial(args.port, 9600, timeout=2) as ser:
            time.sleep(0.5)  # Wait for device ready
            if args.command == "read":
                read_params(ser)
            else:
                write_param(ser, "uart_b", args.uart_baud, "combuad setup complete")
                if args.stop_bit:
                    write_param(ser, "uart_stop_bit", stop_bit_map[args.stop_bit], "stopbit setup complete")
                if args.check_bit:
                    write_param(ser, "uart_check_bit", check_bit_map[args.check_bit], "checkbit setup complete")
                write_param(ser, "plc_b", args.plc_baud, "pwrbaud setup complete")
                write_param(ser, "plc_freq", args.plc_freq, "pwrfreque setup complete")
    except serial.SerialException as e:
        sys.stderr.write(f"Serial error: {e}\n")
        sys.exit(1)
    except RuntimeError as e:
        sys.stderr.write(f"Runtime error: {e}\n")
        sys.exit(1)

if __name__ == "__main__":
    main()
