using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodewarsKatas_MSTestPro
{
    /// <summary>
    /// Description:
    /// Create a function that takes a Roman numeral as its argument and returns its value as a numeric devimal integer.
    /// You don't need to validate the form of te Roman Numeral.
    /// 
    /// Modern Roman numerals are written by expressing each decimal digit to the number to be encoded seåarately,
    /// starting with the leftmost digit and skipping any 0s.
    /// So 1990 is rendered "MCMXC"
    /// (1000 = M, 900 = CM, 90 = XC)
    /// and 2008 is rendered "MMVIII"
    /// 
    /// Example:
    /// RomanDecode.Solution("XXI") -- should return 21.
    /// 
    /// Help:
    /// Symbol: | Value
    /// I       | 1
    /// V       | 5
    /// X       | 10
    /// L       | 50
    /// C       | 100
    /// D       | 500
    /// M       | 1.000
    /// 
    /// Link to Kata:
    /// https://www.codewars.com/kata/51b6249c4612257ac0000005
    /// </summary>
    [TestClass]
    public class ConvertRomanNumeralsToInt
    {
        /// <summary>
        /// Roman numerals and their corresponding integer values.
        /// </summary>
        public Dictionary<char, int> RomanNumbers = new Dictionary<char, int>()
        {
            { 'I', 1},
            { 'V', 5},
            { 'X', 10},
            { 'L', 50},
            { 'C', 100},
            { 'D', 500},
            { 'M', 1000}
        };

        /// <summary>
        /// Uses a dictionary to convert a string of roman numeral to integer.
        /// The letters in the input string are made uppercase.
        /// The Dictionary used is called "RomanNumbers".
        /// </summary>
        /// <param name="romanNumber">The input roman numerals.</param>
        /// <returns>Returns a integer corresponding to the int value of the roman numerals in the input string.</returns>
        public int ConvertRomanNumeralsToInt0(string romanNumber)
        {
            Dictionary<char, int> LinkDictionary = RomanNumbers;
            string capitalLetters = romanNumber.ToUpper(); // Make sure that the input string is in capital letters.
            int convertedNumber = 0; // Set a string that hold the output integer.

            for (int i = 0; i < capitalLetters.Length; i++)
            {
                // Check if the the current Letter is the last letter in the string,
                // also check if the next letter/roman number in the string bigger than the current letter/string.
                if (i + 1 < capitalLetters.Length && RomanNumbers[capitalLetters[i]] < RomanNumbers[capitalLetters[i + 1]])
                {
                    // Subtract from convertedNumber if the value of the next letter in capitalLetters is bigger than the value at capitalLetters[i]
                    convertedNumber -= RomanNumbers[capitalLetters[i]];
                }
                else
                {
                    // Add a value to the convertedNumber, the value added is the int value corresponding to the letter at capitalLetters[i].
                    convertedNumber += RomanNumbers[capitalLetters[i]];
                }
            }
            return convertedNumber;
        }

        /// <summary>
        /// Kata Solution from Codewars.
        /// </summary>
        /// <param name="romanNumber">The string of roman numerals to turn into integers.</param>
        /// <returns>Returns a integer corresponding to the value of the roman numerals from the input string.</returns>
        public int ConvertRomanNumeralsToInt1(string romanNumber)
        {
            string upperString = romanNumber.ToUpper(); // Convert the string to upper characters.
            int result = 0;
            int max = 0;
            foreach (var c in upperString.Reverse())
            {
                int value = RomanNumbers[c];

                if (value < max)
                {
                    result -= value;
                }
                else
                {
                    result += value;
                    max = value;
                }
            }
            return result;
        }

        [TestMethod]
        public void TestMethod0()
        {
            Assert.AreEqual(1, ConvertRomanNumeralsToInt0("I"));
            Assert.AreEqual(21, ConvertRomanNumeralsToInt0("XXI"));
            Assert.AreEqual(21, ConvertRomanNumeralsToInt0("xxi"));
        }

        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(1, ConvertRomanNumeralsToInt1("I"));
            Assert.AreEqual(21, ConvertRomanNumeralsToInt1("XXI"));
            Assert.AreEqual(21, ConvertRomanNumeralsToInt1("xxi"));
        }
    }
}
