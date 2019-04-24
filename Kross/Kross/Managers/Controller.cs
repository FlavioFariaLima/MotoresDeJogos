using Kross.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Kross
{
    class Controller
    {
        IPureObject[] objects;

        Model shipModel;
        Model floor;

        Matrix floorPosition;
        BoundingBox floorBoundingBox;

        public Controller(int objectsPool)
        {
            objects = new Ship[objectsPool];
            Vector3 position = new Vector3();
            int counter = 0;
            int distanceBetweenRows = 0;
            float startX = -25;
            for(int i=0; i < objectsPool; i++)
            {
                if(counter == 50)
                {
                    distanceBetweenRows += 3;
                    counter = 0;
                    startX = -25;
                }
                startX += 2.5f;
                position = new Vector3(startX, distanceBetweenRows, distanceBetweenRows);
                objects[i] = new Ship(position, i, 0.8f);
                counter++;
            }
            floorPosition = Matrix.CreateTranslation(0, -4f, 0);
            floorBoundingBox = new BoundingBox(new Vector3(-1000f, -5f, -1000f), new Vector3(1000f, -4f, 1000f));
        }

        public void Update(GameTime gameTime)
        {
            foreach (IPureObject _object in objects)
            {
                _object.Update(gameTime);
            }
        }

        public void ApplyModelToShips()
        {
            for(int i=0; i < objects.Length; i++)
            {
                objects[i].SetModel(shipModel);
            }
        }

        public void LoadAllModels(ContentManager content)
        {
            shipModel = content.Load<Model>("Models/3D/p1_saucer");
            floor = content.Load<Model>("Models/3D/Floor");
        }

        public void DrawModels()
        {
            for (int i = 0; i < 1000; i++)
            {
                objects[i].DrawModel();
            }

            foreach (ModelMesh mesh in floor.Meshes)
            {
                foreach (BasicEffect effect in mesh.Effects)
                {
                    effect.World = floorPosition;
                    effect.View = Player.cameraView;
                    effect.Projection = Player.Projection(); ;
                }
                mesh.Draw();
            }
        }

        public BoundingBox FloorCollider()
        {
            return floorBoundingBox;
        }

        public IPureObject[] Objects()
        {
            return objects;
        }
    }
}
