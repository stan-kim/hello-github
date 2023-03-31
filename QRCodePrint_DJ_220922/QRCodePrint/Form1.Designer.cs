namespace QRCodePrint
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.TIME_date = new System.Windows.Forms.Label();
            this.tmDisplay = new System.Windows.Forms.Timer(this.components);
            this.lb_SWVER = new System.Windows.Forms.Label();
            this.lb_CON_PRINT = new System.Windows.Forms.Label();
            this.lb_CON_SERIAL = new System.Windows.Forms.Label();
            this.LB_LOG = new System.Windows.Forms.ListBox();
            this.lb_LOG_TEXT = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_TCP_CONNECT = new System.Windows.Forms.Button();
            this.tB_IP_PORT = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tB_IP = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_SERIAL_CONNECT = new System.Windows.Forms.Button();
            this.tB_SERIAL_PORT = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tB_BAUDRATE = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.SP_PLC = new System.IO.Ports.SerialPort(this.components);
            this.tmUI_Update = new System.Windows.Forms.Timer(this.components);
            this.tm_PLC = new System.Windows.Forms.Timer(this.components);
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cbInterfaces = new System.Windows.Forms.ComboBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTimeout = new System.Windows.Forms.TextBox();
            this.btnLoadFile = new System.Windows.Forms.Button();
            this.txtSend = new System.Windows.Forms.RichTextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnQuery = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.SAVE_Set = new System.Windows.Forms.Button();
            this.panelUSB = new System.Windows.Forms.Panel();
            this.cbUSBPorts = new System.Windows.Forms.ComboBox();
            this.textPartNum = new System.Windows.Forms.TextBox();
            this.textDate = new System.Windows.Forms.TextBox();
            this.textCount = new System.Windows.Forms.TextBox();
            this.textWriteSet = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ComMCU = new System.IO.Ports.SerialPort(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.TEST_2 = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.textPartNum2 = new System.Windows.Forms.TextBox();
            this.textCount2 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.textDate2 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.btnPrint2 = new System.Windows.Forms.Button();
            this.cbInterfaces2 = new System.Windows.Forms.ComboBox();
            this.panelUSB2 = new System.Windows.Forms.Panel();
            this.cbUSBPorts2 = new System.Windows.Forms.ComboBox();
            this.btnRefresh2 = new System.Windows.Forms.Button();
            this.cSingleLot = new System.Windows.Forms.CheckBox();
            this.TEST_1 = new System.Windows.Forms.Button();
            this.textIP_1 = new System.Windows.Forms.TextBox();
            this.textPort_1 = new System.Windows.Forms.TextBox();
            this.textIP_2 = new System.Windows.Forms.TextBox();
            this.textPort_2 = new System.Windows.Forms.TextBox();
            this.lblIP_1 = new System.Windows.Forms.Label();
            this.lblIP_2 = new System.Windows.Forms.Label();
            this.label_Port_1 = new System.Windows.Forms.Label();
            this.label_Port_2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panelUSB.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panelUSB2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("휴먼둥근헤드라인", 35F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.SlateGray;
            this.label1.Location = new System.Drawing.Point(100, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(517, 96);
            this.label1.TabIndex = 1;
            this.label1.Text = "검사기 QR Printer";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TIME_date
            // 
            this.TIME_date.BackColor = System.Drawing.Color.White;
            this.TIME_date.Font = new System.Drawing.Font("휴먼둥근헤드라인", 12F, System.Drawing.FontStyle.Bold);
            this.TIME_date.ForeColor = System.Drawing.Color.SlateGray;
            this.TIME_date.Location = new System.Drawing.Point(618, 38);
            this.TIME_date.Name = "TIME_date";
            this.TIME_date.Size = new System.Drawing.Size(183, 59);
            this.TIME_date.TabIndex = 4;
            this.TIME_date.Text = "TIME";
            this.TIME_date.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tmDisplay
            // 
            this.tmDisplay.Tick += new System.EventHandler(this.tmDisplay_Tick);
            // 
            // lb_SWVER
            // 
            this.lb_SWVER.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_SWVER.BackColor = System.Drawing.Color.White;
            this.lb_SWVER.Font = new System.Drawing.Font("휴먼둥근헤드라인", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_SWVER.ForeColor = System.Drawing.Color.SlateGray;
            this.lb_SWVER.Location = new System.Drawing.Point(618, 1);
            this.lb_SWVER.Name = "lb_SWVER";
            this.lb_SWVER.Size = new System.Drawing.Size(183, 36);
            this.lb_SWVER.TabIndex = 5;
            this.lb_SWVER.Text = "Ver.220921";
            this.lb_SWVER.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_CON_PRINT
            // 
            this.lb_CON_PRINT.BackColor = System.Drawing.Color.White;
            this.lb_CON_PRINT.Font = new System.Drawing.Font("휴먼엑스포", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_CON_PRINT.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lb_CON_PRINT.Location = new System.Drawing.Point(803, 70);
            this.lb_CON_PRINT.Name = "lb_CON_PRINT";
            this.lb_CON_PRINT.Size = new System.Drawing.Size(101, 27);
            this.lb_CON_PRINT.TabIndex = 8;
            this.lb_CON_PRINT.Text = "Connected";
            this.lb_CON_PRINT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_CON_SERIAL
            // 
            this.lb_CON_SERIAL.BackColor = System.Drawing.Color.White;
            this.lb_CON_SERIAL.Font = new System.Drawing.Font("휴먼엑스포", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_CON_SERIAL.ForeColor = System.Drawing.Color.Red;
            this.lb_CON_SERIAL.Location = new System.Drawing.Point(906, 70);
            this.lb_CON_SERIAL.Name = "lb_CON_SERIAL";
            this.lb_CON_SERIAL.Size = new System.Drawing.Size(101, 27);
            this.lb_CON_SERIAL.TabIndex = 10;
            this.lb_CON_SERIAL.Text = "Disconnected";
            this.lb_CON_SERIAL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LB_LOG
            // 
            this.LB_LOG.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LB_LOG.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_LOG.ForeColor = System.Drawing.Color.Black;
            this.LB_LOG.FormattingEnabled = true;
            this.LB_LOG.ItemHeight = 16;
            this.LB_LOG.Location = new System.Drawing.Point(614, 144);
            this.LB_LOG.Name = "LB_LOG";
            this.LB_LOG.Size = new System.Drawing.Size(392, 580);
            this.LB_LOG.TabIndex = 231;
            // 
            // lb_LOG_TEXT
            // 
            this.lb_LOG_TEXT.BackColor = System.Drawing.Color.White;
            this.lb_LOG_TEXT.Font = new System.Drawing.Font("휴먼둥근헤드라인", 12F, System.Drawing.FontStyle.Bold);
            this.lb_LOG_TEXT.ForeColor = System.Drawing.Color.SlateGray;
            this.lb_LOG_TEXT.Location = new System.Drawing.Point(614, 107);
            this.lb_LOG_TEXT.Name = "lb_LOG_TEXT";
            this.lb_LOG_TEXT.Size = new System.Drawing.Size(392, 34);
            this.lb_LOG_TEXT.TabIndex = 232;
            this.lb_LOG_TEXT.Text = "LOG";
            this.lb_LOG_TEXT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btn_TCP_CONNECT);
            this.panel1.Controls.Add(this.tB_IP_PORT);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.tB_IP);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Font = new System.Drawing.Font("휴먼엑스포", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.panel1.Location = new System.Drawing.Point(729, 482);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(274, 83);
            this.panel1.TabIndex = 242;
            this.panel1.Visible = false;
            // 
            // btn_TCP_CONNECT
            // 
            this.btn_TCP_CONNECT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.btn_TCP_CONNECT.Font = new System.Drawing.Font("휴먼엑스포", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_TCP_CONNECT.ForeColor = System.Drawing.Color.White;
            this.btn_TCP_CONNECT.Location = new System.Drawing.Point(114, 51);
            this.btn_TCP_CONNECT.Name = "btn_TCP_CONNECT";
            this.btn_TCP_CONNECT.Size = new System.Drawing.Size(122, 34);
            this.btn_TCP_CONNECT.TabIndex = 243;
            this.btn_TCP_CONNECT.Text = "Connect";
            this.btn_TCP_CONNECT.UseVisualStyleBackColor = false;
            this.btn_TCP_CONNECT.Click += new System.EventHandler(this.btn_TCP_CONNECT_Click);
            // 
            // tB_IP_PORT
            // 
            this.tB_IP_PORT.Font = new System.Drawing.Font("휴먼엑스포", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tB_IP_PORT.Location = new System.Drawing.Point(68, 28);
            this.tB_IP_PORT.Name = "tB_IP_PORT";
            this.tB_IP_PORT.Size = new System.Drawing.Size(168, 21);
            this.tB_IP_PORT.TabIndex = 245;
            this.tB_IP_PORT.Text = "9100";
            this.tB_IP_PORT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("휴먼엑스포", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label9.Location = new System.Drawing.Point(19, 31);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 13);
            this.label9.TabIndex = 244;
            this.label9.Text = "PORT :";
            // 
            // tB_IP
            // 
            this.tB_IP.Font = new System.Drawing.Font("휴먼엑스포", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tB_IP.Location = new System.Drawing.Point(68, 4);
            this.tB_IP.Name = "tB_IP";
            this.tB_IP.Size = new System.Drawing.Size(168, 21);
            this.tB_IP.TabIndex = 243;
            this.tB_IP.Text = "192.168.3.1";
            this.tB_IP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("휴먼엑스포", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label8.Location = new System.Drawing.Point(40, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(26, 13);
            this.label8.TabIndex = 243;
            this.label8.Text = "IP :";
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Gainsboro;
            this.label7.Font = new System.Drawing.Font("휴먼엑스포", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.label7.Location = new System.Drawing.Point(729, 457);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(274, 22);
            this.label7.TabIndex = 0;
            this.label7.Text = "PRINT SETUP";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label7.Visible = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.btn_SERIAL_CONNECT);
            this.panel2.Controls.Add(this.tB_SERIAL_PORT);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.tB_BAUDRATE);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Font = new System.Drawing.Font("휴먼엑스포", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.panel2.Location = new System.Drawing.Point(732, 640);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(274, 83);
            this.panel2.TabIndex = 244;
            this.panel2.Visible = false;
            // 
            // btn_SERIAL_CONNECT
            // 
            this.btn_SERIAL_CONNECT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.btn_SERIAL_CONNECT.Font = new System.Drawing.Font("휴먼엑스포", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_SERIAL_CONNECT.ForeColor = System.Drawing.Color.White;
            this.btn_SERIAL_CONNECT.Location = new System.Drawing.Point(89, 52);
            this.btn_SERIAL_CONNECT.Name = "btn_SERIAL_CONNECT";
            this.btn_SERIAL_CONNECT.Size = new System.Drawing.Size(122, 34);
            this.btn_SERIAL_CONNECT.TabIndex = 243;
            this.btn_SERIAL_CONNECT.Text = "Connect";
            this.btn_SERIAL_CONNECT.UseVisualStyleBackColor = false;
            this.btn_SERIAL_CONNECT.Click += new System.EventHandler(this.btn_SERIAL_CONNECT_Click);
            // 
            // tB_SERIAL_PORT
            // 
            this.tB_SERIAL_PORT.Font = new System.Drawing.Font("휴먼엑스포", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tB_SERIAL_PORT.Location = new System.Drawing.Point(100, 5);
            this.tB_SERIAL_PORT.Name = "tB_SERIAL_PORT";
            this.tB_SERIAL_PORT.Size = new System.Drawing.Size(111, 21);
            this.tB_SERIAL_PORT.TabIndex = 245;
            this.tB_SERIAL_PORT.Text = "COM1";
            this.tB_SERIAL_PORT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("휴먼엑스포", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label10.Location = new System.Drawing.Point(44, 10);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(50, 13);
            this.label10.TabIndex = 244;
            this.label10.Text = "PORT :";
            // 
            // tB_BAUDRATE
            // 
            this.tB_BAUDRATE.Font = new System.Drawing.Font("휴먼엑스포", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tB_BAUDRATE.Location = new System.Drawing.Point(100, 29);
            this.tB_BAUDRATE.Name = "tB_BAUDRATE";
            this.tB_BAUDRATE.Size = new System.Drawing.Size(111, 21);
            this.tB_BAUDRATE.TabIndex = 243;
            this.tB_BAUDRATE.Text = "9600";
            this.tB_BAUDRATE.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("휴먼엑스포", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label11.Location = new System.Drawing.Point(15, 32);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(79, 13);
            this.label11.TabIndex = 243;
            this.label11.Text = "BaudRate :";
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.Gainsboro;
            this.label12.Font = new System.Drawing.Font("휴먼엑스포", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.label12.Location = new System.Drawing.Point(732, 615);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(274, 22);
            this.label12.TabIndex = 243;
            this.label12.Text = "RS232 SETUP";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label12.Visible = false;
            // 
            // tmUI_Update
            // 
            this.tmUI_Update.Interval = 1000;
            this.tmUI_Update.Tick += new System.EventHandler(this.tmUI_Update_Tick);
            // 
            // tm_PLC
            // 
            this.tm_PLC.Interval = 500;
            this.tm_PLC.Tick += new System.EventHandler(this.tm_PLC_Tick);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.White;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox3.Image = global::QRCodePrint.Properties.Resources.plc;
            this.pictureBox3.Location = new System.Drawing.Point(906, 1);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(101, 67);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 9;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.White;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox2.Image = global::QRCodePrint.Properties.Resources.print1;
            this.pictureBox2.Location = new System.Drawing.Point(802, 1);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(101, 67);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Image = global::QRCodePrint.Properties.Resources.print;
            this.pictureBox1.Location = new System.Drawing.Point(1, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(98, 96);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // cbInterfaces
            // 
            this.cbInterfaces.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbInterfaces.FormattingEnabled = true;
            this.cbInterfaces.Items.AddRange(new object[] {
            "TCP/IP Socket",
            "Serial COM",
            "Parallel LPT",
            "USB Port",
            "Driver"});
            this.cbInterfaces.Location = new System.Drawing.Point(621, 185);
            this.cbInterfaces.Name = "cbInterfaces";
            this.cbInterfaces.Size = new System.Drawing.Size(140, 20);
            this.cbInterfaces.TabIndex = 245;
            this.cbInterfaces.Visible = false;
            this.cbInterfaces.SelectedIndexChanged += new System.EventHandler(this.cbInterfaces_SelectedIndexChanged);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.Location = new System.Drawing.Point(219, 8);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(27, 21);
            this.btnRefresh.TabIndex = 247;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Visible = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtTimeout);
            this.groupBox1.Controls.Add(this.btnLoadFile);
            this.groupBox1.Controls.Add(this.txtSend);
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.btnQuery);
            this.groupBox1.Controls.Add(this.btnSend);
            this.groupBox1.Location = new System.Drawing.Point(677, 211);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(326, 220);
            this.groupBox1.TabIndex = 248;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Send Data";
            this.groupBox1.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(172, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(155, 12);
            this.label4.TabIndex = 27;
            this.label4.Text = "Connection Timeout (ms):";
            // 
            // txtTimeout
            // 
            this.txtTimeout.Location = new System.Drawing.Point(194, 122);
            this.txtTimeout.Name = "txtTimeout";
            this.txtTimeout.Size = new System.Drawing.Size(47, 21);
            this.txtTimeout.TabIndex = 26;
            this.txtTimeout.Text = "2500";
            // 
            // btnLoadFile
            // 
            this.btnLoadFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoadFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadFile.Location = new System.Drawing.Point(10, 93);
            this.btnLoadFile.Name = "btnLoadFile";
            this.btnLoadFile.Size = new System.Drawing.Size(156, 23);
            this.btnLoadFile.TabIndex = 23;
            this.btnLoadFile.Text = "Load File";
            this.btnLoadFile.UseVisualStyleBackColor = true;
            this.btnLoadFile.Click += new System.EventHandler(this.btnLoadFile_Click);
            // 
            // txtSend
            // 
            this.txtSend.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.txtSend.Location = new System.Drawing.Point(5, 15);
            this.txtSend.MaxLength = 0;
            this.txtSend.Name = "txtSend";
            this.txtSend.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.txtSend.Size = new System.Drawing.Size(293, 72);
            this.txtSend.TabIndex = 0;
            this.txtSend.Text = "";
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnClear.Location = new System.Drawing.Point(10, 189);
            this.btnClear.Margin = new System.Windows.Forms.Padding(0);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(156, 23);
            this.btnClear.TabIndex = 21;
            this.btnClear.Text = "Clear All";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnQuery
            // 
            this.btnQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuery.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuery.Location = new System.Drawing.Point(10, 153);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(156, 23);
            this.btnQuery.TabIndex = 10;
            this.btnQuery.Text = "Query";
            this.btnQuery.UseVisualStyleBackColor = true;
            // 
            // btnSend
            // 
            this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSend.Location = new System.Drawing.Point(10, 122);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(156, 23);
            this.btnSend.TabIndex = 7;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Location = new System.Drawing.Point(12, 406);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(274, 64);
            this.btnPrint.TabIndex = 7;
            this.btnPrint.Text = "QR Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // SAVE_Set
            // 
            this.SAVE_Set.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SAVE_Set.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SAVE_Set.Location = new System.Drawing.Point(432, 498);
            this.SAVE_Set.Name = "SAVE_Set";
            this.SAVE_Set.Size = new System.Drawing.Size(175, 33);
            this.SAVE_Set.TabIndex = 7;
            this.SAVE_Set.Text = "SAVE";
            this.SAVE_Set.UseVisualStyleBackColor = true;
            this.SAVE_Set.Click += new System.EventHandler(this.btnSAVE_Click);
            // 
            // panelUSB
            // 
            this.panelUSB.Controls.Add(this.cbUSBPorts);
            this.panelUSB.Controls.Add(this.btnRefresh);
            this.panelUSB.Location = new System.Drawing.Point(5, 685);
            this.panelUSB.Name = "panelUSB";
            this.panelUSB.Size = new System.Drawing.Size(275, 32);
            this.panelUSB.TabIndex = 249;
            this.panelUSB.Visible = false;
            // 
            // cbUSBPorts
            // 
            this.cbUSBPorts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUSBPorts.FormattingEnabled = true;
            this.cbUSBPorts.Location = new System.Drawing.Point(-3, 8);
            this.cbUSBPorts.Name = "cbUSBPorts";
            this.cbUSBPorts.Size = new System.Drawing.Size(212, 20);
            this.cbUSBPorts.TabIndex = 250;
            this.cbUSBPorts.Visible = false;
            this.cbUSBPorts.SelectedIndexChanged += new System.EventHandler(this.cbUSBPorts_SelectedIndexChanged);
            // 
            // textPartNum
            // 
            this.textPartNum.Font = new System.Drawing.Font("휴먼엑스포", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textPartNum.Location = new System.Drawing.Point(94, 9);
            this.textPartNum.Name = "textPartNum";
            this.textPartNum.Size = new System.Drawing.Size(166, 29);
            this.textPartNum.TabIndex = 245;
            this.textPartNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textPartNum.TextChanged += new System.EventHandler(this.textPartNum_TextChanged);
            // 
            // textDate
            // 
            this.textDate.Font = new System.Drawing.Font("휴먼엑스포", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textDate.Location = new System.Drawing.Point(144, 593);
            this.textDate.Name = "textDate";
            this.textDate.Size = new System.Drawing.Size(111, 29);
            this.textDate.TabIndex = 245;
            this.textDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textDate.Visible = false;
            // 
            // textCount
            // 
            this.textCount.Font = new System.Drawing.Font("휴먼엑스포", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textCount.Location = new System.Drawing.Point(94, 63);
            this.textCount.Name = "textCount";
            this.textCount.Size = new System.Drawing.Size(166, 29);
            this.textCount.TabIndex = 245;
            this.textCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textCount.TextChanged += new System.EventHandler(this.textCount_TextChanged);
            // 
            // textWriteSet
            // 
            this.textWriteSet.BackColor = System.Drawing.Color.Gainsboro;
            this.textWriteSet.Font = new System.Drawing.Font("휴먼엑스포", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textWriteSet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.textWriteSet.Location = new System.Drawing.Point(11, 225);
            this.textWriteSet.Name = "textWriteSet";
            this.textWriteSet.Size = new System.Drawing.Size(274, 22);
            this.textWriteSet.TabIndex = 0;
            this.textWriteSet.Text = "QR Data Set Stage 1";
            this.textWriteSet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.textPartNum);
            this.panel3.Controls.Add(this.textCount);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Font = new System.Drawing.Font("휴먼엑스포", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.panel3.Location = new System.Drawing.Point(11, 250);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(274, 94);
            this.panel3.TabIndex = 246;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("휴먼엑스포", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.Location = new System.Drawing.Point(32, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 243;
            this.label5.Text = "Count :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("휴먼엑스포", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(26, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 243;
            this.label2.Text = "Part No. :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("휴먼엑스포", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(57, 602);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 243;
            this.label3.Text = "DATE :";
            this.label3.Visible = false;
            // 
            // ComMCU
            // 
            this.ComMCU.PortName = "COM2";
            this.ComMCU.ReadTimeout = 500;
            this.ComMCU.WriteTimeout = 500;
            this.ComMCU.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.ComMCU_DataReceived);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Gainsboro;
            this.label6.Font = new System.Drawing.Font("휴먼엑스포", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.label6.Location = new System.Drawing.Point(327, 225);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(274, 22);
            this.label6.TabIndex = 0;
            this.label6.Text = "QR Data Set Stage 2";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TEST_2
            // 
            this.TEST_2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TEST_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TEST_2.Location = new System.Drawing.Point(484, 559);
            this.TEST_2.Name = "TEST_2";
            this.TEST_2.Size = new System.Drawing.Size(98, 23);
            this.TEST_2.TabIndex = 7;
            this.TEST_2.Text = "Count Reset";
            this.TEST_2.UseVisualStyleBackColor = true;
            this.TEST_2.Visible = false;
            this.TEST_2.Click += new System.EventHandler(this.btnTEST_Click2);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.textPartNum2);
            this.panel4.Controls.Add(this.textCount2);
            this.panel4.Controls.Add(this.label13);
            this.panel4.Controls.Add(this.label15);
            this.panel4.Font = new System.Drawing.Font("휴먼엑스포", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.panel4.Location = new System.Drawing.Point(326, 250);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(274, 94);
            this.panel4.TabIndex = 246;
            // 
            // textPartNum2
            // 
            this.textPartNum2.Font = new System.Drawing.Font("휴먼엑스포", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textPartNum2.Location = new System.Drawing.Point(97, 9);
            this.textPartNum2.Name = "textPartNum2";
            this.textPartNum2.Size = new System.Drawing.Size(166, 29);
            this.textPartNum2.TabIndex = 245;
            this.textPartNum2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textPartNum2.TextChanged += new System.EventHandler(this.textPartNum2_TextChanged);
            // 
            // textCount2
            // 
            this.textCount2.Font = new System.Drawing.Font("휴먼엑스포", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textCount2.Location = new System.Drawing.Point(97, 63);
            this.textCount2.Name = "textCount2";
            this.textCount2.Size = new System.Drawing.Size(166, 29);
            this.textCount2.TabIndex = 245;
            this.textCount2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textCount2.TextChanged += new System.EventHandler(this.textCount2_TextChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("휴먼엑스포", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label13.Location = new System.Drawing.Point(36, 66);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(54, 13);
            this.label13.TabIndex = 243;
            this.label13.Text = "Count :";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("휴먼엑스포", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label15.Location = new System.Drawing.Point(30, 15);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(66, 13);
            this.label15.TabIndex = 243;
            this.label15.Text = "Part No. :";
            // 
            // textDate2
            // 
            this.textDate2.Font = new System.Drawing.Font("휴먼엑스포", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textDate2.Location = new System.Drawing.Point(383, 598);
            this.textDate2.Name = "textDate2";
            this.textDate2.Size = new System.Drawing.Size(111, 29);
            this.textDate2.TabIndex = 245;
            this.textDate2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textDate2.Visible = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("휴먼엑스포", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label14.Location = new System.Drawing.Point(297, 604);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(50, 13);
            this.label14.TabIndex = 243;
            this.label14.Text = "DATE :";
            this.label14.Visible = false;
            // 
            // btnPrint2
            // 
            this.btnPrint2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint2.Location = new System.Drawing.Point(328, 406);
            this.btnPrint2.Name = "btnPrint2";
            this.btnPrint2.Size = new System.Drawing.Size(274, 64);
            this.btnPrint2.TabIndex = 7;
            this.btnPrint2.Text = "QR Print";
            this.btnPrint2.UseVisualStyleBackColor = true;
            this.btnPrint2.Click += new System.EventHandler(this.btnPrint_Click2);
            // 
            // cbInterfaces2
            // 
            this.cbInterfaces2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbInterfaces2.FormattingEnabled = true;
            this.cbInterfaces2.Items.AddRange(new object[] {
            "TCP/IP Socket",
            "Serial COM",
            "Parallel LPT",
            "USB Port",
            "Driver"});
            this.cbInterfaces2.Location = new System.Drawing.Point(863, 185);
            this.cbInterfaces2.Name = "cbInterfaces2";
            this.cbInterfaces2.Size = new System.Drawing.Size(140, 20);
            this.cbInterfaces2.TabIndex = 245;
            this.cbInterfaces2.Visible = false;
            this.cbInterfaces2.SelectedIndexChanged += new System.EventHandler(this.cbInterfaces_SelectedIndexChanged2);
            // 
            // panelUSB2
            // 
            this.panelUSB2.Controls.Add(this.cbUSBPorts2);
            this.panelUSB2.Controls.Add(this.btnRefresh2);
            this.panelUSB2.Location = new System.Drawing.Point(336, 685);
            this.panelUSB2.Name = "panelUSB2";
            this.panelUSB2.Size = new System.Drawing.Size(275, 32);
            this.panelUSB2.TabIndex = 249;
            this.panelUSB2.Visible = false;
            // 
            // cbUSBPorts2
            // 
            this.cbUSBPorts2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUSBPorts2.FormattingEnabled = true;
            this.cbUSBPorts2.Location = new System.Drawing.Point(-3, 8);
            this.cbUSBPorts2.Name = "cbUSBPorts2";
            this.cbUSBPorts2.Size = new System.Drawing.Size(212, 20);
            this.cbUSBPorts2.TabIndex = 250;
            this.cbUSBPorts2.Visible = false;
            this.cbUSBPorts2.SelectedIndexChanged += new System.EventHandler(this.cbUSBPorts2_SelectedIndexChanged);
            // 
            // btnRefresh2
            // 
            this.btnRefresh2.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh2.Image")));
            this.btnRefresh2.Location = new System.Drawing.Point(219, 8);
            this.btnRefresh2.Name = "btnRefresh2";
            this.btnRefresh2.Size = new System.Drawing.Size(27, 21);
            this.btnRefresh2.TabIndex = 247;
            this.btnRefresh2.UseVisualStyleBackColor = true;
            this.btnRefresh2.Visible = false;
            this.btnRefresh2.Click += new System.EventHandler(this.btnRefresh_Click2);
            // 
            // cSingleLot
            // 
            this.cSingleLot.AutoSize = true;
            this.cSingleLot.Font = new System.Drawing.Font("굴림", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cSingleLot.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.cSingleLot.Location = new System.Drawing.Point(7, 498);
            this.cSingleLot.Name = "cSingleLot";
            this.cSingleLot.Size = new System.Drawing.Size(291, 33);
            this.cSingleLot.TabIndex = 250;
            this.cSingleLot.Text = "단일 Lot 사용 모드";
            this.cSingleLot.UseVisualStyleBackColor = true;
            this.cSingleLot.CheckedChanged += new System.EventHandler(this.cSingleLot_CheckedChanged);
            // 
            // TEST_1
            // 
            this.TEST_1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TEST_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TEST_1.Location = new System.Drawing.Point(154, 559);
            this.TEST_1.Name = "TEST_1";
            this.TEST_1.Size = new System.Drawing.Size(98, 23);
            this.TEST_1.TabIndex = 7;
            this.TEST_1.Text = "Count Reset";
            this.TEST_1.UseVisualStyleBackColor = true;
            this.TEST_1.Visible = false;
            this.TEST_1.Click += new System.EventHandler(this.btnTEST_Click);
            // 
            // textIP_1
            // 
            this.textIP_1.Font = new System.Drawing.Font("휴먼엑스포", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textIP_1.Location = new System.Drawing.Point(33, 163);
            this.textIP_1.Name = "textIP_1";
            this.textIP_1.Size = new System.Drawing.Size(138, 29);
            this.textIP_1.TabIndex = 245;
            this.textIP_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textPort_1
            // 
            this.textPort_1.Font = new System.Drawing.Font("휴먼엑스포", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textPort_1.Location = new System.Drawing.Point(218, 163);
            this.textPort_1.Name = "textPort_1";
            this.textPort_1.Size = new System.Drawing.Size(71, 29);
            this.textPort_1.TabIndex = 245;
            this.textPort_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textPort_1.TextChanged += new System.EventHandler(this.textPort_1_TextChanged);
            // 
            // textIP_2
            // 
            this.textIP_2.Font = new System.Drawing.Font("휴먼엑스포", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textIP_2.Location = new System.Drawing.Point(349, 163);
            this.textIP_2.Name = "textIP_2";
            this.textIP_2.Size = new System.Drawing.Size(138, 29);
            this.textIP_2.TabIndex = 245;
            this.textIP_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textPort_2
            // 
            this.textPort_2.Font = new System.Drawing.Font("휴먼엑스포", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textPort_2.Location = new System.Drawing.Point(529, 163);
            this.textPort_2.Name = "textPort_2";
            this.textPort_2.Size = new System.Drawing.Size(71, 29);
            this.textPort_2.TabIndex = 245;
            this.textPort_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblIP_1
            // 
            this.lblIP_1.AutoSize = true;
            this.lblIP_1.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblIP_1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblIP_1.Location = new System.Drawing.Point(9, 168);
            this.lblIP_1.Name = "lblIP_1";
            this.lblIP_1.Size = new System.Drawing.Size(23, 16);
            this.lblIP_1.TabIndex = 251;
            this.lblIP_1.Text = "IP";
            // 
            // lblIP_2
            // 
            this.lblIP_2.AutoSize = true;
            this.lblIP_2.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblIP_2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblIP_2.Location = new System.Drawing.Point(322, 168);
            this.lblIP_2.Name = "lblIP_2";
            this.lblIP_2.Size = new System.Drawing.Size(23, 16);
            this.lblIP_2.TabIndex = 251;
            this.lblIP_2.Text = "IP";
            // 
            // label_Port_1
            // 
            this.label_Port_1.AutoSize = true;
            this.label_Port_1.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_Port_1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label_Port_1.Location = new System.Drawing.Point(172, 168);
            this.label_Port_1.Name = "label_Port_1";
            this.label_Port_1.Size = new System.Drawing.Size(42, 16);
            this.label_Port_1.TabIndex = 251;
            this.label_Port_1.Text = "Port";
            // 
            // label_Port_2
            // 
            this.label_Port_2.AutoSize = true;
            this.label_Port_2.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_Port_2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label_Port_2.Location = new System.Drawing.Point(486, 168);
            this.label_Port_2.Name = "label_Port_2";
            this.label_Port_2.Size = new System.Drawing.Size(42, 16);
            this.label_Port_2.TabIndex = 251;
            this.label_Port_2.Text = "Port";
            // 
            // groupBox2
            // 
            this.groupBox2.Font = new System.Drawing.Font("휴먼엑스포", 12F, System.Drawing.FontStyle.Bold);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox2.Location = new System.Drawing.Point(2, 126);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(296, 353);
            this.groupBox2.TabIndex = 253;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "STAGE #1";
            // 
            // groupBox3
            // 
            this.groupBox3.Font = new System.Drawing.Font("휴먼엑스포", 12F, System.Drawing.FontStyle.Bold);
            this.groupBox3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox3.Location = new System.Drawing.Point(316, 126);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(296, 353);
            this.groupBox3.TabIndex = 254;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "STAGE #2";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.lblIP_2);
            this.Controls.Add(this.label_Port_2);
            this.Controls.Add(this.label_Port_1);
            this.Controls.Add(this.lblIP_1);
            this.Controls.Add(this.cSingleLot);
            this.Controls.Add(this.textDate2);
            this.Controls.Add(this.textPort_2);
            this.Controls.Add(this.textIP_2);
            this.Controls.Add(this.textPort_1);
            this.Controls.Add(this.textIP_1);
            this.Controls.Add(this.textDate);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panelUSB2);
            this.Controls.Add(this.panelUSB);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cbInterfaces2);
            this.Controls.Add(this.cbInterfaces);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnPrint2);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.TEST_1);
            this.Controls.Add(this.TEST_2);
            this.Controls.Add(this.SAVE_Set);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textWriteSet);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lb_LOG_TEXT);
            this.Controls.Add(this.LB_LOG);
            this.Controls.Add(this.lb_CON_SERIAL);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.lb_CON_PRINT);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lb_SWVER);
            this.Controls.Add(this.TIME_date);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "QR Code Print ";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panelUSB.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panelUSB2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label TIME_date;
        private System.Windows.Forms.Timer tmDisplay;
        private System.Windows.Forms.Label lb_SWVER;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label lb_CON_PRINT;
        private System.Windows.Forms.Label lb_CON_SERIAL;
        private System.Windows.Forms.ListBox LB_LOG;
        private System.Windows.Forms.Label lb_LOG_TEXT;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tB_IP;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btn_TCP_CONNECT;
        private System.Windows.Forms.TextBox tB_IP_PORT;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_SERIAL_CONNECT;
        private System.Windows.Forms.TextBox tB_SERIAL_PORT;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tB_BAUDRATE;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.IO.Ports.SerialPort SP_PLC;
        private System.Windows.Forms.Timer tmUI_Update;
        private System.Windows.Forms.Timer tm_PLC;
        private System.Windows.Forms.ComboBox cbInterfaces;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnLoadFile;
        private System.Windows.Forms.RichTextBox txtSend;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Panel panelUSB;
        private System.Windows.Forms.ComboBox cbUSBPorts;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTimeout;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.TextBox textPartNum;
        private System.Windows.Forms.TextBox textDate;
        private System.Windows.Forms.TextBox textCount;
        private System.Windows.Forms.Label textWriteSet;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button SAVE_Set;
        private System.IO.Ports.SerialPort ComMCU;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button TEST_2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox textPartNum2;
        private System.Windows.Forms.TextBox textDate2;
        private System.Windows.Forms.TextBox textCount2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnPrint2;
        private System.Windows.Forms.ComboBox cbInterfaces2;
        private System.Windows.Forms.Panel panelUSB2;
        private System.Windows.Forms.ComboBox cbUSBPorts2;
        private System.Windows.Forms.Button btnRefresh2;
        private System.Windows.Forms.CheckBox cSingleLot;
        private System.Windows.Forms.Button TEST_1;
        private System.Windows.Forms.TextBox textIP_1;
        private System.Windows.Forms.TextBox textPort_1;
        private System.Windows.Forms.TextBox textIP_2;
        private System.Windows.Forms.TextBox textPort_2;
        private System.Windows.Forms.Label lblIP_1;
        private System.Windows.Forms.Label lblIP_2;
        private System.Windows.Forms.Label label_Port_1;
        private System.Windows.Forms.Label label_Port_2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}

