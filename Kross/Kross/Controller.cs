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

        public Controller(int shipNumber)
        {
            ships = new Ship[shipNumber];
            for(int i=0; i < shipNumber; i++)
            {
                ships[i] = new Ship(i);
            }
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

        public void LoadShipModel(ContentManager content)
        {
            shipModel = content.Load<Model>("Models/Ship1/p1_saucer");
        }

        public void DrawModel(int shipIndex, Matrix projection)
        {
            ships[shipIndex].DrawModel(projection);
            ships[shipIndex].SetActive(true);
        }

        public Ship GetShip(int index)
        {
            return ships[index];
        }
    }
}
