using MailKit.Net.Smtp;
using MailKit.Security;
using MessageServices.Factory;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageServices
{
    public class MailKitEmailSender : MessageService
    {
        private MimeMessage Prepare(MessageFactory msgFactory, IMailKitMessageEmail mailkitOptions)
        {
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(mailkitOptions.mailKitEmailSenderOptions.Sender_EMail);
            if (!string.IsNullOrEmpty(mailkitOptions.mailKitEmailSenderOptions.Sender_Name))
                email.Sender.Name = mailkitOptions.mailKitEmailSenderOptions.Sender_Name;
            email.From.Add(email.Sender);
            email.To.Add(MailboxAddress.Parse(mailkitOptions.ReceiverEmail));
            email.Subject = mailkitOptions.ReceiverSubject;
            email.Body = mailkitOptions.MessageBody.ToMessageBody();

            return email;
        }

        public override void SendMessage(MessageFactory msgFactory)
        {
            var mailkitOptions = msgFactory.MailKitEmailSystem;

            MessageResult msgResult = new MessageResult();
            if (!string.IsNullOrEmpty(mailkitOptions.mailKitEmailSenderOptions.Host_Address))
            {

                // create message
                var email = Prepare(msgFactory, mailkitOptions);

                // send email
                using (var smtp = new SmtpClient()) // dispatch called even if throw error occur 
                {
                    smtp.ConnectAsync(mailkitOptions.mailKitEmailSenderOptions.Host_Address, mailkitOptions.mailKitEmailSenderOptions.Host_Port, mailkitOptions.mailKitEmailSenderOptions.Host_SecureSocketOptions);
                    smtp.AuthenticateAsync(mailkitOptions.mailKitEmailSenderOptions.Host_Username, new System.Net.NetworkCredential(string.Empty, mailkitOptions.mailKitEmailSenderOptions.Host_Password).Password);
                    smtp.Send(email);
                    smtp.Disconnect(true);

                    msgResult.IsSended = true;
                }
            }
            OnMessageSend(msgResult);
        }
    }
}
