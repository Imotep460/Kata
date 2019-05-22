using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestKata.Unittests
{
    //Description:
    //Upon arriving at an interview, you are presented with a solid blue cube.The cube is then dipped in red paint, coating the entire surface of the cube.The interviewer then proceeds to cut through the cube in all three dimensions a certain number of times.
    //The number of times that the cube is cut in each dimension --> the argument 'cuts'.
    //To solve the puzzle you must create a function that returns an integer representing the total number of small cubes with at least one red side.

    [TestClass]
    public class CountSurfaceCubes
    {
        public static int CountSquares(int n)
        {
            // Selution 1:
            //int x = n + 1;
            //int y = n + 1;
            //int z = n + 1;
            //int cubes1 = 0;
            //int cubes2 = 0;
            //int cubes3 = 0;
            //int cubestotal = 1;
            //if (n > 1)
            //{
            //    cubes1 = 2 * x * y;
            //    z = z - 2;
            //    cubestotal = cubes1;
            //    if (z > 1)
            //    {
            //        cubes2 = 2 * y * z;
            //        y = y - 2;
            //        cubestotal = cubes1 + cubes2;
            //    }
            //    if (y > 1)
            //    {
            //        cubes3 = 2 * y * z;
            //        cubestotal = cubes1 + cubes2 + cubes3;
            //    }
            //    else
            //    {
            //        cuts = cubestotal;
            //        return cubestotal;
            //    }
            //}
            //return cubestotal;

            //Selution 2:
            //return n == 0 ? 1 : 6 * n * n + 2;

            //Selution 3:
            return n < 1 ? 1 : (int)(Math.Pow(++n, 3) - Math.Pow(n - 2, 3));
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
