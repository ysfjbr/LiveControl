﻿namespace LiveControl
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
            this.vlc1 = new AxAXVLC.AxVLCPlugin2();
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
            ((System.ComponentModel.ISupportInitialize)(this.vlc1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.obs_grp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.obs_grid)).BeginInit();
            this.SuspendLayout();
            // 
            // vlc1
            // 
            this.vlc1.Enabled = true;
            this.vlc1.Location = new System.Drawing.Point(15, 28);
            this.vlc1.Name = "vlc1";
            this.vlc1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("vlc1.OcxState")));
            this.vlc1.Size = new System.Drawing.Size(392, 238);
            this.vlc1.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 513);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(165, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(15, 487);
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
            this.groupBox1.Location = new System.Drawing.Point(959, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(180, 388);
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
            this.label3.Location = new System.Drawing.Point(13, 189);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "Connected Devices";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(16, 348);
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
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(16, 208);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(150, 134);
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
            this.obs_grp.Controls.Add(this.label6);
            this.obs_grp.Controls.Add(this.source_list);
            this.obs_grp.Controls.Add(this.scene_list);
            this.obs_grp.Controls.Add(this.swich_scene_btn);
            this.obs_grp.Controls.Add(this.button5);
            this.obs_grp.Controls.Add(this.button4);
            this.obs_grp.Controls.Add(this.button2);
            this.obs_grp.Enabled = false;
            this.obs_grp.Location = new System.Drawing.Point(413, 178);
            this.obs_grp.Name = "obs_grp";
            this.obs_grp.Size = new System.Drawing.Size(540, 238);
            this.obs_grp.TabIndex = 16;
            this.obs_grp.TabStop = false;
            this.obs_grp.Text = "Remote OBS";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(169, 39);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Scene contents";
            // 
            // source_list
            // 
            this.source_list.FormattingEnabled = true;
            this.source_list.Location = new System.Drawing.Point(169, 58);
            this.source_list.Name = "source_list";
            this.source_list.Size = new System.Drawing.Size(157, 160);
            this.source_list.TabIndex = 10;
            // 
            // scene_list
            // 
            this.scene_list.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.scene_list.FormattingEnabled = true;
            this.scene_list.Location = new System.Drawing.Point(6, 58);
            this.scene_list.Name = "scene_list";
            this.scene_list.Size = new System.Drawing.Size(157, 121);
            this.scene_list.TabIndex = 9;
            this.scene_list.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.scene_list_DrawItem);
            this.scene_list.SelectedIndexChanged += new System.EventHandler(this.scene_list_SelectedIndexChanged);
            this.scene_list.DoubleClick += new System.EventHandler(this.scene_list_DoubleClick);
            // 
            // swich_scene_btn
            // 
            this.swich_scene_btn.Location = new System.Drawing.Point(6, 186);
            this.swich_scene_btn.Name = "swich_scene_btn";
            this.swich_scene_btn.Size = new System.Drawing.Size(157, 32);
            this.swich_scene_btn.TabIndex = 7;
            this.swich_scene_btn.Text = "Switch Scene";
            this.swich_scene_btn.UseVisualStyleBackColor = true;
            this.swich_scene_btn.Click += new System.EventHandler(this.button7_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(332, 58);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(180, 31);
            this.button5.TabIndex = 6;
            this.button5.Text = "Stop Stream";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(332, 21);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(180, 31);
            this.button4.TabIndex = 5;
            this.button4.Text = "Start Stream";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(6, 19);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(157, 33);
            this.button2.TabIndex = 4;
            this.button2.Text = "Load Scenes";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(15, 272);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(106, 43);
            this.button6.TabIndex = 17;
            this.button6.Text = "HTTP Play";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(416, 431);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(723, 105);
            this.textBox1.TabIndex = 27;
            // 
            // data_str
            // 
            this.data_str.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.data_str.BackColor = System.Drawing.SystemColors.ControlDark;
            this.data_str.Location = new System.Drawing.Point(0, 557);
            this.data_str.Name = "data_str";
            this.data_str.Size = new System.Drawing.Size(1155, 36);
            this.data_str.TabIndex = 28;
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(127, 272);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(106, 43);
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
            this.obs_grid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.obs_grid_CellContentClick);
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
            this.switch_OBS_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.switch_OBS_btn.Image = global::LiveControl.Properties.Resources.onair;
            this.switch_OBS_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.switch_OBS_btn.Location = new System.Drawing.Point(745, 139);
            this.switch_OBS_btn.Name = "switch_OBS_btn";
            this.switch_OBS_btn.Size = new System.Drawing.Size(205, 39);
            this.switch_OBS_btn.TabIndex = 32;
            this.switch_OBS_btn.Text = "Switch OBS Server to AIR";
            this.switch_OBS_btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.switch_OBS_btn.UseVisualStyleBackColor = true;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(662, 139);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(77, 38);
            this.button7.TabIndex = 34;
            this.button7.Text = "Refresh ";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click_1);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(15, 326);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(45, 143);
            this.richTextBox1.TabIndex = 35;
            this.richTextBox1.Text = "";
            this.richTextBox1.Visible = false;
            // 
            // tim_loadsc
            // 
            this.tim_loadsc.Tick += new System.EventHandler(this.tim_loadsc_Tick);
            // 
            // LiveControlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(1151, 592);
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
            ((System.ComponentModel.ISupportInitialize)(this.vlc1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.obs_grp.ResumeLayout(false);
            this.obs_grp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.obs_grid)).EndInit();
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
    }
}
