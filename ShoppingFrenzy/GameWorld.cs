using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
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
        private static Tile[,] mapArray = new Tile[10, 10];
        SpriteFont font;

        

        public Shopper[] Shoppers { get => shoppers; set => shoppers = value; }
        public static Tile[,] MapArray { get => mapArray; set => mapArray = value; }

        public GameWorld()
        {
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
            for (int i = 0; i < 3; i++)
            {
                Shoppers[i] = new Shopper("smallGuy", Content);
            }
            
            GenerateMap();

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            font = Content.Load<SpriteFont>("SmallFont");
            
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            
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
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();

            foreach (Tile tiles in MapArray)
            {
                tiles.Draw(spriteBatch);
                spriteBatch.DrawString(font, $"{tiles.HValue}", new Vector2(tiles.Position.X + 70, tiles.Position.Y + 5), Color.Black);
            }

            foreach (Shopper shopper in Shoppers)
            {
                shopper.Draw(spriteBatch);
            }

            base.Draw(gameTime);

            spriteBatch.End();
        }

        private void GenerateMap()
        {
            //Generates base tiles
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    MapArray[i, j] = new Tile(new Vector2(460 + i * 100, 5 + j * 100), Content, "Floor");
                }
            }

            //Empty Displays
            MapArray[0, 2] = new Tile(MapArray[0, 2].Position, Content, "Display");
            MapArray[0, 4] = new Tile(MapArray[0, 4].Position, Content, "Display");
            MapArray[0, 8] = new Tile(MapArray[0, 8].Position, Content, "Display");
            MapArray[0, 9] = new Tile(MapArray[0, 9].Position, Content, "Display");
            MapArray[2, 3] = new Tile(MapArray[2, 3].Position, Content, "Display");
            MapArray[2, 4] = new Tile(MapArray[2, 4].Position, Content, "Display");
            MapArray[2, 5] = new Tile(MapArray[2, 5].Position, Content, "Display");
            MapArray[2, 6] = new Tile(MapArray[2, 6].Position, Content, "Display");
            MapArray[3, 4] = new Tile(MapArray[3, 4].Position, Content, "Display");
            MapArray[3, 6] = new Tile(MapArray[3, 6].Position, Content, "Display");
            MapArray[6, 3] = new Tile(MapArray[6, 3].Position, Content, "Display");
            MapArray[6, 4] = new Tile(MapArray[6, 4].Position, Content, "Display");
            MapArray[6, 5] = new Tile(MapArray[6, 5].Position, Content, "Display");
            MapArray[6, 6] = new Tile(MapArray[6, 6].Position, Content, "Display");
            MapArray[7, 3] = new Tile(MapArray[7, 3].Position, Content, "Display");
            MapArray[7, 5] = new Tile(MapArray[7, 5].Position, Content, "Display");
            MapArray[9, 8] = new Tile(MapArray[9, 8].Position, Content, "Display");
            MapArray[8, 8] = new Tile(MapArray[8, 8].Position, Content, "Display");
            MapArray[7, 8] = new Tile(MapArray[7, 8].Position, Content, "Display");
            MapArray[7, 9] = new Tile(MapArray[7, 9].Position, Content, "Display");

            //Empty displays, hard coded
            //mapArray[0, 2] = new Tile(new Vector2(460 + 0 * 100, 5 + 2 * 100), Content, "Display");
            //mapArray[0, 4] = new Tile(new Vector2(460 + 0 * 100, 5 + 4 * 100), Content, "Display");
            //mapArray[0, 8] = new Tile(new Vector2(460 + 0 * 100, 5 + 8 * 100), Content, "Display");
            //mapArray[0, 9] = new Tile(new Vector2(460 + 0 * 100, 5 + 9 * 100), Content, "Display");
            //mapArray[2, 3] = new Tile(new Vector2(460 + 2 * 100, 5 + 3 * 100), Content, "Display");
            //mapArray[2, 4] = new Tile(new Vector2(460 + 2 * 100, 5 + 4 * 100), Content, "Display");
            //mapArray[2, 5] = new Tile(new Vector2(460 + 2 * 100, 5 + 5 * 100), Content, "Display");
            //mapArray[2, 6] = new Tile(new Vector2(460 + 2 * 100, 5 + 6 * 100), Content, "Display");
            //mapArray[3, 4] = new Tile(new Vector2(460 + 3 * 100, 5 + 4 * 100), Content, "Display");
            //mapArray[3, 6] = new Tile(new Vector2(460 + 3 * 100, 5 + 6 * 100), Content, "Display");
            //mapArray[6, 3] = new Tile(new Vector2(460 + 6 * 100, 5 + 3 * 100), Content, "Display");
            //mapArray[6, 4] = new Tile(new Vector2(460 + 6 * 100, 5 + 4 * 100), Content, "Display");
            //mapArray[6, 5] = new Tile(new Vector2(460 + 6 * 100, 5 + 5 * 100), Content, "Display");
            //mapArray[6, 6] = new Tile(new Vector2(460 + 6 * 100, 5 + 6 * 100), Content, "Display");
            //mapArray[7, 3] = new Tile(new Vector2(460 + 7 * 100, 5 + 3 * 100), Content, "Display");
            //mapArray[7, 5] = new Tile(new Vector2(460 + 7 * 100, 5 + 5 * 100), Content, "Display");
            //mapArray[9, 8] = new Tile(new Vector2(460 + 9 * 100, 5 + 8 * 100), Content, "Display");
            //mapArray[8, 8] = new Tile(new Vector2(460 + 8 * 100, 5 + 8 * 100), Content, "Display");
            //mapArray[7, 8] = new Tile(new Vector2(460 + 7 * 100, 5 + 8 * 100), Content, "Display");
            //mapArray[7, 9] = new Tile(new Vector2(460 + 7 * 100, 5 + 9 * 100), Content, "Display");

            //Item Displays
            MapArray[0, 3] = new Tile(MapArray[0, 3].Position, Content, "DisplayAxe");
            MapArray[0, 7] = new Tile(MapArray[0, 7].Position, Content, "DisplayShuriken");
            MapArray[3, 3] = new Tile(MapArray[3, 3].Position, Content, "DisplayStaff");
            MapArray[3, 5] = new Tile(MapArray[3, 5].Position, Content, "DisplayDagger");
            MapArray[7, 4] = new Tile(MapArray[7, 4].Position, Content, "DisplayClaw");
            MapArray[7, 6] = new Tile(MapArray[7, 6].Position, Content, "DisplayMace");

            //Item displays, hard coded
            //mapArray[0, 3] = new Tile(new Vector2(460 + 0 * 100, 5 + 3 * 100), Content, "DisplayAxe");
            //mapArray[0, 7] = new Tile(new Vector2(460 + 0 * 100, 5 + 7 * 100), Content, "DisplayShuriken");
            //mapArray[3, 3] = new Tile(new Vector2(460 + 3 * 100, 5 + 3 * 100), Content, "DisplayStaff");
            //mapArray[3, 5] = new Tile(new Vector2(460 + 3 * 100, 5 + 5 * 100), Content, "DisplayDagger");
            //mapArray[7, 4] = new Tile(new Vector2(460 + 7 * 100, 5 + 4 * 100), Content, "DisplayClaw");
            //mapArray[7, 6] = new Tile(new Vector2(460 + 7 * 100, 5 + 6 * 100), Content, "DisplayMace");

            //Interactable
            MapArray[1, 3] = new Tile(MapArray[1, 3].Position, Content, "BuyAxe");
            MapArray[1, 7] = new Tile(MapArray[1, 7].Position, Content, "BuyShuriken");
            MapArray[4, 3] = new Tile(MapArray[4, 3].Position, Content, "BuyStaff");
            MapArray[4, 5] = new Tile(MapArray[4, 5].Position, Content, "BuyDagger");
            MapArray[8, 4] = new Tile(MapArray[8, 4].Position, Content, "BuyClaw");
            MapArray[8, 6] = new Tile(MapArray[8, 6].Position, Content, "BuyMace");

            //Interactable, hard coded
            //mapArray[1, 3] = new Tile(new Vector2(460 + 1 * 100, 5 + 3 * 100), Content, "BuyAxe");
            //mapArray[1, 7] = new Tile(new Vector2(460 + 1 * 100, 5 + 7 * 100), Content, "BuyShuriken");
            //mapArray[4, 3] = new Tile(new Vector2(460 + 4 * 100, 5 + 3 * 100), Content, "BuyStaff");
            //mapArray[4, 5] = new Tile(new Vector2(460 + 4 * 100, 5 + 5 * 100), Content, "BuyDagger");
            //mapArray[8, 4] = new Tile(new Vector2(460 + 8 * 100, 5 + 4 * 100), Content, "BuyClaw");
            //mapArray[8, 6] = new Tile(new Vector2(460 + 8 * 100, 5 + 6 * 100), Content, "BuyMace");

            int index = 0;

            //Adds nodes for each tile
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    MapArray[i, j].Node = new Node();
                    MapArray[i, j].Node.Index = index;
                    index++;
                }
            }

            //Adds edges for each node
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (j != 0) //Checks limit values
                    {
                        if (MapArray[i, j - 1].Walkable)
                        {
                            MapArray[i, j].Node.Edges[0] = new Edge(MapArray[i, j].Node, MapArray[i, j - 1].Node);
                        }
                    }
                    if (i != 0) //Checks limit values
                    {
                        if (MapArray[i - 1, j].Walkable)
                        {
                            MapArray[i, j].Node.Edges[1] = new Edge(MapArray[i, j].Node, MapArray[i - 1, j].Node);
                        }
                    }
                    if (j != 9) //Checks limit values
                    {
                        if (MapArray[i, j + 1].Walkable)
                        {
                            MapArray[i, j].Node.Edges[2] = new Edge(MapArray[i, j].Node, MapArray[i, j + 1].Node);
                        }
                    }
                    if (i != 9) //Checks limit values
                    {
                        if (MapArray[i + 1, j].Walkable)
                        {
                            MapArray[i, j].Node.Edges[3] = new Edge(MapArray[i, j].Node, MapArray[i + 1, j].Node);
                        }
                        
                    }
                }
            }
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
        /// Returns first item from array ([0]) and resizes array to exclude the removed items position
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="array">Array from which to remove and return first item</param>
        /// <returns></returns>
        public static T Dequeue<T>(ref T[] array)
        {
            T returnItem = array[0];
            T[] tmp = new T[array.Length - 1];
            for (int i = 1; i < array.Length; i++)
            {
                tmp[i - 1] = array[i];
            }
            array = new T[array.Length - 1];
            tmp.CopyTo(array, 0);

            return returnItem;
        }

        public void CalculatePath(int targetTileX, int targetTileY)
        {
            foreach (Shopper customer in shoppers)
            {
                int currentGValue = 10;
                int tempTileX = customer.TileXPosition;
                int tempTileY = customer.TileYPosition;
                int tempFvalue1;
                int tempFvalue2;
                int tempFvalue3;
                int tempFvalue4;
                bool pathing = true;
                if ((customer.TileXPosition == targetTileX - 1 || customer.TileXPosition == targetTileX + 1) && (customer.TileYPosition == targetTileY - 1 || customer.TileYPosition == targetTileY + 1))
                {
                    //Go to tile and grab item
                }

                while (pathing == true)
                {
                    if (customer.ShopperMap[tempTileX + 1, tempTileY].Walkable == true && tempTileX + 1 <= 9)
                    {
                        tempFvalue1 = customer.ShopperMap[customer.TileXPosition + 1, customer.TileYPosition].HValue + currentGValue;
                    }

                    else
                    {
                        tempFvalue1 = 9999;
                    }

                    if (customer.ShopperMap[tempTileX - 1, tempTileY].Walkable == true && tempTileX - 1 >= 0)
                    {
                        tempFvalue2 = customer.ShopperMap[customer.TileXPosition - 1, customer.TileYPosition].HValue + currentGValue;
                    }

                    else
                    {
                        tempFvalue2 = 9999;
                    }

                    if (customer.ShopperMap[tempTileX, tempTileY + 1].Walkable == true && tempTileY + 1 <= 9)
                    {
                        tempFvalue3 = customer.ShopperMap[customer.TileYPosition, customer.TileYPosition + 1].HValue + currentGValue;
                    }

                    else
                    {
                        tempFvalue3 = 9999;
                    }

                    if (customer.ShopperMap[tempTileX, tempTileY - 1].Walkable == true && tempTileY - 1 >= 0)
                    {
                        tempFvalue4 = customer.ShopperMap[customer.TileYPosition, customer.TileYPosition - 1].HValue + currentGValue;
                    }

                    else
                    {
                        tempFvalue4 = 9999;
                    }

                    MathHelper.Min(MathHelper.Min(tempFvalue1, tempFvalue2), MathHelper.Min(tempFvalue3, tempFvalue4));

                }
            }
        }
    }
}

