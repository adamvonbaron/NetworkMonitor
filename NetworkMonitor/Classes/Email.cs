using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.Security;
using NetworkMonitor.Classes;

namespace NetworkMonitor.Classes
{
    class Email
    {
        public SecureString CreatePassword(string password)
        {
            SecureString retpass = new SecureString();
            password.ToCharArray();
            foreach (var c in password.ToCharArray())
                retpass.AppendChar(c);
            return retpass;
        }

        public bool Send(MailMessage message, string Server, Int32 Port, string username, SecureString password)
        {
            Log log = new Log();
            SmtpClient client = new SmtpClient(Server, Port);
            client.Credentials = CredentialCache.DefaultNetworkCredentials;
            if (username != null && username.Length > 0)
            {
                client.EnableSsl = true;
                NetworkCredential credentials = new NetworkCredential(username, password);
                client.Credentials = credentials;
            }
            try
            {
                client.Send(message);
                return true;
            }
            catch (Exception exception)
            {
                log.AppendToFile(exception.ToString(), log.path);
            }
            message.Dispose();
            return false;
        }

        public MailMessage Create(string ToEmail, string ToName, string FromEmail, string FromName)
        {
            /* TODO: Allow multiple recipients (string array run through for loop to append to message.
             * message.To.Add()) */
            Log log = new Log();
            MailAddress to = new MailAddress(ToEmail, ToName, System.Text.Encoding.UTF8);
            MailAddress from = new MailAddress(FromEmail, FromName, System.Text.Encoding.UTF8);
            MailMessage message = new MailMessage(from, to);
            message.Subject = "Network Monitor Log Report";
            message.Body = log.SendCurrentFile();
            return message;
        }
    }
}
