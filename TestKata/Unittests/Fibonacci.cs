using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestKata.Unittests
{
    /// <summary>
    /// I love Fibonacci numbers in general, but I must admit I love some more than others.
    /// I would like for you to write me a function that when given a number(n) returns the n-th number in the Fibonacci Sequence.
    /// 
    /// For example:
    /// 
    /// Fib(4) = 2
    /// 
    /// Because "2" is the 4th number in the Fibonacci Sequence.
    /// For reference, the first two numbers in the Fibonacci sequence are 0 and 1, and each subsequent number is the sum of the previous two.
    /// </summary>
    [TestClass]
    public class Fibonacci
    {
        /// <summary>
        /// My solution.
        /// </summary>
        /// <param name="n">The number in the fibonacci you wanna find.</param>
        /// <returns>The n-th number in a fibonacci sequence.</returns>
        public int Fib(int n)
        {
            int a = 0;
            int b = 1;
            int c = 0;

            if (n < 2)
            {
                return c = 0;
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    c = a + b;
                    a = b;
                    b = c;
                }
                return b - a;
            }
        }

        public int Fib2(int n)
        {
            if (n == 1) return 0;
            if (n == 2) return 1;
            return Fib2(n - 2) + Fib2(n - 1);
        }

        public int Fib3(int n)
        {
            return n == 1 ? 0 : n <= 3 ? 1 : Fib3(n - 2) + Fib3(n - 1);
        }

        public int Fib4(int n)
        {
            var phi = (1 + Math.Sqrt(5)) / 2;
            return (int)Math.Round(Math.Pow(phi, n - 1) / Math.Sqrt(5));
        }

        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(0, Fib(1));
            Assert.AreEqual(1, Fib(2));
            Assert.AreEqual(1, Fib(3));
            Assert.AreEqual(2, Fib(4));
            Assert.AreEqual(13, Fib2(8));
        }

        [TestMethod]
        public void TestMethod2()
        {
            Assert.AreEqual(0, Fib2(1));
            Assert.AreEqual(1, Fib2(2));
            Assert.AreEqual(1, Fib2(3));
            Assert.AreEqual(2, Fib2(4));
            Assert.AreEqual(13, Fib2(8));
        }

        [TestMethod]
        public void TestMethod3()
        {
            Assert.AreEqual(0, Fib3(1));
            Assert.AreEqual(1, Fib3(2));
            Assert.AreEqual(1, Fib3(3));
            Assert.AreEqual(2, Fib3(4));
            Assert.AreEqual(13, Fib3(8));
        }

        [TestMethod]
        public void TestMethod4()
        {
            Assert.AreEqual(0, Fib4(1));
            Assert.AreEqual(1, Fib4(2));
            Assert.AreEqual(1, Fib4(3));
            Assert.AreEqual(2, Fib4(4));
            Assert.AreEqual(13, Fib4(8));
        }
    }
}
