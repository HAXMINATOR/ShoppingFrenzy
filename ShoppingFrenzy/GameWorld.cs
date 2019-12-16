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
        Shopper[] shoppers = new Shopper[3];
        

        public Shopper[] Shoppers { get => shoppers; set => shoppers = value; }

        public GameWorld()
        {
            //killroy was here
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 1020;
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
            for (int i = 0; i < 3; i++)
            {
                Shoppers[i] = new Shopper("smallGuy", Content);
            }

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
            
            foreach (Shopper shopper in Shoppers)
            {
                shopper.Update(gameTime);
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.SlateBlue);

            spriteBatch.Begin();

            foreach (Shopper shopper in Shoppers)
            {
                shopper.Draw(spriteBatch);
            }

            base.Draw(gameTime);
            spriteBatch.End();
        }

        private void GenerateMap()
        {

        }

        /// <summary>
        /// Resizes array and adds input to last position in array
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="array">Array in which item will be placed</param>
        /// <param name="input">Item to add to array</param>
        public static void Enqueue<T>(ref T[] array, ref T input)
        {
            T[] tmp = array;
            array = new T[array.Length + 1];
            tmp.CopyTo(array, 0);
            array[array.Length - 1] = input;
        }

        /// <summary>
        /// Returns item at position [0] in given array
        /// Resizes array to remove dequeued item
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="array">Array from which the first item will be removed and returned</param>
        /// <returns></returns>
        public static T Dequeue<T>(ref T[] array)
        {
            T output = array[0];
            T[] tmp = new T[array.Length - 1];
            for (int i = 1; i < array.Length; i++)
            {
                tmp[i - 1] = array[i];
            }
            array = new T[array.Length - 1];
            tmp.CopyTo(array, 0);

            return output;
        }
    }
}
