namespace NetworkMonitor
{
    partial class NetworkMonitor
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
            this.grdServerList = new System.Windows.Forms.DataGridView();
            this.btnGeneralConfig = new System.Windows.Forms.Button();
            this.btnServerConfig = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnSilentMode = new System.Windows.Forms.Button();
            this.btnTestEmail = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ServerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NetworkInterfaces = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Comment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmAlarm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdServerList)).BeginInit();
            this.SuspendLayout();
            // 
            // grdServerList
            // 
            this.grdServerList.AllowUserToAddRows = false;
            this.grdServerList.AllowUserToDeleteRows = false;
            this.grdServerList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdServerList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ServerName,
            this.NetworkInterfaces,
            this.Comment,
            this.clmAlarm});
            this.grdServerList.Location = new System.Drawing.Point(12, 27);
            this.grdServerList.Name = "grdServerList";
            this.grdServerList.Size = new System.Drawing.Size(543, 211);
            this.grdServerList.TabIndex = 0;
            this.grdServerList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // btnGeneralConfig
            // 
            this.btnGeneralConfig.Location = new System.Drawing.Point(382, 244);
            this.btnGeneralConfig.Name = "btnGeneralConfig";
            this.btnGeneralConfig.Size = new System.Drawing.Size(85, 23);
            this.btnGeneralConfig.TabIndex = 1;
            this.btnGeneralConfig.Text = "General Config";
            this.btnGeneralConfig.UseVisualStyleBackColor = true;
            this.btnGeneralConfig.Click += new System.EventHandler(this.btnGeneralConfig_Click);
            // 
            // btnServerConfig
            // 
            this.btnServerConfig.Location = new System.Drawing.Point(473, 244);
            this.btnServerConfig.Name = "btnServerConfig";
            this.btnServerConfig.Size = new System.Drawing.Size(82, 23);
            this.btnServerConfig.TabIndex = 2;
            this.btnServerConfig.Text = "Server Config";
            this.btnServerConfig.UseVisualStyleBackColor = true;
            this.btnServerConfig.Click += new System.EventHandler(this.btnServerConfig_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(93, 244);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 3;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Visible = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click_1);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(12, 244);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Visible = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnSilentMode
            // 
            this.btnSilentMode.Location = new System.Drawing.Point(174, 244);
            this.btnSilentMode.Name = "btnSilentMode";
            this.btnSilentMode.Size = new System.Drawing.Size(78, 23);
            this.btnSilentMode.TabIndex = 5;
            this.btnSilentMode.Text = "Silent Mode";
            this.btnSilentMode.UseVisualStyleBackColor = true;
            this.btnSilentMode.Visible = false;
            // 
            // btnTestEmail
            // 
            this.btnTestEmail.Location = new System.Drawing.Point(258, 244);
            this.btnTestEmail.Name = "btnTestEmail";
            this.btnTestEmail.Size = new System.Drawing.Size(75, 23);
            this.btnTestEmail.TabIndex = 6;
            this.btnTestEmail.Text = "Test Email";
            this.btnTestEmail.UseVisualStyleBackColor = true;
            this.btnTestEmail.Visible = false;
            this.btnTestEmail.Click += new System.EventHandler(this.btnTestEmail_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "label1";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // ServerName
            // 
            this.ServerName.HeaderText = "IP Address";
            this.ServerName.Name = "ServerName";
            // 
            // NetworkInterfaces
            // 
            this.NetworkInterfaces.HeaderText = "Netwok Interfaces";
            this.NetworkInterfaces.Name = "NetworkInterfaces";
            this.NetworkInterfaces.Width = 200;
            // 
            // Comment
            // 
            this.Comment.HeaderText = "Server Name";
            this.Comment.Name = "Comment";
            // 
            // clmAlarm
            // 
            this.clmAlarm.HeaderText = "Status";
            this.clmAlarm.Name = "clmAlarm";
            // 
            // NetworkMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 277);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnTestEmail);
            this.Controls.Add(this.btnSilentMode);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnServerConfig);
            this.Controls.Add(this.btnGeneralConfig);
            this.Controls.Add(this.grdServerList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "NetworkMonitor";
            this.Text = "Network Monitor";
            this.Load += new System.EventHandler(this.NetworkMonitor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdServerList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grdServerList;
        private System.Windows.Forms.Button btnGeneralConfig;
        private System.Windows.Forms.Button btnServerConfig;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnSilentMode;
        private System.Windows.Forms.Button btnTestEmail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ServerName;
        private System.Windows.Forms.DataGridViewComboBoxColumn NetworkInterfaces;
        private System.Windows.Forms.DataGridViewTextBoxColumn Comment;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmAlarm;
    }
}

