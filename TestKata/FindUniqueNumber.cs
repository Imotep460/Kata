using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodewarsKatas_MSTestPro
{
    /// <summary>
    /// Description:
    /// There is an array with some numbers.All numbers are equal except for one.Try to find it!
    /// 
    /// Example:
    /// findUniq([1, 1, 1, 2, 1, 1 ]) === 2
    /// findUniq([0, 0, 0.55, 0, 0 ]) === 0.55
    /// 
    /// It’s guaranteed that array contains at least 3 numbers.
    /// The tests contain some very huge arrays, so think about performance.
    /// This is the first kata in series:
    /// 
    /// Find the unique number (this kata) : https://www.codewars.com/kata/585d7d5adb20cf33cb000235
    /// Find the unique string
    /// Find The Unique
    /// </summary>
    [TestClass]
    public class FindUniqueNumber
    {
        /// <summary>
        /// Solution from Codewars.
        /// </summary>
        /// <param name="numbers">The IEnumerable list of numbers being the input.</param>
        /// <returns>Returns a number that only appears once in the input list.</returns>
        public int GetUniqueNumber0(IEnumerable<int> numbers)
        {
            return numbers.GroupBy(x => x).Single(x => x.Count() == 1).Key;
        }

        /// <summary>
        /// Solution from Codewars.
        /// </summary>
        /// <param name="numbers">The IEnumerable list of numbers being the input.</param>
        /// <returns>Returns a number that appears only once in the input list.</returns>
        public int GetUniqueNumber1(IEnumerable<int> numbers)
        {
            return numbers.First(x => numbers.Count(i => i == x) == 1);
        }

        /// <summary>
        /// Solution from codewars.
        /// </summary>
        /// <param name="numbers">The IEnumerable list of numbers being the input.</param>
        /// <returns>Returns a number that only appears once in the input list.</returns>
        public int GetUniqueNumber2(IEnumerable<int> numbers)
        {
            List<int> numbersList = numbers.ToList();
            numbersList.Sort();
            if (numbersList[0] != numbersList[1])
            {
                return numbersList[0];
            }
            return numbersList[numbersList.Count - 1];
        }

        /// <summary>
        /// Solution from codewars.
        /// </summary>
        /// <param name="numbers">The IEnumerable list of numbers being the input.</param>
        /// <returns>Returns a number that only appears once in the input list.</returns>
        public int GetUniqueNumber3(IEnumerable<int> numbers)
        {
            var num = numbers.OrderBy(x => x).ToArray();
            return num[0] != num[1] ? num.First() : num.Last();
        }

        [TestMethod]
        public void TestMethod0()
        {
            Assert.AreEqual(1, GetUniqueNumber0(new[] { 1, 2, 2, 2 }));
            Assert.AreEqual(-2, GetUniqueNumber0(new[] { -2, 2, 2, 2 }));
            Assert.AreEqual(14, GetUniqueNumber0(new[] { 11, 11, 14, 11, 11 }));
        }

        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(1, GetUniqueNumber1(new[] { 1, 2, 2, 2 }));
            Assert.AreEqual(-2, GetUniqueNumber1(new[] { -2, 2, 2, 2 }));
            Assert.AreEqual(14, GetUniqueNumber1(new[] { 11, 11, 14, 11, 11 }));
        }

        [TestMethod]
        public void TestMethod2()
        {
            Assert.AreEqual(1, GetUniqueNumber2(new[] { 1, 2, 2, 2 }));
            Assert.AreEqual(-2, GetUniqueNumber2(new[] { -2, 2, 2, 2 }));
            Assert.AreEqual(14, GetUniqueNumber2(new[] { 11, 11, 14, 11, 11 }));
        }

        [TestMethod]
        public void TestMethod3()
        {
            Assert.AreEqual(1, GetUniqueNumber3(new[] { 1, 2, 2, 2 }));
            Assert.AreEqual(-2, GetUniqueNumber3(new[] { -2, 2, 2, 2 }));
            Assert.AreEqual(14, GetUniqueNumber3(new[] { 11, 11, 14, 11, 11 }));
        }
    }
}