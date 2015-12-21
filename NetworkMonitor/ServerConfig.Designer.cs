namespace NetworkMonitor
{
    partial class ServerConfig
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
            this.btnServerlist = new System.Windows.Forms.DataGridView();
            this.ServerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NetwokInterfaces = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Comments = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAcceptServerConfig = new System.Windows.Forms.Button();
            this.btnDeclineServerConfig = new System.Windows.Forms.Button();
            this.btnRemoveRow = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.btnServerlist)).BeginInit();
            this.SuspendLayout();
            // 
            // btnServerlist
            // 
            this.btnServerlist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.btnServerlist.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ServerName,
            this.NetwokInterfaces,
            this.Comments});
            this.btnServerlist.Location = new System.Drawing.Point(12, 12);
            this.btnServerlist.Name = "btnServerlist";
            this.btnServerlist.Size = new System.Drawing.Size(343, 255);
            this.btnServerlist.TabIndex = 0;
            this.btnServerlist.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.btnServerlist_CellContentClick);
            // 
            // ServerName
            // 
            this.ServerName.HeaderText = "Server Name";
            this.ServerName.Name = "ServerName";
            // 
            // NetwokInterfaces
            // 
            this.NetwokInterfaces.HeaderText = "Network Interface";
            this.NetwokInterfaces.Name = "NetwokInterfaces";
            // 
            // Comments
            // 
            this.Comments.HeaderText = "Comments";
            this.Comments.Name = "Comments";
            // 
            // btnAcceptServerConfig
            // 
            this.btnAcceptServerConfig.Location = new System.Drawing.Point(12, 273);
            this.btnAcceptServerConfig.Name = "btnAcceptServerConfig";
            this.btnAcceptServerConfig.Size = new System.Drawing.Size(75, 23);
            this.btnAcceptServerConfig.TabIndex = 1;
            this.btnAcceptServerConfig.Text = "OK";
            this.btnAcceptServerConfig.UseVisualStyleBackColor = true;
            this.btnAcceptServerConfig.Click += new System.EventHandler(this.btnAcceptServerConfig_Click);
            // 
            // btnDeclineServerConfig
            // 
            this.btnDeclineServerConfig.Location = new System.Drawing.Point(280, 273);
            this.btnDeclineServerConfig.Name = "btnDeclineServerConfig";
            this.btnDeclineServerConfig.Size = new System.Drawing.Size(75, 23);
            this.btnDeclineServerConfig.TabIndex = 2;
            this.btnDeclineServerConfig.Text = "Cancel";
            this.btnDeclineServerConfig.UseVisualStyleBackColor = true;
            this.btnDeclineServerConfig.Click += new System.EventHandler(this.btnDeclineServerConfig_Click);
            // 
            // btnRemoveRow
            // 
            this.btnRemoveRow.Location = new System.Drawing.Point(93, 273);
            this.btnRemoveRow.Name = "btnRemoveRow";
            this.btnRemoveRow.Size = new System.Drawing.Size(125, 23);
            this.btnRemoveRow.TabIndex = 3;
            this.btnRemoveRow.Text = "Remove Selected Row";
            this.btnRemoveRow.UseVisualStyleBackColor = true;
            this.btnRemoveRow.Click += new System.EventHandler(this.btnRemoveRow_Click);
            // 
            // ServerConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(367, 305);
            this.ControlBox = false;
            this.Controls.Add(this.btnRemoveRow);
            this.Controls.Add(this.btnDeclineServerConfig);
            this.Controls.Add(this.btnAcceptServerConfig);
            this.Controls.Add(this.btnServerlist);
            this.MaximizeBox = false;
            this.Name = "ServerConfig";
            this.Text = "Sever Configuration";
            ((System.ComponentModel.ISupportInitialize)(this.btnServerlist)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView btnServerlist;
        private System.Windows.Forms.DataGridViewTextBoxColumn ServerName;
        private System.Windows.Forms.DataGridViewComboBoxColumn NetwokInterfaces;
        private System.Windows.Forms.DataGridViewTextBoxColumn Comments;
        private System.Windows.Forms.Button btnAcceptServerConfig;
        private System.Windows.Forms.Button btnDeclineServerConfig;
        private System.Windows.Forms.Button btnRemoveRow;
    }
}