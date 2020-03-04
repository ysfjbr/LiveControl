namespace LiveControl
{
    partial class LiveControlForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LiveControlForm));
            this.button1 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.port_txt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.pass_txt = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ip_txt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.clientName_txt = new System.Windows.Forms.TextBox();
            this.conn_btn = new System.Windows.Forms.Button();
            this.obs_grp = new System.Windows.Forms.GroupBox();
            this.pnl_ChangeText = new System.Windows.Forms.Panel();
            this.pnl_plist = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.button11 = new System.Windows.Forms.Button();
            this.grd_pList = new System.Windows.Forms.DataGridView();
            this.clNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clVideo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_sourcesettings = new System.Windows.Forms.TextBox();
            this.btn_sendTextChanges = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.source_list = new System.Windows.Forms.ListBox();
            this.scene_list = new System.Windows.Forms.ListBox();
            this.swich_scene_btn = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.data_str = new System.Windows.Forms.Label();
            this.button10 = new System.Windows.Forms.Button();
            this.obs_grid = new System.Windows.Forms.DataGridView();
            this.OBS_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OBS_ready_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OBS_onair_col = new System.Windows.Forms.DataGridViewImageColumn();
            this.label7 = new System.Windows.Forms.Label();
            this.switch_OBS_btn = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button7 = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.tim_loadsc = new System.Windows.Forms.Timer(this.components);
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.vlc1 = new AxAXVLC.AxVLCPlugin2();
            this.button12 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.obs_grp.SuspendLayout();
            this.pnl_ChangeText.SuspendLayout();
            this.pnl_plist.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd_pList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.obs_grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vlc1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(814, 639);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(165, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Send";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(413, 642);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(392, 20);
            this.textBox2.TabIndex = 6;
            this.textBox2.Text = "OBSC_/command";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.port_txt);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.pass_txt);
            this.groupBox1.Controls.Add(this.listBox1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.ip_txt);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.clientName_txt);
            this.groupBox1.Controls.Add(this.conn_btn);
            this.groupBox1.Location = new System.Drawing.Point(1092, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(180, 434);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Connect to Server";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 27;
            this.label5.Text = "Port";
            // 
            // port_txt
            // 
            this.port_txt.Location = new System.Drawing.Point(77, 45);
            this.port_txt.Name = "port_txt";
            this.port_txt.Size = new System.Drawing.Size(89, 20);
            this.port_txt.TabIndex = 1;
            this.port_txt.Text = "8123";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 175);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 15);
            this.label3.TabIndex = 26;
            this.label3.Text = "Connected Devices";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(16, 398);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(150, 25);
            this.button3.TabIndex = 25;
            this.button3.Text = "Refresh";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // pass_txt
            // 
            this.pass_txt.Location = new System.Drawing.Point(77, 97);
            this.pass_txt.Name = "pass_txt";
            this.pass_txt.PasswordChar = '*';
            this.pass_txt.Size = new System.Drawing.Size(89, 20);
            this.pass_txt.TabIndex = 3;
            this.pass_txt.Text = "mypass";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(16, 195);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(150, 199);
            this.listBox1.TabIndex = 24;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Server IP";
            // 
            // ip_txt
            // 
            this.ip_txt.Location = new System.Drawing.Point(77, 19);
            this.ip_txt.Name = "ip_txt";
            this.ip_txt.Size = new System.Drawing.Size(89, 20);
            this.ip_txt.TabIndex = 0;
            this.ip_txt.Text = "207.180.219.104";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Name";
            // 
            // clientName_txt
            // 
            this.clientName_txt.Location = new System.Drawing.Point(77, 71);
            this.clientName_txt.Name = "clientName_txt";
            this.clientName_txt.Size = new System.Drawing.Size(89, 20);
            this.clientName_txt.TabIndex = 2;
            this.clientName_txt.Text = "Ahmed";
            // 
            // conn_btn
            // 
            this.conn_btn.Location = new System.Drawing.Point(16, 123);
            this.conn_btn.Name = "conn_btn";
            this.conn_btn.Size = new System.Drawing.Size(150, 27);
            this.conn_btn.TabIndex = 4;
            this.conn_btn.Text = "Connect !";
            this.conn_btn.UseVisualStyleBackColor = true;
            this.conn_btn.Click += new System.EventHandler(this.conn_btn_Click);
            // 
            // obs_grp
            // 
            this.obs_grp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.obs_grp.Controls.Add(this.pnl_ChangeText);
            this.obs_grp.Controls.Add(this.label6);
            this.obs_grp.Controls.Add(this.source_list);
            this.obs_grp.Controls.Add(this.scene_list);
            this.obs_grp.Controls.Add(this.swich_scene_btn);
            this.obs_grp.Controls.Add(this.button5);
            this.obs_grp.Controls.Add(this.button4);
            this.obs_grp.Controls.Add(this.button2);
            this.obs_grp.Enabled = false;
            this.obs_grp.Location = new System.Drawing.Point(413, 184);
            this.obs_grp.Name = "obs_grp";
            this.obs_grp.Size = new System.Drawing.Size(673, 278);
            this.obs_grp.TabIndex = 16;
            this.obs_grp.TabStop = false;
            this.obs_grp.Text = "Remote OBS";
            this.obs_grp.Enter += new System.EventHandler(this.obs_grp_Enter);
            // 
            // pnl_ChangeText
            // 
            this.pnl_ChangeText.BackColor = System.Drawing.Color.Transparent;
            this.pnl_ChangeText.Controls.Add(this.pnl_plist);
            this.pnl_ChangeText.Controls.Add(this.txt_sourcesettings);
            this.pnl_ChangeText.Controls.Add(this.btn_sendTextChanges);
            this.pnl_ChangeText.Controls.Add(this.label8);
            this.pnl_ChangeText.Location = new System.Drawing.Point(300, 35);
            this.pnl_ChangeText.Name = "pnl_ChangeText";
            this.pnl_ChangeText.Size = new System.Drawing.Size(367, 237);
            this.pnl_ChangeText.TabIndex = 15;
            this.pnl_ChangeText.Visible = false;
            // 
            // pnl_plist
            // 
            this.pnl_plist.Controls.Add(this.label9);
            this.pnl_plist.Controls.Add(this.button11);
            this.pnl_plist.Controls.Add(this.grd_pList);
            this.pnl_plist.Location = new System.Drawing.Point(0, 0);
            this.pnl_plist.Name = "pnl_plist";
            this.pnl_plist.Size = new System.Drawing.Size(367, 237);
            this.pnl_plist.TabIndex = 38;
            this.pnl_plist.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(6, 6);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 15);
            this.label9.TabIndex = 16;
            this.label9.Text = "Play List";
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(6, 203);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(211, 31);
            this.button11.TabIndex = 15;
            this.button11.Text = "Send Changes";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click_1);
            // 
            // grd_pList
            // 
            this.grd_pList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grd_pList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clNum,
            this.clVideo});
            this.grd_pList.Location = new System.Drawing.Point(3, 30);
            this.grd_pList.Name = "grd_pList";
            this.grd_pList.Size = new System.Drawing.Size(361, 167);
            this.grd_pList.TabIndex = 0;
            // 
            // clNum
            // 
            this.clNum.HeaderText = "#";
            this.clNum.Name = "clNum";
            this.clNum.Width = 50;
            // 
            // clVideo
            // 
            this.clVideo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clVideo.HeaderText = "Video";
            this.clVideo.Name = "clVideo";
            // 
            // txt_sourcesettings
            // 
            this.txt_sourcesettings.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_sourcesettings.Location = new System.Drawing.Point(6, 24);
            this.txt_sourcesettings.MaxLength = 350;
            this.txt_sourcesettings.Multiline = true;
            this.txt_sourcesettings.Name = "txt_sourcesettings";
            this.txt_sourcesettings.Size = new System.Drawing.Size(358, 174);
            this.txt_sourcesettings.TabIndex = 12;
            // 
            // btn_sendTextChanges
            // 
            this.btn_sendTextChanges.Location = new System.Drawing.Point(6, 203);
            this.btn_sendTextChanges.Name = "btn_sendTextChanges";
            this.btn_sendTextChanges.Size = new System.Drawing.Size(211, 32);
            this.btn_sendTextChanges.TabIndex = 14;
            this.btn_sendTextChanges.Text = "Send Changes";
            this.btn_sendTextChanges.UseVisualStyleBackColor = true;
            this.btn_sendTextChanges.Click += new System.EventHandler(this.button11_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(3, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(30, 15);
            this.label8.TabIndex = 13;
            this.label8.Text = "Text";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(159, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 15);
            this.label6.TabIndex = 11;
            this.label6.Text = "Scene contents";
            // 
            // source_list
            // 
            this.source_list.FormattingEnabled = true;
            this.source_list.Location = new System.Drawing.Point(159, 58);
            this.source_list.Name = "source_list";
            this.source_list.Size = new System.Drawing.Size(135, 212);
            this.source_list.TabIndex = 10;
            this.source_list.SelectedIndexChanged += new System.EventHandler(this.source_list_SelectedIndexChanged);
            this.source_list.DoubleClick += new System.EventHandler(this.source_list_DoubleClick);
            // 
            // scene_list
            // 
            this.scene_list.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.scene_list.FormattingEnabled = true;
            this.scene_list.Location = new System.Drawing.Point(6, 58);
            this.scene_list.Name = "scene_list";
            this.scene_list.Size = new System.Drawing.Size(147, 173);
            this.scene_list.TabIndex = 9;
            this.scene_list.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.scene_list_DrawItem);
            this.scene_list.SelectedIndexChanged += new System.EventHandler(this.scene_list_SelectedIndexChanged);
            this.scene_list.DoubleClick += new System.EventHandler(this.scene_list_DoubleClick);
            // 
            // swich_scene_btn
            // 
            this.swich_scene_btn.Location = new System.Drawing.Point(6, 238);
            this.swich_scene_btn.Name = "swich_scene_btn";
            this.swich_scene_btn.Size = new System.Drawing.Size(147, 32);
            this.swich_scene_btn.TabIndex = 7;
            this.swich_scene_btn.Text = "Switch Scene";
            this.swich_scene_btn.UseVisualStyleBackColor = true;
            this.swich_scene_btn.Click += new System.EventHandler(this.button7_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(288, 15);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(27, 31);
            this.button5.TabIndex = 6;
            this.button5.Text = "Stop Stream";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Visible = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(257, 15);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(25, 31);
            this.button4.TabIndex = 5;
            this.button4.Text = "Start Stream";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Visible = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(6, 19);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(147, 33);
            this.button2.TabIndex = 4;
            this.button2.Text = "Load Scenes";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(15, 272);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(140, 43);
            this.button6.TabIndex = 17;
            this.button6.Text = "HTTP Play";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(413, 468);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(859, 168);
            this.textBox1.TabIndex = 27;
            // 
            // data_str
            // 
            this.data_str.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.data_str.BackColor = System.Drawing.SystemColors.ControlDark;
            this.data_str.Location = new System.Drawing.Point(0, 690);
            this.data_str.Name = "data_str";
            this.data_str.Size = new System.Drawing.Size(1288, 23);
            this.data_str.TabIndex = 28;
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(161, 272);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(134, 43);
            this.button10.TabIndex = 30;
            this.button10.Text = "RTMP Play";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // obs_grid
            // 
            this.obs_grid.AllowUserToAddRows = false;
            this.obs_grid.AllowUserToDeleteRows = false;
            this.obs_grid.AllowUserToResizeColumns = false;
            this.obs_grid.AllowUserToResizeRows = false;
            this.obs_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.obs_grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OBS_col,
            this.OBS_ready_col,
            this.OBS_onair_col});
            this.obs_grid.Location = new System.Drawing.Point(413, 28);
            this.obs_grid.MultiSelect = false;
            this.obs_grid.Name = "obs_grid";
            this.obs_grid.ReadOnly = true;
            this.obs_grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.obs_grid.Size = new System.Drawing.Size(537, 105);
            this.obs_grid.TabIndex = 31;
            this.obs_grid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.obs_grid_CellClick);
            this.obs_grid.SelectionChanged += new System.EventHandler(this.obs_grid_SelectionChanged);
            // 
            // OBS_col
            // 
            this.OBS_col.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.OBS_col.HeaderText = "OBS Server Name";
            this.OBS_col.Name = "OBS_col";
            this.OBS_col.ReadOnly = true;
            // 
            // OBS_ready_col
            // 
            this.OBS_ready_col.HeaderText = "Ready";
            this.OBS_ready_col.Name = "OBS_ready_col";
            this.OBS_ready_col.ReadOnly = true;
            // 
            // OBS_onair_col
            // 
            this.OBS_onair_col.HeaderText = "On Air";
            this.OBS_onair_col.Name = "OBS_onair_col";
            this.OBS_onair_col.ReadOnly = true;
            this.OBS_onair_col.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.OBS_onair_col.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(410, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(114, 13);
            this.label7.TabIndex = 33;
            this.label7.Text = "Available OBS Servers";
            // 
            // switch_OBS_btn
            // 
            this.switch_OBS_btn.Enabled = false;
            this.switch_OBS_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.switch_OBS_btn.Image = global::LiveControl.Properties.Resources.onair;
            this.switch_OBS_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.switch_OBS_btn.Location = new System.Drawing.Point(413, 139);
            this.switch_OBS_btn.Name = "switch_OBS_btn";
            this.switch_OBS_btn.Size = new System.Drawing.Size(250, 38);
            this.switch_OBS_btn.TabIndex = 32;
            this.switch_OBS_btn.Text = "Start Streamming from this OBS";
            this.switch_OBS_btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.switch_OBS_btn.UseVisualStyleBackColor = true;
            this.switch_OBS_btn.Click += new System.EventHandler(this.switch_OBS_btn_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(814, 139);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(135, 38);
            this.button7.TabIndex = 34;
            this.button7.Text = "Refresh OBS\'s Status";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click_1);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(223, 642);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(154, 34);
            this.richTextBox1.TabIndex = 35;
            this.richTextBox1.Text = "";
            this.richTextBox1.Visible = false;
            // 
            // tim_loadsc
            // 
            this.tim_loadsc.Tick += new System.EventHandler(this.tim_loadsc_Tick);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(301, 271);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(106, 43);
            this.button8.TabIndex = 36;
            this.button8.Text = "Stop";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(669, 139);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(139, 38);
            this.button9.TabIndex = 37;
            this.button9.Text = "Stop Streamming";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // vlc1
            // 
            this.vlc1.Enabled = true;
            this.vlc1.Location = new System.Drawing.Point(15, 28);
            this.vlc1.Name = "vlc1";
            this.vlc1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("vlc1.OcxState")));
            this.vlc1.Size = new System.Drawing.Size(392, 237);
            this.vlc1.TabIndex = 2;
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(223, 371);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(101, 45);
            this.button12.TabIndex = 38;
            this.button12.Text = "button12";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // LiveControlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(1284, 712);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.switch_OBS_btn);
            this.Controls.Add(this.obs_grid);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.data_str);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.obs_grp);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.vlc1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "LiveControlForm";
            this.Text = "Live Control";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LiveControlForm_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.obs_grp.ResumeLayout(false);
            this.obs_grp.PerformLayout();
            this.pnl_ChangeText.ResumeLayout(false);
            this.pnl_ChangeText.PerformLayout();
            this.pnl_plist.ResumeLayout(false);
            this.pnl_plist.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd_pList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.obs_grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vlc1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AxAXVLC.AxVLCPlugin2 vlc1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ip_txt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox clientName_txt;
        private System.Windows.Forms.Button conn_btn;
        private System.Windows.Forms.GroupBox obs_grp;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox port_txt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox pass_txt;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button swich_scene_btn;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label data_str;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.ListBox source_list;
        private System.Windows.Forms.ListBox scene_list;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView obs_grid;
        private System.Windows.Forms.Button switch_OBS_btn;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewTextBoxColumn OBS_col;
        private System.Windows.Forms.DataGridViewTextBoxColumn OBS_ready_col;
        private System.Windows.Forms.DataGridViewImageColumn OBS_onair_col;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Timer tim_loadsc;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_sourcesettings;
        private System.Windows.Forms.Button btn_sendTextChanges;
        private System.Windows.Forms.Panel pnl_ChangeText;
        private System.Windows.Forms.Panel pnl_plist;
        private System.Windows.Forms.DataGridView grd_pList;
        private System.Windows.Forms.DataGridViewTextBoxColumn clNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn clVideo;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button12;
    }
}

