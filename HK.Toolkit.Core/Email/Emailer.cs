using System.IO;
using System.Net.Mail;

namespace HK.Toolkit.Email
{
    public static class Emailer
    {
        /// <summary>
        /// It Sends Data To SMTP Server
        /// </summary>
        /// <param name="from">from</param>
        /// <param name="to">To:</param>
        /// <param name="subject">Subject Title</param>
        /// <param name="body">Body Message</param>
        /// <param name="cc">Copy</param>
        /// <param name="bcc">Blind Copy</param>
        /// <param name="isHtml">Used Html?</param>
        /// <param name="attachmentStringArray">Have Attachment?</param>
        /// <param name="attachmentStream">Attachment Stram</param>
        /// <param name="attachmentStreamFileName">Attachment Stream FileName</param>
        /// <param name="host">Host Name or IP</param>
        /// <param name="userName">Host User Name </param>
        /// <param name="password">Host Password</param>
        /// <param name="port">Host Port</param>
        /// <param name="priority">Priority</param>
        /// <returns>Returns Boolean</returns>
        public static bool SendToSmtp(
            string from,
            string[] to,
            string subject,
            string body,
            string[] cc = null,
            string[] bcc = null,
            bool isHtml = false,
            string[] attachmentStringArray = null,
            MemoryStream attachmentStream = null,
            string attachmentStreamFileName = null,
            string host = null,
            string userName = null,
            string password = null,
            int port = 25,
            int priority = 1
            )
        {
            var oMailMessage = new MailMessage
            {
                From = new MailAddress(from),
                Body = body,
                Subject = subject,
                IsBodyHtml = isHtml
            };

            switch (priority)
            {
                case -1:
                    oMailMessage.Priority = MailPriority.Low;
                    break;

                case 1:
                    oMailMessage.Priority = MailPriority.High;
                    break;

                default:
                    oMailMessage.Priority = MailPriority.Normal;
                    break;
            }

            // Add TO
            if (to != null)
            {
                foreach (var email in to)
                    oMailMessage.To.Add(email);
            }

            // Add CC
            if (cc != null)
            {
                foreach (var email in cc)
                    oMailMessage.CC.Add(email);
            }

            // Add BCC
            if (bcc != null)
            {
                foreach (var email in bcc)
                    oMailMessage.Bcc.Add(email);
            }

            // Add Attachment
            if (attachmentStringArray != null)
            {
                foreach (var att in attachmentStringArray)
                    oMailMessage.Attachments.Add(new Attachment(att));
            }

            // Add Attachment from Stream
            if (attachmentStream != null)
            {
                var attachment = new Attachment(attachmentStream, attachmentStreamFileName);
                oMailMessage.Attachments.Add(attachment);
            }

            var smtpClient = new SmtpClient(host, port);

            smtpClient.EnableSsl = false;
            smtpClient.UseDefaultCredentials = true;
            smtpClient.Credentials = new System.Net.NetworkCredential(userName, password);

            try
            {
                smtpClient.Send(oMailMessage);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}