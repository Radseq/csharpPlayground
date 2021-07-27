using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageServices.Model
{
    public class MailKitMessageEmail : IMailKitMessageEmail
    {
        public MailKitEmailSenderOptions mailKitEmailSenderOptions { get; set; } = new MailKitEmailSenderOptions();

        public string ReceiverEmail { get; set; }
        public string ReceiverSubject { get; set; }
        public string ReceiverMessage { get; set; }
        public BodyBuilder MessageBody { get; set; } = new BodyBuilder();
    }
}
