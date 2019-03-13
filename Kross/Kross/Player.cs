using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Kross
{
    class Player
    {
        static KeyboardState keyStateAnterior;
        static MouseState originalMouseState;

        public static Matrix cameraView;

        static Ship target;

        public static void SetTarget(Ship _target)
        {
            originalMouseState = Mouse.GetState();
            target = _target;
        }

        public static Ship GetTarget()
        {
            return target;
        }

        private static void ProcessInput(float amount)
        {
            //Controlos do teclado
            Vector3 moveVector = new Vector3(0, 0, 0);
            KeyboardState keyState = Keyboard.GetState();
            if (keyState.IsKeyDown(Keys.Up) || keyState.IsKeyDown(Keys.W))
                moveVector += target.Translation().Forward;
            if (keyState.IsKeyDown(Keys.Down) || keyState.IsKeyDown(Keys.S))
                moveVector += target.Translation().Backward;
            if (keyState.IsKeyDown(Keys.Right) || keyState.IsKeyDown(Keys.D))
                moveVector += target.Translation().Right;
            if (keyState.IsKeyDown(Keys.Left) || keyState.IsKeyDown(Keys.A))
                moveVector += target.Translation().Left;

            float rotationAmount = 0;

            if (keyState.IsKeyDown(Keys.Q))
                rotationAmount = 0.05f;
            else if (keyState.IsKeyDown(Keys.E))
                rotationAmount = -0.05f;

            MovePlayer(moveVector, rotationAmount);

            keyStateAnterior = keyState;
        }

        private static void MovePlayer(Vector3 vectorToAdd, float rotation)
        {
            // Updates target position
            target.Update(vectorToAdd/4, rotation);
        }

        public static void Update(GameTime gameTime)
        {
            float timeDifference = (float)gameTime.ElapsedGameTime.TotalMilliseconds / 1000.0f;
            if(target != null)
                ProcessInput(timeDifference);

            //I want to locate my camera 25 units behind the player and 5 units above him
            Vector3 cameraPosition = target.Position() + (target.Translation().Backward * 7) + (target.Translation().Up * 2);
            //I want my cameras to look at a point 10 units directly in front of my player
            Vector3 cameraTarget = target.Position() + (target.Translation().Forward * 10);
            //build a view matrix that represents this
            cameraView = Matrix.CreateLookAt(cameraPosition, cameraTarget, Vector3.Up);
        }
    }
}
