using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.Security;

namespace ConsoleApplication1
{
    class Program
    {
        public static bool Send(MailMessage message, string Server, Int32 Port, string username, SecureString password)
        {
            bool retVal = false;
            SmtpClient client = new SmtpClient(Server, Port);
            if (username != null && username.Length > 0)
            {
                client.EnableSsl = true;
                NetworkCredential credentials = new NetworkCredential(username, password);
            }
            try
            {
                client.Send(message);
                retVal = true;
            }
            catch (Exception exception)
            {
                Console.WriteLine("Error: {0}", exception);
                //Write error information to log file.
                //exception.ToString();
            }
            message.Dispose();
            return (retVal);
        }

        public static MailMessage Create(string ToEmail, string ToName, string FromEmail, string FromName)
        {
            /* TODO: Allow multiple recipients (string array run through for loop to append to message using message.To.Add()) */
            MailAddress to = new MailAddress(ToEmail, ToName, System.Text.Encoding.UTF8);
            MailAddress from = new MailAddress(FromEmail, FromName, System.Text.Encoding.UTF8);
            MailMessage message = new MailMessage(from, to);
            message.Subject = "Network Monitor Log Report";
            message.Sender = from;
            message.From = from;
            message.Body = "Test E-Mail please ignore"/* Log to send goes here */;
            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.SubjectEncoding = System.Text.Encoding.UTF8;
            message.HeadersEncoding = System.Text.Encoding.UTF8;
            message.IsBodyHtml = true;
            return message;
        }

        static void Main(string[] args)
        {
            SecureString password = new SecureString();
            string pass = "";
            foreach (var c in pass.ToCharArray())
                password.AppendChar(c);
            MailMessage message = Create("adam@kesslerig.com", "Adam Kessler", "adam@kesslerig.com", "Adam Kessler");
            if (Send(message, "smtp.gmail.com", 465, "adam@kesslerig.com", password) == true)
                Console.WriteLine("Email sent");
            else
                Console.WriteLine("Email not sent");
        }
    }
}
