using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkMonitor.Classes
{
    public class Server
    {
        public int ID { get; set; }
        public String Name { get; set; }
        public String NIC { get; set; }
        public String Comments { get; set; }

        public Server() { }

        public Server(int ID, String Name, String NIC, String Comments)
        {
            this.ID = ID;
            this.Name = Name;
            this.NIC = NIC;
            this.Comments = Comments;
        }
    }
}
