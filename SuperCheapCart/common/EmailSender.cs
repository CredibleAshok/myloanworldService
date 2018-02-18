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
        //todo: don't need separate methods.
        public string SendEnquiryDetailsEmailViaWebApi()
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("relay-hosting.secureserver.net");
            //SmtpClient SmtpServer = new SmtpClient("smtpout.secureserver.net");
            //Note: This code will only work on live environment but not on localhost.
            mail.From = new MailAddress(From);
            mail.To.Add(To);
            mail.Subject = Subject;
            mail.Body = Body;
            mail.IsBodyHtml = true;
            SmtpServer.Port = 25;
            SmtpServer.Credentials = new System.Net.NetworkCredential("letusknow@myloanworld.com", "!@#pwd123");
            SmtpServer.EnableSsl = false;
            SmtpServer.Send(mail);          
            return "email sent";
        }

        public string SendUserIdToClientEmailViaWebApi()
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("relay-hosting.secureserver.net");
            //SmtpClient SmtpServer = new SmtpClient("smtpout.secureserver.net");
            //Note: This code will only work on live environment but not on localhost.
            mail.From = new MailAddress(From);
            mail.To.Add(To);
            mail.Subject = Subject;
            mail.Body = Body;
            mail.IsBodyHtml = true;
            SmtpServer.Port = 25;
            SmtpServer.Credentials = new System.Net.NetworkCredential("letusknow@myloanworld.com", "!@#pwd123");
            SmtpServer.EnableSsl = false;
            SmtpServer.Send(mail);
            return "email sent";
        }

        public string SendPasswordToClientEmailViaWebApi()
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("relay-hosting.secureserver.net");
            //SmtpClient SmtpServer = new SmtpClient("smtpout.secureserver.net");
            //Note: This code will only work on live environment but not on localhost.
            mail.From = new MailAddress(From);
            mail.To.Add(To);
            mail.Subject = Subject;
            mail.Body = Body;
            mail.IsBodyHtml = true;
            SmtpServer.Port = 25;
            SmtpServer.Credentials = new System.Net.NetworkCredential("letusknow@myloanworld.com", "!@#pwd123");
            SmtpServer.EnableSsl = false;
            SmtpServer.Send(mail);
            return "email sent";
        }

        public string SendForgotPasswordEmailViaWebApi()
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("relay-hosting.secureserver.net");
            //SmtpClient SmtpServer = new SmtpClient("smtpout.secureserver.net");
            //Note: This code will only work on live environment but not on localhost.
            mail.From = new MailAddress(From);
            mail.To.Add(To);
            mail.Subject = Subject;
            mail.Body = Body;
            mail.IsBodyHtml = true;
            SmtpServer.Port = 25;
            SmtpServer.Credentials = new System.Net.NetworkCredential("letusknow@myloanworld.com", "!@#pwd123");
            SmtpServer.EnableSsl = false;
            SmtpServer.Send(mail);
            return "email sent";
        }
    }
}