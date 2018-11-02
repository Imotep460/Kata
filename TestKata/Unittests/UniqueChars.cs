using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestKata
{
    [TestClass]
    public class UniqueChars
    {
        ////Instructions:

        //Write a program to determine if a string contains all unique characters.Return true if it does and false otherwise.
        //The string may contain any of the 128 ASCII characters.


        ////Super simple1:
        //public static bool HasUniqueChars(string str)
        //{
        //    return str.Distinct().SequenceEqual(str);
        //}

        ////Super simple 2:
        //public static bool HasUniqueChars(string str)
        //{
        //    return str.ToArray().Distinct().Count() == str.Length;
        //}

        //// linq solution 1:

        //public static bool HasUniqueChars(string str)
        //{
        //    return str.All(n => str.Count(m => m == n) == 1);
        //}

        //// Linq Solution 2:
        //public static bool HasUniqueChars(string str)
        //{
        //    var chars = (str.GroupBy(n => n)
        //              .Select(n => n.Count())).Count();

        //    return (chars == str.Length);
        //}

        //// Linq Solution 3:
        //public static bool HasUniqueChars(string str) => string.Concat(str.Distinct()) == str;

        ////Linq solution 4:
        //public static bool HasUniqueChars(string str)
        //{
        //    var grouped = str.GroupBy(n => n).Select(l => new { Value = l.Key, Count = l.Count() }).ToList();

        //    foreach (var letter in grouped)
        //    {
        //        if (letter.Count > 1)
        //        {
        //            return false;
        //        }
        //    }
        //    return true;
        //}

        public static bool HasUniqueChars(string str)
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
            Assert.IsTrue(HasUniqueChars("abcdef"));
        }

        [TestMethod]
        public void TestMethod2()
        {
            Assert.IsFalse(HasUniqueChars("++-"));
        }

        [TestMethod]
        public void TestMethod3()
        {
            Assert.IsFalse(HasUniqueChars("  nAa"));
        }

        [TestMethod]
        public void TestMethod4()
        {
            Assert.IsFalse(HasUniqueChars("aba"));
        }

        [TestMethod]
        public void TestMethod5()
        {
            Assert.IsTrue(HasUniqueChars("Is True"));
        }
    }
}
