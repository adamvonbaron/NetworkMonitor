using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace NetworkMonitor.Classes
{
    public class Log
    {
        public string path = Properties.Settings.Default.logfilepath.ToString() +
                             DateTime.Now.ToString("yyyy-MM-dd") + ".log";
        public FileStream currentFile;

        public Log()
        {
            //currentFile = new FileStream(path, FileMode.Open);
        }

        public bool AppendToFile(string content, string filename)
        {
            try
            {
                if (!File.Exists(filename))
                {
                    currentFile = File.Create(filename);
                }
                else
                {
                    currentFile = File.Open(filename, FileMode.Append);
                }
                byte[] newline = Encoding.UTF8.GetBytes("\n");
                byte[] contentEnc = Encoding.UTF8.GetBytes(content);
                byte[] Content = new byte[contentEnc.Length + newline.Length];
                contentEnc.CopyTo(Content, 0);
                newline.CopyTo(Content, contentEnc.Length);
                int contentSize = content.Length;
                currentFile.Write(Content, 0, contentSize + 1);
                currentFile.Flush();
                currentFile.Close();
                return true;
            }
            catch (Exception ex)
            {
                //System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
            return false;   
        }

        public string SendCurrentFile()
        {
            string file = "";

            if (currentFile != null)
                file = currentFile.ToString();
            return file;
        }

        //public string CurrentFile()
        //{ return filename; }
    }
}
