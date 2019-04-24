using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Kross.Managers
{
    public enum KeyPressed { Up, Down, Right, Left, RotateRight, RotateLeft }

    class InputHandler
    {
        static KeyboardState keyboardState;

        static List<KeyPressed> keysPressed;

        public static void Init()
        {
            keyboardState = new KeyboardState();
            keysPressed = new List<KeyPressed>();
        }

        public static void Update()
        {
            keysPressed.Clear();
            keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.Up) || keyboardState.IsKeyDown(Keys.W))
            {
                keysPressed.Add(KeyPressed.Up);
            }
            if(keyboardState.IsKeyDown(Keys.Right) || keyboardState.IsKeyDown(Keys.D))
            {
                keysPressed.Add(KeyPressed.Right);
            }
            if(keyboardState.IsKeyDown(Keys.Down) || keyboardState.IsKeyDown(Keys.S))
            {
                keysPressed.Add(KeyPressed.Down);
            }
            if(keyboardState.IsKeyDown(Keys.Left) || keyboardState.IsKeyDown(Keys.A))
            {
                keysPressed.Add(KeyPressed.Left);
            }
            if (keyboardState.IsKeyDown(Keys.Q))
            {
                keysPressed.Add(KeyPressed.RotateLeft);
            }
            if (keyboardState.IsKeyDown(Keys.E))
            {
                keysPressed.Add(KeyPressed.RotateRight);
            }
        }

        public static List<KeyPressed> GetKeysDown()
        {
            return keysPressed;
        }
    }
}
