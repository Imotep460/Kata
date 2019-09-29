using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestKata.Unittests
{
    /// <summary>
    /// 
    /// A square of squares:
    /// You like building blocks. You especially like building blocks that are squares. And what you even like more, is to arrange them into a square of square building blocks!
    /// However, sometimes, you can't arrange them into a square. Instead, you end up with an ordinary rectangle! Those blasted things! If you just had a way to know, whether you're currently working in vain… Wait! That's it! You just have to check if your number of building blocks is a perfect square.
    /// 
    /// Task
    /// Given an integral number, determine if it's a square number:
    ///     In mathematics, a square number or perfect square is an integer that is the square of an integer; in other words, it is the product of some integer with itself.
    /// The tests will always use some integral number, so don't worry about that in dynamic typed languages.
    /// 
    /// Examples
    /// isSquare(-1) returns  false
    /// isSquare(0) returns   true
    /// isSquare(3) returns   false
    /// isSquare(4) returns   true
    /// isSquare(25) returns  true
    /// isSquare(26) returns  false
    /// 
    /// </summary>

    [TestClass]
    public class PerfectSquare
    {
        public bool PerfectSquare1(double n)
        {
            n = Math.Sqrt(n);
            bool isSquare = n % 1 == 0;
            return isSquare;
        }

        public bool PerfectSquare2(int n)
        {
            return Math.Sqrt(n) % 1 == 0;
        }

        public bool PerfectSquare3(int n)
        {
            return Math.Sqrt(n) == (int)Math.Sqrt(n);
        }

        public bool PerfectSquare4(int n)
        {
            return n < 0 ? false : Math.Sqrt(n) == Math.Round(Math.Sqrt(n));
        }

        public bool PerfectSquare5(int n) => (Math.Sqrt(n) % 1 == 0);

        public bool PerfectSquare6(int n)
        {
            return Math.Abs(Math.Sqrt(n) - (int)Math.Sqrt(n)) < double.Epsilon;
        }

        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(false, PerfectSquare1(-1));
            Assert.AreEqual(false, PerfectSquare1(3));
            Assert.AreEqual(true, PerfectSquare1(4));
            Assert.AreEqual(true, PerfectSquare1(25));
            Assert.AreEqual(false, PerfectSquare1(26));
        }

        [TestMethod]
        public void TestMethod2()
        {
            Assert.AreEqual(false, PerfectSquare2(-1));
            Assert.AreEqual(false, PerfectSquare2(3));
            Assert.AreEqual(true, PerfectSquare2(4));
            Assert.AreEqual(true, PerfectSquare2(25));
            Assert.AreEqual(false, PerfectSquare2(26));
        }

        [TestMethod]
        public void TestMethod3()
        {
            Assert.AreEqual(false, PerfectSquare3(-1));
            Assert.AreEqual(false, PerfectSquare3(3));
            Assert.AreEqual(true, PerfectSquare3(4));
            Assert.AreEqual(true, PerfectSquare3(25));
            Assert.AreEqual(false, PerfectSquare3(26));
        }

        [TestMethod]
        public void TestMethod4()
        {
            Assert.AreEqual(false, PerfectSquare4(-1));
            Assert.AreEqual(false, PerfectSquare4(3));
            Assert.AreEqual(true, PerfectSquare4(4));
            Assert.AreEqual(true, PerfectSquare4(25));
            Assert.AreEqual(false, PerfectSquare4(26));
        }

        [TestMethod]
        public void TestMethod5()
        {
            Assert.AreEqual(false, PerfectSquare5(-1));
            Assert.AreEqual(false, PerfectSquare5(3));
            Assert.AreEqual(true, PerfectSquare5(4));
            Assert.AreEqual(true, PerfectSquare5(25));
            Assert.AreEqual(false, PerfectSquare5(26));
        }

        [TestMethod]
        public void TestMethod6()
        {
            Assert.AreEqual(false, PerfectSquare6(-1));
            Assert.AreEqual(false, PerfectSquare6(3));
            Assert.AreEqual(true, PerfectSquare6(4));
            Assert.AreEqual(true, PerfectSquare6(25));
            Assert.AreEqual(false, PerfectSquare6(26));
        }
    }
}
