using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestKata.Unittests
{
    /// <summary>
    /// In this kata, your task is to create all permutations of a non-empty input string and remove duplicates, if present.
    /// Create as many "shufflings" as you can!
    /// 
    /// Examples:
    /// 
    /// With input 'a':
    /// Your function should return: ['a']
    /// 
    /// With input 'ab':
    /// Your function should return ['ab', 'ba']
    /// 
    /// With input 'abc':
    /// Your function should return ['abc', 'acb', 'bac', 'bca', 'cab', 'cba']
    /// 
    /// With input 'aabb':
    /// Your function should return ['aabb', 'abab', 'abba', 'baab', 'baba', 'bbaa']
    /// Note: The order of the permutations doesn't matter.
    /// 
    /// Good luck!
    /// 
    /// Link to Kata: https://www.codewars.com/kata/5254ca2719453dcc0b00027d
    /// </summary>
    public class ManyPermutations
    {
        /// <summary>
        /// My first solution for this Kata. USING LINQ.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static List<string> SinglePermutations0(string s)
        {
            return GetPermutations(s)
              .Distinct()
              .ToList();
        }

        private static IEnumerable<string> GetPermutations(string str)
        {
            if (str.Length == 1)
                return new List<string> { str };

            return str.Select((c, i) =>
                              GetPermutations(str.Remove(i, 1))
                              .Select(p => c + p))
                              .SelectMany(x => x);
        }

        /// <summary>
        /// My second solution for this Kata NOT using LINQ.
        /// </summary>
        public static List<string> SinglePermutations1(string s)
        {
            var results = new HashSet<string>();
            Permute(s.ToCharArray(), 0, results);
            return new List<string>(results);
        }

        private static void Permute(char[] chars, int start, HashSet<string> results)
        {
            if (start == chars.Length - 1)
            {
                results.Add(new string(chars));
                return;
            }

            var seen = new HashSet<char>();
            for (int i = start; i < chars.Length; i++)
            {
                if (seen.Contains(chars[i])) continue;
                seen.Add(chars[i]);

                Swap(chars, start, i);
                Permute(chars, start + 1, results);
                Swap(chars, start, i);
            }
        }

        private static void Swap(char[] arr, int i, int j)
        {
            if (i == j) return;
            char temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

        /// <summary>
        /// Solution for Codewars
        /// </summary>
        public static List<string> SinglePermutations2(string s)
        {
            if (s.Length < 2)
            {
                return new List<string> { s };
            }
            var result = new HashSet<string>();
            foreach (var sub in SinglePermutations2(s.Substring(1)))
            {
                for (int i = 0; i <= sub.Length; i++)
                {
                    result.Add(sub.Substring(0, i) + s[0] + sub.Substring(i));
                }
            }
            return result.ToList();
        }

        /// <summary>
        /// Solution from Codewars
        /// </summary>
        public static List<string> SinglePermutations3(string s) => $"{s}".Length < 2 ?
            new List<string> { s } :
            SinglePermutations3(s.Substring(1))
            .SelectMany(x => Enumerable.Range(0, x.Length + 1)
            .Select((_, i) => x.Substring(0, i) + s[0] + x.Substring(i)))
            .Distinct()
            .ToList();


        [Test, Order(1)]
        public void TestMethod0()
        {
            Assert.That(SinglePermutations0("a").OrderBy(x => x).ToList(), Is.EqualTo(new List<string> { "a" }));
            Assert.That(SinglePermutations0("ab").OrderBy(x => x).ToList(), Is.EqualTo(new List<string> { "ab", "ba" }));
            Assert.That(SinglePermutations0("aabb").OrderBy(x => x).ToList(), Is.EqualTo(new List<string> { "abab", "abba", "baba", "bbaa", "baab", "aabb" }));
        }

        [Test, Order(2)]
        public void TestMethod2()
        {
            Assert.That(SinglePermutations1("a").OrderBy(x => x).ToList(), Is.EqualTo(new List<string> { "a" }));
            Assert.That(SinglePermutations1("ab").OrderBy(x => x).ToList(), Is.EqualTo(new List<string> { "ab", "ba" }));
            Assert.That(SinglePermutations1("aabb").OrderBy(x => x).ToList(), Is.EqualTo(new List<string> { "abab", "abba", "baba", "bbaa", "baab", "aabb" }));
        }

        [Test, Order(3)]
        public void TestMethod3()
        {
            Assert.That(SinglePermutations2("a").OrderBy(x => x).ToList(), Is.EqualTo(new List<string> { "a" }));
            Assert.That(SinglePermutations2("ab").OrderBy(x => x).ToList(), Is.EqualTo(new List<string> { "ab", "ba" }));
            Assert.That(SinglePermutations2("aabb").OrderBy(x => x).ToList(), Is.EqualTo(new List<string> { "abab", "abba", "baba", "bbaa", "baab", "aabb" }));
        }

        [Test, Order(4)]
        public void TestMethod4()
        {
            Assert.That(SinglePermutations3("a").OrderBy(x => x).ToList(), Is.EqualTo(new List<string> { "a" }));
            Assert.That(SinglePermutations3("ab").OrderBy(x => x).ToList(), Is.EqualTo(new List<string> { "ab", "ba" }));
            Assert.That(SinglePermutations3("aabb").OrderBy(x => x).ToList(), Is.EqualTo(new List<string> { "abab", "abba", "baba", "bbaa", "baab", "aabb" }));
        }
    }
}
