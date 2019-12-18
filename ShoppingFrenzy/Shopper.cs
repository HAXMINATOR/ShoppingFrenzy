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

        public Shopper()
        {

        }

        public Shopper(string spriteName, ContentManager content) : base(spriteName, content)
        {
            Random rng = new Random();
            for (int i = 0; i < 3; i++)
            {
                shoppingList[i] = Tile.BuyAbles[rng.Next(0, Tile.BuyAbles.Length - 1)];
            }

            for (int i = 0; i < 10; i++)
            {
                for (int k = 0; k < 10; k++)
                {
                    ShopperMap[i, k] = GameWorld.MapArray[i, k];
                }
            }
        }

        public int[,] Pathfinding { get => pathfinding; set => pathfinding = value; }
        public Tile[,] ClosedList { get => closedList; set => closedList = value; }
        public Tile[,] OpenList { get => openList; set => openList = value; }
        public Tile[,] ShopperMap { get => shopperMap; set => shopperMap = value; }
        public int TileXPosition { get => tileXPosition; set => tileXPosition = value; }
        public int TileYPosition { get => tileYPosition; set => tileYPosition = value; }

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
                    if (!wedge.Child.Discovered && wedge != null)
                    {
                        GameWorld.Enqueue(ref edgeQueue, ref wedge.Child.Edges[i]);
                        wedge.Child.Discovered = true;
                        wedge.Parent = edge.Child;
                    }
                }
            }
        }
    }
}
