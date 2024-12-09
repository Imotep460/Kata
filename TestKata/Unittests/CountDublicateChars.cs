using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Numerics;
using System.Linq;

namespace TestKata.Unittests
{
    /// <summary>
    /// 
    /// Count the number of Duplicates:
    /// Write a function that will return the count of distinct case-insensitive alphabetic characters and numeric digits that occur more than once in the input string.
    /// The input string can be assumed to contain only alphabets(both uppercase and lowercase) and numeric digits.
    /// 
    /// Example
    /// "abcde" -> 0 # no characters repeats more than once
    /// "aabbcde" -> 2 # 'a' and 'b'
    /// "aabBcde" -> 2 # 'a' occurs twice and 'b' twice (`b` and `B`)
    /// "indivisibility" -> 1 # 'i' occurs six times
    /// "Indivisibilities" -> 2 # 'i' occurs seven times and 's' occurs twice
    /// "aA11" -> 2 # 'a' and '1'
    /// "ABBA" -> 2 # 'A' and 'B' each occur twice
    /// 
    /// Link to Kata: https://www.codewars.com/kata/54bf1c2cd5b56cc47f0007a1/csharp
    /// </summary>
    [TestClass]
    public class CountDublicateChars
    {
        /// <summary>
        /// My own solution
        /// </summary>
        /// <param name="input">The string to run the algoritme on.</param>
        /// <returns>Returns an integer inditating the number of letters that ovvur more than once,</returns>
        public int DuplicateCount0(string input)
        {
            // Convert the string to lowercase to make it case-insensitive
            string lowerInput = input.ToLower();

            // Group the characters, count their occurrences, and filter those with count > 1
            var duplicateCount = lowerInput
              .GroupBy(c => c) // Group by each character
              .Where(group => group.Count() > 1) // Filter groups with more than 1 occurrence
              .Count(); // Count the number of such groups

            return duplicateCount;
        }

        /// <summary>
        /// Solution from Codewars
        /// </summary>
        /// <param name="str">The string to run the algoritme on.</param>
        /// <returns>Returns an integer inditating the number of letters that ovvur more than once,</returns>
        public int DuplicateCount1(string str)
        {
            return str.ToLower().GroupBy(c => c).Where(g => g.Count() > 1).Count();
        }

        /// <summary>
        /// Solution from Codewars
        /// </summary>
        /// <param name="str">The string to run the algoritme on.</param>
        /// <returns>Returns an integer inditating the number of letters that ovvur more than once,</returns>
        public int DuplicateCount2(string str)
        {
            int count = 0;
            str = str.ToLower();

            for (int i = 0; i < str.Length; i++)
            {
                if (str.Split(str[i]).Length - 1 > 1)
                {
                    str = str.Replace(str[i].ToString(), string.Empty);
                    i--;
                    count++;
                }
            }

            return count;
        }

        [TestMethod]
        public void TestMethod0()
        {
            Assert.AreEqual(0, DuplicateCount0(""));
            Assert.AreEqual(0, DuplicateCount0("abcde"));
            Assert.AreEqual(2, DuplicateCount0("aabbcde"));
            Assert.AreEqual(2, DuplicateCount0("aabBcde")); // Should ignore Case
            Assert.AreEqual(1, DuplicateCount0("Indivisibility"));
            Assert.AreEqual(2, DuplicateCount0("Indivisibilities")); // Characters may not be adjacent
        }

        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(0, DuplicateCount1(""));
            Assert.AreEqual(0, DuplicateCount1("abcde"));
            Assert.AreEqual(2, DuplicateCount1("aabbcde"));
            Assert.AreEqual(2, DuplicateCount1("aabBcde")); // Should ignore Case
            Assert.AreEqual(1, DuplicateCount1("Indivisibility"));
            Assert.AreEqual(2, DuplicateCount1("Indivisibilities")); // Characters may not be adjacent
        }

        [TestMethod]
        public void TestMethod2()
        {
            Assert.AreEqual(0, DuplicateCount2(""));
            Assert.AreEqual(0, DuplicateCount2("abcde"));
            Assert.AreEqual(2, DuplicateCount2("aabbcde"));
            Assert.AreEqual(2, DuplicateCount2("aabBcde")); // Should ignore Case
            Assert.AreEqual(1, DuplicateCount2("Indivisibility"));
            Assert.AreEqual(2, DuplicateCount2("Indivisibilities")); // Characters may not be adjacent
        }
    }
}
