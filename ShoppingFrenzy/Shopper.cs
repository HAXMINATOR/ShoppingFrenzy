using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingFrenzy
{
    public class Shopper : GameObject
    {
        private string[] shoppingList = new string[3];
        private string[] bought = new string[0];
        private int[,] pathfinding;
        private Node currentNode;
        private Tile[,] shopperMap = new Tile[10,10];
        private Tile[,] closedList;
        private Tile[,] openList;
        private int tileXPosition = 4;
        private int tileYPosition = 9;
        private Tile[] path = new Tile[0];

        public Shopper()
        {

        }

        public Shopper(string spriteName, ContentManager content) : base(spriteName, content)
        {
            GetNewShoppingList();

            for (int i = 0; i < 10; i++)
            {
                for (int k = 0; k < 10; k++)
                {
                    ShopperMap[i, k] = GameWorld.MapArray[i, k];
                }
            }

            position = GameWorld.MapArray[9, 4].Position;
            currentNode = GameWorld.MapArray[9, 4].Node;
        }

        public int[,] Pathfinding { get => pathfinding; set => pathfinding = value; }
        public Tile[,] ClosedList { get => closedList; set => closedList = value; }
        public Tile[,] OpenList { get => openList; set => openList = value; }
        public Tile[,] ShopperMap { get => shopperMap; set => shopperMap = value; }
        public int TileXPosition { get => tileXPosition; set => tileXPosition = value; }
        public int TileYPosition { get => tileYPosition; set => tileYPosition = value; }
        public Node CurrentNode { get => currentNode; set => currentNode = value; }
        public Tile[] Path { get => path; set => path = value; }

        /// <summary>
        /// doesn't work
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        public void BreadthFirstSearch(Node start, Node end)
        {
            Edge[] edgeQueue = new Edge[0];
            Edge newEdge = new Edge(start, start);
            GameWorld.Enqueue(ref edgeQueue, ref newEdge);
            while (edgeQueue.Length > 0)
            {
                Edge edge = GameWorld.Dequeue(ref edgeQueue);
                for (int i = 0; i < end.Edges.Length; i++)
                {
                    if (edge == end.Edges[i])
                    {
                        //return;
                    }
                }

                for (int i = 0; i < edge.Child.Edges.Length; i++)
                {
                    Edge wedge = edge.Child.Edges[i];
                    if (wedge != null && !wedge.Child.Discovered)
                    {
                        for (int j = 0; j < wedge.Child.Edges.Length; j++)
                        {
                            if (wedge.Child.Edges[j] != null && !wedge.Child.Edges[j].Child.Discovered)
                            {
                                GameWorld.Enqueue(ref edgeQueue, ref wedge.Child.Edges[j]);
                            }
                        }

                        wedge.Parent.Discovered = true;
                        wedge.Child.Discovered = true;
                        wedge.Parent = edge.Child;
                    }
                }
            }
        }

        public void Update(GameTime gameTime)
        {
            if (path.Length > 0)
            {
                Vector2 direction = path[0].Position - position;
                position += new Vector2(direction.X * (float)gameTime.ElapsedGameTime.TotalMilliseconds, direction.Y * (float)gameTime.ElapsedGameTime.TotalMilliseconds);
                if (Math.Abs(position.X - path[0].Position.X) > 0.5f && Math.Abs(position.Y - path[0].Position.Y) > 0.5f)
                {
                    position = path[0].Position;
                    currentNode = path[0].Node;
                    GameWorld.Dequeue(ref path);
                }
            }
            else if (path.Length <= 0)
            {
                CalculatePath(GameWorld.MapArray[1, 3]);
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, new Vector2(position.X - sprite.Width * 0.5f, position.Y - sprite.Height * 0.5f), color);
        }

        private void GetNewShoppingList()
        {
            Random rng = new Random();
            for (int i = 0; i < 3; i++)
            {
                shoppingList[i] = Tile.BuyAbles[rng.Next(0, Tile.BuyAbles.Length - 1)];
            }
        }

        public void CalculatePath(Tile targetTile)
        {
            int currentGValue = 10;
            int tempTileX = TileXPosition;
            int tempTileY = TileYPosition;
            int tempFvalue1;
            int tempFvalue2;
            int tempFvalue3;
            int tempFvalue4;
            bool pathing = true;
            //if ((TileXPosition == targetTileX - 1 || TileXPosition == targetTileX + 1) && (TileYPosition == targetTileY - 1 || TileYPosition == targetTileY + 1))
            //{
            //    //Go to tile and grab item
            //}

            Tile[] newPath = new Tile[0]; //Path array
            Tile workaroundTile = CurrentNode.Tile;
            GameWorld.Enqueue(ref newPath, ref workaroundTile); //Adds the customers current node to the path array
            Tile smallestHTile = CurrentNode.Edges[0].Child.Tile;
            for (int i = 0; i < CurrentNode.Edges.Length; i++)
            {
                if (CurrentNode.Edges[i] != null)
                {
                    smallestHTile = CurrentNode.Edges[i].Child.Tile; //Takes the first non-null tile and adds it to smallestHTile for later comparison
                }
            }

            while (pathing == true)
            {
                for (int i = 0; i < newPath[newPath.Length - 1].Node.Edges.Length; i++) //Goes through all the edges of the the last node in the path array
                {
                    if (newPath[newPath.Length - 1].Node.Edges[i] != null && newPath[newPath.Length - 1].Node.Edges[i].Child.Tile.HValue < smallestHTile.HValue) //Makes sure the current edge isn't null. Compares HValues of the current edge's child's tile and the currently lowest HValue tile found
                    {
                        smallestHTile = CurrentNode.Edges[i].Child.Tile; //Assigns the lower tile to the smallestHTile reference
                    }
                }

                GameWorld.Enqueue(ref newPath, ref smallestHTile); //Adds the found tile with the smallest HValues to the path array

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

                if (smallestHTile == targetTile) //If the smallest found tile is the target tile
                {
                    pathing = false;
                    Path = newPath;
                }
            }
        }
    }
}
