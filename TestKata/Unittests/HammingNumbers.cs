using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Numerics;

namespace Codewars
{
    /// <summary>
    /// Description:
    /// A Hamming number is a positive integer of the form 2i3j5k, for some non-negative integers i, j, and k.
    /// Write a function that computes the nth smallest Hamming number.
    /// Specifically:
    /// The first smallest Hamming number is 1 = 203050
    /// The second smallest Hamming number is 2 = 213050
    /// The third smallest Hamming number is 3 = 203150
    /// The fourth smallest Hamming number is 4 = 223050
    /// The fifth smallest Hamming number is 5 = 203051
    /// The 20 smallest Hamming numbers are given in example test fixture.
    /// Your code should be able to compute all of the smallest 5,000 (Clojure: 2000, NASM: 13282) Hamming numbers without timing out.
    /// 
    /// Link to the code kata:
    /// https://www.codewars.com/kata/526d84b98f428f14a60008da
    /// </summary>
    [TestClass]
    public class HammingNumbers
    {
        /// <summary>
        /// Solution from Codewars
        /// </summary>
        /// <param name="number">Number for which to find the n'th smallest hamming number.</param>
        /// <returns>Returns the smallest hamming number for a given input.</returns>
        public long HammingNumbers0(int number)
        {
            var sortedSet = new SortedSet<long>();
            sortedSet.Add(1);

            for (int i = 1; i < number; i++)
            {
                var hamming = sortedSet.First();
                sortedSet.Remove(hamming);
                sortedSet.Add(hamming * 2);
                sortedSet.Add(hamming * 3);
                sortedSet.Add(hamming * 5);
            }

            return sortedSet.First();
        }

        /// <summary>
        /// Solution from Codewars
        /// </summary>
        /// <param name="n">Number for which to find the n'th smallest hamming number.</param>
        /// <returns>Returns the smallest hamming number for a given input.</returns>
        public long HammingNumbers1(int n)
        {
            BigInteger two = 2, three = 3, five = 5;
            var h = new BigInteger[n];
            h[0] = 1;
            BigInteger x2 = 2, x3 = 3, x5 = 5;
            int i = 0, j = 0, k = 0;

            for (int index = 1; index < n; index++)
            {
                h[index] = BigInteger.Min(x2, BigInteger.Min(x3, x5));
                if (h[index] == x2) x2 = two * h[++i];
                if (h[index] == x3) x3 = three * h[++j];
                if (h[index] == x5) x5 = five * h[++k];
            }
            return (long)h[n - 1];
        }

        [TestMethod]
        public void TestMethod0()
        {
            Assert.AreEqual(1, HammingNumbers0(1), "hamming(1) should be 1");
            Assert.AreEqual(2, HammingNumbers0(2), "hamming(2) should be 2");
            Assert.AreEqual(3, HammingNumbers0(3), "hamming(3) should be 3");
            Assert.AreEqual(4, HammingNumbers0(4), "hamming(4) should be 4");
            Assert.AreEqual(5, HammingNumbers0(5), "hamming(5) should be 5");
            Assert.AreEqual(6, HammingNumbers0(6), "hamming(6) should be 6");
            Assert.AreEqual(8, HammingNumbers0(7), "hamming(7) should be 8");
            Assert.AreEqual(9, HammingNumbers0(8), "hamming(8) should be 9");
            Assert.AreEqual(10, HammingNumbers0(9), "hamming(9) should be 10");
            Assert.AreEqual(12, HammingNumbers0(10), "hamming(10) should be 12");
            Assert.AreEqual(15, HammingNumbers0(11), "hamming(11) should be 15");
            Assert.AreEqual(16, HammingNumbers0(12), "hamming(12) should be 16");
            Assert.AreEqual(18, HammingNumbers0(13), "hamming(13) should be 18");
            Assert.AreEqual(20, HammingNumbers0(14), "hamming(14) should be 20");
            Assert.AreEqual(24, HammingNumbers0(15), "hamming(15) should be 24");
            Assert.AreEqual(25, HammingNumbers0(16), "hamming(16) should be 25");
            Assert.AreEqual(27, HammingNumbers0(17), "hamming(17) should be 27");
            Assert.AreEqual(30, HammingNumbers0(18), "hamming(18) should be 30");
            Assert.AreEqual(32, HammingNumbers0(19), "hamming(19) should be 32");
        }

        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(1, HammingNumbers1(1), "hamming(1) should be 1");
            Assert.AreEqual(2, HammingNumbers1(2), "hamming(2) should be 2");
            Assert.AreEqual(3, HammingNumbers1(3), "hamming(3) should be 3");
            Assert.AreEqual(4, HammingNumbers1(4), "hamming(4) should be 4");
            Assert.AreEqual(5, HammingNumbers1(5), "hamming(5) should be 5");
            Assert.AreEqual(6, HammingNumbers1(6), "hamming(6) should be 6");
            Assert.AreEqual(8, HammingNumbers1(7), "hamming(7) should be 8");
            Assert.AreEqual(9, HammingNumbers1(8), "hamming(8) should be 9");
            Assert.AreEqual(10, HammingNumbers1(9), "hamming(9) should be 10");
            Assert.AreEqual(12, HammingNumbers1(10), "hamming(10) should be 12");
            Assert.AreEqual(15, HammingNumbers1(11), "hamming(11) should be 15");
            Assert.AreEqual(16, HammingNumbers1(12), "hamming(12) should be 16");
            Assert.AreEqual(18, HammingNumbers1(13), "hamming(13) should be 18");
            Assert.AreEqual(20, HammingNumbers1(14), "hamming(14) should be 20");
            Assert.AreEqual(24, HammingNumbers1(15), "hamming(15) should be 24");
            Assert.AreEqual(25, HammingNumbers1(16), "hamming(16) should be 25");
            Assert.AreEqual(27, HammingNumbers1(17), "hamming(17) should be 27");
            Assert.AreEqual(30, HammingNumbers1(18), "hamming(18) should be 30");
            Assert.AreEqual(32, HammingNumbers1(19), "hamming(19) should be 32");
        }
    }
}