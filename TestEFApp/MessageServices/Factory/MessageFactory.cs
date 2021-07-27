using MessageServices.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageServices.Factory
{
    public class MessageFactory : IAbstractMessageFactory
    {
        public IMailKitMessageEmail MailKitEmailSystem { get; set; } = new MailKitMessageEmail();
    }
}
