using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Kross
{
    class Physics
    {
        static Controller controller;
        static Ship[] ships;
        static Vector3 gravityAmount;
        static bool collision;

        public static void Init(Controller _controller)
        {
            controller = _controller;
            ships = controller.Ships();
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

        public static Ship[] GetShips()
        {
            return ships;
        }

        public static void Update()
        {
            foreach(Ship ship in ships)
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
