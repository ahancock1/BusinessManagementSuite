using System;
using System.Net.Mail;
using Com.Framework.Data;
using Com.Framework.Common.Logging;

namespace Com.Framework.Service
{
    public class MailService
    {
        private readonly string smtpServer;

        private readonly string accountEmail;


        public MailService(string accountEmail, string smtpServer)
        {
            this.accountEmail = accountEmail;
            this.smtpServer = smtpServer;
        }

        public void Send(User user, string subject, string body)
        {
            try
            {
                SmtpClient smtp = new SmtpClient(smtpServer);
                smtp.Send(new MailMessage(accountEmail, user.Email.Address)
                {
                    Subject = subject,
                    Body = body
                });
            }
            catch (Exception e)
            {
                Logger.Info(String.Format("Invalid email address: {0}", user.Email), e);
            }
        }
    }
}
