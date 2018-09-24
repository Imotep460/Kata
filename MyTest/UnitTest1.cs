using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void FirstTest()
        {
            List<int[]> = peopleList = new List<int[]>()
            {
                new []{10,0},
                new []{3,5},
                new []{5,8}
            };
            Assert.AreEqual(5, Kata.Number(peopleList));

        }
    }
}
