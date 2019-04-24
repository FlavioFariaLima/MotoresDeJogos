using Kross.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Kross
{
    class Ship : IPureObject
    {
        Model model;
        Matrix worldPosition;
        BoundingSphere boundingSphere;

        bool active;
        bool onGround;
        bool inViewFrustum;

        Vector3 gravityValue;

        int index;

        public Ship(Vector3 position, int _index)
        {
            active = true;
            index = _index;
            worldPosition = Matrix.CreateTranslation(position);
            gravityValue = new Vector3(0, 0, 0);
            onGround = false;
            inViewFrustum = false;
        }

        public Ship(Vector3 position, int _index, float boundingSphereRadius)
        {
            active = true;
            index = _index;
            worldPosition = Matrix.CreateTranslation(position);
            boundingSphere = new BoundingSphere(worldPosition.Translation, boundingSphereRadius);
            gravityValue = new Vector3(0, 0, 0);
            onGround = false;
            inViewFrustum = false;
        }

        public void SetActive(bool status)
        {
            active = status;
        }

        public bool IsActive()
        {
            return active;
        }

        public void SetOnGround(bool _onGround)
        {
            onGround = _onGround;
        }

        public Matrix PositionMatrix()
        {
            return worldPosition;
        }

        public void SetModel(Model _model)
        {
            model = _model;
        }

        public int PoolPosition()
        {
            return index;
        }

        public BoundingSphere Collider()
        {
            return boundingSphere;
        }

        public void SetInFrustumView(bool _inView)
        {
            inViewFrustum = _inView;
        }

        public void DrawModel()
        {
            if (active && inViewFrustum)
            {
                foreach (ModelMesh mesh in model.Meshes)
                {
                    foreach (BasicEffect effect in mesh.Effects)
                    {
                        effect.World = worldPosition;
                        effect.View = Player.cameraView;
                        effect.Projection = Player.Projection();
                    }
                    mesh.Draw();
                }
            }
        }

        public void Update(GameTime gameTime)
        {
            if (active)
            {
                float timeDifference = (float)gameTime.ElapsedGameTime.TotalMilliseconds / 1000.0f;
                if (!onGround)
                {
                    gravityValue += Physics.GravityAmount();
                    Vector3 valueToAdd = gravityValue * timeDifference;
                    worldPosition = Matrix.CreateTranslation(worldPosition.Translation + valueToAdd);
                    boundingSphere.Center = worldPosition.Translation;
                }
                else
                {
                    worldPosition = Matrix.CreateTranslation(worldPosition.Translation);
                    boundingSphere.Center = worldPosition.Translation;
                    gravityValue = new Vector3(0, 0, 0);
                }
            }
        }
    }
}
