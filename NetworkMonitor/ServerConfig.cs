using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NetworkMonitor.Classes;
using System.Net.NetworkInformation;
using System.Net;

namespace NetworkMonitor
{
    public partial class ServerConfig : Form
    {
        public ServerConfig()
        {
            InitializeComponent();
            ServerConfig_Load();
        }

        private Serializer serverdata = new Serializer();
        private string serverDataPath = Application.UserAppDataPath.ToString() + "\\networkMonitorServerData.txt";
        private List<Server> serverList = new List<Server>();
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

        private void ServerConfig_Load()
        {
            try
            {
                Dictionary<String, IPAddress> networkcards = GetNetworkAdapters();
                var NICNames = (from cards in networkcards select cards.Key).ToArray();
                DataGridViewComboBoxColumn networkcolumn = btnServerlist.Columns[1] as DataGridViewComboBoxColumn;
                networkcolumn.DataSource = NICNames;
                NetworkInterface[] NICCads = NetworkInterface.GetAllNetworkInterfaces();
                if (File.Exists(serverDataPath))
                    serverList = serverdata.readData(serverDataPath);
                int i = 0;
                btnServerlist.Rows.Add(null, null, null);
                if (serverList != null)
                {
                    foreach (Server item in serverList)
                    {
                        DataGridViewRow newRow = (DataGridViewRow)btnServerlist.Rows[0].Clone();
                        newRow.Cells[0].Value = item.Name;
                        newRow.Cells[2].Value = item.Comments;
                        ((DataGridViewComboBoxCell)newRow.Cells[1]).Value = item.NIC;
                        btnServerlist.Rows.Add(newRow);
                        i++;
                    }
                    btnServerlist.Rows.RemoveAt(0);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnDeclineServerConfig_Click(object sender, EventArgs e)
        {
            List<Server> currentList = serverdata.readData(serverDataPath);
            if (currentList.Equals(serverList) == false)
            {
                DialogResult dialogResult = MessageBox.Show("Close without saving?", "Confirm", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Close();
                }
            }
        }

        private void btnAcceptServerConfig_Click(object sender, EventArgs e)
        {
            List<Server> data = new List<Server>();
            Serializer serializer = new Serializer();
            foreach (DataGridViewRow row in btnServerlist.Rows)
            {
                if (((DataGridViewComboBoxCell)row.Cells[1]).Value != null)
                {
                    Server item = new Server();
                    item.Name = row.Cells["ServerName"].Value.ToString();
                    item.NIC = ((DataGridViewComboBoxCell)row.Cells[1]).Value.ToString();
                    item.Comments = row.Cells["Comments"].Value == null ? "" : row.Cells["Comments"].Value.ToString();
                    data.Add(item);
                }
                serializer.WriteData(serverDataPath, data);
            }

            if (serverdata.WriteData(serverDataPath, data) == false)
                MessageBox.Show("Error saving data");
            else
                this.Close();
        }


        private void btnServerlist_CellContentClick(object sender, DataGridViewCellEventArgs e){

        }

        private void btnServerlist_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnRemoveRow_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in btnServerlist.SelectedRows)
            {
                try
                {
                    btnServerlist.Rows.RemoveAt(row.Index);
                }
                catch (InvalidOperationException ex)
                {
                    MessageBox.Show("Cannot delete first row in table.");
                }
            }
        }
    }
}
