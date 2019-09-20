using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;

namespace TestKata.Unittests
{
    // Replace all vowels in a string with exclamation marks (!).
    // aeiouAEIOU is a vowel.
    [TestClass]
    public class ReplaceVowel
    {
        //Linq solution;
        public static string Replace(string s)
            => Regex.Replace(s, "[aeiouyAEIOUY]", "!", RegexOptions.IgnoreCase);


        public string ReplaceVowel1(string s)
        {
            return Regex.Replace(s, "[aeiouyAEIOUY]", "!", RegexOptions.IgnoreCase);
        }

        public string ReplaceVowel2(string s)
        {
            string vowels = "aeiouyAEIOUY";

            foreach (var vowel in vowels)
            {
                s = s.Replace(vowel, '!');
            }
            return s;
        }

        [TestMethod]
        public void TestMethod()
        {
            Assert.AreEqual("H!!", ReplaceVowel1("Hi!"));
        }
        [TestMethod]
        public void TestMehotd1()
        {
            Assert.AreEqual("!H!! H!!", ReplaceVowel1("!Hi! Hi!"));
        }
        [TestMethod]
        public void TestMehotd2()
        {
            Assert.AreEqual("!!!!!", ReplaceVowel1("aeiou"));
        }
        [TestMethod]
        public void TestMehotd3()
        {
            Assert.AreEqual("!BCD!", ReplaceVowel1("ABCDE"));
        }

        [TestMethod]
        public void TestMethod4()
        {
            Assert.AreEqual("H!!", ReplaceVowel2("Hi!"));
        }
        [TestMethod]
        public void TestMehotd5()
        {
            Assert.AreEqual("!H!! H!!", ReplaceVowel2("!Hi! Hi!"));
        }
        [TestMethod]
        public void TestMehotd6()
        {
            Assert.AreEqual("!!!!!", ReplaceVowel2("aeiou"));
        }
        [TestMethod]
        public void TestMehotd7()
        {
            Assert.AreEqual("!BCD!", ReplaceVowel2("ABCDE"));
        }

        [TestMethod]
        public void TestMethod8()
        {
            Assert.AreEqual("H!!", Replace("Hi!"));
        }
        [TestMethod]
        public void TestMehotd9()
        {
            Assert.AreEqual("!H!! H!!", Replace("!Hi! Hi!"));
        }
        [TestMethod]
        public void TestMehotd10()
        {
            Assert.AreEqual("!!!!!", Replace("aeiou"));
        }
        [TestMethod]
        public void TestMehotd11()
        {
            Assert.AreEqual("!BCD!", Replace("ABCDE"));
        }
    }
}
