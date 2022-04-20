using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Codewars
{
    /// <summary>
    /// Complete the solution so that it strips all text that follows any of a set of comment markers passed in.
    /// Any whitespace at the end of the line should also be stripped out.
    /// 
    /// Example:
    /// Given an input string of:
    /// apples, pears # and bananas
    /// grapes
    /// bananas !apples
    ///
    /// The output expected would be:
    /// apples, pears
    /// grapes
    /// bananas
    ///
    /// The code would be called like so:
    /// string stripped = StripCommentsSolution.StripComments("apples, pears # and bananas\ngrapes\nbananas !apples", new [] { "#", "!" })
    /// // result should == "apples, pears\ngrapes\nbananas"
    ///
    /// Link to the Kata:
    /// https://www.codewars.com/kata/51c8e37cee245da6b40000bd
    /// </summary>
    [TestClass]
    public class StripComments
    {
        ///// <summary>
        ///// My solution to the Kata
        ///// </summary>
        ///// <param name="text">Text input</param>
        ///// <param name="commentSymbols">Symbols to strip from the input text.</param>
        ///// <returns></returns>
        //public static string StripComments0(string text, string[] commentSymbols)
        //{
        //    string[] stringArray = text.Split('\n');
        //    for (var i = 0; i < stringArray.Length; i++)
        //    {
        //        for (var j = 0; j < commentSymbols.Length; j++)
        //        {
        //            stringArray[i] = stringArray[i].Split(commentSymbols[j])[0].TrimEnd();
        //        }
        //    }
        //    return string.Join("\n", stringArray);
        //}

        /// <summary>
        /// Solution from Codewars
        /// </summary>
        /// <param name="text">Text input.</param>
        /// <param name="commentSymbols">Symbols to strip from the input text.</param>
        /// <returns></returns>
        public string StripComments1(string text, string[] commentSymbols)
        {
            string[] lines = text.Split('\n');
            for (var i = 0; i < lines.Length; i++)
            {
                for (var j = 0; j < commentSymbols.Length; j++)
                {
                    int index = lines[i].IndexOf(commentSymbols[j]);
                    if (index >= 0)
                    {
                        lines[i] = lines[i].Substring(0, index);
                    }
                }

                lines[i] = lines[i].TrimEnd();
            }
            return string.Join("\n", lines);
        }

        /// <summary>
        /// Solution from Codewars.
        /// </summary>
        /// <param name="text">Text input.</param>
        /// <param name="commentSymbols">Symbols to strip from the text input.</param>
        /// <returns></returns>
        public string StripComments2(string text, string[] commentSymbols)
        {
            string[] lines = text.Split(new[] { "\n" }, StringSplitOptions.None);
            lines = lines.Select(x => x.Split(commentSymbols, StringSplitOptions.None).First().TrimEnd()).ToArray();
            return string.Join("\n", lines);
        }

        //[TestMethod]
        //public void TestMethod0()
        //{
        //    Assert.AreEqual("apples, pears\ngrapes\nbananas", StripComments0("apples, pears # and bananas\ngrapes\nbananas !apples", new string[] { "#", "!" }));
        //    Assert.AreEqual("a\nc\nd", StripComments0("a #b\nc\nd $e f g", new string[] { "#", "$" }));
        //}

        /// <summary>
        /// Solution from Codewars.
        /// </summary>
        /// <param name="text">Raw input text.</param>
        /// <param name="commentSymbols">The symbols to strip from the input text.</param>
        /// <returns></returns>
        public string StringComments3(string text, string[] commentSymbols)
        {
            return Regex.Replace(text, $@"(\ +(?=(\n|\r?$))|[ ]*[{ String.Concat(commentSymbols) }].*)", "");
        }

        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual("apples, pears\ngrapes\nbananas", StripComments1("apples, pears # and bananas\ngrapes\nbananas !apples", new string[] { "#", "!" }));
            Assert.AreEqual("a\nc\nd", StripComments1("a #b\nc\nd $e f g", new string[] { "#", "$" }));
        }

        [TestMethod]
        public void TestMethod2()
        {
            Assert.AreEqual("apples, pears\ngrapes\nbananas", StripComments2("apples, pears # and bananas\ngrapes\nbananas !apples", new string[] { "#", "!" }));
            Assert.AreEqual("a\nc\nd", StripComments2("a #b\nc\nd $e f g", new string[] { "#", "$" }));
        }

        [TestMethod]
        public void TestMethod3()
        {
            Assert.AreEqual("apples, pears\ngrapes\nbananas", StripComments2("apples, pears # and bananas\ngrapes\nbananas !apples", new string[] { "#", "!" }));
            Assert.AreEqual("a\nc\nd", StripComments2("a #b\nc\nd $e f g", new string[] { "#", "$" }));
        }
    }
}