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

        public static void AddNewMessage(Message.MessageType messageType, Vector3 _position)
        {
            Message message = new Message(messageType, _position);
            messages.Add(message);
        }
    }
}
