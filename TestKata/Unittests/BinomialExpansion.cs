using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;

namespace TestKata.Unittests
{
    /// <summary>
    /// The purpose of this kata is to write a program that can do some algebra.
    /// Write a function expand that takes in an expression with a single,
    /// one character variable, and expands it.The expression is in the form(ax+b)^n where a and b are integers which may be positive or negative,
    /// x is any single character variable, and n is a natural number.If a = 1,
    /// no coefficient will be placed in front of the variable.If a = -1, a "-" will be placed in front of the variable.
    /// 
    /// The expanded form should be returned as a string in the form ax^b+cx^d+ex^f...where a, c, and e are the coefficients of the term,
    /// x is the original one character variable that was passed in the original expression and b, d, and f,
    /// are the powers that x is being raised to in each term and are in decreasing order.
    /// 
    /// If the coefficient of a term is zero, the term should not be included.
    /// If the coefficient of a term is one, the coefficient should not be included.
    /// If the coefficient of a term is -1, only the "-" should be included.If the power of the term is 0,
    /// only the coefficient should be included. If the power of the term is 1, the caret and power should be excluded.
    /// 
    /// Examples:
    /// KataSolution.Expand("(x+1)^2");      // returns "x^2+2x+1"
    /// KataSolution.Expand("(p-1)^3");      // returns "p^3-3p^2+3p-1"
    /// KataSolution.Expand("(2f+4)^6");     // returns "64f^6+768f^5+3840f^4+10240f^3+15360f^2+12288f+4096"
    /// KataSolution.Expand("(-2a-4)^0");    // returns "1"
    /// KataSolution.Expand("(-12t+43)^2");  // returns "144t^2-1032t+1849"
    /// KataSolution.Expand("(r+0)^203");    // returns "r^203"
    /// KataSolution.Expand("(-x-1)^2");     // returns "x^2+2x+1"
    /// 
    /// Link to Kata: https://www.codewars.com/kata/540d0fdd3b6532e5c3000b5b/csharp
    /// </summary>
    public class BinomialExpansion
    {
        /// <summary>
        /// My own solution
        /// </summary>
        /// <param name="expr">Input Expretion</param>
        /// <returns></returns>
        public string Expand0(string expr)
        {
            // Extract the parts of the expression
            var expressionMatch = System.Text.RegularExpressions.Regex.Match(expr, @"\(([-]?\d*)([a-z])([+-]\d+)\)\^(\d+)");

            // If match fails, return the original string (unlikely, as per problem constraints)
            if (!expressionMatch.Success) return expr;

            // Parse the expression components
            int a = expressionMatch.Groups[1].Value == "" || expressionMatch.Groups[1].Value == "-" ? (expressionMatch.Groups[1].Value == "-" ? -1 : 1) : int.Parse(expressionMatch.Groups[1].Value);
            char x = expressionMatch.Groups[2].Value[0];
            int b = int.Parse(expressionMatch.Groups[3].Value);
            int n = int.Parse(expressionMatch.Groups[4].Value);

            // Handle the special case where n = 0
            if (n == 0) return "1";

            StringBuilder result = new StringBuilder();

            // Apply the binomial theorem
            for (int k = 0; k <= n; k++)
            {
                long binom = BinomialCoefficient(n, k);
                long coefficient = binom * (long)Math.Pow(a, n - k) * (long)Math.Pow(b, k);

                if (coefficient == 0) continue;

                int power = n - k;

                // Add the coefficient (considering sign)
                if (coefficient > 0 && k > 0) result.Append("+");
                if (coefficient < 0) result.Append("-");
                if (Math.Abs(coefficient) != 1 || power == 0) result.Append(Math.Abs(coefficient));

                // Add the variable and its power
                if (power > 0)
                {
                    result.Append(x);
                    if (power > 1) result.Append("^").Append(power);
                }
            }

            return result.ToString();
        }

        /// <summary>
        /// Helper function to calculate binomial coefficient
        /// </summary>
        private long BinomialCoefficient(int n, int k)
        {
            if (k > n - k) k = n - k;
            long result = 1;
            for (int i = 1; i <= k; i++)
            {
                result *= (n - (k - i));
                result /= i;
            }
            return result;
        }

