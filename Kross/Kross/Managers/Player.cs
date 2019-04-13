using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Kross
{
    class Player
    {
        static KeyboardState keyStateAnterior;
        static MouseState originalMouseState;

        public static Matrix cameraView;
        static Matrix worldPosition;
        static Matrix projection;

        static Model playerModel;
        static BoundingSphere boundingSphere;

        static float currentRotation;
        static float movementSpeed;

        static Vector3 currentGravityValue;

        public static void Init(float boundingSphereRadius, float _speed)
        {
            originalMouseState = Mouse.GetState();
            worldPosition = Matrix.CreateTranslation(new Vector3(-6f, 10f, 0));
            boundingSphere = new BoundingSphere(worldPosition.Translation, boundingSphereRadius);
            projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45), 800f / 480f, 0.1f, 1500f);
            currentGravityValue = new Vector3(0, 0, 0);
            movementSpeed = _speed;
        }

        public static Matrix WorldPosition()
        {
            return worldPosition;
        }

        public static Matrix Projection()
        {
            return projection;
        }

        public static void LoadModel(ContentManager content)
        {
            playerModel = content.Load<Model>("Models/3D/p1_wedge");
        }

        private static void ProcessInput(float amount)
        {
            // Keyboard controllers to be replaced with Input Manager
            Vector3 moveVector = new Vector3(0, 0, 0);
            KeyboardState keyState = Keyboard.GetState();
            if (keyState.IsKeyDown(Keys.Up) || keyState.IsKeyDown(Keys.W))
                moveVector += worldPosition.Forward;
            if (keyState.IsKeyDown(Keys.Down) || keyState.IsKeyDown(Keys.S))
                moveVector += worldPosition.Backward;
            if (keyState.IsKeyDown(Keys.Right) || keyState.IsKeyDown(Keys.D))
                moveVector += worldPosition.Right;
            if (keyState.IsKeyDown(Keys.Left) || keyState.IsKeyDown(Keys.A))
                moveVector += worldPosition.Left;

            float rotationAmount = 0;

            if (keyState.IsKeyDown(Keys.Q))
                rotationAmount = 0.05f;
            else if (keyState.IsKeyDown(Keys.E))
                rotationAmount = -0.05f;

            MovePlayer(moveVector, rotationAmount, amount);

            keyStateAnterior = keyState;
        }

        private static void MovePlayer(Vector3 vectorToAdd, float rotation, float deltaTime)
        {
            if (!Physics.PlayerCollision())
            {
                currentGravityValue += Physics.GravityAmount();
                Vector3 valueToAdd = (vectorToAdd * movementSpeed + currentGravityValue) * deltaTime;
                worldPosition = Matrix.CreateRotationY(currentRotation + rotation) * Matrix.CreateTranslation(worldPosition.Translation +  valueToAdd);
            }
            else
            {
                Vector3 valueToAdd = vectorToAdd * movementSpeed * deltaTime;
                worldPosition = Matrix.CreateRotationY(currentRotation + rotation) * Matrix.CreateTranslation(worldPosition.Translation + valueToAdd);
            }
            currentRotation += rotation;
            boundingSphere.Center = worldPosition.Translation;
        }

        public static void Update(GameTime gameTime)
        {
            float timeDifference = (float)gameTime.ElapsedGameTime.TotalMilliseconds / 1000.0f;
            ProcessInput(timeDifference);

            Vector3 cameraPosition = worldPosition.Translation + (worldPosition.Backward * 7) + (worldPosition.Up * 2);
            Vector3 cameraTarget = worldPosition.Translation + (worldPosition.Forward * 10);
            cameraView = Matrix.CreateLookAt(cameraPosition, cameraTarget, Vector3.Up);

            foreach(Ship ship in Physics.GetShips())
            {
                ship.SetInFrustumView(InView(ship.Collider()));
            }
        }

        public static void DrawModel()
        {
            foreach (ModelMesh mesh in playerModel.Meshes)
            {
                foreach (BasicEffect effect in mesh.Effects)
                {
                    effect.World = worldPosition;
                    effect.View = cameraView;
                    effect.Projection = projection;
                }
                mesh.Draw();
            }
        }

        public static BoundingSphere PlayerCollider()
        {
            return boundingSphere;
        }

        static bool InView(BoundingSphere boundingSphere)
        {
            return new BoundingFrustum(cameraView * projection).Intersects(boundingSphere);
        }
    }
}
