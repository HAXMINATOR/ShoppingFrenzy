using System;
using Microsoft.Xna.Framework.Content;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingFrenzy;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest
    {

        [TestMethod]
        public void TestEnqueue()
        {
            int int1 = 5;
            int int2 = 2;
            int int3 = 8;
            int[] ints = new int[] { int1, int2, int3 };
            int toAdd = 3;

            int[] expectedInts = new int[] { int1, int2, int3, toAdd };

            GameWorld.Enqueue(ref ints, ref toAdd);
            
            CollectionAssert.AreEqual(expectedInts, ints);
        }

        [TestMethod]
        public void TestDequeue()
        {
            int int1 = 5;
            int int2 = 2;
            int int3 = 8;
            int[] ints = new int[] { int1, int2, int3 };

            int expectedReturnInt = int1;
            int[] expectedInts = new int[] { int2, int3 };
            int returnInt;

            returnInt = GameWorld.Dequeue(ref ints);

            Assert.AreEqual(expectedReturnInt, returnInt);
            CollectionAssert.AreEqual(expectedInts, ints);
        }

        [TestMethod]
        public void TestBreadthFirstSearch()
        {
            Shopper shopper = new Shopper();

            Tile[,] mapArray = new Tile[10, 10];

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    mapArray[i, j] = new Tile();
                    mapArray[i, j].Walkable = true;
                }
            }
            int index = 0;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    mapArray[i, j].Node = new Node();
                    mapArray[i, j].Node.Index = index;
                    index++;
                }
            }
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (j != 0) //Checks limit values
                    {
                        if (mapArray[i, j - 1].Walkable)
                        {
                            mapArray[i, j].Node.Edges[0] = new Edge(mapArray[i, j].Node, mapArray[i, j - 1].Node);
                        }
                    }
                    if (i != 0) //Checks limit values
                    {
                        if (mapArray[i - 1, j].Walkable)
                        {
                            mapArray[i, j].Node.Edges[1] = new Edge(mapArray[i, j].Node, mapArray[i - 1, j].Node);
                        }
                    }
                    if (j != 9) //Checks limit values
                    {
                        if (mapArray[i, j + 1].Walkable)
                        {
                            mapArray[i, j].Node.Edges[2] = new Edge(mapArray[i, j].Node, mapArray[i, j + 1].Node);
                        }
                    }
                    if (i != 9) //Checks limit values
                    {
                        if (mapArray[i + 1, j].Walkable)
                        {
                            mapArray[i, j].Node.Edges[3] = new Edge(mapArray[i, j].Node, mapArray[i + 1, j].Node);
                        }
                    }
                }
            }

            shopper.BreadthFirstSearch(mapArray[0, 0].Node, mapArray[9, 9].Node);

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Assert.AreEqual(true, mapArray[i, j].Node.Discovered);
                }
            }
        }
    }
}
