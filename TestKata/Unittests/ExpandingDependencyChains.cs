using System;
using System.Collections.Generic;
using NUnit.Framework;
using System.Linq;

namespace TestKata.Unittests
{
    /// <summary>
    /// Explanation:
    /// When building a program a file only needs to be compiled if it or one of its dependencies has changed since the last build.However,
    /// these changes can propogate upwards through dependencies.For example,
    /// if A is dependent on B, and B is dependent on C, then a change to C will require that all three files be recompiled.
    /// 
    /// For this kata you will be provided with a list of files along with their immediate dependencies.Your task is to determine all dependencies for every file in the list, and return those values.
    /// 
    /// Specification:
    /// Your code needs to accept as its input a Dictionary<string,
    /// string[]> The keys in the dictionary contain the names of the files you need to consider as strings.Each key (file) is mapped to an array of strings,
    /// each element of which represents a single direct dependency.A file with no dependencies is mapped to an empty array.
    /// The return from your method needs to follow the same format, a Dictionary<string,
    /// string[]> mapping file names to dependencies, but needs to include all the dependencies, not just the direct dependencies.
    /// 
    /// You will also need to check for circular dependencies. For example,
    /// if you have three files, A, B, and C, with A dependent on B, B dependent on C,
    /// and C dependent on A, there is a circular dependency.In such cases you should throw an InvalidOperationException.
    /// 
    /// Example:
    /// As input for our example I have provided a dictionary detailing 4 files, A, B, C, and D. A is dependent on B and D.B is dependent on C, and C and dependent on D.
    /// 
    /// "A" => ["B", "D"]
    /// "B" => ["C"]
    /// "C" => ["D"]
    /// "D" => [ ]
    /// 
    /// When we expand these out we come up with a new set up dependencies:
    /// 
    /// "A" => ["B", "C", "D"]
    /// "B" => ["C", "D"]
    /// "C" => ["D"]
    /// "D" => [ ]
    /// 
    /// Because B is dependent on C and, indirectly, D, those are added to A as well.The order isn't important in your results,
    /// but even files with no dependencies still need to remain in the list.
    /// 
    /// Link to Kata: https://www.codewars.com/kata/56293ae77e20756fc500002e
    /// </summary>
    public class ExpandingDependencyChains
    {
        public static Dictionary<string, string[]> ExpandDependencies(Dictionary<string, string[]> files)
        {
            var result = new Dictionary<string, string[]>();
            var visited = new HashSet<string>(); // Tracks fully explored nodes
            var currentPath = new HashSet<string>(); // Tracks the current DFS path to detect cycles

            foreach (var file in files.Keys)
            {
                if (!visited.Contains(file))
                {
                    ExploreDependencies(file, files, result, visited, currentPath);
                }
            }

            return result;
        }

        private static HashSet<string> ExploreDependencies(
            string file,
            Dictionary<string, string[]> files,
            Dictionary<string, string[]> result,
            HashSet<string> visited,
            HashSet<string> currentPath)
        {
            // Check for circular dependencies
            if (currentPath.Contains(file))
            {
                throw new InvalidOperationException("Circular dependency detected involving " + file);
            }

            // If already visited, return the cached result
            if (visited.Contains(file))
            {
                return new HashSet<string>(result[file]);
            }

            currentPath.Add(file);

            var allDependencies = new HashSet<string>();
            foreach (var dependency in files[file])
            {
                allDependencies.Add(dependency);
                var depDependencies = ExploreDependencies(dependency, files, result, visited, currentPath);
                allDependencies.UnionWith(depDependencies);
            }

            currentPath.Remove(file);

            // Mark this file as visited and cache its dependencies
            visited.Add(file);
            result[file] = allDependencies.ToArray();

            return allDependencies;
        }

        public static void Main(string[] args)
        {
            var files = new Dictionary<string, string[]>
        {
            { "A", new[] { "B", "D" } },
            { "B", new[] { "C" } },
            { "C", new[] { "D" } },
            { "D", new string[] { } }
        };

            try
            {
                var allDependencies = ExpandDependencies(files);
                foreach (var file in allDependencies.Keys)
                {
                    Console.WriteLine($"{file} => [{string.Join(", ", allDependencies[file])}]");
                }
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static Dictionary<string, string[]> ExpandDependencies1(Dictionary<string, string[]> d)
        {
            int old = -1;
            while (old != d.Values.Select(x => x.Length).Sum())
            {
                old = d.Values.Select(x => x.Length).Sum();
                var rs = new Dictionary<string, string[]>(d);
                foreach (var a in rs)
                {
                    var tmp = new List<string>(a.Value);
                    foreach (var b in a.Value) tmp.AddRange(d[b]);
                    if (tmp.Contains(a.Key)) throw new InvalidOperationException();
                    d[a.Key] = tmp.Distinct().ToArray();
                }
            }
            return d;
        }

        //[Test]
        //public void ExampleFromDescription()
        //{
        //    // Arrange
        //    var startFiles = new Dictionary<string, string[]>();
        //    startFiles["A"] = new string[] { "B", "D" };
        //    startFiles["B"] = new string[] { "C" };
        //    startFiles["C"] = new string[] { "D" };
        //    startFiles["D"] = new string[] { };

        //    var correctFiles = new Dictionary<string, string[]>();
        //    correctFiles["A"] = new string[] { "B", "C", "D" };
        //    correctFiles["B"] = new string[] { "C", "D" };
        //    correctFiles["C"] = new string[] { "D" };
        //    correctFiles["D"] = new string[] { };

        //    // Act
        //    var actualFiles = ExpandDependencies(startFiles);
        //    var errorMessage = "Expected:\n" + TestTools.Print(correctFiles) + "\nGot:\n" + TestTools.Print(actualFiles);

        //    // Assert
        //    Assert.IsTrue(TestTools.Match(actualFiles, correctFiles), errorMessage);
        //}

        //[Test]
        //public void TestEmptyFileList()
        //{
        //    // Arrange
        //    var startFiles = new Dictionary<string, string[]>();
        //    var correctFiles = new Dictionary<string, string[]>();

        //    // Act
        //    var actualFiles = ExpandDependencies(startFiles);
        //    var errorMessage = "Expected:\n" + TestTools.Print(correctFiles) + "\nGot:\n" + TestTools.Print(actualFiles);

        //    // Assert
        //    Assert.IsTrue(TestTools.Match(actualFiles, correctFiles), errorMessage);
        //}

        //[Test]
        //public void TestCircularDependencies()
        //{
        //    // Arrange
        //    var startFiles = new Dictionary<string, string[]>();
        //    startFiles["A"] = new string[] { "B" };
        //    startFiles["B"] = new string[] { "C" };
        //    startFiles["C"] = new string[] { "D" };
        //    startFiles["D"] = new string[] { "A" };

        //    // Act/Assert
        //    Assert.Throws(typeof(InvalidOperationException),
        //      delegate { ExpandDependencies(startFiles); },
        //      "A circular dependency should have thrown an InvalidOperationException.");
        //}
    }
}
