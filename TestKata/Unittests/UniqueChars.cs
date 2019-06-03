using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace TestKata
{
    [TestClass]
    public class UniqueChars
    {
        ////Instructions:
        //Write a program to determine if a string contains all unique characters.Return true if it does and false otherwise.
        //The string may contain any of the 128 ASCII characters.

        //Super simple 1:
        public static bool HasUniqueChars0(string str)
        {
            return str.Distinct().SequenceEqual(str);
        }

        //Super simple 2:
        public static bool HasUniqueChars1(string str)
        {
            return str.ToArray().Distinct().Count() == str.Length;
        }

        // linq solution 1:

        public static bool HasUniqueChars2(string str)
        {
            return str.All(n => str.Count(m => m == n) == 1);
        }

        // Linq Solution 2:
        public static bool HasUniqueChars3(string str)
        {
            var chars = (str.GroupBy(n => n)
                      .Select(n => n.Count())).Count();

            return (chars == str.Length);
        }

        // Linq Solution 3:
        public static bool HasUniqueChars4(string str) => string.Concat(str.Distinct()) == str;

        //Linq solution 4:
        public static bool HasUniqueChars5(string str)
        {
            var grouped = str.GroupBy(n => n).Select(l => new { Value = l.Key, Count = l.Count() }).ToList();

            foreach (var letter in grouped)
            {
                if (letter.Count > 1)
                {
                    return false;
                }
            }
            return true;
        }

        public static bool HasUniqueChars6(string str)
        {
            if (str.Length > 256)
            {
                return false;
            }
            bool[] char_set = new bool[256];
            for (int i = 0; i < str.Length; i++)
            {
                int val = str[i];
                if (char_set[val])
                {
                    return false;
                }
                char_set[val] = true;
            }
            return true;
        }

        [TestMethod]
        public void TestMethod1()
        {
            Assert.IsTrue(HasUniqueChars0("abcdef"));
        }

        [TestMethod]
        public void TestMethod2()
        {
            Assert.IsFalse(HasUniqueChars1("++-"));
        }

        [TestMethod]
        public void TestMethod3()
        {
            Assert.IsFalse(HasUniqueChars2("  nAa"));
        }

        [TestMethod]
        public void TestMethod4()
        {
            Assert.IsFalse(HasUniqueChars3("aba"));
        }

        [TestMethod]
        public void TestMethod5()
        {
            Assert.IsTrue(HasUniqueChars4("Is True"));
        }

        [TestMethod]
        public void TestMethod6()
        {
            Assert.IsTrue(HasUniqueChars5("abcdef"));
        }

        [TestMethod]
        public void TestMethod7()
        {
            Assert.IsFalse(HasUniqueChars6("++-"));
        }

        [TestMethod]
        public void TestMethod8()
        {
            Assert.IsFalse(HasUniqueChars0("  nAa"));
        }

        [TestMethod]
        public void TestMethod9()
        {
            Assert.IsFalse(HasUniqueChars1("aba"));
        }

        [TestMethod]
        public void TestMethod10()
        {
            Assert.IsTrue(HasUniqueChars2("Is True"));
        }
    }
}
