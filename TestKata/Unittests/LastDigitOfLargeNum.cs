using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Numerics;

namespace TestKata.Unittests
{
    /// <summary>
    /// Define a function that takes in two non-negative integers a and b and returns the last decimal defit of a^b.
    /// Note that a and b may be very large
    /// 
    /// For example, the last digit of 9^7 = 4782969. The last decimal digit of(2^200)^2^300, which has over 10^92 decimal degits, is 6 Also please take 0^0 to be 1.
    /// 
    /// You may assume that the input will always be valid.
    /// Examples
    /// GetLastDigit(4, 1)            // returns 4
    /// GetLastDigit(4, 2)            // returns 6
    /// GetLastDigit(9, 7)            // returns 9    
    /// GetLastDigit(10, 10000000000) // returns 0
    /// 
    /// please make the solution for C#
    /// 
    /// Link to Kata: https://www.codewars.com/kata/5511b2f550906349a70004e1/csharp
    /// </summary>
    [TestClass]
    public class LastDigitOfLargeNum
    {
        /// <summary>
        /// My solution to the Kata
        /// </summary>
        /// <param name="a">Int 1.</param>
        /// <param name="b">Int 2.</param>
        /// <returns>Returns the last digit.</returns>
        public int LastDigit0(BigInteger a, BigInteger b)
        {
            if (a == 0 && b == 0) return 1; // Define 0^0 as 1
            if (b == 0) return 1;           // Any number raised to 0 is 1
            if (a == 0) return 0;           // 0 raised to any positive power is 0

            // Get the last digit of 'a'
            int lastDigitOfA = (int)(a % 10);

            // Patterns repeat every 4 for powers
            int[] pattern = new int[4];
            pattern[0] = lastDigitOfA;
            for (int i = 1; i < 4; i++)
            {
                pattern[i] = (pattern[i - 1] * lastDigitOfA) % 10;
            }

            // Determine the effective exponent in the cycle
            BigInteger effectiveExponent = b % 4;
            int cycleIndex = (effectiveExponent == 0) ? 3 : (int)effectiveExponent - 1;

            return pattern[cycleIndex];
        }

        /// <summary>
        /// Solution from Codewars
        /// </summary>
        /// <param name="n1">int 1.</param>
        /// <param name="n2">int 2.</param>
        /// <returns>Returns the last digit of the number.</returns>
        public int LastDigit1(BigInteger a, BigInteger b)
        {
            return (int)BigInteger.ModPow(a, b, 10);
        }

        /// <summary>
        /// Solution from Codewars
        /// </summary>
        /// <param name="n1">int 1.</param>
        /// <param name="n2">int 2.</param>
        /// <returns>Returns the last digit of the number.</returns>
        public int LastDigit2(BigInteger n1, BigInteger n2) => n2 == 0 ? 1 : (int)Math.Pow((int)(n1 % 10), (int)(--n2 % 4) + 1) % 10;

        [TestMethod]
        public void TestMethod0()
        {
            Assert.AreEqual(4, LastDigit0(4, 1));
            Assert.AreEqual(6, LastDigit0(4, 2));
            Assert.AreEqual(9, LastDigit0(9, 7));
            Assert.AreEqual(0, LastDigit0(10, BigInteger.Pow(10, 10)));
            Assert.AreEqual(6, LastDigit0(BigInteger.Pow(2, 200), BigInteger.Pow(2, 300)));
            Assert.AreEqual(7, LastDigit0(BigInteger.Parse("3715290469715693021198967285016729344580685479654510946723"), BigInteger.Parse("68819615221552997273737174557165657483427362207517952651")));

            foreach (var d in Enumerable.Range(0, 9))
            {
                Assert.AreEqual(1, LastDigit0(d, 0));
            }
        }

        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(4, LastDigit1(4, 1));
            Assert.AreEqual(6, LastDigit1(4, 2));
            Assert.AreEqual(9, LastDigit1(9, 7));
            Assert.AreEqual(0, LastDigit1(10, BigInteger.Pow(10, 10)));
            Assert.AreEqual(6, LastDigit1(BigInteger.Pow(2, 200), BigInteger.Pow(2, 300)));
            Assert.AreEqual(7, LastDigit1(BigInteger.Parse("3715290469715693021198967285016729344580685479654510946723"), BigInteger.Parse("68819615221552997273737174557165657483427362207517952651")));

            foreach (var d in Enumerable.Range(0, 9))
            {
                Assert.AreEqual(1, LastDigit1(d, 0));
            }
        }

        [TestMethod]
        public void TestMethod2()
        {
            Assert.AreEqual(4, LastDigit2(4, 1));
            Assert.AreEqual(6, LastDigit2(4, 2));
            Assert.AreEqual(9, LastDigit2(9, 7));
            Assert.AreEqual(0, LastDigit2(10, BigInteger.Pow(10, 10)));
            Assert.AreEqual(6, LastDigit2(BigInteger.Pow(2, 200), BigInteger.Pow(2, 300)));
            Assert.AreEqual(7, LastDigit2(BigInteger.Parse("3715290469715693021198967285016729344580685479654510946723"), BigInteger.Parse("68819615221552997273737174557165657483427362207517952651")));

            foreach (var d in Enumerable.Range(0, 9))
            {
                Assert.AreEqual(1, LastDigit2(d, 0));
            }
        }
    }
}
