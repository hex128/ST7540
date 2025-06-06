using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.IO.Ports;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;

namespace st7540_config
{
    public partial class Configform : Form
    {
        [DllImport("kernel32.dll")]                                             //延时用
        static extern uint GetTickCount();

        public string PortNum;
        public Configform()
        {
            InitializeComponent();
        }

        private void Configform_Load(object sender, EventArgs e)
        {
            Rectangle rect = new Rectangle();
            rect = Screen.GetWorkingArea(this);
            Point p = new Point((rect.Width - this.Width) / 2, (rect.Height - this.Height) / 2);
            this.Location = p;                                                          //设置初始位置    


            //初始化显示
            cmb_BaudRate.SelectedIndex = 2;         //串口波特率4800  
            cmb_StopBits.SelectedIndex = 0;         //停止位1          
            cmb_Parity.SelectedIndex = 0;           //无校验   
            cmb_PLC_B.SelectedIndex = 3;            //载波波特率4800
            cmb_PLC_F.SelectedIndex = 6;            //载波频率110000
        }

        /// <summary>
        /// 毫秒延时
        /// </summary>
        /// <param name="ms">毫秒数</param>
        public static void Delay(uint ms)                                              
        {
            uint start = GetTickCount();
            while (GetTickCount() - start < ms)
            { Application.DoEvents(); }
        }

        //获取当前配置按钮
        private void btn_getconfig_Click(object sender, EventArgs e)
        {
            try
            {
                if (combo_uart.Text == "") { MessageBox.Show("未选择串口"); return; }
                btn_getconfig.Enabled = false;
                btn_restore.Enabled = false;
                btn_config.Enabled = false;
                mycomm = new SerialPort(combo_uart.Text);
                mycomm.BaudRate = 9600;
                mycomm.DtrEnable = true;             //打开DTR
                mycomm.DataBits = 8;
                mycomm.Parity = Parity.None;
                mycomm.StopBits = StopBits.One;
                mycomm.Handshake = Handshake.None;
                mycomm.RtsEnable = false;               

                try { mycomm.Open(); }
                catch
                {
                    MessageBox.Show("打开串口失败");
                    btn_getconfig.Enabled = true;
                    btn_restore.Enabled = true;
                    btn_config.Enabled = true;
                    return;
                }
                Delay(100);
                readconfig();                       //读取配置信息
                mycomm.Close();
                btn_getconfig.Enabled = true;
                btn_restore.Enabled = true;
                btn_config.Enabled = true;
            }
            catch
            {
                MessageBox.Show("失败");
                btn_getconfig.Enabled = true;
                btn_restore.Enabled = true;
                btn_config.Enabled = true;
            }
        }

        //恢复默认按钮
        private void btn_restore_Click(object sender, EventArgs e)
        {
            try
            {
                if (combo_uart.Text == "") { MessageBox.Show("未选择串口"); }
                btn_getconfig.Enabled = false;
                btn_restore.Enabled = false;
                btn_config.Enabled = false;
                mycomm = new SerialPort(combo_uart.Text);
                mycomm.BaudRate = 9600;
                mycomm.DtrEnable = true;             //打开DTR
                try { mycomm.Open(); }
                catch
                {
                    MessageBox.Show("打开串口失败");
                    btn_getconfig.Enabled = true;
                    btn_restore.Enabled = true;
                    btn_config.Enabled = true;
                    return;
                }
                Delay(50);
                mycomm.Write("\n");               
                mycomm.Write("def\n");              

                Delay(1000);
                readconfig();
                mycomm.Close();
                btn_getconfig.Enabled = true;
                btn_restore.Enabled = true;
                btn_config.Enabled = true;
            }
            catch
            {
                btn_getconfig.Enabled = true;
                btn_restore.Enabled = true;
                btn_config.Enabled = true;
            }
        }

        //修改配置按钮
        private void btn_config_Click(object sender, EventArgs e)
        {
            try
            {                
                if (combo_uart.Text == "") { MessageBox.Show("未选择串口"); return; }
              
                btn_getconfig.Enabled = false;
                btn_restore.Enabled = false;
                btn_config.Enabled = false;
                mycomm = new SerialPort(combo_uart.Text);
                mycomm.BaudRate = 9600;
                mycomm.DtrEnable = true;             //打开DTR
                try { mycomm.Open(); }
                catch
                {
                    MessageBox.Show("打开串口失败");
                    btn_getconfig.Enabled = true;
                    btn_restore.Enabled = true;
                    btn_config.Enabled = true;
                    return;
                }
                if (setconfig()) { MessageBox.Show("配置成功"); }
                else
                {
                    MessageBox.Show("配置失败");
                }
                mycomm.Close();
                btn_getconfig.Enabled = true;
                btn_restore.Enabled = true;
                btn_config.Enabled = true;
            }
            catch
            {
                MessageBox.Show("配置出错,请检查输入");
                btn_getconfig.Enabled = true;
                btn_restore.Enabled = true;
                btn_config.Enabled = true;
            }
        }

