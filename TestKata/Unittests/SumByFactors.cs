using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace TestKata.Unittests
{
    /// <summary>
    /// Given an array of positive or negative integers
    /// 
    /// I= [i1,..,in]
    /// 
    /// you have to produce a sorted array P of the form
    /// [[p, sum of all ij of I for which p is a prime factor(p positive) of ij]...]
    /// 
    /// P will be sorted by increasing order of the prime numbers.The final result has to be given as a string in Java, C#, C, C++ and as an array of arrays in other languages.
    /// 
    /// Example:
    /// I = { 12, 15}; // result = "(2 12)(3 27)(5 15)"
    /// [2, 3, 5] is the list of all prime factors of the elements of I, hence the result.
    /// 
    /// Notes:
    /// It can happen that a sum is 0 if some numbers are negative!
    /// Example: I = [15, 30, -45] 5 divides 15, 30 and(-45) so 5 appears in the result, the sum of the numbers for which 5 is a factor is 0 so we have[5, 0] in the result amongst others.
    /// In Fortran - as in any other language - the returned string is not permitted to contain any redundant trailing whitespace: you can use dynamically allocated character strings.
    /// 
    /// Link to Kata: https://www.codewars.com/kata/54d496788776e49e6b00052f/csharp
    /// </summary>
    [TestClass]
    public class SumByFactors
    {
        public static bool IsPrime(int n)
        {
            if (n <= 1) return false;
            if (n <= 3) return true;
            if (n % 2 == 0 || n % 3 == 0) return false;
            for (int i = 5; i * i <= n; i += 6)
            {
                if (n % i == 0 || n % (i + 2) == 0) return false;
            }
            return true;
        }

        public static List<int> PrimeFactors(int n)
        {
            List<int> factors = new List<int>();
            if (n < 0) n = -n;
            for (int i = 2; i * i <= n; i++)
            {
                while (n % i == 0)
                {
                    if (IsPrime(i))
                    {
                        factors.Add(i);
                    }
                    n /= i;
                }
            }
            if (n > 1 && IsPrime(n))
            {
                factors.Add(n);
            }
            return factors;
        }

        public static string sumOfDivided0(int[] I)
        {
            Dictionary<int, int> primeSumMap = new Dictionary<int, int>();

            foreach (int num in I)
            {
                HashSet<int> primeFactors = new HashSet<int>(PrimeFactors(num));
                foreach (int prime in primeFactors)
                {
                    if (!primeSumMap.ContainsKey(prime))
                    {
                        primeSumMap[prime] = 0;
                    }
                    primeSumMap[prime] += num;
                }
            }

            List<int> primes = primeSumMap.Keys.ToList();
            primes.Sort();

            StringBuilder result = new StringBuilder();
            foreach (int prime in primes)
            {
                result.Append("(").Append(prime).Append(" ").Append(primeSumMap[prime]).Append(")");
            }

            return result.ToString();
        }

        public static void Main(string[] args)
        {
            int[] I = { 12, 15 };
            Console.WriteLine(sumOfDivided0(I));

            int[] I2 = { 15, 30, -45 };
            Console.WriteLine(sumOfDivided0(I2));
        }

        public static string sumOfDivided1(int[] l)
        {
            string result = "";
            List<int> primes = new List<int>();
            for (int i = 2; i <= l.Max(Math.Abs); i++)
                if (primes.All(e => i % e != 0) && l.Any(e => e % i == 0))
                {
                    primes.Add(i);
                    result += $"({i} {l.Where(e => Math.Abs(e) % i == 0).Sum()})";
                }
            return result;
        }

        [TestMethod]
        public void Test1()
        {
            int[] lst = new int[] { 12, 15 };
            Assert.AreEqual("(2 12)(3 27)(5 15)", sumOfDivided0(lst));
        }

        [TestMethod]
        public void Test2()
        {
            int[] lst = new int[] { 12, 15 };
            Assert.AreEqual("(2 12)(3 27)(5 15)", sumOfDivided1(lst));
        }
    }
}
