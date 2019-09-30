using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace TestKata.Unittests
{
    /// <summary>
    /// If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. The sum of these multiples is 23
    /// Finish the solution so that it returns the sum of all the multiples of 3 or 5 below the number passed in.
    /// Note: If the number is a multiple of both 3 and 5, only count it once
    /// </summary>

    [TestClass]
    public class SumOfMultiples
    {
        // My solution
        public int SumOfMultiples1(int n)
        {
            int sum = 0;
            for (int i = 3; i < n; i++)
            {
                if (i % 3 == 0 || i % 5 == 0)
                {
                    sum += i;
                }
            }
            return sum;
        }

        // using System.Linq;
        public int SumOfMultiples2(int value)
        {
            return Enumerable.Range(0, value).Where(e => e % 3 == 0 || e % 5 == 0).Sum();
        }

        public int SumOfMultiples3(int value)
        {
            return Enumerable.Range(0, value)
                .Where(x => x % 3 == 0 || x % 5 == 0)
                .Sum();
        }

        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(23, SumOfMultiples1(10));
            Assert.AreEqual(233168, SumOfMultiples1(1000));
        }

        [TestMethod]
        public void TestMethod2()
        {
            Assert.AreEqual(23, SumOfMultiples2(10));
            Assert.AreEqual(233168, SumOfMultiples2(1000));
        }

        [TestMethod]
        public void TestMethod3()
        {
            Assert.AreEqual(23, SumOfMultiples3(10));
            Assert.AreEqual(233168, SumOfMultiples3(1000));
        }
    }
}
