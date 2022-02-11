using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;

namespace CodewarsKatas_MSTestPro
{
    /// <summary>
    /// Description:
    /// How can you tell an extrovert from an introvert at NSA? Va gur ryringbef, gur rkgebireg ybbxf ng gur BGURE thl'f fubrf.
    /// I found this joke on USENET, but the punchline is scrambled.Maybe you can decipher it?
    /// According to Wikipedia, ROT13 (http://en.wikipedia.org/wiki/ROT13) is frequently used to obfuscate jokes on USENET.
    /// Hint: For this task you're only supposed to substitue characters. Not spaces, punctuation, numbers etc.
    /// 
    /// Test examples:
    /// rot13("EBG13 rknzcyr.") == "ROT13 example.";
    /// rot13("This is my first ROT13 excercise!" == "Guvf vf zl svefg EBG13 rkprepvfr!"
    /// 
    /// Link to codewars kata:
    /// https://www.codewars.com/kata/52223df9e8f98c7aa7000062
    /// </summary>
    [TestClass]
    public class Rot13Encryption
    {
        /// <summary>
        /// Uses ROT13 encryption teori to decrypt a string.
        /// </summary>
        /// <param name="codedMessage">The string being decrypted.</param>
        /// <returns>Returns a decrypted string.</returns>
        public string DecryptString0(string codedMessage)
        {
            char[] charArray = codedMessage.ToCharArray();

            for (int i = 0; i < charArray.Length; i++)
            {
                int number = (int)charArray[i];

                if (number >= 'a' && number <= 'z')
                {
                    if (number > 'm')
                    {
                        number -= 13;
                    }
                    else
                    {
                        number += 13;
                    }
                }
                else if (number >= 'A' && number <= 'Z')
                {
                    if (number > 'M')
                    {
                        number -= 13;
                    }
                    else
                    {
                        number += 13;
                    }
                }
                charArray[i] = (char)number;
            }
            return new string(charArray);
        }

        /// <summary>
        /// Linq solution from Codewars.
        /// </summary>
        /// <param name="input">the string being decrypted.</param>
        /// <returns>Returns a decrypted string.</returns>
        public string DecryptString1(string input)
        {
            var s1 = "NOPQRSTUVWXYZABCDEFGHIJKLMnopqrstuvwxyzabcdefghijklm";
            var s2 = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            return string.Join("", input.Select(x => char.IsLetter(x) ? s1[s2.IndexOf(x)] : x));
        }

        /// <summary>
        /// Regex solution from codewars.
        /// </summary>
        /// <param name="input">The string being decrypted.</param>
        /// <returns>Returns a decrypted string.</returns>
        public string DecryptString2(string input) =>
            Regex.Replace(input, "[a-zA-Z]", new MatchEvaluator(c => ((char)(c.Value[0] + (Char.ToLower(c.Value[0]) >= 'n' ? -13 : 13))).ToString()));

        /// <summary>
        /// Another Linq solution from Codewars.
        /// </summary>
        /// <param name="input">The string being decrypted.</param>
        /// <returns>Returns a decrypted string.</returns>
        public string DecryptString3(string input)
        {
            return new string(input.Select(x =>
            char.IsLetter(x) ? (char)((int)x + (char.ToUpper(x) < 'N' ? 13 : -13)) : x).ToArray());
        }

        [TestMethod]
        public void Testmethod0()
        {
            Assert.AreEqual("ROT13 example.", DecryptString0("EBG13 rknzcyr."));
        }

        [TestMethod]
        public void Testmethod1()
        {
            Assert.AreEqual("ROT13 example.", DecryptString1("EBG13 rknzcyr."));
        }

        [TestMethod]
        public void Testmethod2()
        {
            Assert.AreEqual("ROT13 example.", DecryptString2("EBG13 rknzcyr."));
        }

        [TestMethod]
        public void Testmethod3()
        {
            Assert.AreEqual("ROT13 example.", DecryptString3("EBG13 rknzcyr."));
        }
    }
}
