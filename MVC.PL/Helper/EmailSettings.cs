using MVC.DAL.Entities;
using System.Net;
using System.Net.Mail;

namespace MVC.PL.Helper
{
    public class EmailSettings
    {
        public static void SendEmail(Email email) 
        {
            var client = new SmtpClient("smtp.ethereal.email" , 587);

            client.EnableSsl = true;
            client.Credentials = new NetworkCredential("kathryn62@ethereal.email", "ZCqTvdCDeqHzxDY2er");

            client.Send("kathryn62@ethereal.email", email.To, email.Subject, email.Body);
        }
    }
}
