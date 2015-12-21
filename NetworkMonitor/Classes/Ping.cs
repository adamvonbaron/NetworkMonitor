using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetworkMonitor.Classes;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;

namespace NetworkMonitor.Classes
{
    public class Ping
    {
        public bool Send(string from, string to)
        {
            Log log = new Log();
            try
            {
                IPAddress fromaddress = IPAddress.Parse(from);
                IPAddress toaddress = IPAddress.Parse(to);
                int timeout = 5000;
                byte[] buffer = null;
                PingOptions options = null;
                IcmpPing ping = new IcmpPing();
                IcmpPing.Send(fromaddress, toaddress, timeout, buffer, options);
                return true;
            }
            catch (PingException ex)
            {
                log.AppendToFile(ex.ToString(), log.path);
            }
            catch (Exception ex)
            {
                //log.AppendToFile(ex.ToString(), log.path);
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
            return false;
        }
    }
}
