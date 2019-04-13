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

        public Ship(int _index)
        {
            active = true;
            index = _index;
            worldPosition = Matrix.CreateTranslation(new Vector3(5f, 2f, 0) * index);
            gravityValue = new Vector3(0, 0, 0);
            onGround = false;
            inViewFrustum = false;
        }

        public Ship(int _index, float boundingSphereRadius)
        {
            active = true;
            index = _index;
            worldPosition = Matrix.CreateTranslation(new Vector3(5f, 5f, 0) * index);
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

        public int Index()
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
