using System;
using System.Numerics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestKata.Unittests
{
    //The drawing shows 6 squares the sides of which have a length of 1, 1, 2, 3, 5, 8. It's easy to see that the sum of the perimeters of these squares is : 4 * (1 + 1 + 2 + 3 + 5 + 8) = 4 * 20 = 80
    //Could you give the sum of the perimeters of all the squares in a rectangle when there are n + 1 squares disposed in the same manner as in the drawing:
    //The function perimeter has for parameter n where n + 1 is the number of squares(they are numbered from 0 to n) and returns the total perimeter of all the squares.

   [TestClass]
    public class Perimeter
    {
        public static BigInteger perimeter(BigInteger n)
        {
            int f0 = 1;
            int f1 = 1;

            int peri = 0;

            for (int i = 0; i < n; i++)
            {
                int f2 = f0 + f1;
                peri += f1;
                f0 = f1;
                f1 = f2;
            }
            return 4 * (1 + peri);
        }

        [TestMethod]
        public void Test1()
        {
            Assert.AreEqual(new BigInteger(80), perimeter(new BigInteger(5)));
        }

        [TestMethod]
        public void Test2()
        {
            Assert.AreEqual(new BigInteger(216), perimeter(new BigInteger(7)));
        }
    }
}
