using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodewarsKatas_MSTestPro
{
    /// <summary>
    /// Description:
    /// In mathematics, Pascal's triangle is a triangular array of the binomial coefficients expressed with formula
    /// where n denotes a row of the triangle, and k is a position of a term in the row.
    /// Task
    /// Write a function that, given a depth n, returns n top rows of Pascal's Triangle flattened into a one-dimensional list/array.
    /// Example:
    /// n = 1: [1]
    /// n = 2: [1,  1, 1]
    /// n = 4: [1,  1, 1,  1, 2, 1,  1, 3, 3, 1]
    /// Note
    /// Beware of overflow.Requested terms of a triangle are guaranteed to fit into the returned type, but depending on seleced method of calculations, intermediate values can be larger.
    /// 
    /// Link to kata:
    /// https://www.codewars.com/kata/5226eb40316b56c8d500030f
    /// </summary>
    [TestClass]
    public class PascalTriangleCalculator
    {
        /// <summary>
        /// My own solution for the Codekata
        /// </summary>
        /// <param name="n">The depth of the pascal triangle.</param>
        /// <returns>The values inside the Pascal triangle flattened in a list<int>.</int></returns>
        public List<int> PascalsTriangle0(int n)
        {
            List<int> pascalsTriangle = new List<int>();

            pascalsTriangle.Add(1);

            for (int i = 1; i < n; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    if (j == 0 || j == i)
                    {
                        pascalsTriangle.Add(1);
                    }
                    else
                    {
                        pascalsTriangle.Add(pascalsTriangle[pascalsTriangle.Count - i] + pascalsTriangle[pascalsTriangle.Count - (i + 1)]);
                    }
                }
            }
            return pascalsTriangle;
        }

        /// <summary>
        /// Solution from codewars
        /// </summary>
        /// <param name="n">The depth of the pascal triangle.</param>
        /// <returns>Returns a list<int> of the the values in the pascal triangle.</returns>
        public static List<int> PascalsTriangle1(int n)
        {
            if (n < 1) return null;
            var workingList = new List<int> { 1 };
            var result = new List<int>(workingList);

            for (int i = 1; i < n; i++)
            {
                var addend = new List<int> { 0 };
                addend.AddRange(workingList);
                workingList.Add(0);
                workingList = workingList.Zip(addend, (a, b) => a + b).ToList();
                result.AddRange(workingList);
            }

            return result;
        }

        [TestMethod]
        public void Testmethod0()
        {
            CollectionAssert.AreEqual(new List<int> { 1, 1, 1 }, PascalsTriangle0(2));
            CollectionAssert.AreEqual(new List<int> { 1, 1, 1, 1, 2, 1, 1, 3, 3, 1 }, PascalsTriangle0(4));
        }

        [TestMethod]
        public void Testmethod1()
        {
            CollectionAssert.AreEqual(new List<int> { 1, 1, 1 }, PascalsTriangle1(2));
            CollectionAssert.AreEqual(new List<int> { 1, 1, 1, 1, 2, 1, 1, 3, 3, 1 }, PascalsTriangle1(4));
        }
    }
}