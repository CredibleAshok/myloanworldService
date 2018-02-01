using System.Net.Mail;

namespace SuperCheapCart.common
{
    public class EmailSender
    {
        public string From { get; set; }
        public string Body { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }

        public EmailSender( string from, string to, string body, string subject)
        {
            this.From = from;
            this.To = to;
            this.Body = body;
            this.Subject = subject;
        }
        public string SendEmailViaWebApi()
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("relay-hosting.secureserver.net");
            mail.From = new MailAddress(From);
            mail.To.Add(To);
            mail.Subject = Subject;
            mail.Body = Body;
            SmtpServer.Port = 25;
            SmtpServer.Credentials = new System.Net.NetworkCredential("letusknow@myloanworld.com", "!@#pwd123");
            SmtpServer.EnableSsl = false;
            SmtpServer.Send(mail);
            return "email sent";
        }
    }
}