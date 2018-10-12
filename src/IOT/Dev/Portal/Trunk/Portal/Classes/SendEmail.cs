using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Net;
using System.Configuration;
//
namespace Portal.Classes
{
    public class SendEmail
    {
        internal static bool Send(string from, string to, string subject, string body)
        {
            try
            {
                //Create the msg object to be sent
                MailMessage msg = new MailMessage();

                //Add your email address to the recipients
                msg.To.Add(to);


                MailAddress address = new MailAddress(System.Configuration.ConfigurationManager.AppSettings["EmailAddress"]);
                msg.From = address;

                msg.Subject = subject;

                msg.Body = body;

                //Configure an SmtpClient to send the mail.

                SmtpClient client = new SmtpClient(System.Configuration.ConfigurationManager.AppSettings["Server"].ToString(), 587);

                client.EnableSsl = true; //only enable this if your provider requires it

                NetworkCredential credentials = new NetworkCredential(System.Configuration.ConfigurationManager.AppSettings["EmailAddress"].ToString(), System.Configuration.ConfigurationManager.AppSettings["EmailPass"].ToString());
                client.Credentials = credentials;

                //Send the msg
                client.Send(msg);

                return true;
            }
            catch (Exception ex)
            {
                //If the message failed at some point, let the user know
                Log(ex.Message);
                return false;
            }
        }

        internal static void Log(string log)
        {
            // Logging logic here
        }
    }
}