using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestKata.Unittests
{
    /// <summary>
    /// Write a program that finds the summation of every number from 1 to num. The number will always be a positive integer greater than 0.
    /// for example:
    /// summation(2) -> 3
    /// 1 + 2
    /// 
    /// Summation(8) -> 36
    /// 1 + 2 + 3 + 4 + 5 + 6 + 7 + 8
    /// </summary>


    [TestClass]
    public class Summation
    {
        public int Summation1(int num)
        {
            int sum = 0;
            return sum = (num * (num + 1)) / 2;
        }

        // Linq solution:
        public int Summation2(int num) => (num * (num + 1)) / 2;

        public int Summation3(int num)
        {
            int sum = 0;

            for (var i = 0; i <= num; i++)
            {
                sum += i;
            }

            return sum;
        }

        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(1, Summation1(1));
            Assert.AreEqual(36, Summation1(8));
            Assert.AreEqual(253, Summation1(22));
            Assert.AreEqual(5050, Summation1(100));
            Assert.AreEqual(22791, Summation1(213));
        }

        [TestMethod]
        public void TestMethod2()
        {
            Assert.AreEqual(1, Summation2(1));
            Assert.AreEqual(36, Summation2(8));
            Assert.AreEqual(253, Summation2(22));
            Assert.AreEqual(5050, Summation2(100));
            Assert.AreEqual(22791, Summation2(213));
        }

        [TestMethod]
        public void TestMethod3()
        {
            Assert.AreEqual(1, Summation3(1));
            Assert.AreEqual(36, Summation3(8));
            Assert.AreEqual(253, Summation3(22));
            Assert.AreEqual(5050, Summation3(100));
            Assert.AreEqual(22791, Summation3(213));
        }

    }
}
