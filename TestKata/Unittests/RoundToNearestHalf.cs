using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestKata.Unittests
{
    /// <summary>
    /// Round any given number to the closest 0.5 step
    /// I.E.
    /// solution(4.2) = 4
    /// solution(4.3) = 4.5
    /// solution(4.6) = 4.5
    /// solution(4.8) = 5
    /// Round up if number is as close to previous and next 0.5 steps.
    /// solution(4.75) == 5
    /// </summary>
    [TestClass]
    public class RoundToNearestHalf
    {
        /// <summary>
        /// Using the subroutine "MidpointRounding.AwayFromZero" in the Math.Round method we round to nearest .5.
        /// </summary>
        /// <param name="n">The number to Round up or down.</param>
        /// <returns>Returns double of nearest .5</returns>
        public double RoundToNearestHalf0(double n)
        {
            return Math.Round((n * 2), MidpointRounding.AwayFromZero) / 2;
        }

        /// <summary>
        /// Alternate solution from codewars.
        /// </summary>
        /// <param name="n">The Number to Round.</param>
        /// <returns>Returns double of .5 nearest to input double.</returns>
        public double RoundToNearestHalf1(double n)
        {
            return (int)Math.Round(n / .5) * .5;
        }

        /// <summary>
        /// Example of linq solution.
        /// </summary>
        /// <param name="n">The number to round.</param>
        /// <returns>Returns double of .5 nearest to input double.</returns>
        public double RoundToNearestHalf2(double n) => Math.Round(n * 2) / 2;

        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(4, RoundToNearestHalf0(4.2));
            Assert.AreEqual(4.5, RoundToNearestHalf0(4.4));
            Assert.AreEqual(4.5, RoundToNearestHalf0(4.6));
            Assert.AreEqual(5, RoundToNearestHalf0(4.8));
        }

        [TestMethod]
        public void TestMethod2()
        {
            Assert.AreEqual(4, RoundToNearestHalf1(4.2));
            Assert.AreEqual(4.5, RoundToNearestHalf1(4.4));
            Assert.AreEqual(4.5, RoundToNearestHalf1(4.6));
            Assert.AreEqual(5, RoundToNearestHalf1(4.8));
        }

        [TestMethod]
        public void TestMethod3()
        {
            Assert.AreEqual(4, RoundToNearestHalf2(4.2));
            Assert.AreEqual(4.5, RoundToNearestHalf2(4.4));
            Assert.AreEqual(4.5, RoundToNearestHalf2(4.6));
            Assert.AreEqual(5, RoundToNearestHalf2(4.8));
        }
    }
}