        //读取设置
        private void readconfig()
        {
            Delay(50);
            mycomm.Write("\n");
            Delay(50);
            //打开回显
           // mycomm.Write("echo 1\n");
          
           // Delay(100);
            mycomm.DiscardInBuffer();            //清接收缓存   
            mycomm.Write("stat\n");
                       
            Delay(1000);
            string statstring = mycomm.ReadExisting();          
          //  string pattern = @"stat([\s\S]*?)>";
          //  if (!Regex.IsMatch(statstring, pattern))        //检测是否收全了配置信息
          //  {
          //      MessageBox.Show("读取配置信息失败"); mycomm.Close(); return;
          //  }
            mycomm.Close();


            string pattern_uart_b = @"com baud: (.*?)\n";
            if (!Regex.IsMatch(statstring, pattern_uart_b))
            {
                MessageBox.Show("读取配置信息失败"); return;
            }

            Match match_uart_b = Regex.Match(statstring, pattern_uart_b);
            try
            {
                cmb_BaudRate.Text = match_uart_b.Groups[1].Value;
            }
            catch
            {
                MessageBox.Show("读取配置信息出错"); return;
            }


            string pattern_uart_check = @"com check bit: (.*?)\n";
            if (!Regex.IsMatch(statstring, pattern_uart_check))
            {
                MessageBox.Show("读取配置信息失败"); return;
            }

            Match match_uart_check = Regex.Match(statstring, pattern_uart_check);
            try
            {
                cmb_Parity.SelectedIndex = Convert.ToInt32(match_uart_check.Groups[1].Value);
            }
            catch
            {
                MessageBox.Show("读取配置信息出错"); return;
            }


            string pattern_uart_stop = @"com stop bit: (.*?)\n";
            if (!Regex.IsMatch(statstring, pattern_uart_stop))
            {
                MessageBox.Show("读取配置信息失败"); return;
            }

            Match match_uart_stop = Regex.Match(statstring, pattern_uart_stop);
            try
            {
                cmb_StopBits.SelectedIndex = Convert.ToInt32(match_uart_stop.Groups[1].Value);
            }
            catch
            {
                MessageBox.Show("读取配置信息出错"); return;
            }

            string pattern_pwr_b = @"pwr baud: (.*?)\n";
            if (!Regex.IsMatch(statstring, pattern_pwr_b))
            {
                MessageBox.Show("读取配置信息失败"); return;
            }

            Match match_pwr_b = Regex.Match(statstring, pattern_pwr_b);
            try
            {
                cmb_PLC_B.Text = match_pwr_b.Groups[1].Value;
            }
            catch
            {
                MessageBox.Show("读取配置信息出错"); return;
            }

            string pattern_pwr_f = @"pwr freque: (.*?)\n";
            if (!Regex.IsMatch(statstring, pattern_pwr_f))
            {
                MessageBox.Show("读取配置信息失败"); return;
            }

            Match match_pwr_f = Regex.Match(statstring, pattern_pwr_f);
            try
            {
                cmb_PLC_F.Text = match_pwr_f.Groups[1].Value;
            }
            catch
            {
                MessageBox.Show("读取配置信息出错"); return;
            }


            MessageBox.Show("获取状态完毕");
         
            return;
        }

        //发送设置
        private bool setconfig()        
        {
            string backstr;
            string pattern;
            try
            {
                mycomm.Write("\n");
                Delay(50);
             
                
                mycomm.DiscardInBuffer();            //清接收缓存 
                //串口波特率
                mycomm.Write("uart_b " + cmb_BaudRate.Text + "\n");
                Delay(200);
                backstr = mycomm.ReadExisting();
                pattern = @"combuad setup complete";
                if (!Regex.IsMatch(backstr, pattern))        //检测是否收全了配置信息
                {
                     return false;
                }

                mycomm.DiscardInBuffer();            //清接收缓存 
                //停止位
                mycomm.Write("uart_stop_bit " + cmb_StopBits.SelectedIndex + "\n");
                Delay(200);
                backstr = mycomm.ReadExisting();
                pattern = @"stopbit setup complete";
                if (!Regex.IsMatch(backstr, pattern))        //检测是否收全了配置信息
                {
                    return false;
                }

                //校验位
                mycomm.Write("uart_check_bit " + cmb_Parity.SelectedIndex + "\n");
                Delay(200);
                backstr = mycomm.ReadExisting();
                pattern = @"checkbit setup complete";
                if (!Regex.IsMatch(backstr, pattern))        //检测是否收全了配置信息
                {
                    return false;
                }



                //载波波特率
                mycomm.Write("plc_b " + cmb_PLC_B.Text + "\n");
                Delay(200);
                backstr = mycomm.ReadExisting();
                pattern = @"pwrbaud setup complete";
                if (!Regex.IsMatch(backstr, pattern))        //检测是否收全了配置信息
                {
                    return false;
                }

                //载波频率
                mycomm.Write("plc_freq " + cmb_PLC_F.Text + "\n");
                Delay(200);
                backstr = mycomm.ReadExisting();
                pattern = @"pwrfreque setup complete";
                if (!Regex.IsMatch(backstr, pattern))        //检测是否收全了配置信息
                {
                    return false;
                }
                return true;
            }
            catch
            {
            
                return false;
            }
       
        }
       
        //关闭窗口事件
        private void Configform_FormClosing(object sender, FormClosingEventArgs e)
        {
            mycomm.Close();
        }

        //串口下拉框点击事件（搜索串口）
        private void combo_uart_Click(object sender, EventArgs e)
        {
            combo_uart.Items.Clear();
            string[] ports = SerialPort.GetPortNames();             //搜索串口
            Array.Sort(ports);
            combo_uart.Items.AddRange(ports);
        }
        
       


       
   

      
                
    }
}
