using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestKata.Unittests
{
    /// <summary>
    /// You are given 2 angles of a triangle, it's your job to find the third.
    /// </summary>
    [TestClass]
    public class TriangleAngleSum
    {
        public int TriangleAngleSum0(int a, int b)
        {
            return 180 - (a + b);
        }

        [TestMethod]
        public void TestMethod()
        {
            Assert.AreEqual(90, TriangleAngleSum0(30, 60));
        }
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(60, TriangleAngleSum0(60, 60));
        }
        [TestMethod]
        public void TestMethod2()
        {
            Assert.AreEqual(59, TriangleAngleSum0(43, 78));
        }
        [TestMethod]
        public void TestMethod3()
        {
            Assert.AreEqual(150, TriangleAngleSum0(10, 20));
        }
    }
}
