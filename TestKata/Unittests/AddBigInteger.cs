using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TestKata.Unittests
{
    /// <summary>
    /// We need to sum big numbers and we require your help.
    /// Write a function that returns the sum of two numbers.
    /// The input numbers are strings and the function must return a string.
    /// 
    /// Example
    /// add("123", "321"); -> "444"
    /// add("11", "99");   -> "110"
    /// 
    /// Notes:
    /// * The input numbers are big.
    /// * The input is a string of only digits
    /// * The numbers are positives
    /// 
    /// Link til Kata: https://www.codewars.com/kata/525f4206b73515bffb000b21/csharp
    /// </summary>
    [TestClass]
    public class AddBigInteger
    {
        /// <summary>
        /// Takes input of 2 strings and converts them to BigIntegers, adds them together, and them returns the result as a string.
        /// </summary>
        /// <param name="a">String 1.</param>
        /// <param name="b">String 2.</param>
        /// <returns>Returns the sum of 2 strings converted to BigIntegers.</returns>
        public string Add0(string a, string b)
        {
            return BigInteger.Add(BigInteger.Parse(a), BigInteger.Parse(b)).ToString();
        }

        /// <summary>
        /// Linq version of my solution.
        /// </summary>
        /// <param name="a">String 1.</param>
        /// <param name="b">String 2.</param>
        /// <returns>Returns the sum of 2 strings converted to BigIntegers.</returns>
        public string Add1(string a, string b) =>
            BigInteger.Add(
                BigInteger.Parse(a),
                BigInteger.Parse(b)
                ).ToString();

        /// <summary>
        /// Solution not using BigInteger.
        /// </summary>
        /// <param name="a">String 1.</param>
        /// <param name="b">String 2.</param>
        /// <returns>Returns the sum of 2 strings converted to BigIntegers.</returns>
        public string Add2(string a, string b)
        {
            var maxLength = Math.Max(a.Length, b.Length);
            var stack = new Stack<char>();
            var remainder = 0;
            for (var i = 1; i <= maxLength; i++)
            {
                var digit1 = (a.Length >= i ? a[a.Length - i] : '0') - '0';
                var digit2 = (b.Length >= i ? b[b.Length - i] : '0') - '0';
                var sum = digit1 + digit2 + remainder;
                stack.Push((char)('0' + (sum % 10)));
                remainder = sum / 10;
            }
            if (remainder > 0)
                stack.Push(remainder.ToString()[0]);
            return new string(stack.ToArray());
        }

        /// <summary>
        /// Another solution not relying on BigInteger.
        /// </summary>
        /// <param name="a">String 1.</param>
        /// <param name="b">String 2.</param>
        /// <returns>Returns the sum of 2 strings converted to BigIntegers.</returns>
        public string Add3(string a, string b)
        {
            var reverseResult = new StringBuilder();
            int aLength = a.Length, bLength = b.Length, length = aLength > bLength ? aLength : bLength, carry = 0;
            a = a.PadLeft(length, '0');
            b = b.PadLeft(length, '0');

            for (var index = length - 1; index >= 0; index--)
            {
                var sum = carry + a[index] - 48 + b[index] - 48;
                reverseResult.Append(sum % 10);
                carry = sum / 10;
            }

            if (carry > 0)
            {
                reverseResult.Append(1);
            }

            var result = reverseResult.ToString().ToCharArray();

            Array.Reverse(result);

            return String.Join(String.Empty, result);
        }

        [TestMethod]
        public void TestMethod0()
        {
            Assert.AreEqual("110", Add0("91", "19"));
            Assert.AreEqual("1111111111", Add0("123456789", "987654322"));
            Assert.AreEqual("1000000000", Add0("999999999", "1"));
        }

        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual("110", Add1("91", "19"));
            Assert.AreEqual("1111111111", Add1("123456789", "987654322"));
            Assert.AreEqual("1000000000", Add1("999999999", "1"));
        }

        [TestMethod]
        public void TestMethod2()
        {
            Assert.AreEqual("110", Add2("91", "19"));
            Assert.AreEqual("1111111111", Add2("123456789", "987654322"));
            Assert.AreEqual("1000000000", Add2("999999999", "1"));
        }

        [TestMethod]
        public void TestMethod3()
        {
            Assert.AreEqual("110", Add3("91", "19"));
            Assert.AreEqual("1111111111", Add3("123456789", "987654322"));
            Assert.AreEqual("1000000000", Add3("999999999", "1"));
        }
    }
}
