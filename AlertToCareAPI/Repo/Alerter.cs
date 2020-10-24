using System.Net;
using System.Net.Mail;

namespace AlertToCareAPI.Repo
{
    public interface Alerter
    {
        bool Alert(string message);
    }
    public class EmailAlert : Alerter
    {
        public bool Alert(string message)
        {
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("sharma.dikshit404@gmail.com", "pa$$word@123"),
                EnableSsl = true,
            };
            smtpClient.Send("sharma.dikshit404@gmail.com", "sharma.dikshit001@gmail.com", "ALERT", message);

            return true;
        }
    }
}
