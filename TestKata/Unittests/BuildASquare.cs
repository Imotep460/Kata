using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Text;

namespace TestKata.Unittests
{

    /// <summary>
    /// I will give you an integer. Give me back a shape that is as long and wide as the integer. The integer will be a whole number between 1 and 50.
    /// Example
    /// n = 3, so I expect a 3x3 square back just like below as a string:
    /// +++
    /// +++
    /// +++
    /// 
    /// Link to the Kata: https://www.codewars.com/kata/59a96d71dbe3b06c0200009c
    /// </summary>
    [TestClass]
    public class BuildASquare
    {
        /// <summary>
        /// My solution
        /// </summary>
        /// <param name="n">The depth</param>
        /// <returns>The string.</returns>
        public string GenerateShape0(int n)
        {
            string shape = "";
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    shape += "+";
                }
                if (i != n - 1) // add newline character after all rows except the last one
                {
                    shape += "\n";
                }
            }
            return shape;
        }

        public static string GenerateShape1(int n)
            => string.Join("\n", Enumerable.Repeat(new string('+', n), n));


        public static string GenerateShape2(int n)
        {
            return string.Join("\n", Enumerable.Repeat("".PadLeft(n, '+'), n));
        }

        public static string GenerateShape3(int n)
        {
            var stringBuilder = new StringBuilder("");

            for (var i = 1; i <= n * n; i++)
            {
                stringBuilder.Append(i % n == 0 && i != n * n ? "+\n" : "+");
            }

            return stringBuilder.ToString();
        }

        public static string GenerateShape4(int n)
        {
            string[] tempAns = new string[n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    tempAns[i] += "+";
                }
            }

            return string.Join("\n", tempAns);
        }

        [TestMethod]
        public void FirstTest()
        {
            Assert.AreEqual("", GenerateShape0(0));
            Assert.AreEqual("+", GenerateShape0(1));
            Assert.AreEqual("++\n++", GenerateShape0(2));
            Assert.AreEqual("+++\n+++\n+++", GenerateShape0(3));
        }

        [TestMethod]
        public void SecondTest()
        {
            Assert.AreEqual("", GenerateShape1(0));
            Assert.AreEqual("+", GenerateShape1(1));
            Assert.AreEqual("++\n++", GenerateShape1(2));
            Assert.AreEqual("+++\n+++\n+++", GenerateShape1(3));
        }


        [TestMethod]
        public void ThirdTest()
        {
            Assert.AreEqual("", GenerateShape2(0));
            Assert.AreEqual("+", GenerateShape2(1));
            Assert.AreEqual("++\n++", GenerateShape2(2));
            Assert.AreEqual("+++\n+++\n+++", GenerateShape2(3));
        }

        [TestMethod]
        public void FourthTest()
        {
            Assert.AreEqual("", GenerateShape3(0));
            Assert.AreEqual("+", GenerateShape3(1));
            Assert.AreEqual("++\n++", GenerateShape3(2));
            Assert.AreEqual("+++\n+++\n+++", GenerateShape3(3));
        }

        [TestMethod]
        public void FifthTest()
        {
            Assert.AreEqual("", GenerateShape4(0));
            Assert.AreEqual("+", GenerateShape4(1));
            Assert.AreEqual("++\n++", GenerateShape4(2));
            Assert.AreEqual("+++\n+++\n+++", GenerateShape4(3));
        }
    }
}
