using MessageServices.Factory;
using System;

namespace MessageServices
{
    public class MessageServiceEventArgs : EventArgs
    {
        public MessageResult m_Message { get; set; }
    }

    public abstract class MessageService
    {
        //public delegate void MessageServiceEventHandler(object source, MessageServiceEventArgs args);
        //public event MessageServiceEventHandler MessageSender;
        public event EventHandler<MessageServiceEventArgs> MessageSender;

        public abstract void SendMessage(MessageFactory MessageToSend);

        protected internal void OnMessageSend(MessageResult msg)
        {
            if (MessageSender != null) // ONLY if we have subscribers
                MessageSender(this, new MessageServiceEventArgs() { m_Message = msg });
        }
    }
}
