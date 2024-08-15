using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace TestKata.Unittests
{
    /// <summary>
    /// Create a function that takes a positive integer and returns the next bigger number that can be formed by rearranging its digits. For example:
    /// 
    /// 12 ==> 21
    /// 513 ==> 531
    /// 2017 ==> 2071
    /// 
    /// If the digits can't be rearranged to form a bigger number, return -1 (or nil in Swift, None in Rust):
    /// 
    /// 9 ==> -1
    /// 111 ==> -1
    /// 531 ==> -1
    /// 
    /// Link to Kata: https://www.codewars.com/kata/next-bigger-number-with-the-same-digits
    /// </summary>
    [TestClass]
    public class NextBiggerDigit
    {
        /// <summary>
        /// My own solution
        /// </summary>
        /// <param name="number">Number torevork</param>
        /// <returns>Returns next number in with the same digits.</returns>
        public long NextBiggerNumber0(long number)
        {
            char[] digits = number.ToString().ToCharArray();
            int length = digits.Length;

            // Step 1: Find the pivot
            int pivot = -1;
            for (int i = length - 2; i >= 0; i--)
            {
                if (digits[i] < digits[i + 1])
                {
                    pivot = i;
                    break;
                }
            }

            // If no pivot found, return -1 as no bigger number is possible
            if (pivot == -1) return -1;

            // Step 2: Find the smallest digit to the right of the pivot that is larger than the pivot
            int smallestLargerIndex = -1;
            for (int i = length - 1; i > pivot; i--)
            {
                if (digits[i] > digits[pivot])
                {
                    smallestLargerIndex = i;
                    break;
                }
            }

            // Step 3: Swap the pivot with the smallest larger digit
            Swap(ref digits[pivot], ref digits[smallestLargerIndex]);

            // Step 4: Sort the rest of the digits after the pivot in ascending order
            Array.Sort(digits, pivot + 1, length - pivot - 1);

            // Convert the array back to a number
            long result = long.Parse(new string(digits));

            return result;
        }

        /// <summary>
        /// Helper method to swap two characters
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        private void Swap(ref char a, ref char b)
        {
            char temp = a;
            a = b;
            b = temp;
        }

        /// <summary>
        /// Solution from Codewars
        /// </summary>
        /// <param name="number">Number to analyse</param>
        /// <returns>Returns next number with the same digits as the input number.</returns>
        public long NextBiggerNumber1(long number)
        {
            if (number < 10) return -1;
            string s = number + "";
            for (int i = s.Length - 2; i >= 0; i--)
            {
                if (s.Substring(i) != string.Concat(s.Substring(i).OrderByDescending(x => x)))
                {
                    var t = string.Concat(s.Substring(i).OrderBy(x => x));
                    var c = t.First(x => x > s[i]);
                    return long.Parse(s.Substring(0, i) + c + string.Concat(t.Where((x, y) => y != t.IndexOf(c))));
                }
            }
            return -1;
        }

        /// <summary>
        /// Solution from Codewars
        /// </summary>
        /// <param name="number">Number to analyse</param>
        /// <returns>Returns next number with the same digits as the input number.</returns>
        public long NextBiggerNumber2(long number)
        {
            var str = GetNumbers(number);
            for (long i = number + 1; i <= long.Parse(str); i++)
            {
                if (GetNumbers(number) == GetNumbers(i))
                {
                    return i;
                }
            }
            return -1;
        }

        public string GetNumbers(long numberToGet)
        {
            return string.Join("", numberToGet.ToString().ToCharArray().OrderByDescending(x => x));
        }

        [TestMethod]
        public void TestMethod0()
        {
            Assert.AreEqual(21, NextBiggerNumber0(12));
            Assert.AreEqual(531, NextBiggerNumber0(513));
            Assert.AreEqual(2071, NextBiggerNumber0(2017));
            Assert.AreEqual(441, NextBiggerNumber0(414));
            Assert.AreEqual(414, NextBiggerNumber0(144));
        }

        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(21, NextBiggerNumber1(12));
            Assert.AreEqual(531, NextBiggerNumber1(513));
            Assert.AreEqual(2071, NextBiggerNumber1(2017));
            Assert.AreEqual(441, NextBiggerNumber1(414));
            Assert.AreEqual(414, NextBiggerNumber1(144));
        }

        [TestMethod]
        public void TestMethod2()
        {
            Assert.AreEqual(21, NextBiggerNumber2(12));
            Assert.AreEqual(531, NextBiggerNumber2(513));
            Assert.AreEqual(2071, NextBiggerNumber2(2017));
            Assert.AreEqual(441, NextBiggerNumber2(414));
            Assert.AreEqual(414, NextBiggerNumber2(144));
        }
    }
}
