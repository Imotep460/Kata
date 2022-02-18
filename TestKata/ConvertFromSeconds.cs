using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodewarsKatas_MSTestPro
{
    /// <summary>
    /// Description:
    /// Write a function, which takes a non-negative integer(seconds) as input and returns the time in a human-readable format(HH:MM:SS)
    /// 
    /// Examples:
    /// HH = hours, padded to 2 digits, range: 00 - 99
    /// MM = minutes, padded to 2 digits, range: 00 - 59
    /// SS = seconds, padded to 2 digits, range: 00 - 59
    /// 
    /// The maximum time never exceeds 359999 (99:59:59)
    /// You can find some examples in the test fixtures.
    /// 
    /// Link to kata:
    /// https://www.codewars.com/kata/52685f7382004e774f0001f7
    /// </summary>
    [TestClass]
    public class ConvertFromSeconds
    {
        /// <summary>
        /// My own solution to codekata "Human Readable Time".
        /// Takes a int seconds input and converts it into total hours, minutes, and seconds
        /// NOTE: expect errors if input seconds exceeds 99 hrs, 59 minutes and 59 seconds.
        /// </summary>
        /// <param name="seconds">Integer input of how many secods user wants converted into hh:mm:ss format.</param>
        /// <returns>Returns a "hrs:min:sec" conversion of input seconds.</returns>
        public string ConvertSeconds0(int seconds)
        {
            TimeSpan time = TimeSpan.FromSeconds(seconds);
            int days = time.Days;

            string humanReadable = string.Format("{0:D2}:{1:D2}:{2:D2}",
                time.Hours + (days * 24),
                time.Minutes,
                time.Seconds);
            return humanReadable;
        }

        /// <summary>
        /// Solution from codewars.
        /// </summary>
        /// <param name="seconds">Integer input of seconds.</param>
        /// <returns>Return seconds converted into a human readable format.</returns>
        public string ConvertSeconds1(int seconds)
        {
            return string.Format("{0:d2}:{1:d2}:{2:d2}", seconds / 3600, seconds / 60 % 60, seconds % 60);
        }

        /// <summary>
        /// Solution from codewars.
        /// </summary>
        /// <param name="seconds">Input integer of seonds user wants converted into human readable time format.</param>
        /// <returns>Return input seconds in a human readable timeformat.</returns>
        public string ConvertSeconds2(int seconds)
        {
            var t = TimeSpan.FromSeconds(seconds);
            return string.Format("{0:d2}:{1:d2}:{2:d2}", (int)t.TotalHours, t.Minutes, t.Seconds);
        }

        [TestMethod]
        public void TestMethod0()
        {
            Assert.AreEqual("00:00:00", ConvertSeconds0(0));
            Assert.AreEqual("00:00:05", ConvertSeconds0(5));
            Assert.AreEqual("00:01:00", ConvertSeconds0(60));
            Assert.AreEqual("23:59:59", ConvertSeconds0(86399));
            Assert.AreEqual("99:59:59", ConvertSeconds0(359999));
        }

        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual("00:00:00", ConvertSeconds1(0));
            Assert.AreEqual("00:00:05", ConvertSeconds1(5));
            Assert.AreEqual("00:01:00", ConvertSeconds1(60));
            Assert.AreEqual("23:59:59", ConvertSeconds1(86399));
            Assert.AreEqual("99:59:59", ConvertSeconds1(359999));
        }

        [TestMethod]
        public void TestMethod2()
        {
            Assert.AreEqual("00:00:00", ConvertSeconds2(0));
            Assert.AreEqual("00:00:05", ConvertSeconds2(5));
            Assert.AreEqual("00:01:00", ConvertSeconds2(60));
            Assert.AreEqual("23:59:59", ConvertSeconds2(86399));
            Assert.AreEqual("99:59:59", ConvertSeconds2(359999));
        }
    }
}