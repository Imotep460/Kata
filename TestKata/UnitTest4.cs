using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestKata
{
    /// <summary>
    /// Summary description for UnitTest4
    /// </summary>
    [TestClass]
    public class UnitTest4
    {
        //Instructions:

        //Write a program to determine if a string contains all unique characters.Return true if it does and false otherwise.

        //The string may contain any of the 128 ASCII characters.

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
