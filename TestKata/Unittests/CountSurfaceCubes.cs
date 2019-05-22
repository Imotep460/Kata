using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestKata.Unittests
{

    [TestClass]
    public class CountSurfaceCubes
    {
        public static int CountSquares(int cuts)
        {
            int x = cuts + 1;
            int y = cuts + 1;
            int z = cuts + 1;
            int cubes1 = 0;
            int cubes2 = 0;
            int cubes3 = 0;
            int cubestotal = 1;
            if (cuts > 1)
            {
                cubes1 = 2 * x * y;
                z = z - 2;
                cubestotal = cubes1;
                if (z > 1)
                {
                    cubes2 = 2 * y * z;
                    y = y - 2;
                    cubestotal = cubes1 + cubes2;
                }
                if (y > 1)
                {
                    cubes3 = 2 * y * z;
                    cubestotal = cubes1 + cubes2 + cubes3;
                }
                else
                {
                    cuts = cubestotal;
                    return cubestotal;
                }
            }
            return cubestotal;
        }

        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(1, CountSurfaceCubes.CountSquares(0));
        }

        [TestMethod]
        public void TestMethod2()
        {
            Assert.AreEqual(152, CountSurfaceCubes.CountSquares(5));
        }

        [TestMethod]
        public void TestMethod3()
        {
            Assert.AreEqual(1538, CountSurfaceCubes.CountSquares(16));
        }

        [TestMethod]
        public void TestMethod4()
        {
            Assert.AreEqual(3176, CountSurfaceCubes.CountSquares(23));
        }
    }
}
