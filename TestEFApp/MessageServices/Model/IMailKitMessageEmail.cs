using MessageServices.Model;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace MessageServices
{
    public interface IMailKitMessageEmail
    {
        public MailKitEmailSenderOptions mailKitEmailSenderOptions { get; set; }
        string ReceiverEmail { get; set; }
        string ReceiverSubject { get; set; }
        string ReceiverMessage { get; set; }

        public BodyBuilder MessageBody { get; set; } // add attachment AND mail body like html, txt link etc.
    }
}
