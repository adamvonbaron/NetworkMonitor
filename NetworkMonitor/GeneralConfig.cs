using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NetworkMonitor.Classes;
using System.Text.RegularExpressions;
using System.Configuration;
using System.Net.Mail;

namespace NetworkMonitor
{
    public partial class GeneralConfig : Form
    {
        public GeneralConfig()
        {
            InitializeComponent();
        }

        private bool checkInputForInt(string input){
            try {
                int integer_check;
                if (!int.TryParse(input, out integer_check))
                {
                    char[] backspace_check = input.ToCharArray();
                    for (int i = 0; i < backspace_check.Length; i++)
                    {
                        if (backspace_check[i] != (char)Keys.Back)
                        {
                            System.Windows.Forms.MessageBox.Show("Error: Cannot place character in input box.");
                            break;
                        }
                    }
                }
                return true;
            }
            catch (Exception ex) {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
            return false;
        }
        private bool checkInputForEmail(string input)
        {
            try
            {
                MailAddress mailaddress = new MailAddress(input);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void GeneralConfig_Load(object sender, EventArgs e)
        {
            try
            {
                //txtAlarmPingFrequency.Text = Properties.Settings.Default.alarmpingfreq;
                //txtAlarmPingThreshold.Text = Properties.Settings.Default.alarmpingthreshold;
                //txtAlarmStatusDuration.Text = Properties.Settings.Default.alarmstatusduration;
                txtEmailPort.Text = Properties.Settings.Default.emailport;
                try
                {
                    txtEmailRecipients.Text = Properties.Settings.Default.emailrecipients;
                }
                catch (FormatException ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.ToString());
                }
                try
                {
                    txtEmailSenderAddress.Text = Properties.Settings.Default.emailsenderaddress;
                }
                catch (FormatException ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.ToString());
                }
                txtPrimaryEmailPassword.Text = Properties.Settings.Default.primaryemailpassword;
                txtEmailServer.Text = Properties.Settings.Default.emailserver;
                txtLogPath.Text = Properties.Settings.Default.logfilepath;
                txtPingFrequency.Text = Properties.Settings.Default.pingfreq;
                //chkIgnoreSingleMissedPacket.Checked = Properties.Settings.Default.ignoresinglemissedpacket;
                //chkManuallyClearAlarmStatus.Checked = Properties.Settings.Default.manuallyclearalarmstatus;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }

/*        private void ManuallyClearAlarmStatus_CheckedChanged(object sender, EventArgs e)
        {
            if (chkManuallyClearAlarmStatus.Checked == true)
            {
                Properties.Settings.Default.manuallyclearalarmstatus = true;
            }
            else
            {
                Properties.Settings.Default.manuallyclearalarmstatus= false;
            }
            Properties.Settings.Default.Save();
        } */

        private void btnAcceptGeneralConfig_Click(object sender, EventArgs e)
        {
            try
            {
                Properties.Settings.Default.Save();
                checkInputForEmail(Properties.Settings.Default.emailrecipients);
                checkInputForEmail(Properties.Settings.Default.emailsenderaddress);
                checkInputForEmail(Properties.Settings.Default.secondaryemailaddress);
                Close();
            }
            catch (Exception ex)
            {
                if (ex is FormatException)
                {
                    System.Windows.Forms.MessageBox.Show("Error: Email is invalid format.");
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show(ex.ToString());
                }
            }
        }

        private void btnDeclineGeneralConfig_Click(object sender, EventArgs e)
        {
            if (false == false)
            {
                DialogResult dialogResult = MessageBox.Show("Close without saving?", "Confirm", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Close();
                }
                else if (dialogResult == DialogResult.No)
                {
                    
                }
            }
        }

        private void txtPingFrequency_TextChanged(object sender, EventArgs e)
        {
            string input_text = txtPingFrequency.Text.ToString();
            checkInputForInt(input_text);
            Properties.Settings.Default.pingfreq = input_text;
            Properties.Settings.Default.Save();
        }

        /*private void txtAlarmPingFrequency_TextChanged(object sender, EventArgs e)
        {
            string input_text = txtAlarmPingFrequency.Text.ToString();
            checkInputForInt(input_text);
            Properties.Settings.Default.alarmpingfreq = input_text;
            Properties.Settings.Default.Save();
        }*/

        /*private void txtAlarmPingThreshold_TextChanged(object sender, EventArgs e)
        {
            string input_text = txtAlarmPingThreshold.Text.ToString();
            checkInputForInt(input_text);
            Properties.Settings.Default.alarmpingthreshold = input_text;
            Properties.Settings.Default.Save();
        }*/

        /*private void txtAlarmStatusDuration_TextChanged(object sender, EventArgs e)
        {
            string input_text = txtAlarmStatusDuration.Text.ToString();
            checkInputForInt(input_text);
            Properties.Settings.Default.alarmstatusduration = input_text;
            Properties.Settings.Default.Save();
        }*/

        private void txtEmailPort_TextChanged(object sender, EventArgs e)
        {
            string input_text = txtEmailPort.Text.ToString();
            checkInputForInt(input_text);
            Properties.Settings.Default.emailport = input_text;
            Properties.Settings.Default.Save();
        }

        private void txtEmailSenderAddress_TextChanged(object sender, EventArgs e)
        {
            string input_text = txtEmailSenderAddress.Text.ToString();
            if (input_text != "")
            {
                checkInputForEmail(input_text);
                Properties.Settings.Default.emailsenderaddress = input_text;
            }
            Properties.Settings.Default.Save();
        }

        /*private void chkIgnoreSingleMissedPacket_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIgnoreSingleMissedPacket.Checked == true)
            {
                Properties.Settings.Default.ignoresinglemissedpacket = true;
            }
            else
            {
                Properties.Settings.Default.ignoresinglemissedpacket = false;
            }
            Properties.Settings.Default.Save();
        }*/

        private void txtLogPath_TextChanged(object sender, EventArgs e)
        {
            string input_text = txtLogPath.Text.ToString();
            Properties.Settings.Default.logfilepath = input_text;
            Properties.Settings.Default.Save();
        }

        private void txtEmailRecipients_TextChanged(object sender, EventArgs e)
        {
            string input_text = txtEmailRecipients.Text.ToString();
            if (input_text != "")
            {
                checkInputForEmail(input_text);
                Properties.Settings.Default.emailrecipients = input_text;
            }
            Properties.Settings.Default.Save();
        }

        private void txtEmailServer_TextChanged(object sender, EventArgs e)
        {
            string input_text = txtEmailServer.Text.ToString();
            Properties.Settings.Default.emailserver = input_text;
            Properties.Settings.Default.Save();
        }

        private void txtPrimaryEmailPassword_TextChanged(object sender, EventArgs e)
        {
            string input_text = txtPrimaryEmailPassword.Text.ToString();
            Properties.Settings.Default.primaryemailpassword = input_text;
            Properties.Settings.Default.Save();
        }
    }
}