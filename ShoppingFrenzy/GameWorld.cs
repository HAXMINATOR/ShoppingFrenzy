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
        Node[,] nodeArray = new Node[10, 10];

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

            #region Specific tiles
            //Empty Displays
            mapArray[0, 2] = new Tile(mapArray[0, 2].Position, Content, "Display");
            mapArray[0, 4] = new Tile(mapArray[0, 4].Position, Content, "Display");
            mapArray[0, 8] = new Tile(mapArray[0, 8].Position, Content, "Display");
            mapArray[0, 9] = new Tile(mapArray[0, 9].Position, Content, "Display");
            mapArray[2, 3] = new Tile(mapArray[2, 3].Position, Content, "Display");
            mapArray[2, 4] = new Tile(mapArray[2, 4].Position, Content, "Display");
            mapArray[2, 5] = new Tile(mapArray[2, 5].Position, Content, "Display");
            mapArray[2, 6] = new Tile(mapArray[2, 6].Position, Content, "Display");
            mapArray[3, 4] = new Tile(mapArray[3, 4].Position, Content, "Display");
            mapArray[3, 6] = new Tile(mapArray[3, 6].Position, Content, "Display");
            mapArray[6, 3] = new Tile(mapArray[6, 3].Position, Content, "Display");
            mapArray[6, 4] = new Tile(mapArray[6, 4].Position, Content, "Display");
            mapArray[6, 5] = new Tile(mapArray[6, 5].Position, Content, "Display");
            mapArray[6, 6] = new Tile(mapArray[6, 6].Position, Content, "Display");
            mapArray[7, 3] = new Tile(mapArray[7, 3].Position, Content, "Display");
            mapArray[7, 5] = new Tile(mapArray[7, 5].Position, Content, "Display");
            mapArray[9, 8] = new Tile(mapArray[9, 8].Position, Content, "Display");
            mapArray[8, 8] = new Tile(mapArray[8, 8].Position, Content, "Display");
            mapArray[7, 8] = new Tile(mapArray[7, 8].Position, Content, "Display");
            mapArray[7, 9] = new Tile(mapArray[7, 9].Position, Content, "Display");
            
            //Item Displays
            mapArray[0, 3] = new Tile(mapArray[0, 3].Position, Content, "DisplayAxe");
            mapArray[0, 7] = new Tile(mapArray[0, 7].Position, Content, "DisplayShuriken");
            mapArray[3, 3] = new Tile(mapArray[3, 3].Position, Content, "DisplayStaff");
            mapArray[3, 5] = new Tile(mapArray[3, 5].Position, Content, "DisplayDagger");
            mapArray[7, 4] = new Tile(mapArray[7, 4].Position, Content, "DisplayClaw");
            mapArray[7, 6] = new Tile(mapArray[7, 6].Position, Content, "DisplayMace");
            
            //Interactable
            mapArray[1, 3] = new Tile(mapArray[1, 3].Position, Content, "BuyAxe");
            mapArray[1, 7] = new Tile(mapArray[1, 7].Position, Content, "BuyShuriken");
            mapArray[4, 3] = new Tile(mapArray[4, 3].Position, Content, "BuyStaff");
            mapArray[4, 5] = new Tile(mapArray[4, 5].Position, Content, "BuyDagger");
            mapArray[8, 4] = new Tile(mapArray[8, 4].Position, Content, "BuyClaw");
            mapArray[8, 6] = new Tile(mapArray[8, 6].Position, Content, "BuyMace");
            mapArray[9, 7] = new Tile(mapArray[9, 7].Position, Content, "ShopPay");
            #endregion

            int index = 0;

            //Adds nodes for each tile
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    mapArray[i, j].Node = new Node();
                    mapArray[i, j].Node.Position = mapArray[i, j].Position + new Vector2(mapArray[i, j].Sprite.Width * 0.5f);
                    mapArray[i, j].Node.Tile = mapArray[i, j];
                    mapArray[i, j].Node.Index = index;
                    index++;
                    if (mapArray[i, j].Walkable)
                    {
                        nodeArray[i, j] = mapArray[i, j].Node;
                    }
                }
            }

            //Adds edges for each node
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    #region Horizontal/Vertical
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
                    #endregion
                    #region Diagonal
                    if (i != 0 && j != 0) //Checks limit values
                    {
                        if (mapArray[i - 1, j - 1].Walkable)
                        {
                            mapArray[i, j].Node.Edges[4] = new Edge(mapArray[i, j].Node, mapArray[i - 1, j - 1].Node);
                        }
                    }
                    if (i != 9 && j != 0) //Checks limit values
                    {
                        if (mapArray[i + 1, j - 1].Walkable)
                        {
                            mapArray[i, j].Node.Edges[5] = new Edge(mapArray[i, j].Node, mapArray[i + 1, j - 1].Node);
                        }
                    }
                    if (i != 0 && j != 9) //Checks limit values
                    {
                        if (mapArray[i - 1, j + 1].Walkable)
                        {
                            mapArray[i, j].Node.Edges[6] = new Edge(mapArray[i, j].Node, mapArray[i - 1, j + 1].Node);
                        }
                    }
                    if (i != 9 && j != 9) //Checks limit values
                    {
                        if (mapArray[i + 1, j + 1].Walkable)
                        {
                            mapArray[i, j].Node.Edges[7] = new Edge(mapArray[i, j].Node, mapArray[i + 1, j + 1].Node);
                        }
                    }
                    #endregion
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

                Tile[] path = new Tile[0]; //Path array
                Tile workaroundTile = customer.CurrentNode.Tile;
                Enqueue(ref path, ref workaroundTile); //Adds the customers current node to the path array
                Tile smallestHTile = customer.CurrentNode.Edges[0].Child.Tile;
                for (int i = 0; i < customer.CurrentNode.Edges.Length; i++)
                {
                    if (customer.CurrentNode.Edges[i] != null)
                    {
                        smallestHTile = customer.CurrentNode.Edges[i].Child.Tile; //Takes the first non-null tile and adds it to smallestHTile for later comparison
                    }
                }
                
                while (pathing == true)
                {
                    for (int i = 0; i < path[path.Length - 1].Node.Edges.Length; i++) //Goes through all the edges of the the last node in the path array
                    {
                        if (path[path.Length - 1].Node.Edges[i] != null && path[path.Length - 1].Node.Edges[i].Child.Tile.HValue < smallestHTile.HValue) //Makes sure the current edge isn't null. Compares HValues of the current edge's child's tile and the currently lowest HValue tile found
                        {
                            smallestHTile = customer.CurrentNode.Edges[i].Child.Tile; //Assigns the lower tile to the smallestHTile reference
                        }
                    }

                    Enqueue(ref path, ref smallestHTile); //Adds the found tile with the smallest HValues to the path array

                    //if (customer.ShopperMap[tempTileX + 1, tempTileY].Walkable == true && tempTileX + 1 <= 9)
                    //{
                    //    tempFvalue1 = customer.ShopperMap[customer.TileXPosition + 1, customer.TileYPosition].HValue + currentGValue;
                    //}

                    //else
                    //{
                    //    tempFvalue1 = 9999;
                    //}

                    //if (customer.ShopperMap[tempTileX - 1, tempTileY].Walkable == true && tempTileX - 1 >= 0)
                    //{
                    //    tempFvalue2 = customer.ShopperMap[customer.TileXPosition - 1, customer.TileYPosition].HValue + currentGValue;
                    //}

                    //else
                    //{
                    //    tempFvalue2 = 9999;
                    //}

                    //if (customer.ShopperMap[tempTileX, tempTileY + 1].Walkable == true && tempTileY + 1 <= 9)
                    //{
                    //    tempFvalue3 = customer.ShopperMap[customer.TileYPosition, customer.TileYPosition + 1].HValue + currentGValue;
                    //}

                    //else
                    //{
                    //    tempFvalue3 = 9999;
                    //}

                    //if (customer.ShopperMap[tempTileX, tempTileY - 1].Walkable == true && tempTileY - 1 >= 0)
                    //{
                    //    tempFvalue4 = customer.ShopperMap[customer.TileYPosition, customer.TileYPosition - 1].HValue + currentGValue;
                    //}

                    //else
                    //{
                    //    tempFvalue4 = 9999;
                    //}

                    //MathHelper.Min(MathHelper.Min(tempFvalue1, tempFvalue2), MathHelper.Min(tempFvalue3, tempFvalue4));

                    if (smallestHTile == MapArray[targetTileX, targetTileY]) //If the smallest found tile is the target tile
                    {
                        pathing = false;
                    }
                }
            }
        }
    }
}

