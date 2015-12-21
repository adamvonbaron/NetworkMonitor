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
using System.Net;
using System.Security;
using System.Net.Mail;
using System.Threading;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.IO;

namespace NetworkMonitor
{
    public partial class NetworkMonitor : Form
    {
        delegate TimerCallback SetPingCallBack(String message, bool success);
        private Serializer serverdata = new Serializer();
        private string serverDataPath = Application.UserAppDataPath.ToString() + "\\networkMonitorServerData.txt";
        private List<Server> serverList = new List<Server>();
        private List<System.Threading.Timer> serverTimers;
        public int pingfreq = Convert.ToInt32(Properties.Settings.Default.pingfreq);

        public NetworkMonitor()
        {
            InitializeComponent();
            DataLoad();
        }

        private void DataLoad()
        {
            try
            {
                serverTimers = new List<System.Threading.Timer>();
                Dictionary<String, IPAddress> networkcards = GetNetworkAdapters();
                var NICNames = (from cards in networkcards select cards.Key).ToArray();
                DataGridViewComboBoxColumn networkcolumn = grdServerList.Columns[1] as DataGridViewComboBoxColumn;
                networkcolumn.DataSource = NICNames;
                NetworkInterface[] NICCards = NetworkInterface.GetAllNetworkInterfaces();
                if (File.Exists(serverDataPath))
                    serverList = serverdata.readData(serverDataPath);
                Classes.Ping ping = new Classes.Ping();
                grdServerList.Rows.Add(null, null, null);

                int i = 0;
                if (serverList != null)
                    foreach (Server item in serverList)
                    {
                        string pingfrom = GetLocalIPv4(NetworkInterfaceType.Wireless80211);
                        //Callback_data.rowID = i;
                        DataGridViewRow newRow = new DataGridViewRow();
                        newRow = (DataGridViewRow)grdServerList.Rows[0].Clone();
                        newRow.Cells[0].Value = item.Name;
                        newRow.Cells[2].Value = item.Comments;
                        ((DataGridViewComboBoxCell)newRow.Cells[1]).Value = item.NIC;
                        grdServerList.Rows.Add(newRow);
                        serverTimers.Add(new System.Threading.Timer(timerCallBack, i, 1000, pingfreq * 1000));
                        serverTimers.Add(new System.Threading.Timer(PingCallback, i, 1000, pingfreq * 1000));
                        i++;
                    }

                grdServerList.Rows.RemoveAt(0);
            }
            catch (Exception ex)
            {

            }

        }

        public string GetLocalIPv4(NetworkInterfaceType _type)
        {
            string output = "";
            foreach (NetworkInterface item in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (item.NetworkInterfaceType == _type && item.OperationalStatus == OperationalStatus.Up)
                {
                    foreach (UnicastIPAddressInformation ip in item.GetIPProperties().UnicastAddresses)
                    {
                        if (ip.Address.AddressFamily == AddressFamily.InterNetwork)
                        {
                            output = ip.Address.ToString();
                        }
                    }
                }
            }
            return output;
        }

        protected void timerCallBack(object data)
        {
            try
            {
                int rowID = Convert.ToInt32(data);
                Server serverItem = serverList[rowID];

                IPAddress sourceIP = IPAddress.Loopback;
                IPAddress destIP = IPAddress.Parse(serverItem.Name);

                NetworkInterface[] cards = NetworkInterface.GetAllNetworkInterfaces();

                foreach (NetworkInterface card in cards)
                {
                    String cardName = card.Description;

                    if (cardName == serverItem.NIC)
                        foreach (UnicastIPAddressInformation ip in card.GetIPProperties().UnicastAddresses)
                        {
                            if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                            {
                                sourceIP = ip.Address;
                            }
                        }
                }

                bool pinged = Classes.IcmpPing.Send(sourceIP, destIP).Status.ToString() == "Success";
                Classes.Ping ping = new Classes.Ping();
                Log logger = new Log();
                string localIP = GetLocalIPv4(NetworkInterfaceType.Wireless80211);
                pinged= ping.Send(localIP, serverList[rowID].Name);
                if (pinged)
                {
                    logger.AppendToFile("Successfully pinged " +
                    serverList[rowID].Name +
                    " during " +
                    DateTime.Now.TimeOfDay +
                    " on " + DateTime.Now.Date +
                    " using " + serverList[rowID].NIC +
                    Environment.NewLine,
                    logger.path);
                }
                else
                {
                    logger.AppendToFile("Failed to ping " +
                    serverList[rowID].Name +
                    " during " +
                    DateTime.Now.TimeOfDay +
                    " on " + DateTime.Now.Date +
                    " using " + serverList[rowID].NIC +
                    Environment.NewLine,
                    logger.path);
                }
            }
            catch (DirectoryNotFoundException ex)
            {
                MessageBox.Show("Error: Directory does not exist:" +
                                Environment.NewLine + 
                                Properties.Settings.Default.logfilepath);
            }
        }

