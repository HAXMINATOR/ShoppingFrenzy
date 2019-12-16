using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ShoppingFrenzy
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class GameWorld : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private Tile[,] mapArray = new Tile[10, 10];
        

        public GameWorld()
        {
            //killroy was here
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 1920;
            graphics.PreferredBackBufferHeight = 1020;
            graphics.ApplyChanges();
            IsMouseVisible = true;
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
            GenerateMap();
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

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();
            foreach (Tile tiles in mapArray)
            {
                tiles.Draw(spriteBatch);
            }

            // TODO: Add your drawing code here

            base.Draw(gameTime);

            spriteBatch.End();
        }

        private void GenerateMap()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int k = 0; k < 10; k++)
                {
                    mapArray[i, k] = new Tile(new Vector2(460 + i * 100, 5 + k * 100), Content, "Floor");
                }
            }

        //Empty Displays
            mapArray[0, 2] = new Tile(new Vector2(460 + 0 * 100, 5 + 2 * 100), Content, "Display");
            mapArray[0, 4] = new Tile(new Vector2(460 + 0 * 100, 5 + 4 * 100), Content, "Display");
            mapArray[0, 8] = new Tile(new Vector2(460 + 0 * 100, 5 + 8 * 100), Content, "Display");
            mapArray[0, 9] = new Tile(new Vector2(460 + 0 * 100, 5 + 9 * 100), Content, "Display");
            mapArray[2, 3] = new Tile(new Vector2(460 + 2 * 100, 5 + 3 * 100), Content, "Display");
            mapArray[2, 4] = new Tile(new Vector2(460 + 2 * 100, 5 + 4 * 100), Content, "Display");
            mapArray[2, 5] = new Tile(new Vector2(460 + 2 * 100, 5 + 5 * 100), Content, "Display");
            mapArray[2, 6] = new Tile(new Vector2(460 + 2 * 100, 5 + 6 * 100), Content, "Display");
            mapArray[3, 4] = new Tile(new Vector2(460 + 3 * 100, 5 + 4 * 100), Content, "Display");
            mapArray[3, 6] = new Tile(new Vector2(460 + 3 * 100, 5 + 6 * 100), Content, "Display");
            mapArray[6, 3] = new Tile(new Vector2(460 + 6 * 100, 5 + 3 * 100), Content, "Display");
            mapArray[6, 4] = new Tile(new Vector2(460 + 6 * 100, 5 + 4 * 100), Content, "Display");
            mapArray[6, 5] = new Tile(new Vector2(460 + 6 * 100, 5 + 5 * 100), Content, "Display");
            mapArray[6, 6] = new Tile(new Vector2(460 + 6 * 100, 5 + 6 * 100), Content, "Display");
            mapArray[7, 3] = new Tile(new Vector2(460 + 7 * 100, 5 + 3 * 100), Content, "Display");
            mapArray[7, 5] = new Tile(new Vector2(460 + 7 * 100, 5 + 5 * 100), Content, "Display");
            mapArray[9, 8] = new Tile(new Vector2(460 + 9 * 100, 5 + 8 * 100), Content, "Display");
            mapArray[8, 8] = new Tile(new Vector2(460 + 8 * 100, 5 + 8 * 100), Content, "Display");
            mapArray[7, 8] = new Tile(new Vector2(460 + 7 * 100, 5 + 8 * 100), Content, "Display");
            mapArray[7, 9] = new Tile(new Vector2(460 + 7 * 100, 5 + 9 * 100), Content, "Display");

            //Item Displays
            mapArray[0, 3] = new Tile(new Vector2(460 + 0 * 100, 5 + 3 * 100), Content, "DisplayAxe");
            mapArray[0, 7] = new Tile(new Vector2(460 + 0 * 100, 5 + 7 * 100), Content, "DisplayShuriken");
            mapArray[3, 3] = new Tile(new Vector2(460 + 3 * 100, 5 + 3 * 100), Content, "DisplayStaff");
            mapArray[3, 5] = new Tile(new Vector2(460 + 3 * 100, 5 + 5 * 100), Content, "DisplayDagger");
            mapArray[7, 4] = new Tile(new Vector2(460 + 7 * 100, 5 + 4 * 100), Content, "DisplayClaw");
            mapArray[7, 6] = new Tile(new Vector2(460 + 7 * 100, 5 + 6 * 100), Content, "DisplayMace");

            //Interactable
            mapArray[1, 3] = new Tile(new Vector2(460 + 1 * 100, 5 + 3 * 100), Content, "BuyAxe");
            mapArray[1, 7] = new Tile(new Vector2(460 + 1 * 100, 5 + 7 * 100), Content, "BuyShuriken");
            mapArray[4, 3] = new Tile(new Vector2(460 + 4 * 100, 5 + 3 * 100), Content, "BuyStaff");
            mapArray[4, 5] = new Tile(new Vector2(460 + 4 * 100, 5 + 5 * 100), Content, "BuyDagger");
            mapArray[8, 4] = new Tile(new Vector2(460 + 8 * 100, 5 + 4 * 100), Content, "BuyClaw");
            mapArray[8, 6] = new Tile(new Vector2(460 + 8 * 100, 5 + 6 * 100), Content, "BuyMace");
        }
    }
}
