using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace CodewarsKatas_MSTestPro
{
    /// <summary>
    /// Write a function that accepts a string,
    /// and returns true if it is in the form of a phone number.
    /// Assume that any integer from 0-9 in any of the spots will produce a valid phone number.
    /// Only worry about the following format:
    /// (123) 456-7890 (don't forget the space after the close parentheses)
    /// Examples:
    /// 
    /// "(123) 456-7890" => true
    /// "(1111)555 2345" => false
    /// "(098) 123 4567 => false
    /// </summary>
    [TestClass]
    public class ValidatePhoneNumber
    {
        /// <summary>
        /// My own ValidatePhoneNumber Method.
        /// </summary>
        /// <param name="pNumber">The string with the phone number.</param>
        /// <returns></returns>
        public bool ValidatePhoneNumber0(string pNumber)
        {
            string validString = "(###) ###-####";
            string inputToTest = Regex.Replace(pNumber, @"\d", "#");
            if (validString == inputToTest)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Regex solution from Codewars.
        /// </summary>
        /// <param name="pNumber">String to validate.</param>
        /// <returns></returns>
        public bool ValidatePhoneNumber1(string pNumber)
        {
            return Regex.IsMatch(pNumber, @"^\(\d{3}\) \d{3}-\d{4}\z");
        }

        /// <summary>
        /// Linq solution from Codewars.
        /// </summary>
        /// <param name="pNumber">String to check.</param>
        /// <returns></returns>
        public bool ValidatePhoneNumber2(string pNumber) =>
            "(000) 000-0000" == string.Concat(pNumber.Select(x => char.IsDigit(x) ? '0' : x));

        [TestMethod]
        public void TestMethod0()
        {
            Assert.IsTrue(ValidatePhoneNumber0("(012) 345-6789"));
            Assert.IsFalse(ValidatePhoneNumber0("(1111)5x5 2345"));
            Assert.IsFalse(ValidatePhoneNumber0("(098) 123 4567"));
            Assert.IsFalse(ValidatePhoneNumber0("(1111)555 2345"));
        }

        [TestMethod]
        public void TestMethod1()
        {
            Assert.IsTrue(ValidatePhoneNumber1("(012) 345-6789"));
            Assert.IsFalse(ValidatePhoneNumber1("(1111)5x5 2345"));
            Assert.IsFalse(ValidatePhoneNumber1("(098) 123 4567"));
            Assert.IsFalse(ValidatePhoneNumber1("(1111)555 2345"));
        }

        [TestMethod]
        public void TestMethod2()
        {
            Assert.IsTrue(ValidatePhoneNumber2("(012) 345-6789"));
            Assert.IsFalse(ValidatePhoneNumber2("(1111)5x5 2345"));
            Assert.IsFalse(ValidatePhoneNumber2("(098) 123 4567"));
            Assert.IsFalse(ValidatePhoneNumber2("(1111)555 2345"));
        }
    }
}
