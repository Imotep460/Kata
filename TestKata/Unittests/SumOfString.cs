using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text.RegularExpressions;

namespace TestKata.Unittests
{
    /// <summary>
    /// Description:
    /// Given the string representations of two integers, return the string representation of the sum of those integers.
    /// 
    /// For example:
    /// sumStrings('1','2') // => '3'
    /// 
    /// A string representation of an integer will contain no characters besides the ten numerals "0" to "9".
    /// I have removed the use of BigInteger and BigDecimal in java
    /// Python: your solution need to work with huge numbers(about a milion digits), converting to int will not work.
    /// 
    /// Link to Kata: https://www.codewars.com/kata/5324945e2ece5e1f32000370/csharp
    /// </summary>
    [TestClass]
    public class SumOfString
    {
        /// <summary>
        /// My own solution
        /// </summary>
        /// <param name="a">First string to parse</param>
        /// <param name="b">Second string to parse</param>
        /// <returns>Returns a string representing the sum of string a and string b.</returns>
        public string SumStrings0(string a, string b)
        {
            BigInteger valueA, valueB; // Setup fields for string a & string b to be parsed into.

            if (!BigInteger.TryParse(a, out valueA))
            {
                valueB = 0; // If unable to parse "a" cast it as 0
            }
            if (!BigInteger.TryParse(b, out valueB))
            {
                valueA = 0; // If unable to parse "b" cast it as 0
            }

            return (valueA + valueB).ToString(); // Add the parsed values together and convert the result back into a string.
        }

        /// <summary>
        /// Solution from Codewars
        /// </summary>
        /// <param name="numbers">Array of input numbers.</param>
        /// <returns>Returns a string with all the numbers added together.</returns>
        public static string SumStrings1(params string[] numbers)
        {
            return numbers
              .Select(s => String.IsNullOrEmpty(s)
                ? BigInteger.Zero
                : BigInteger.Parse(s)).Aggregate((a, b) => a + b)
              .ToString();
        }

        /// <summary>
        /// Solution from Codewars
        /// </summary>
        /// <param name="a">First string to parse</param>
        /// <param name="b">Second string to parse</param>
        /// <returns>Returns a string representing the sum of string a and string b.</returns>
        public static string SumStrings2(string a, string b)
        {
            return (int.Parse(a) + int.Parse(b)).ToString();
        }

        /// <summary>
        /// Regex solution from Codewars
        /// </summary>
        /// <param name="a">First string to parse</param>
        /// <param name="b">Second string to parse</param>
        /// <returns>Returns a string representing the sum of string a and string b.</returns>
        public static string SumStrings3(string a, string b)
        {
            var res = "";
            var c = 0;
            var aChars = new Stack<char>(a.ToCharArray());
            var bChars = new Stack<char>(b.ToCharArray());
            while (aChars.Count + bChars.Count + c > 0)
            {
                c += (aChars.Count > 0 ? (aChars.Pop() - '0') : 0) +
                    (bChars.Count > 0 ? (bChars.Pop() - '0') : 0);
                res = c % 10 + res;
                c /= 10;
            }
            return new Regex("^0").Replace(res, "");
        }

        [TestMethod]
        public void TestMethod0()
        {
            Assert.AreEqual("579", SumStrings0("123", "456"));
        }

        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual("579", SumStrings1("123", "456"));
        }

        [TestMethod]
        public void TestMethod2()
        {
            Assert.AreEqual("579", SumStrings2("123", "456"));
        }

        [TestMethod]
        public void TestMethod3()
        {
            Assert.AreEqual("579", SumStrings3("123", "456"));
        }
    }
}
