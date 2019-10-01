using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace TestKata.Unittests
{
    /// <summary>
    /// #Find the missing letter
    /// Write a method that takes an array of consecutive (increasing) letters as input and that returns the missing letter in the array.
    /// You will always get an valid array. And it will be always exactly one letter be missing. The length of the array will always be at least 2.
    /// The array will always contain letters in only one case.
    /// 
    /// Example:
    /// ["a","b","c","d","f"] -> "e"
    /// ["O","Q","R","S"] -> "P"
    /// (Use the English alphabet with 26 letters!)    /// 
    /// </summary>

    [TestClass]
    public class MissingLetter
    {
        // My solution
        public char MissingLetter1(char[] array)
        {
            Func<char[], char> f =
                s => { for (int i = 0; s[++i] == ++s[0];) {; } return s[0]; };
            char letter = f(array);
            return letter;
        }

        public char MissingLetter2(char [] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i + 1] - array[i] > 1)
                {
                    return (char)(array[i] + 1);
                }
            }
            return ' ';
        }

        // Linq solution
        public char MissingLetter3(char[] array) => (char)Enumerable.Range(array[0], 25).First(x => !array.Contains((char)x));

        public char MissingLetter4(char[] array)
        {
            char m = array.First(), n = array.Last();
            return (char)(n * (n + 1) / 2 - (m - 1) * m / 2 - array.Sum(c => c));
        }

        public char MissingLetter5(char[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] - array[i - 1] != 1)
                    return (char)(array[i - 1] + 1);
            }
            return (char)0;
        }

        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual('e', MissingLetter1(new[] { 'a', 'b', 'c', 'd', 'f' }));
            Assert.AreEqual('P', MissingLetter1(new[] { 'O', 'Q', 'R', 'S' }));
        }

        [TestMethod]
        public void TestMethod2()
        {
            Assert.AreEqual('e', MissingLetter2(new[] { 'a', 'b', 'c', 'd', 'f' }));
            Assert.AreEqual('P', MissingLetter2(new[] { 'O', 'Q', 'R', 'S' }));
        }

        [TestMethod]
        public void TestMethod3()
        {
            Assert.AreEqual('e', MissingLetter3(new[] { 'a', 'b', 'c', 'd', 'f' }));
            Assert.AreEqual('P', MissingLetter3(new[] { 'O', 'Q', 'R', 'S' }));
        }

        [TestMethod]
        public void TestMethod4()
        {
            Assert.AreEqual('e', MissingLetter4(new[] { 'a', 'b', 'c', 'd', 'f' }));
            Assert.AreEqual('P', MissingLetter4(new[] { 'O', 'Q', 'R', 'S' }));
        }

        [TestMethod]
        public void TestMethod5()
        {
            Assert.AreEqual('e', MissingLetter5(new[] { 'a', 'b', 'c', 'd', 'f' }));
            Assert.AreEqual('P', MissingLetter5(new[] { 'O', 'Q', 'R', 'S' }));
        }
    }
}
