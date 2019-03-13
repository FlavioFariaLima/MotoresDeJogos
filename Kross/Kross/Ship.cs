using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Kross
{
    class Ship
    {
        Model model;
        Matrix worldPosition;

        bool active;

        int index;
        float currentRotation;

        public Ship(int _index)
        {
            active = false;
            index = _index;
            worldPosition = Matrix.CreateTranslation(new Vector3(1, 1, 1) * index);
        }

        public void SetActive(bool status)
        {
            active = status;
        }

        public bool IsActive()
        {
            return active;
        }

        public Vector3 Position()
        {
            return worldPosition.Translation;
        }

        public Matrix Translation()
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

        public void DrawModel(Matrix projection)
        {
            foreach (ModelMesh mesh in model.Meshes)
            {
                foreach (BasicEffect effect in mesh.Effects)
                {
                    effect.World = worldPosition;
                    effect.View = Player.cameraView;
                    effect.Projection = projection;
                }
                mesh.Draw();
            }
        }

        public void Update(Vector3 position, float rotationAmount)
        {
            worldPosition = Matrix.CreateRotationY(currentRotation + rotationAmount) * Matrix.CreateTranslation(worldPosition.Translation + position);
            currentRotation += rotationAmount;
        }
    }
}
