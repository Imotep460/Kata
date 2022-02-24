using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodewarsKatas_MSTestPro
{
    /// <summary>
    /// Description:
    /// Write a function that accepts an array of 10 integers(between 0 and 9), that returns a string of those numbers in the form of a phone number.
    /// 
    /// Example
    /// Kata.CreatePhoneNumber(new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 0}) // => returns "(123) 456-7890"
    /// 
    /// The returned format must be correct in order to complete this challenge.
    /// Don't forget the space after the closing parentheses!
    /// 
    /// Link to the Kata:
    /// https://www.codewars.com/kata/525f50e3b73515a6db000b83
    /// /// </summary>
    [TestClass]
    public class CreatePhoneNumber
    {
        /// <summary>
        /// My Own solution for kata from codewars.
        /// </summary>
        /// <param name="newPhoneNumber"></param>
        /// <returns>Returns a string with a new phone number in the right format.</returns>
        public string CreatePhoneNumber0(int[] newPhoneNumber)
        {
            string phoneNumber;
            return phoneNumber = string.Format("({0}{1}{2}) {3}{4}{5}-{6}{7}{8}{9}", newPhoneNumber[0].ToString(), newPhoneNumber[1].ToString(), newPhoneNumber[2].ToString(), newPhoneNumber[3].ToString(), newPhoneNumber[4].ToString(), newPhoneNumber[5].ToString(), newPhoneNumber[6].ToString(), newPhoneNumber[7].ToString(), newPhoneNumber[8].ToString(), newPhoneNumber[9].ToString());
        }

        /// <summary>
        /// Solution from Codewars
        /// </summary>
        /// <param name="NewPhoneNumber">A int array with the new phone number.</param>
        /// <returns>Returns a string with a new phone number in the right format.</returns>
        public string CreatePhoneNumber1(int[] NewPhoneNumber)
        {
            return long.Parse(string.Concat(NewPhoneNumber)).ToString("(000) 000-0000");
        }

        /// <summary>
        /// Solution from Codewars
        /// </summary>
        /// <param name="n">A int array with the new phone number.</param>
        /// <returns>Returns a string with a new phone number in the right format.</returns>
        public string CreatePhoneNumber2(int[] n)
        {
            return "(" + n[0] + n[1] + n[2] + ") " + n[3] + n[4] + n[5] + "-" + n[6] + n[7] + n[8] + n[9]; 
        }

        /// <summary>
        /// Solution from Codewars
        /// </summary>
        /// <param name="NewPhoneNumber">A int array with the new phone number.</param>
        /// <returns>Returns a string with a new phone number in the right format.</returns>
        public string CreatePhoneNumber3(int[] newPhoneNumber) =>
            new Regex("(...)(...)(...)").Replace(String.Concat(newPhoneNumber), "($1) $2-$3");

        /// <summary>
        /// Solution from Codewars
        /// </summary>
        /// <param name="NewPhoneNumber">A int array with the new phone number.</param>
        /// <returns>Returns a string with a new phone number in the right format.</returns>
        public string CreatePhoneNumber4(int[] newPhoneNumber)
        {
            return string.Format("({0}{1}{2}) {3}{4}{5}-{6}{7}{8}{9}", newPhoneNumber.Select(x => x.ToString()).ToArray());
        }

        [TestMethod]
        public void TestMethod0()
        {
            Assert.AreEqual("(123) 456-7890", CreatePhoneNumber0(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 }));
            Assert.AreEqual("(111) 111-1111", CreatePhoneNumber0(new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }));
        }

        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual("(123) 456-7890", CreatePhoneNumber1(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 }));
            Assert.AreEqual("(111) 111-1111", CreatePhoneNumber1(new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }));
        }

        [TestMethod]
        public void TestMethod2()
        {
            Assert.AreEqual("(123) 456-7890", CreatePhoneNumber2(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 }));
            Assert.AreEqual("(111) 111-1111", CreatePhoneNumber2(new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }));
        }

        [TestMethod]
        public void TestMethod3()
        {
            Assert.AreEqual("(123) 456-7890", CreatePhoneNumber3(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 }));
            Assert.AreEqual("(111) 111-1111", CreatePhoneNumber3(new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }));
        }

        [TestMethod]
        public void TestMethod4()
        {
            Assert.AreEqual("(123) 456-7890", CreatePhoneNumber4(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 }));
            Assert.AreEqual("(111) 111-1111", CreatePhoneNumber4(new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }));
        }
    }
}