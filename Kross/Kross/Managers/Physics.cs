using Kross.Managers;
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
            objects = controller.Ships();
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
            foreach(IPureObject ship in objects)
            {
                if (ship.IsActive())
                {
                    if (Player.PlayerCollider().Intersects(ship.Collider()))
                    {
                        ship.SetActive(false);
                    }

                    if (ship.Collider().Intersects(controller.FloorCollider()))
                    {
                        ship.SetOnGround(true);
                    }
                    else
                    {
                        ship.SetOnGround(false);
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
