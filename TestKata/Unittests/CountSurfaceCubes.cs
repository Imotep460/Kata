﻿using System;
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
        public static int CountSquares0(int n)
        {
            //Selution 1:
            int x = n + 1;
            int y = n + 1;
            int z = n + 1;
            int cubesFrontAndBack = 0;
            int cubesSides = 0;
            int cubesTopAndBottom = 0;
            int cubestotal = 1;
            if (n > 1)
            {
                cubesFrontAndBack = 2 * x * y;
                z = z - 2;
                cubestotal = cubesFrontAndBack;
                if (z > 1)
                {
                    cubesSides = 2 * y * z;
                    y = y - 2;
                    cubestotal = cubesFrontAndBack + cubesSides;
                }
                if (y > 1)
                {
                    cubesTopAndBottom = 2 * y * z;
                    cubestotal = cubesFrontAndBack + cubesSides + cubesTopAndBottom;
                }
                else
                {
                    n = cubestotal;
                    return cubestotal;
                }
            }
            return cubestotal;
        }

        //Solution 2:
        public static int CountSquares1(int n2)
        {
            return n2 < 1 ? 1 : (int)(Math.Pow(++n2, 3) - Math.Pow(n2 - 2, 3));
        }

        //Solution 3:
        public static int CountSquares2(int n3)
        {
            return n3 == 0 ? 1 : 6 * n3 * n3 + 2;
        }

        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(1, CountSquares0(0));
            Assert.AreEqual(1, CountSquares1(0));
            Assert.AreEqual(1, CountSquares2(0));
        }

        [TestMethod]
        public void TestMethod2()
        {
            Assert.AreEqual(152, CountSquares0(5));
            Assert.AreEqual(152, CountSquares1(5));
            Assert.AreEqual(152, CountSquares2(5));
        }

        [TestMethod]
        public void TestMethod3()
        {
            Assert.AreEqual(1538, CountSquares0(16));
            Assert.AreEqual(1538, CountSquares1(16));
            Assert.AreEqual(1538, CountSquares2(16));
        }

        [TestMethod]
        public void TestMethod4()
        {
            Assert.AreEqual(3176, CountSquares0(23));
            Assert.AreEqual(3176, CountSquares1(23));
            Assert.AreEqual(3176, CountSquares2(23));
        }

        [TestMethod]
        public void TestMethod5()
        {
            Assert.AreEqual(56, CountSquares0(3));
            Assert.AreEqual(56, CountSquares1(3));
            Assert.AreEqual(56, CountSquares2(3));
        }

        [TestMethod]
        public void TestMethod6()
        {
            Assert.AreEqual(60002, CountSquares0(100));
            Assert.AreEqual(60002, CountSquares1(100));
            Assert.AreEqual(60002, CountSquares2(100));
        }

        [TestMethod]
        public void TestMethod7()
        {
            Assert.AreEqual(15002, CountSquares0(50));
            Assert.AreEqual(15002, CountSquares1(50));
            Assert.AreEqual(15002, CountSquares2(50));
        }
    }
}
