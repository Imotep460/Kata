using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestKata.Unittests
{
    /// <summary>
    /// When provided with a number between 0-9, return it in words.
    /// Input: "1".
    /// Output: "One".
    /// </summary>
    [TestClass]
    public class WhichNumber
    {
        /// <summary>
        /// Using a Switch statement, return a given number between 0 and 9 as words.
        /// </summary>
        /// <param name="n">The number to transform into letters.</param>
        /// <returns>Returns a string consisting of the word corrosponding to the given number.</returns>
        public string SwitchItUp(int n)
        {
            switch (n)
            {
                case 0:
                    return "Zero";
                case 1:
                    return "One";
                case 2:
                    return "Two";
                case 3:
                    return "Three";
                case 4:
                    return "Four";
                case 5:
                    return "Five";
                case 6:
                    return "Six";
                case 7:
                    return "Seven";
                case 8:
                    return "Eight";
                case 9:
                    return "Nine";
            }
            return "";
        }

        /// <summary>
        /// Use a array to return the word corrosponding to the given number.
        /// </summary>
        /// <param name="n">The number to turn into a word.</param>
        /// <returns>Returns a string consisting of the word corrosponding to the given number.</returns>
        public string SwitchItUp2(int n)
        {
            return new[] { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" }[n];
        }

        /// <summary>
        /// Using a Dictionary return a given number as a word.
        /// </summary>
        /// <param name="n">The number to turn into a word.</param>
        /// <returns>Returns a string consisting of a word corrosponding to the given number.</returns>
        public string SwitchItUp3(int n)
        {
            var dictionary = new Dictionary<int, string>()
            {
                {1, "One"},
                {2, "Two"},
                {3, "Three"},
                {4, "Four"},
                {5, "Five"},
                {6, "Six"},
                {7, "Seven"},
                {8, "Eight"},
                {9, "Nine"},
                {0, "Zero"}
            };
            return dictionary[n];
        }

        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(SwitchItUp(1), "One");
            Assert.AreEqual(SwitchItUp(3), "Three");
            Assert.AreEqual(SwitchItUp(5), "Five");
        }

        [TestMethod]
        public void TestMethod2()
        {
            Assert.AreEqual(SwitchItUp2(1), "One");
            Assert.AreEqual(SwitchItUp2(3), "Three");
            Assert.AreEqual(SwitchItUp2(5), "Five");
        }

        [TestMethod]
        public void TestMethod3()
        {
            Assert.AreEqual(SwitchItUp3(1), "One");
            Assert.AreEqual(SwitchItUp3(3), "Three");
            Assert.AreEqual(SwitchItUp3(5), "Five");
        }
    }
}