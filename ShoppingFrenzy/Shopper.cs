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
        private Tile[] shoppingList = new Tile[0];
        private int[,] pathfinding;
        private Node currentNode;
        private Tile[,] shopperMap = new Tile[10,10];
        private Tile[,] closedList;
        private Tile[,] openList;
        private int tileXPosition = 4;
        private int tileYPosition = 9;
        private Tile[] path = new Tile[0];
        private Vector2 direction;
        private float speed = 5;
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

            position = GameWorld.MapArray[4, 9].Position;
            currentNode = GameWorld.MapArray[4, 9].Node;
        }

        public int[,] Pathfinding { get => pathfinding; set => pathfinding = value; }
        public Tile[,] ClosedList { get => closedList; set => closedList = value; }
        public Tile[,] OpenList { get => openList; set => openList = value; }
        public Tile[,] ShopperMap { get => shopperMap; set => shopperMap = value; }
        public int TileXPosition { get => tileXPosition; set => tileXPosition = value; }
        public int TileYPosition { get => tileYPosition; set => tileYPosition = value; }
        public Node CurrentNode { get => currentNode; set => currentNode = value; }
        public Tile[] Path { get => path; set => path = value; }

        public void Update(GameTime gameTime)
        {
            if (path.Length > 0)
            {

                if (Vector2.Distance(path[0].Position, position) < 2)
                {
                    position = path[0].Position;
                }
                else
                {
                    direction = path[0].Position - position;
                    direction.Normalize();
                    position += direction * speed;

                }

                //Move to spot if close to spot
                if (Math.Abs(position.X - path[0].Position.X) < 0.5f && Math.Abs(position.Y - path[0].Position.Y) < 0.5f)
                {
                    position = path[0].Position;
                    currentNode = path[0].Node;
                    GameWorld.Dequeue(ref path);
                }
            }
            else if (path.Length <= 0)
            {
                if (shoppingList.Length > 0)
                {
                    Tile.GenerateHValue(this, shoppingList[0].BuyItem);
                }
                else
                {
                    GetNewShoppingList();
                    Tile.GenerateHValue(this, shoppingList[0].BuyItem);
                }
                CalculatePath(shoppingList[0]);
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, new Vector2(position.X + sprite.Width * 0.5f, position.Y + sprite.Height * 0.5f), color);
        }

        private void GetNewShoppingList()
        {
            Random rng = new Random();
            for (int i = 0; i < 3; i++)
            {
                GameWorld.Enqueue(ref shoppingList, ref GameWorld.buyingSpots[rng.Next(0, 6)]);
            }

            GameWorld.Enqueue(ref shoppingList, ref GameWorld.buyingSpots[6]);
        }

        public void CalculatePath(Tile targetTile)
        {
            int currentGValue = 10;
            int tempTileX = TileXPosition;
            int tempTileY = TileYPosition;
            bool pathing = true;

            Tile[] newPath = new Tile[0]; //Path array
            Tile workaroundTile = CurrentNode.Tile;
            GameWorld.Enqueue(ref newPath, ref workaroundTile); //Adds the customers current node to the path array
            Tile smallestHTile;


            while (pathing == true)
            {

               
                smallestHTile = new Tile(10000);



                for (int i = 0; i < newPath[newPath.Length - 1].Node.Edges.Length; i++) //Goes through all the edges of the the last node in the path array
                {
                    if (newPath[newPath.Length - 1].Node.Edges[i] != null && newPath[newPath.Length - 1].Node.Edges[i].Child.Tile.HValue < smallestHTile.HValue) //Makes sure the current edge isn't null. Compares HValues of the current edge's child's tile and the currently lowest HValue tile found
                    {
                        if (newPath[newPath.Length - 1].Node.Edges[i] != null && !newPath.Contains(newPath[newPath.Length - 1].Node.Edges[i].Child.Tile))
                        {
                            smallestHTile = newPath[newPath.Length - 1].Node.Edges[i].Child.Tile; //Assigns the lower tile to the smallestHTile reference
                        }
                       
                    }
                }

                GameWorld.Enqueue(ref newPath, ref smallestHTile); //Adds the found tile with the smallest HValues to the path array
                smallestHTile = new Tile(10000);

                //Step 1: If within 1 tile of goal, enter goal
                if (targetTile == newPath[newPath.Length - 1])
                {
                    pathing = false;
                    path = new Tile[newPath.Length];
                    path = newPath;

                    if (shoppingList.Length > 3 && shoppingList[1].BuyItem == shoppingList[2].BuyItem)
                    {
                        GameWorld.Dequeue(ref shoppingList);
                    }

                    if (shoppingList.Length > 2 && shoppingList[0].BuyItem == shoppingList[1].BuyItem)
                    {
                        GameWorld.Dequeue(ref shoppingList);
                    }

                    GameWorld.Dequeue(ref shoppingList);
                }

            }
        }
    }
}
