using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestKata.Unittests
{
    /// <summary>
    /// In mathematics, the factorial of a non-negative integer n, denoted by n!, is the product of all positive integers less than or equal to n. For example,
    /// 
    /// 5! = 5 * 4 * 3 * 2 * 1 = 120.
    /// The value of 0! is 1.
    /// #Your task
    /// You have to create the function factorial that receives n and returns n!. You have to use recursion.
    /// </summary>
 

    [TestClass]
    public class Recursion
    {
        
        public ulong Recursion1(ulong n)
        {
            checked
            {
                if (n <= 0)
                {
                    return 1;
                }
                return n * Recursion1(n - 1);
            }
        }
        public ulong Recursion2(ulong n)
        {
            checked
            {
                return n == 0 ? 1 : n * Recursion2(n - 1);
            }
        }

        public ulong Recursion3(ulong n)
        {
            checked
            {
                if (n > 1)
                    return ((ulong)n) * Recursion3(n - 1);
                else
                    return 1;
            }
        }

        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(1, (Int64)Recursion1(0));
            Assert.AreEqual(1, (Int64)Recursion1(1));
            Assert.AreEqual(2, (Int64)Recursion1(2));
            Assert.AreEqual(6, (Int64)Recursion1(3));
        }

        [TestMethod]
        public void TestMethod2()
        {
            Assert.AreEqual(1, (Int64)Recursion2(0));
            Assert.AreEqual(1, (Int64)Recursion2(1));
            Assert.AreEqual(2, (Int64)Recursion2(2));
            Assert.AreEqual(6, (Int64)Recursion2(3));
        }

        [TestMethod]
        public void TestMethod3()
        {
            Assert.AreEqual(1, (Int64)Recursion3(0));
            Assert.AreEqual(1, (Int64)Recursion3(1));
            Assert.AreEqual(2, (Int64)Recursion3(2));
            Assert.AreEqual(6, (Int64)Recursion3(3));
        }
    }
}
