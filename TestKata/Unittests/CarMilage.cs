using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TestKata.Unittests
{
    /// <summary>
    /// "7777...8?!??!", exclaimed Bob,
    /// "I missed it again! Argh!" Every time there's an interesting number coming up, he notices and then promptly forgets. Who doesn't like catching those one-off interesting mileage numbers?
    /// 
    /// Let's make it so Bob never misses another interesting number.
    /// We've hacked into his car's computer, and we have a box hooked up that reads mileage numbers.
    /// We've got a box glued to his dash that lights up yellow or green depending on whether it receives a 1 or a 2 (respectively).
    /// 
    /// It's up to you, intrepid warrior, to glue the parts together.
    /// Write the function that parses the mileage number input, and returns a 2 if the number is "interesting" (see below),
    /// a 1 if an interesting number occurs within the next two miles, or a 0 if the number is not interesting.
    /// 
    /// Note: In Haskell, we use No, Almost and Yes instead of 0, 1 and 2.
    /// 
    /// "Interesting" Numbers
    /// Interesting numbers are 3-or-more digit numbers that meet one or more of the following criteria:
    /// 
    /// Any digit followed by all zeros: 100, 90000
    /// Every digit is the same number: 1111
    /// The digits are sequential, incementing†: 1234
    /// The digits are sequential, decrementing‡: 4321
    /// The digits are a palindrome: 1221 or 73837
    /// The digits match one of the values in the awesomePhrases array
    /// † For incrementing sequences, 0 should come after 9, and not before 1, as in 7890.
    /// ‡ For decrementing sequences, 0 should come after 1, and not before 9, as in 3210.
    /// 
    /// So, you should expect these inputs and outputs:
    /// 
    /// "boring" numbers
    /// Kata.IsInteresting(3, new List<int>() { 1337, 256 });    // 0
    /// Kata.IsInteresting(3236, new List<int>() { 1337, 256 }); // 0
    /// progress as we near an "interesting" number
    /// 
    /// Kata.IsInteresting(11207, new List<int>() { });   // 0
    /// Kata.IsInteresting(11208, new List<int>() { });   // 0
    /// Kata.IsInteresting(11209, new List<int>() { });   // 1
    /// Kata.IsInteresting(11210, new List<int>() { });   // 1
    /// Kata.IsInteresting(11211, new List<int>() { });   // 2
    /// 
    /// nearing a provided "awesome phrase"
    /// Kata.IsInteresting(1335, new List<int>() { 1337, 256 });   // 1
    /// Kata.IsInteresting(1336, new List<int>() { 1337, 256 });   // 1
    /// Kata.IsInteresting(1337, new List<int>() { 1337, 256 });   // 2
    /// Error Checking
    /// A number is only interesting if it is greater than 99!
    /// Input will always be an integer greater than 0, and less than 1,000,000,000.
    /// The awesomePhrases array will always be provided, and will always be an array, but may be empty. (Not everyone thinks numbers spell funny words...)
    /// You should only ever output 0, 1, or 2.
    /// </summary>
    [TestClass]
    public class CarMilage
    {
        public int IsInteresting0(int number, List<int> awesomePhrases)
        {
            if (IsInterestingNumber(number, awesomePhrases))
                return 2;

            if (IsInterestingNumber(number + 1, awesomePhrases))
                return 1;

            if (IsInterestingNumber(number + 2, awesomePhrases))
                return 1;

            return 0;
        }

        private bool IsInterestingNumber(int number, List<int> awesomePhrases)
        {
            if (number < 100)
                return false;

            string numStr = number.ToString();

            return IsAllZerosExceptFirst(numStr) ||
              IsAllSameDigits(numStr) ||
              IsSequentialIncrementing(numStr) ||
              IsSequentialDecrementing(numStr) ||
              IsPalindrome(numStr) ||
              awesomePhrases.Contains(number);
        }

        private bool IsAllZerosExceptFirst(string number)
        {
            return number.Substring(1).Trim('0').Length == 0;
        }

        private bool IsAllSameDigits(string number)
        {
            return new HashSet<char>(number).Count == 1;
        }

        private bool IsSequentialIncrementing(string number)
        {
            string sequential = "1234567890";
            return sequential.Contains(number);
        }

        private bool IsSequentialDecrementing(string number)
        {
            string sequential = "9876543210";
            return sequential.Contains(number);
        }

        private bool IsPalindrome(string number)
        {
            char[] arr = number.ToCharArray();
            Array.Reverse(arr);
            return number == new string(arr);
        }


        /// <summary>
        /// Colution from Codewars
        /// </summary>
        /// <param name="number"></param>
        /// <param name="awesomePhrases"></param>
        /// <returns></returns>
        public int IsInteresting1(int number, List<int> awesomePhrases)
        {
            Predicate<int> isAbove99 = x => 99 < x;
            Predicate<int> isAllZero = x => x.ToString().Skip(1).All('0'.Equals);
            Predicate<int> isAllSame = x => x.ToString().Distinct().Count() == 1;
            Predicate<int> isIncrementing = x => "1234567890".Contains(x.ToString());
            Predicate<int> isDecrementing = x => "9876543210".Contains(x.ToString());
            Predicate<int> isPalindrome = x => x.ToString().SequenceEqual(x.ToString().Reverse());
            Predicate<int> isAwesome = awesomePhrases.Contains;
            Predicate<int> isInteresting = x => isAbove99(x) && (isAllZero(x) || isAllSame(x) || isIncrementing(x) || isDecrementing(x) || isPalindrome(x) || isAwesome(x));

            if (isInteresting(number))
                return 2;

            if (isInteresting(number + 1) || isInteresting(number + 2))
                return 1;

            return 0;
        }

        /// <summary>
        /// Solution from Codewars
        /// </summary>
        /// <param name="n"></param>
        /// <param name="awesomePhrases"></param>
        /// <returns></returns>
        public static int IsInteresting2(int n, List<int> awesomePhrases)
        {
            if (n == 1337 || n == 11211 || n == 100 || n == 7000 || n == 800000 || n == 111 || n == 444 || n == 9999999 || n == 80085
                || n == 256 || n == 101 || n == 1234 || n == 67890 || n == 234567890 || n == 3210 || n == 654 || n == 8765
                || n == 987654321 || n == 78687)
                return 2;
            if (n == 1336 || n == 11209 || n == 79998 || n == 98 || n == 99 || n == 6998 || n == 799999 || n == 109 || n == 110
                || n == 442 || n == 9999997 || n == 1335 || n == 255 || n == 80083 || n == 254 || n == 119 || n == 120 || n == 7473745
                || n == 122 || n == 1232 || n == 67888 || n == 234567889 || n == 3208 || n == 987654320 || n == 3209 || n == 987654319)
                return 1;
            return 0;
        }

        [TestMethod]
        public void TestMethod0()
        {
            Assert.AreEqual(0, IsInteresting0(3, new List<int>() { 1337, 256 }));
            Assert.AreEqual(1, IsInteresting0(1336, new List<int>() { 1337, 256 }));
            Assert.AreEqual(2, IsInteresting0(1337, new List<int>() { 1337, 256 }));
            Assert.AreEqual(0, IsInteresting0(11208, new List<int>() { 1337, 256 }));
            Assert.AreEqual(1, IsInteresting0(11209, new List<int>() { 1337, 256 }));
            Assert.AreEqual(2, IsInteresting0(11211, new List<int>() { 1337, 256 }));
        }

        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(0, IsInteresting1(3, new List<int>() { 1337, 256 }));
            Assert.AreEqual(1, IsInteresting1(1336, new List<int>() { 1337, 256 }));
            Assert.AreEqual(2, IsInteresting1(1337, new List<int>() { 1337, 256 }));
            Assert.AreEqual(0, IsInteresting1(11208, new List<int>() { 1337, 256 }));
            Assert.AreEqual(1, IsInteresting1(11209, new List<int>() { 1337, 256 }));
            Assert.AreEqual(2, IsInteresting1(11211, new List<int>() { 1337, 256 }));
        }

        [TestMethod]
        public void TestMethod2()
        {
            Assert.AreEqual(0, IsInteresting2(3, new List<int>() { 1337, 256 }));
            Assert.AreEqual(1, IsInteresting2(1336, new List<int>() { 1337, 256 }));
            Assert.AreEqual(2, IsInteresting2(1337, new List<int>() { 1337, 256 }));
            Assert.AreEqual(0, IsInteresting2(11208, new List<int>() { 1337, 256 }));
            Assert.AreEqual(1, IsInteresting2(11209, new List<int>() { 1337, 256 }));
            Assert.AreEqual(2, IsInteresting2(11211, new List<int>() { 1337, 256 }));
        }
    }
}
