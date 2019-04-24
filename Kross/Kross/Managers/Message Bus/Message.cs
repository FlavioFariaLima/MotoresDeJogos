using Microsoft.Xna.Framework;

namespace Kross.Managers.Message_Bus
{
    public enum MessageType
    {
        Particle
    }

    class Message
    {
        MessageType messageType;
        Vector3 position;

        public Message(MessageType _messageType, Vector3 _position)
        {
            messageType = _messageType;
            position = _position;
        }

        public MessageType GetMessageType()
        {
            return messageType;
        }

        public Vector3 GetPosition()
        {
            return position;
        }
    }
}
