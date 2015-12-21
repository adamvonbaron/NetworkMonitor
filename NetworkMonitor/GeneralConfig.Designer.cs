namespace NetworkMonitor
{
    partial class GeneralConfig
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
            this.txtPingFrequency = new System.Windows.Forms.TextBox();
            this.lblPingFrequency = new System.Windows.Forms.Label();
            this.txtEmailSenderAddress = new System.Windows.Forms.TextBox();
            this.txtEmailServer = new System.Windows.Forms.TextBox();
            this.txtEmailPort = new System.Windows.Forms.TextBox();
            this.txtEmailRecipients = new System.Windows.Forms.TextBox();
            this.lblEmailSenderAddress = new System.Windows.Forms.Label();
            this.lblEmailSenderPassword = new System.Windows.Forms.Label();
            this.lblEmailServer = new System.Windows.Forms.Label();
            this.lblEmailPort = new System.Windows.Forms.Label();
            this.lblEmailRecipients = new System.Windows.Forms.Label();
            this.btnAcceptGeneralConfig = new System.Windows.Forms.Button();
            this.btnDeclineGeneralConfig = new System.Windows.Forms.Button();
            this.txtLogPath = new System.Windows.Forms.TextBox();
            this.lblLogPath = new System.Windows.Forms.Label();
            this.txtPrimaryEmailPassword = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtPingFrequency
            // 
            this.txtPingFrequency.Location = new System.Drawing.Point(145, 14);
            this.txtPingFrequency.Name = "txtPingFrequency";
            this.txtPingFrequency.Size = new System.Drawing.Size(128, 20);
            this.txtPingFrequency.TabIndex = 0;
            this.txtPingFrequency.TextChanged += new System.EventHandler(this.txtPingFrequency_TextChanged);
            // 
            // lblPingFrequency
            // 
            this.lblPingFrequency.AutoSize = true;
            this.lblPingFrequency.Location = new System.Drawing.Point(12, 17);
            this.lblPingFrequency.Name = "lblPingFrequency";
            this.lblPingFrequency.Size = new System.Drawing.Size(81, 13);
            this.lblPingFrequency.TabIndex = 1;
            this.lblPingFrequency.Text = "Ping Frequency";
            this.lblPingFrequency.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtEmailSenderAddress
            // 
            this.txtEmailSenderAddress.Location = new System.Drawing.Point(145, 67);
            this.txtEmailSenderAddress.Name = "txtEmailSenderAddress";
            this.txtEmailSenderAddress.Size = new System.Drawing.Size(128, 20);
            this.txtEmailSenderAddress.TabIndex = 5;
            this.txtEmailSenderAddress.TextChanged += new System.EventHandler(this.txtEmailSenderAddress_TextChanged);
            // 
            // txtEmailServer
            // 
            this.txtEmailServer.Location = new System.Drawing.Point(145, 121);
            this.txtEmailServer.Name = "txtEmailServer";
            this.txtEmailServer.Size = new System.Drawing.Size(128, 20);
            this.txtEmailServer.TabIndex = 7;
            this.txtEmailServer.TextChanged += new System.EventHandler(this.txtEmailServer_TextChanged);
            // 
            // txtEmailPort
            // 
            this.txtEmailPort.Location = new System.Drawing.Point(145, 148);
            this.txtEmailPort.Name = "txtEmailPort";
            this.txtEmailPort.Size = new System.Drawing.Size(128, 20);
            this.txtEmailPort.TabIndex = 8;
            this.txtEmailPort.TextChanged += new System.EventHandler(this.txtEmailPort_TextChanged);
            // 
            // txtEmailRecipients
            // 
            this.txtEmailRecipients.Location = new System.Drawing.Point(145, 175);
            this.txtEmailRecipients.Name = "txtEmailRecipients";
            this.txtEmailRecipients.Size = new System.Drawing.Size(128, 20);
            this.txtEmailRecipients.TabIndex = 9;
            this.txtEmailRecipients.TextChanged += new System.EventHandler(this.txtEmailRecipients_TextChanged);
            // 
            // lblEmailSenderAddress
            // 
            this.lblEmailSenderAddress.AutoSize = true;
            this.lblEmailSenderAddress.Location = new System.Drawing.Point(12, 70);
            this.lblEmailSenderAddress.Name = "lblEmailSenderAddress";
            this.lblEmailSenderAddress.Size = new System.Drawing.Size(114, 13);
            this.lblEmailSenderAddress.TabIndex = 13;
            this.lblEmailSenderAddress.Text = "E-Mail Sender Address";
            // 
            // lblEmailSenderPassword
            // 
            this.lblEmailSenderPassword.AutoSize = true;
            this.lblEmailSenderPassword.Location = new System.Drawing.Point(12, 97);
            this.lblEmailSenderPassword.Name = "lblEmailSenderPassword";
            this.lblEmailSenderPassword.Size = new System.Drawing.Size(121, 13);
            this.lblEmailSenderPassword.TabIndex = 14;
            this.lblEmailSenderPassword.Text = "E-mail Sender Password";
            // 
            // lblEmailServer
            // 
            this.lblEmailServer.AutoSize = true;
            this.lblEmailServer.Location = new System.Drawing.Point(12, 124);
            this.lblEmailServer.Name = "lblEmailServer";
            this.lblEmailServer.Size = new System.Drawing.Size(69, 13);
            this.lblEmailServer.TabIndex = 15;
            this.lblEmailServer.Text = "E-mail Server";
            // 
            // lblEmailPort
            // 
            this.lblEmailPort.AutoSize = true;
            this.lblEmailPort.Location = new System.Drawing.Point(12, 151);
            this.lblEmailPort.Name = "lblEmailPort";
            this.lblEmailPort.Size = new System.Drawing.Size(57, 13);
            this.lblEmailPort.TabIndex = 16;
            this.lblEmailPort.Text = "E-mail Port";
            // 
            // lblEmailRecipients
            // 
            this.lblEmailRecipients.AutoSize = true;
            this.lblEmailRecipients.Location = new System.Drawing.Point(12, 178);
            this.lblEmailRecipients.Name = "lblEmailRecipients";
            this.lblEmailRecipients.Size = new System.Drawing.Size(88, 13);
            this.lblEmailRecipients.TabIndex = 17;
            this.lblEmailRecipients.Text = "E-mail Recipients";
            // 
            // btnAcceptGeneralConfig
            // 
            this.btnAcceptGeneralConfig.Location = new System.Drawing.Point(15, 207);
            this.btnAcceptGeneralConfig.Name = "btnAcceptGeneralConfig";
            this.btnAcceptGeneralConfig.Size = new System.Drawing.Size(75, 23);
            this.btnAcceptGeneralConfig.TabIndex = 19;
            this.btnAcceptGeneralConfig.Text = "OK";
            this.btnAcceptGeneralConfig.UseVisualStyleBackColor = true;
            this.btnAcceptGeneralConfig.Click += new System.EventHandler(this.btnAcceptGeneralConfig_Click);
            // 
            // btnDeclineGeneralConfig
            // 
            this.btnDeclineGeneralConfig.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnDeclineGeneralConfig.Location = new System.Drawing.Point(198, 207);
            this.btnDeclineGeneralConfig.Name = "btnDeclineGeneralConfig";
            this.btnDeclineGeneralConfig.Size = new System.Drawing.Size(75, 23);
            this.btnDeclineGeneralConfig.TabIndex = 20;
            this.btnDeclineGeneralConfig.Text = "Cancel";
            this.btnDeclineGeneralConfig.UseVisualStyleBackColor = true;
            this.btnDeclineGeneralConfig.Click += new System.EventHandler(this.btnDeclineGeneralConfig_Click);
            // 
            // txtLogPath
            // 
            this.txtLogPath.Location = new System.Drawing.Point(145, 40);
            this.txtLogPath.Name = "txtLogPath";
            this.txtLogPath.Size = new System.Drawing.Size(128, 20);
            this.txtLogPath.TabIndex = 34;
            this.txtLogPath.TextChanged += new System.EventHandler(this.txtLogPath_TextChanged);
            // 
            // lblLogPath
            // 
            this.lblLogPath.AutoSize = true;
            this.lblLogPath.Location = new System.Drawing.Point(12, 43);
            this.lblLogPath.Name = "lblLogPath";
            this.lblLogPath.Size = new System.Drawing.Size(69, 13);
            this.lblLogPath.TabIndex = 35;
            this.lblLogPath.Text = "Log File Path";
            // 
            // txtPrimaryEmailPassword
            // 
            this.txtPrimaryEmailPassword.Location = new System.Drawing.Point(145, 94);
            this.txtPrimaryEmailPassword.Name = "txtPrimaryEmailPassword";
            this.txtPrimaryEmailPassword.PasswordChar = '*';
            this.txtPrimaryEmailPassword.Size = new System.Drawing.Size(128, 20);
            this.txtPrimaryEmailPassword.TabIndex = 37;
            this.txtPrimaryEmailPassword.TextChanged += new System.EventHandler(this.txtPrimaryEmailPassword_TextChanged);
            // 
            // GeneralConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.CancelButton = this.btnDeclineGeneralConfig;
            this.ClientSize = new System.Drawing.Size(290, 245);
            this.ControlBox = false;
            this.Controls.Add(this.txtPrimaryEmailPassword);
            this.Controls.Add(this.lblLogPath);
            this.Controls.Add(this.txtLogPath);
            this.Controls.Add(this.btnDeclineGeneralConfig);
            this.Controls.Add(this.btnAcceptGeneralConfig);
            this.Controls.Add(this.lblEmailRecipients);
            this.Controls.Add(this.lblEmailPort);
            this.Controls.Add(this.lblEmailServer);
            this.Controls.Add(this.lblEmailSenderPassword);
            this.Controls.Add(this.lblEmailSenderAddress);
            this.Controls.Add(this.txtEmailRecipients);
            this.Controls.Add(this.txtEmailPort);
            this.Controls.Add(this.txtEmailServer);
            this.Controls.Add(this.txtEmailSenderAddress);
            this.Controls.Add(this.lblPingFrequency);
            this.Controls.Add(this.txtPingFrequency);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GeneralConfig";
            this.ShowInTaskbar = false;
            this.Text = "General Configuration";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.GeneralConfig_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPingFrequency;
        private System.Windows.Forms.Label lblPingFrequency;
        private System.Windows.Forms.TextBox txtEmailSenderAddress;
        private System.Windows.Forms.TextBox txtEmailServer;
        private System.Windows.Forms.TextBox txtEmailPort;
        private System.Windows.Forms.TextBox txtEmailRecipients;
        private System.Windows.Forms.Label lblEmailSenderAddress;
        private System.Windows.Forms.Label lblEmailSenderPassword;
        private System.Windows.Forms.Label lblEmailServer;
        private System.Windows.Forms.Label lblEmailPort;
        private System.Windows.Forms.Label lblEmailRecipients;
        private System.Windows.Forms.Button btnAcceptGeneralConfig;
        private System.Windows.Forms.Button btnDeclineGeneralConfig;
        private System.Windows.Forms.TextBox txtLogPath;
        private System.Windows.Forms.Label lblLogPath;
        private System.Windows.Forms.TextBox txtPrimaryEmailPassword;
    }
}