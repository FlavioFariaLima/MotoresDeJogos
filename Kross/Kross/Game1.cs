using Kross.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Kross
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Controller controller;
        SkyBox skyBox;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            controller = new Controller(100);
            Physics.Init(controller);
            Player.Init(0.5f, 20f);
            MessageBus.Init();
            skyBox = new SkyBox(graphics.GraphicsDevice);
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            controller.LoadAllModels(Content);
            controller.ApplyModelToShips();
            Player.LoadModel(Content);
            
            skyBox.Textures[0] = Content.Load<Texture2D>("Textures/SkyBox/redFront");
            skyBox.Textures[1] = Content.Load<Texture2D>("Textures/SkyBox/redBack");
            skyBox.Textures[2] = Content.Load<Texture2D>("Textures/SkyBox/redBottom");
            skyBox.Textures[3] = Content.Load<Texture2D>("Textures/SkyBox/redTop");
            skyBox.Textures[4] = Content.Load<Texture2D>("Textures/SkyBox/redLeft");
            skyBox.Textures[5] = Content.Load<Texture2D>("Textures/SkyBox/redRight");

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            Player.Update(gameTime);
            Physics.Update();
            controller.Update();
            skyBox.Update(gameTime);
            foreach(Ship ship in controller.Ships())
            {
                ship.Update(gameTime);
            }

            // TODO: Add your update logic here
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Bisque);
            skyBox.Draw();
            Player.DrawModel();
            controller.DrawModels();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
