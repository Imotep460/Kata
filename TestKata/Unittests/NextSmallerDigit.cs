using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace TestKata.Unittests
{
    /// <summary>
    /// Write a function that takes a positive integer and returns the next smaller positive integer containing the same digits.
    /// 
    /// For example:
    /// 
    /// nextSmaller(21) == 12
    /// nextSmaller(531) == 513
    /// nextSmaller(2071) == 2017
    /// 
    /// Return -1 (for Haskell: return Nothing, for Rust: return None),
    /// when there is no smaller number that contains the same digits.Also return -1,
    /// when the next smaller number with the same digits would require the leading digit to be zero.
    /// 
    /// nextSmaller(9) == -1
    /// nextSmaller(111) == -1
    /// nextSmaller(135) == -1
    /// nextSmaller(1027) == -1 // 0721 is out since we don't write numbers with leading zeros
    /// 
    /// Some tests will include very large numbers.
    /// Test data only employs positive integers.
    /// 
    /// The function you write for this challenge is the inverse of this kata: "Next bigger number with the same digits."
    /// 
    /// Link to Kata: https://www.codewars.com/kata/5659c6d896bc135c4c00021e/csharp
    /// </summary>
    [TestClass]
    public class NextSmallerDigit
    {
        /// <summary>
        /// My own solution
        /// </summary>
        /// <param name="number">Number to work with</param>
        /// <returns>Returns the next number to include all numbers from the input number.</returns>
        public long NextSmallerDigit0(long number)
        {
            char[] digits = number.ToString().ToCharArray();
            int length = digits.Length;
            
            // Step 1: Find the pivot
            int pivot = -1;
            for (int i = length - 2; i >= 0; i--)
            {
                if (digits[i] > digits[i + 1])
                {
                    pivot = i;
                    break;
                }
            }
            
            // If no pivot found, return -1 as no smaller number is possible
            if (pivot == -1) return -1;
            
            // Step 2: Find the largest digit to the right of the pivot that is smaller than pivot
            int largestSmallerIndex = -1;
            for (int i = length - 1; i > pivot; i--)
            {
                if (digits[i] < digits[pivot])
                {
                    if (largestSmallerIndex == -1 || digits[i] > digits[largestSmallerIndex])
                    {
                        largestSmallerIndex = i;
                    }
                }
            }
            
            // Step 3: Swap the pivot with the largest smaller digit
            Swap(ref digits[pivot], ref digits[largestSmallerIndex]);

            // Step 4: Sort the rest of the digits after the pivot in descending order
            Array.Reverse(digits, pivot + 1, length - pivot - 1);
            
            // Convert the array back to a number
            long result = long.Parse(new string(digits));
            
            // Step 5: Check for leading zeros
            if (digits[0] == '0') return -1;
            
            return result;
        }
        
        /// <summary>
        /// Helper method to swap two characters
        /// </summary>
        /// <param name="a">First Char to switch place.</param>
        /// <param name="b">Second Char to switch place.</param>
        private void Swap(ref char a, ref char b)
        {
            char temp = a;
            a = b;
            b = temp;
        }

        /// <summary>
        /// Solution from Codewars
        /// </summary>
        /// <param name="number">Number to work with</param>
        /// <returns>Returns the next number to include all numbers from the input number.</returns>
        public long NextSmallerDigit1(long number)
        {
            var chars = number.ToString();
            for (var i = chars.Length - 1; i > 0; i--)
            {
                if (chars[i] < chars[i - 1])
                {
                    var right = chars.Skip(i).ToArray();
                    var next = right.Where(a => a < chars[i - 1]).Max();
                    right[Array.IndexOf(right, next)] = chars[i - 1];
                    var answer = chars.Substring(0, i - 1) + next + string.Concat(right.OrderByDescending(a => a));
                    return answer[0] == '0' ? -1 : long.Parse(answer);
                }
            }
            return -1;
        }

        /// <summary>
        /// Solution from Codewars
        /// </summary>
        /// <param name="number">Number to work with</param>
        /// <returns>Returns the next number to include all numbers from the input number.</returns>
        public long NextSmallerDigit2(long number)
        {
            if (number > 0 & (number + "").Length == 1) return -1;
            string s = number + "";
            for (int i = s.Length - 2; i >= 0; i--)
            {
                if (s.Substring(i) != string.Concat(s.Substring(i).OrderBy(x => x)))
                {
                    var t = string.Concat(s.Substring(i).OrderByDescending(x => x));
                    var c = t.First(x => x < s[i]);
                    return i == 0 & c == '0' ? -1 : long.Parse(s.Substring(0, i) + c + string.Concat(t.Where((x, y) => y != t.IndexOf(c))));
                }
            }
            return -1;
        }

        [TestMethod]
        public void TestMethod0()
        {
            Assert.AreEqual(12, NextSmallerDigit0(21));
            Assert.AreEqual(790, NextSmallerDigit0(907));
            Assert.AreEqual(513, NextSmallerDigit0(531));
            Assert.AreEqual(-1, NextSmallerDigit0(1027));
            Assert.AreEqual(414, NextSmallerDigit0(441));
            Assert.AreEqual(123456789, NextSmallerDigit0(123456798));
        }

        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(12, NextSmallerDigit1(21));
            Assert.AreEqual(790, NextSmallerDigit1(907));
            Assert.AreEqual(513, NextSmallerDigit1(531));
            Assert.AreEqual(-1, NextSmallerDigit1(1027));
            Assert.AreEqual(414, NextSmallerDigit1(441));
            Assert.AreEqual(123456789, NextSmallerDigit1(123456798));
        }

        [TestMethod]
        public void TestMethod2()
        {
            Assert.AreEqual(12, NextSmallerDigit2(21));
            Assert.AreEqual(790, NextSmallerDigit2(907));
            Assert.AreEqual(513, NextSmallerDigit2(531));
            Assert.AreEqual(-1, NextSmallerDigit2(1027));
            Assert.AreEqual(414, NextSmallerDigit2(441));
            Assert.AreEqual(123456789, NextSmallerDigit2(123456798));
        }
    }
}
