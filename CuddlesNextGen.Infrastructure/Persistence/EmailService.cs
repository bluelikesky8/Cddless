using CuddlesNextGen.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace CuddlesNextGen.Infrastructure.Persistence
{
    public class EmailService : IEmailService
    {
        private readonly string _employeeEmailTemplatesPath;
        private readonly string _fromEmail;
        private readonly string _emailSmtp;
        private readonly string _emailSmtpPassword;
        private readonly string _emailSmtpPort;

        public EmailService(IConfiguration config)
        {

            _employeeEmailTemplatesPath = config.GetSection("FilePath:ResourceBasePath").Value + config.GetSection("FilePath:UserOTPPath").Value;

            _fromEmail = config.GetSection("EmailConfig:From").Value;
            _emailSmtp = config.GetSection("EmailConfig:SMTP").Value;
            _emailSmtpPassword = config.GetSection("EmailConfig:Password").Value;
            _emailSmtpPort = config.GetSection("EmailConfig:Port").Value;

        }

        private bool SendEmail(string emailSubject, string mailContent, string emailTo, List<Attachment> attachments = null)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient(_emailSmtp);
                mail.From = new MailAddress(_fromEmail);
                mail.To.Add(emailTo);
                mail.Subject = emailSubject;
                mail.Body = mailContent;
                mail.IsBodyHtml = true;

                if (attachments != null)
                {
                    foreach (var attachment in attachments)
                    {
                        mail.Attachments.Add(attachment);
                    }
                }

                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Port = Convert.ToInt32(_emailSmtpPort);
                SmtpServer.Credentials = new System.Net.NetworkCredential(_fromEmail, _emailSmtpPassword);
                SmtpServer.EnableSsl = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                SmtpServer.Send(mail);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        /// <summary>
        /// send otp to user email
        /// </summary>
        /// <param name="OTP"></param>
        /// <param name="email"></param>
        /// <returns></returns>

        public bool OTP(int OTP, string email)
        {
            var employeeEmailTemplate = _employeeEmailTemplatesPath + "OTP.html";

            var employeeEmailTemplateText = File.ReadAllText(employeeEmailTemplate);
            employeeEmailTemplateText = employeeEmailTemplateText.Replace("{OTP}", OTP.ToString() );
            SendEmail("CUDDLES Email OTP", employeeEmailTemplateText, email);
            return true;
        }

    }
}
