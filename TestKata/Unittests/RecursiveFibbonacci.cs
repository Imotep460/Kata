using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestKata.Unittests
{
    /// <summary>
    /// In mathematical terms, the sequence f(n) of fibonacci numbers is defined by the recurrence relation
    /// f(n) = f(n-1) + f(n-2)
    /// with seed values
    /// f(1) = 1 and f(2) = 1
    /// #Your task
    /// You have to create the function fibonacci that receives n and returns f(n). You have to use recursion.
    /// </summary>
    [TestClass]
    public class RecursiveFibbonacci
    {
        public int RecursiveFibonacci1(int n)
        {
            if (n < 2)
            {
                return n;
            }
            else
            {
                return RecursiveFibonacci1(n - 1) + RecursiveFibonacci1(n - 2);
            }
        }

        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(1, RecursiveFibonacci1(1));
            Assert.AreEqual(1, RecursiveFibonacci1(2));
            Assert.AreEqual(2, RecursiveFibonacci1(3));
            Assert.AreEqual(3, RecursiveFibonacci1(4));
            Assert.AreEqual(5, RecursiveFibonacci1(5));
            Assert.AreEqual(8, RecursiveFibonacci1(6));
            Assert.AreEqual(13, RecursiveFibonacci1(7));
            Assert.AreEqual(21, RecursiveFibonacci1(8));
            Assert.AreEqual(34, RecursiveFibonacci1(9));
            Assert.AreEqual(55, RecursiveFibonacci1(10));
            Assert.AreEqual(89, RecursiveFibonacci1(11));
            Assert.AreEqual(144, RecursiveFibonacci1(12));
            Assert.AreEqual(233, RecursiveFibonacci1(13));
            Assert.AreEqual(377, RecursiveFibonacci1(14));
            Assert.AreEqual(610, RecursiveFibonacci1(15));
        }
    }
}
