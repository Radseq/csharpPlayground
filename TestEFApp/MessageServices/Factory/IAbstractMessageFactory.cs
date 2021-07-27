using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageServices.Factory
{
    interface IAbstractMessageFactory
    {
        public IMailKitMessageEmail MailKitEmailSystem { get; set; }

        // IMessageSMS CreateMessageSMS();
    }
}
