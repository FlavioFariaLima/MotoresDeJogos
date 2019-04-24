using Kross.Managers.Message_Bus;
using Microsoft.Xna.Framework;

namespace Kross.Managers.Particles
{
    class ParticlesManager
    {
        public static void Update()
        {
            foreach(Message m in MessageBus.GetMessages(MessageType.Particle))
            {
                ExplosionParticlesSystem.InserirExplosao(m.GetPosition(), 30, 0.05f, 0.4f, Vector3.Up);
            }
        }
    }
}
