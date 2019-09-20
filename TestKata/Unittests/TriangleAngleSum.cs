using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestKata.Unittests
{

    // You are given 2 angles of a triangle, it's your job to find the third.

    [TestClass]
    public class TriangleAngleSum
    {
        public int TriangleAngleSum0(int a, int b)
        {
            if(IsValidTriangle(a, b))
            {
                return 180 - (a + b);
            }
            return -1;
        }

        public bool IsValidTriangle(int angleA, int angleB)
        {
            return (angleA + angleB) < 180;
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
        [TestMethod]
        public void TestMethod4()
        {
            Assert.AreEqual(-1, TriangleAngleSum0(90, 100));
        }
    }
}
