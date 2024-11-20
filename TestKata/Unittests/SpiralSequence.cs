using NUnit.Framework;
using System;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;

namespace TestKata.Unittests
{
    public class SpiralSequence
    {
        public int[,] CreateSpiral0(int N)
        {
            if (N < 1)
            {
                return new int[0, 0];
            }

            int[,] spiral = new int[N, N];
            int num = 1;
            int top = 0, bottom = N - 1, left = 0, right = N - 1;

            while (top <= bottom && left <= right)
            {
                for (int i = left; i <= right; i++) spiral[top, i] = num++;
                top++;

                for (int i = top; i <= bottom; i++) spiral[i, right] = num++;
                right--;

                if (top <= bottom)
                {
                    for (int i = right; i >= left; i--) spiral[bottom, i] = num++;
                    bottom--;
                }

                if (left <= right)
                {
                    for (int i = bottom; i >= top; i--) spiral[i, left] = num++;
                    left++;
                }
            }

            return spiral;
        }

        public int[,] CreateSpiral(int N)
        {
            int x = -1, y = 0, r = 0, d = 1;
            int[,] m = new int[N, N];
            while ((d += r / (N * d - d * d / 4)) < 2 * N) m[y += (d % 4 - 1) % 2, x -= (d % 4 - 2) % 2] = ++r;
            return m;
        }

        //[Test]
        //public void TestCase0()
        //{
        //    var expected = new int[,]
        //    {
        //        { 1 }
        //    };
        //    Assert.AreEqual(expected, CreateSpiral(1));
        //}

        //[Test]
        //public void TestCase1()
        //{
        //    var expected = new int[,]
        //    {
        //        {1, 2 },
        //        {4, 3 }
        //    };
        //    Assert.AreEqual(expected, CreateSpiral(2));
        //}

        //[Test]
        //public void TestCase2()
        //{
        //    var expected = new int[,]
        //    {
        //        {1, 2, 3 },
        //        {8, 9, 4 },
        //        {7, 6, 5 }
        //    };
        //    Assert.AreEqual(expected, CreateSpiral(3));
        //}
    }
}
