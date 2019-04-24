using Kross.Managers.Message_Bus;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Kross.Managers
{
    class MessageBus
    {
        static List<Message> messages;

        public static void Init()
        {
            messages = new List<Message>();
        }

        public static void AddNewMessage(MessageType messageType, Vector3 _position)
        {
            Message message = new Message(messageType, _position);
            messages.Add(message);
        }

        public static List<Message> GetMessages(MessageType messageType)
        {
            List<Message> _messages = new List<Message>();
            for (int i = 0; i < messages.Count; i++)
            {
                if(messages[i].GetMessageType() == messageType)
                {
                    _messages.Add(messages[i]);
                    messages.Remove(messages[i]);
                }
            }
            return _messages;
        }
    }
}
