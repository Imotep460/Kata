using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace TestKata.Unittests
{
    /// <summary>
    /// In a small town the population is p0 = 1000 at the beginning of a year.
    /// The population regularly increases by 2 percent per year and
    /// moreover 50 new inhabitants per year come to live in the town.
    /// How many years does the town need to see its population greater or equal to p = 1200 inhabitants?
    /// 
    /// At the end of the first year there will be:
    /// 1000 + 1000 * 0.02 + 50 => 1070 inhabitants
    /// At the end of the 2nd year there will be: 
    /// 1070 + 1070 * 0.02 + 50 => 1141 inhabitants(number of inhabitants is an integer)
    /// At the end of the 3rd year there will be:
    /// 1141 + 1141 * 0.02 + 50 => 1213
    /// It will need 3 entire years.
    /// 
    /// More generally given parameters:
    /// p0, percent, aug (inhabitants coming or leaving each year), p (population to surpass)
    /// the function nb_year should return n number of entire years needed to get a population greater or equal to p.
    /// aug is an integer, percent a positive or null number, p0 and p are positive integers (> 0)
    /// 
    /// Examples:
    /// nb_year(1500, 5, 100, 5000) -> 15
    /// nb_year(1500000, 2.5, 10000, 2000000) -> 10
    /// 
    /// Note: Don't forget to convert the percent parameter as a percentage in the body of your function: if the parameter percent is 2 you have to convert it to 0.02.
    /// </summary>

    [TestClass]
    public class PopulationGrowth
    {
        private static void testing(int actual, int expected)
        {
            Assert.AreEqual(expected, actual);
        }

        // My solution
        public int PopulationGrowth1(int p0, double percent, int aug, int p)
        {
            int n = 0;
            percent = percent / 100;
            while (p0 < p)
            {
                p0 = (int)(p0 + (p0 * percent) + aug);
                n++;
            }
            return n;
        }

        // Extra solutions
        public int PopulationGrowth2(int p0, double percent, int aug, int p)
        {
            int year;
            for (year = 0; p0 < p; year++)
                p0 += (int)(p0 * percent / 100) + aug;
            return year;
        }

        public int PopulationGrowth3(int p0, double percent, int aug, int p)
        {
            int n = 0;
            percent = percent / 100;
            while (p0 < p)
            {
                p0 += (int)(p0 * percent + aug);
                n++;
            }
            return n;
        }

        [TestMethod]
        public void TestMethod1()
        {
            Console.WriteLine("Testing PopulationGrowth1");
            testing(PopulationGrowth1(1500, 5, 100, 5000), 15);
            testing(PopulationGrowth1(1500000, 2.5, 10000, 2000000), 10);
            testing(PopulationGrowth1(1500000, 0.25, 1000, 2000000), 94);
        }

        [TestMethod]
        public void TestMethod2()
        {
            Console.WriteLine("Testing PopulationGrowth2");
            testing(PopulationGrowth2(1500, 5, 100, 5000), 15);
            testing(PopulationGrowth2(1500000, 2.5, 10000, 2000000), 10);
            testing(PopulationGrowth2(1500000, 0.25, 1000, 2000000), 94);
        }

        [TestMethod]
        public void TestMethod3()
        {
            Console.WriteLine("Testing PopulationGrowth2");
            testing(PopulationGrowth3(1500, 5, 100, 5000), 15);
            testing(PopulationGrowth3(1500000, 2.5, 10000, 2000000), 10);
            testing(PopulationGrowth3(1500000, 0.25, 1000, 2000000), 94);
        }
    }
}
