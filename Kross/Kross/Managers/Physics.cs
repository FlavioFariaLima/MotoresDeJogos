using Kross.Managers;
using Kross.Managers.Message_Bus;
using Microsoft.Xna.Framework;

namespace Kross
{
    class Physics
    {
        static Controller controller;
        static IPureObject[] objects;
        static Vector3 gravityAmount;
        static bool collision;

        public static void Init(Controller _controller)
        {
            controller = _controller;
            objects = controller.Objects();
            gravityAmount = new Vector3(0, -0.05f, 0);
        }

        public static Vector3 GravityAmount()
        {
            return gravityAmount;
        }

        public static bool PlayerCollision()
        {
            return collision;
        }

        public static IPureObject[] GetShips()
        {
            return objects;
        }

        public static void Update()
        {
            foreach(IPureObject other in objects)
            {
                if (other.IsActive())
                {
                    if (Player.PlayerCollider().Intersects(other.Collider()))
                    {
                        other.SetActive(false);
                        MessageBus.AddNewMessage(MessageType.Particle, other.PositionMatrix().Translation);
                    }

                    if (other.Collider().Intersects(controller.FloorCollider()))
                    {
                        other.SetOnGround(true);
                    }
                    else
                    {
                        other.SetOnGround(false);
                    }
                }
            }

            if (Player.PlayerCollider().Intersects(controller.FloorCollider()))
            {
                collision = true;
            }
            else
            {
                collision = false;
            }
        }
    }
}
