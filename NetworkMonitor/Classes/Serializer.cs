using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Xml;
using System.IO;

namespace NetworkMonitor.Classes
{
    public class Serializer
    {

        public bool WriteData(string fileName, List<Server> data)
        {
            bool retVal = false;

            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Server>));
                TextWriter tw = new StreamWriter(fileName);
                serializer.Serialize(tw, data);
                tw.Close();
                retVal = true;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

            return (retVal);
        }

        public List<Server> readData(string fileName)
        {
            List<Server> retVal = null;

            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Server>));
                TextReader tr = new StreamReader(fileName);
                retVal = (List<Server>)serializer.Deserialize(tr);
                tr.Close();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return (retVal);
        }
    }
}
