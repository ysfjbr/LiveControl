namespace OBSServ
{
    partial class OBSserv
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.port_txt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pass_txt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ip_txt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.clientName_txt = new System.Windows.Forms.TextBox();
            this.conn_btn = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.data_str = new System.Windows.Forms.Label();
            this.obsPath_txt = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.command_timer = new System.Windows.Forms.Timer(this.components);
            this.obspath_open = new System.Windows.Forms.OpenFileDialog();
            this.label7 = new System.Windows.Forms.Label();
            this.obs_port_txt = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.port_txt);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.pass_txt);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.ip_txt);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.listBox1);
            this.groupBox1.Controls.Add(this.clientName_txt);
            this.groupBox1.Controls.Add(this.conn_btn);
            this.groupBox1.Location = new System.Drawing.Point(551, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(180, 347);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Connect to Server";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 27;
            this.label5.Text = "Port";
            // 
            // port_txt
            // 
            this.port_txt.Location = new System.Drawing.Point(77, 39);
            this.port_txt.MaxLength = 5;
            this.port_txt.Name = "port_txt";
            this.port_txt.Size = new System.Drawing.Size(89, 20);
            this.port_txt.TabIndex = 1;
            this.port_txt.Text = "8123";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "Password";
            // 
            // pass_txt
            // 
            this.pass_txt.Location = new System.Drawing.Point(77, 91);
            this.pass_txt.MaxLength = 200;
            this.pass_txt.Name = "pass_txt";
            this.pass_txt.PasswordChar = '*';
            this.pass_txt.Size = new System.Drawing.Size(89, 20);
            this.pass_txt.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 157);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Connected Devices";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Server IP";
            // 
            // ip_txt
            // 
            this.ip_txt.Location = new System.Drawing.Point(77, 13);
            this.ip_txt.MaxLength = 15;
            this.ip_txt.Name = "ip_txt";
            this.ip_txt.Size = new System.Drawing.Size(89, 20);
            this.ip_txt.TabIndex = 0;
            this.ip_txt.Text = "62.171.160.28";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Name";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(16, 313);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(150, 25);
            this.button3.TabIndex = 18;
            this.button3.Text = "Refresh";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(16, 173);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(150, 134);
            this.listBox1.TabIndex = 17;
            // 
            // clientName_txt
            // 
            this.clientName_txt.Location = new System.Drawing.Point(77, 65);
            this.clientName_txt.MaxLength = 200;
            this.clientName_txt.Name = "clientName_txt";
            this.clientName_txt.Size = new System.Drawing.Size(89, 20);
            this.clientName_txt.TabIndex = 2;
            this.clientName_txt.Text = "OBSServ";
            // 
            // conn_btn
            // 
            this.conn_btn.Location = new System.Drawing.Point(16, 117);
            this.conn_btn.Name = "conn_btn";
            this.conn_btn.Size = new System.Drawing.Size(150, 27);
            this.conn_btn.TabIndex = 4;
            this.conn_btn.Text = "Connect !";
            this.conn_btn.UseVisualStyleBackColor = true;
            this.conn_btn.Click += new System.EventHandler(this.conn_btn_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(20, 138);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(525, 221);
            this.textBox1.TabIndex = 23;
            // 
            // data_str
            // 
            this.data_str.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.data_str.BackColor = System.Drawing.SystemColors.ControlDark;
            this.data_str.Location = new System.Drawing.Point(-1, 387);
            this.data_str.Name = "data_str";
            this.data_str.Size = new System.Drawing.Size(743, 28);
            this.data_str.TabIndex = 21;
            this.data_str.Click += new System.EventHandler(this.data_str_Click);
            // 
            // obsPath_txt
            // 
            this.obsPath_txt.Location = new System.Drawing.Point(96, 25);
            this.obsPath_txt.Name = "obsPath_txt";
            this.obsPath_txt.Size = new System.Drawing.Size(312, 20);
            this.obsPath_txt.TabIndex = 17;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(414, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 23);
            this.button1.TabIndex = 18;
            this.button1.Text = "Browse";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "OBS Program";
            // 
            // command_timer
            // 
            this.command_timer.Enabled = true;
            this.command_timer.Interval = 5000;
            this.command_timer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // obspath_open
            // 
            this.obspath_open.FileName = "obs64.exe";
            this.obspath_open.Filter = "OBS Program(obs64.exe)|obs64.exe|Programs (*.exe)|*.exe";
            this.obspath_open.FileOk += new System.ComponentModel.CancelEventHandler(this.obspath_open_FileOk);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(39, 58);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "OBS Port";
            // 
            // obs_port_txt
            // 
            this.obs_port_txt.Location = new System.Drawing.Point(96, 54);
            this.obs_port_txt.Name = "obs_port_txt";
            this.obs_port_txt.Size = new System.Drawing.Size(74, 20);
            this.obs_port_txt.TabIndex = 23;
            this.obs_port_txt.TextChanged += new System.EventHandler(this.obs_port_txt_TextChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(276, 76);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(72, 42);
            this.button2.TabIndex = 24;
            this.button2.Text = "test";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // OBSserv
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(743, 415);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.obs_port_txt);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.data_str);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.obsPath_txt);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "OBSserv";
            this.Text = "OBSServ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OBSserv_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OBSserv_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox port_txt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox pass_txt;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ip_txt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox clientName_txt;
        private System.Windows.Forms.Button conn_btn;
        private System.Windows.Forms.TextBox obsPath_txt;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Timer command_timer;
        private System.Windows.Forms.OpenFileDialog obspath_open;
        private System.Windows.Forms.Label data_str;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox obs_port_txt;
        private System.Windows.Forms.Button button2;
    }
}