        // Codewars solutions:

        public static string Expand1(string expr)
        {
            Regex pattern = new Regex(@"^\((-?\d*)(.)([-+]\d+)\)\^(\d+)$", RegexOptions.Compiled);

            var matches = pattern.Matches(expr).Cast<Match>().First().Groups.Cast<Group>().Skip(1).Select(g => g.Value).ToArray();
            var a = matches[0].Length == 0 ? 1 : matches[0] == "-" ? -1 : int.Parse(matches[0]);
            var x = matches[1];
            var b = int.Parse(matches[2]);
            var n = int.Parse(matches[3]);
            var f = new BigInteger(Math.Pow(a, n));
            var c = f == -1 ? "-" : f == 1 ? "" : f.ToString();
            var k = (n > 1) ? "^" : "";

            if (n == 0) return "1";
            if (b == 0) return $"{c}{x}{k}{n}";
            var res = new StringBuilder();

            for (var i = 0; i <= n; i++)
            {
                if (f > 0 && i > 0) res.Append("+");
                if (f < 0) res.Append("-");
                if (i > 0 || f * f > 1) res.Append($"{BigInteger.Abs(f)}");
                if (i < n) res.Append(x);
                if (i < n - 1) res.Append($"^{n - i}");
                f = f * (n - i) * b / a / (i + 1);
            }

            return res.ToString();
        }


        [TestMethod]
        public void TestBPositive0()
        {
            Assert.AreEqual("1", Expand0("(x+1)^0"));
            Assert.AreEqual("x+1", Expand0("(x+1)^1"));
            Assert.AreEqual("x^2+2x+1", Expand0("(x+1)^2"));
        }

        [TestMethod]
        public void TestBNegative0()
        {
            Assert.AreEqual("1", Expand0("(x-1)^0"));
            Assert.AreEqual("x-1", Expand0("(x-1)^1"));
            Assert.AreEqual("x^2-2x+1", Expand0("(x-1)^2"));
        }

        [TestMethod]
        public void TestAPositive0()
        {
            Assert.AreEqual("625m^4+1500m^3+1350m^2+540m+81", Expand0("(5m+3)^4"));
            Assert.AreEqual("8x^3-36x^2+54x-27", Expand0("(2x-3)^3"));
            Assert.AreEqual("1", Expand0("(7x-7)^0"));
        }

        [TestMethod]
        public void TestANegative0()
        {
            Assert.AreEqual("625m^4-1500m^3+1350m^2-540m+81", Expand0("(-5m+3)^4"));
            Assert.AreEqual("-8k^3-36k^2-54k-27", Expand0("(-2k-3)^3"));
            Assert.AreEqual("1", Expand0("(-7x-7)^0"));
        }

        [TestMethod]
        public void TestBPositive1()
        {
            Assert.AreEqual("1", Expand1("(x+1)^0"));
            Assert.AreEqual("x+1", Expand1("(x+1)^1"));
            Assert.AreEqual("x^2+2x+1", Expand1("(x+1)^2"));
        }

        [TestMethod]
        public void TestBNegative1()
        {
            Assert.AreEqual("1", Expand1("(x-1)^0"));
            Assert.AreEqual("x-1", Expand1("(x-1)^1"));
            Assert.AreEqual("x^2-2x+1", Expand1("(x-1)^2"));
        }

        [TestMethod]
        public void TestAPositive1()
        {
            Assert.AreEqual("625m^4+1500m^3+1350m^2+540m+81", Expand1("(5m+3)^4"));
            Assert.AreEqual("8x^3-36x^2+54x-27", Expand1("(2x-3)^3"));
            Assert.AreEqual("1", Expand1("(7x-7)^0"));
        }

        [TestMethod]
        public void TestANegative1()
        {
            Assert.AreEqual("625m^4-1500m^3+1350m^2-540m+81", Expand1("(-5m+3)^4"));
            Assert.AreEqual("-8k^3-36k^2-54k-27", Expand1("(-2k-3)^3"));
            Assert.AreEqual("1", Expand1("(-7x-7)^0"));
        }
    }
}
