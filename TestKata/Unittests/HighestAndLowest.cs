using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace TestKata
{
    ////In this little assignment you are given a string of space separated numbers, and have to return the highest and lowest number.

    ////Example:

    ////    Kata.HighAndLow("1 2 3 4 5"); // return "5 1"
    ////    Kata.HighAndLow("1 2 -3 4 5"); // return "5 -3"
    ////    Kata.HighAndLow("1 9 3 4 -5"); // return "9 -5"
    
    ////    Notes:
    ////    All numbers are valid Int32, no need to validate them.
    ////    There will always be at least one number in the input string.
    ////    Output string must be two numbers separated by a single space, and highest number is first.

    [TestClass]
    public class HighestAndLowest
    {
        //// linq solution:
        public static string HighAndLow0(string numbers)
        {
            var numbersList = numbers.Split(' ').Select(x => Convert.ToInt32(x));
            return string.Format("{0} {1}", numbersList.Max(), numbersList.Min());
        }

        public static string HighAndLow1(string numbers)
        {
            var parsed = numbers.Split().Select(int.Parse);
            return parsed.Max() + " " + parsed.Min();
        }

        // Weird solution:
        public static string HighAndLow2(string numbers)
        {
            string[] splittedLine = numbers.Split(' ');

            double highest = 0;
            double lowest = 0;

            int amount = splittedLine.Length;

            double[] converter = new double[amount];

            highest = converter[0];
            lowest = converter[0];

            for (int i = 0; i < splittedLine.Length; i++)
            {

                converter[i] = Convert.ToDouble(splittedLine[i]);
            }
            for (int i = 0; i < converter.Length; i++)
            {
                if (converter[i] > highest)
                {
                    highest = converter[i];

                    if (converter[i] < lowest)
                    {
                        lowest = converter[i];
                    }
                }
                if (converter[i] < lowest)
                {
                    lowest = converter[i];

                    if (converter[i] > highest)
                    {
                        highest = converter[i];
                    }
                }
            }
            string result = highest.ToString() + " " + lowest.ToString();
            return result;
        }

        [TestMethod]
        public void TestMethod0()
        {
            Assert.AreEqual("42 -9", HighAndLow0("8 3 -5 42 -1 0 0 -9 4 7 4 -4"));
            Assert.AreEqual("42 -9", HighAndLow1("8 3 -5 42 -1 0 0 -9 4 7 4 -4"));
            Assert.AreEqual("42 -9", HighAndLow2("8 3 -5 42 -1 0 0 -9 4 7 4 -4"));
        }

        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual("2018 -2018", HighAndLow0("10 8 19 21 -23 -56 2018 -2018 50 110 24 1994"));
            Assert.AreEqual("2018 -2018", HighAndLow1("10 8 19 21 -23 -56 2018 -2018 50 110 24 1994"));
            Assert.AreEqual("2018 -2018", HighAndLow2("10 8 19 21 -23 -56 2018 -2018 50 110 24 1994"));
        }
    }
}
