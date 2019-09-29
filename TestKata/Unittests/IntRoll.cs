using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestKata.Unittests
{
    /// <summary>
    /// Terminal game move function
    /// 
    /// In this game, the hero moves from left to right. The player rolls the dice and moves the number of spaces indicated by the dice two times.
    /// Create a function for the terminal game that takes the current position of the hero and the roll (1-6) and return the new position.
    /// </summary>
    

    [TestClass]
    public class IntRoll
    {
        public int IntRoll1(int position, int roll)
        {
            return position + (2 * roll);
        }

        // Linq solution
        public int IntRoll2(int position, int roll) => position + roll * 2;

        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(8, IntRoll1(0, 4));
            Assert.AreEqual(15, IntRoll1(3, 6));
            Assert.AreEqual(12, IntRoll1(2, 5));
        }

        [TestMethod]
        public void TestMethod2()
        {
            Assert.AreEqual(8, IntRoll2(0, 4));
            Assert.AreEqual(15, IntRoll2(3, 6));
            Assert.AreEqual(12, IntRoll2(2, 5));
        }
    }
}
