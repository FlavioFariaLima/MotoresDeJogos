using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace Kross
{
    class Controller
    {
        Ship[] ships;

        Model shipModel;
        Model floor;

        Matrix floorPosition;
        BoundingBox floorBoundingBox;

        public Controller(int shipNumber)
        {
            ships = new Ship[shipNumber];
            for(int i=0; i < shipNumber; i++)
            {
                ships[i] = new Ship(i, 0.5f);
            }
            floorPosition = Matrix.CreateTranslation(0, -4f, 0);
            floorBoundingBox = new BoundingBox(new Vector3(-1000f, -5f, -1000f), new Vector3(1000f, -4f, 1000f));
        }

        public void Update()
        {
            
        }

        public void ApplyModelToShips()
        {
            for(int i=0; i < ships.Length; i++)
            {
                ships[i].SetModel(shipModel);
            }
        }

        public void LoadAllModels(ContentManager content)
        {
            shipModel = content.Load<Model>("Models/3D/p1_saucer");
            floor = content.Load<Model>("Models/3D/Floor");
        }

        public void DrawModels()
        {
            for (int i = 0; i < 100; i++)
            {
                ships[i].DrawModel();
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

        public Ship[] Ships()
        {
            return ships;
        }
    }
}