        protected void EmailCallback(object sender)
        {
            Email email = new Email();
            MailMessage message = email.Create(Properties.Settings.Default.emailsenderaddress,
                                               Properties.Settings.Default.emailsenderaddress,
                                               Properties.Settings.Default.emailsenderaddress,
                                               Properties.Settings.Default.emailsenderaddress);
            SecureString password = email.CreatePassword(Properties.Settings.Default.primaryemailpassword);
            bool send = email.Send(message, 
                                   Properties.Settings.Default.emailserver, 
                                   Convert.ToInt32(Properties.Settings.Default.emailport), 
                                   Properties.Settings.Default.emailsenderaddress, 
                                   password);
            if (!send)
                MessageBox.Show("Error sending message.");
        }

        protected void PingCallback(object sender)
        {
            try
            {
                int rowID = Convert.ToInt32(sender);
                Server serverItem = serverList[rowID];

                IPAddress sourceIP = IPAddress.Loopback;
                IPAddress destIP = IPAddress.Parse(serverItem.Name);

                NetworkInterface[] cards = NetworkInterface.GetAllNetworkInterfaces();

                foreach (NetworkInterface card in cards)
                {
                    String cardName = card.Description;

                    if (cardName == serverItem.NIC)
                    foreach(UnicastIPAddressInformation ip in card.GetIPProperties().UnicastAddresses)
                    {
                        if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                        {
                            sourceIP = ip.Address;
                        }
                    }
                }

                bool pinged = Classes.IcmpPing.Send(sourceIP, destIP).Status.ToString() == "Success";

                if (pinged)
                {
                    BeginInvoke(new Action(() =>
                    {
                        label1.Text = Dns.GetHostName() + " sucessfully pinged " + serverList[rowID].Name + " at " + DateTime.Now.ToShortTimeString();
                        grdServerList.Rows[rowID].Cells[3].Value = "Online";
                    }));
                }
                else
                {
                    BeginInvoke(new Action(() =>
                    {
                        label1.Text = Dns.GetHostName() + " failed to ping " + serverList[rowID].Name + " at " + DateTime.Now.ToShortTimeString();
                        grdServerList.Rows[rowID].Cells[3].Value = "Offline";
                    }));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnGeneralConfig_Click(object sender, EventArgs e)
        {
            GeneralConfig GeneralConfig = new GeneralConfig();
            GeneralConfig.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private Dictionary<String, IPAddress> GetNetworkAdapters()
        {
            Dictionary<String, IPAddress> retVal = new Dictionary<String, IPAddress>();
            String cardname;
            IPAddress ip;
            NetworkInterface[] NICCards = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface networkinterface in NICCards)
            {
                cardname = networkinterface.Description;
                ip = null;

                foreach (UnicastIPAddressInformation ipinfo in networkinterface.GetIPProperties().UnicastAddresses)
                {
                    if (ipinfo.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    {
                        ip = ipinfo.Address;
                    }
                }

                if (ip != null)
                {
                    retVal.Add(cardname, ip);
                }
            }
            return retVal;
        }

        private void NetworkMonitor_Load(object sender, EventArgs e)
        {

        }

        private void btnServerConfig_Click(object sender, EventArgs e)
        {
            ServerConfig serverconfig = new ServerConfig();
            serverconfig.Show();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            for (int i = 1; i <= serverTimers.Count; i++)
            {
                //serverTimers[i].Change(1000, pingfreq * 1000);
            }
        }

        private void btnTestEmail_Click(object sender, EventArgs e)
        {
            System.Threading.Timer emailTimer = new System.Threading.Timer(EmailCallback, 
                                                                           null, 
                                                                           10, 
                                                                           System.Threading.Timeout.Infinite);
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void btnStop_Click(object sender, EventArgs e){}

        private void btnStop_Click_1(object sender, EventArgs e)
        {
            for (int i = 1; i < serverTimers.Count; i++)
            {
                serverTimers[i].Change(Timeout.Infinite, Timeout.Infinite);
            }
        }
    }
}
