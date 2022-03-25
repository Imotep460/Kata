using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodewarsKatas_MSTestPro
{
    /// <summary>
    /// Description:
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
    /// string stripped = StripCommentsSolution.StripComments("apples, pears # and bananas\ngrapes\nbananas !apples", new[] { "#", "!" })
    /// result should == "apples, pears\ngrapes\nbananas"
    /// 
    /// Link to Kata:
    /// https://www.codewars.com/kata/51c8e37cee245da6b40000bd
    /// </summary>
    [TestClass]
    public class StripComments
    {
        /// <summary>
        /// My solutio to the Kata "Strip Comments" from codewars.
        /// Method strips any comments from a string input, and returns it to the user.
        /// </summary>
        /// <param name="text">Raw input string that may or may not contain comments.</param>
        /// <param name="commentSymbols">The symbols marking that a comment is incomming.</param>
        /// <returns>Return the input string minus the comments and the comment defiers.</returns>
        //public string StripComments0(string text, string[] commentSymbols)
        //{
        //    string[] stringArray = text.Split('\n');
        //    for (var i = 0; i < stringArray.Length; i++)
        //    {
        //        for (var j = 0; j < commentSymbols.Length; j++)
        //        {
        //            stringArray[i] = stringArray[i].Split(commentSymbols[j])[0].Trim();
        //        }
        //    }
        //    return string.Join("\n", stringArray);
        //}

        //[TestMethod]
        //public void TestMethod0()
        //{
        //    Assert.AreEqual("apples, pears\ngrapes\nbananas", StripComments0("apples, pears # and bananas\ngrapes\nbananas !apples", new string[] { "#", "!" }));
        //    Assert.AreEqual("a\nc\nd", StripComments0("a #b\nc\nd $e f g", new string[] { "#", "$" }));
        //}
    }
}