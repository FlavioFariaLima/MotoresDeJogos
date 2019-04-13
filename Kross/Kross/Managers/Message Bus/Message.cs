using Microsoft.Xna.Framework;

namespace Kross.Managers.Message_Bus
{
    class Message
    {
        public enum MessageType
        {
            Particle
        }

        MessageType messageType;
        Vector3 position;

        public Message(MessageType _messageType, Vector3 _position)
        {
            messageType = _messageType;
            position = _position;
        }
    }
}
