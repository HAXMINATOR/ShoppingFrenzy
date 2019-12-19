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
    }
}
