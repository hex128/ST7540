namespace st7540_config
{
    partial class Configform
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.mycomm = new System.IO.Ports.SerialPort(this.components);
            this.btn_config = new System.Windows.Forms.Button();
            this.label_Uart_B = new System.Windows.Forms.Label();
            this.label_PLC_B = new System.Windows.Forms.Label();
            this.label_StopBits = new System.Windows.Forms.Label();
            this.label_Parity = new System.Windows.Forms.Label();
            this.cmb_Parity = new System.Windows.Forms.ComboBox();
            this.cmb_StopBits = new System.Windows.Forms.ComboBox();
            this.cmb_BaudRate = new System.Windows.Forms.ComboBox();
            this.btn_restore = new System.Windows.Forms.Button();
            this.label_COMnumber = new System.Windows.Forms.Label();
            this.combo_uart = new System.Windows.Forms.ComboBox();
            this.btn_getconfig = new System.Windows.Forms.Button();
            this.cmb_PLC_B = new System.Windows.Forms.ComboBox();
            this.cmb_PLC_F = new System.Windows.Forms.ComboBox();
            this.label_PLC_F = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_config
            // 
            this.btn_config.Location = new System.Drawing.Point(353, 208);
            this.btn_config.Margin = new System.Windows.Forms.Padding(2);
            this.btn_config.Name = "btn_config";
            this.btn_config.Size = new System.Drawing.Size(81, 35);
            this.btn_config.TabIndex = 0;
            this.btn_config.Text = "修改配置";
            this.btn_config.UseVisualStyleBackColor = true;
            this.btn_config.Click += new System.EventHandler(this.btn_config_Click);
            // 
            // label_Uart_B
            // 
            this.label_Uart_B.AutoSize = true;
            this.label_Uart_B.Location = new System.Drawing.Point(36, 76);
            this.label_Uart_B.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_Uart_B.Name = "label_Uart_B";
            this.label_Uart_B.Size = new System.Drawing.Size(65, 12);
            this.label_Uart_B.TabIndex = 1;
            this.label_Uart_B.Text = "串口波特率";
            // 
            // label_PLC_B
            // 
            this.label_PLC_B.AutoSize = true;
            this.label_PLC_B.Location = new System.Drawing.Point(36, 160);
            this.label_PLC_B.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_PLC_B.Name = "label_PLC_B";
            this.label_PLC_B.Size = new System.Drawing.Size(65, 12);
            this.label_PLC_B.TabIndex = 2;
            this.label_PLC_B.Text = "载波波特率";
            // 
            // label_StopBits
            // 
            this.label_StopBits.AutoSize = true;
            this.label_StopBits.Location = new System.Drawing.Point(48, 118);
            this.label_StopBits.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_StopBits.Name = "label_StopBits";
            this.label_StopBits.Size = new System.Drawing.Size(41, 12);
            this.label_StopBits.TabIndex = 3;
            this.label_StopBits.Text = "停止位";
            // 
            // label_Parity
            // 
            this.label_Parity.AutoSize = true;
            this.label_Parity.Location = new System.Drawing.Point(266, 76);
            this.label_Parity.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_Parity.Name = "label_Parity";
            this.label_Parity.Size = new System.Drawing.Size(41, 12);
            this.label_Parity.TabIndex = 4;
            this.label_Parity.Text = "校验位";
            // 
            // cmb_Parity
            // 
            this.cmb_Parity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Parity.FormattingEnabled = true;
            this.cmb_Parity.Items.AddRange(new object[] {
            "无校验",
            "奇校验",
            "偶校验"});
            this.cmb_Parity.Location = new System.Drawing.Point(341, 72);
            this.cmb_Parity.Margin = new System.Windows.Forms.Padding(2);
            this.cmb_Parity.Name = "cmb_Parity";
            this.cmb_Parity.Size = new System.Drawing.Size(93, 20);
            this.cmb_Parity.TabIndex = 13;
            // 
            // cmb_StopBits
            // 
            this.cmb_StopBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_StopBits.FormattingEnabled = true;
            this.cmb_StopBits.Items.AddRange(new object[] {
            "1",
            "1.5",
            "2"});
            this.cmb_StopBits.Location = new System.Drawing.Point(120, 113);
            this.cmb_StopBits.Margin = new System.Windows.Forms.Padding(2);
            this.cmb_StopBits.Name = "cmb_StopBits";
            this.cmb_StopBits.Size = new System.Drawing.Size(93, 20);
            this.cmb_StopBits.TabIndex = 12;
            // 
            // cmb_BaudRate
            // 
            this.cmb_BaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_BaudRate.FormattingEnabled = true;
            this.cmb_BaudRate.Items.AddRange(new object[] {
            "1200",
            "2400",
            "4800",
            "9600",
            "14400",
            "19200",
            "28800",
            "38400",
            "57600",
            "115200",
            "230400",
            "460800"});
            this.cmb_BaudRate.Location = new System.Drawing.Point(120, 72);
            this.cmb_BaudRate.Margin = new System.Windows.Forms.Padding(2);
            this.cmb_BaudRate.Name = "cmb_BaudRate";
            this.cmb_BaudRate.Size = new System.Drawing.Size(93, 20);
            this.cmb_BaudRate.TabIndex = 10;
            // 
            // btn_restore
            // 
            this.btn_restore.Location = new System.Drawing.Point(201, 208);
            this.btn_restore.Margin = new System.Windows.Forms.Padding(2);
            this.btn_restore.Name = "btn_restore";
            this.btn_restore.Size = new System.Drawing.Size(76, 35);
            this.btn_restore.TabIndex = 33;
            this.btn_restore.Text = "恢复默认";
            this.btn_restore.UseVisualStyleBackColor = true;
            this.btn_restore.Click += new System.EventHandler(this.btn_restore_Click);
            // 
            // label_COMnumber
            // 
            this.label_COMnumber.BackColor = System.Drawing.Color.Transparent;
            this.label_COMnumber.Location = new System.Drawing.Point(36, 29);
            this.label_COMnumber.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_COMnumber.Name = "label_COMnumber";
            this.label_COMnumber.Size = new System.Drawing.Size(42, 17);
            this.label_COMnumber.TabIndex = 35;
            this.label_COMnumber.Text = "串口号";
            this.label_COMnumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // combo_uart
            // 
            this.combo_uart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_uart.FormattingEnabled = true;
            this.combo_uart.Location = new System.Drawing.Point(120, 27);
            this.combo_uart.Margin = new System.Windows.Forms.Padding(2);
            this.combo_uart.Name = "combo_uart";
            this.combo_uart.Size = new System.Drawing.Size(93, 20);
            this.combo_uart.TabIndex = 34;
            this.combo_uart.Click += new System.EventHandler(this.combo_uart_Click);
            // 
            // btn_getconfig
            // 
            this.btn_getconfig.AutoSize = true;
            this.btn_getconfig.Location = new System.Drawing.Point(38, 208);
            this.btn_getconfig.Margin = new System.Windows.Forms.Padding(2);
            this.btn_getconfig.Name = "btn_getconfig";
            this.btn_getconfig.Size = new System.Drawing.Size(87, 35);
            this.btn_getconfig.TabIndex = 36;
            this.btn_getconfig.Text = "获取当前状态";
            this.btn_getconfig.UseVisualStyleBackColor = true;
            this.btn_getconfig.Click += new System.EventHandler(this.btn_getconfig_Click);
            // 
            // cmb_PLC_B
            // 
            this.cmb_PLC_B.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_PLC_B.FormattingEnabled = true;
            this.cmb_PLC_B.Items.AddRange(new object[] {
            "600",
            "1200",
            "2400",
            "4800"});
            this.cmb_PLC_B.Location = new System.Drawing.Point(120, 156);
            this.cmb_PLC_B.Margin = new System.Windows.Forms.Padding(2);
            this.cmb_PLC_B.Name = "cmb_PLC_B";
            this.cmb_PLC_B.Size = new System.Drawing.Size(93, 20);
            this.cmb_PLC_B.TabIndex = 68;
            // 
            // cmb_PLC_F
            // 
            this.cmb_PLC_F.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_PLC_F.FormattingEnabled = true;
            this.cmb_PLC_F.Items.AddRange(new object[] {
            "60000",
            "66000",
            "72000",
            "76000",
            "82050",
            "86000",
            "110000",
            "132500"});
            this.cmb_PLC_F.Location = new System.Drawing.Point(341, 156);
            this.cmb_PLC_F.Margin = new System.Windows.Forms.Padding(2);
            this.cmb_PLC_F.Name = "cmb_PLC_F";
            this.cmb_PLC_F.Size = new System.Drawing.Size(93, 20);
            this.cmb_PLC_F.TabIndex = 70;
            // 
            // label_PLC_F
            // 
            this.label_PLC_F.AutoSize = true;
            this.label_PLC_F.Location = new System.Drawing.Point(257, 160);
            this.label_PLC_F.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_PLC_F.Name = "label_PLC_F";
            this.label_PLC_F.Size = new System.Drawing.Size(53, 12);
            this.label_PLC_F.TabIndex = 69;
            this.label_PLC_F.Text = "载波频率";
            // 
            // Configform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(486, 270);
            this.Controls.Add(this.cmb_PLC_F);
            this.Controls.Add(this.label_PLC_F);
            this.Controls.Add(this.cmb_PLC_B);
            this.Controls.Add(this.btn_getconfig);
            this.Controls.Add(this.label_COMnumber);
            this.Controls.Add(this.combo_uart);
            this.Controls.Add(this.btn_restore);
            this.Controls.Add(this.cmb_Parity);
            this.Controls.Add(this.cmb_StopBits);
            this.Controls.Add(this.cmb_BaudRate);
            this.Controls.Add(this.label_Parity);
            this.Controls.Add(this.label_StopBits);
            this.Controls.Add(this.label_PLC_B);
            this.Controls.Add(this.label_Uart_B);
            this.Controls.Add(this.btn_config);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Configform";
            this.ShowIcon = false;
            this.Text = "st7540电力线载波模块配置软件";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Configform_FormClosing);
            this.Load += new System.EventHandler(this.Configform_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort mycomm;
        private System.Windows.Forms.Button btn_config;
        private System.Windows.Forms.Label label_Uart_B;
        private System.Windows.Forms.Label label_PLC_B;
        private System.Windows.Forms.Label label_StopBits;
        private System.Windows.Forms.Label label_Parity;
        private System.Windows.Forms.ComboBox cmb_Parity;
        private System.Windows.Forms.ComboBox cmb_StopBits;
        private System.Windows.Forms.ComboBox cmb_BaudRate;
        private System.Windows.Forms.Button btn_restore;
        private System.Windows.Forms.Label label_COMnumber;
        private System.Windows.Forms.ComboBox combo_uart;
        private System.Windows.Forms.Button btn_getconfig;
        private System.Windows.Forms.ComboBox cmb_PLC_B;
        private System.Windows.Forms.ComboBox cmb_PLC_F;
        private System.Windows.Forms.Label label_PLC_F;
    }
}