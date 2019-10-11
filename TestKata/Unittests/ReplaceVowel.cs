using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;

namespace TestKata.Unittests
{
    // Replace all vowels in a string with exclamation marks (!).
    // aeiouyAEIOUY is a vowel.
    [TestClass]
    public class ReplaceVowel
    {
        //Linq solution;
        public static string ReplaceVowel1(string s)
            => Regex.Replace(s, "[aeiouyAEIOUY]", "!", RegexOptions.IgnoreCase);


        public string ReplaceVowel2(string s)
        {
            return Regex.Replace(s, "[aeiouyAEIOUY]", "!", RegexOptions.IgnoreCase);
        }

        public string ReplaceVowel3(string s)
        {
            string vowels = "aeiouyAEIOUY";

            foreach (char vowel in vowels)
            {
                s = s.Replace(vowel, '!');
            }
            return s;
        }

        [TestMethod]
        public void TestMethod()
        {
            Assert.AreEqual("H!!", ReplaceVowel1("Hi!"));
            Assert.AreEqual("!H!! H!!", ReplaceVowel1("!Hi! Hi!"));
            Assert.AreEqual("!!!!!", ReplaceVowel1("aeiou"));
            Assert.AreEqual("!BCD!", ReplaceVowel1("ABCDE"));
        }

        [TestMethod]
        public void TestMethod4()
        {
            Assert.AreEqual("H!!", ReplaceVowel2("Hi!"));
            Assert.AreEqual("!H!! H!!", ReplaceVowel2("!Hi! Hi!"));
            Assert.AreEqual("!BCD!", ReplaceVowel2("ABCDE"));            
            Assert.AreEqual("!!!!!", ReplaceVowel2("aeiou"));
        }

        [TestMethod]
        public void TestMethod8()
        {
            Assert.AreEqual("H!!", ReplaceVowel3("Hi!"));
            Assert.AreEqual("!H!! H!!", ReplaceVowel3("!Hi! Hi!"));
            Assert.AreEqual("!!!!!", ReplaceVowel3("aeiou"));
            Assert.AreEqual("!BCD!", ReplaceVowel3("ABCDE"));
        }
    }
}
