using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestKata
{
//Your function takes two arguments:
//current father's age (years)
//current age of his son(years)
//Сalculate how many years ago the father was twice as old as his son(or in how many years he will be twice as old).

    [TestClass]
    public class TwiceAsOld
    {
        // Javascrit solution:
        // function twiseAsOld(dadYearsOld, sonYearsOld) {
        //      return Math.abs((2 * sonYearsOld) - dadYearsOld);
        // }
        
        // const twiceAsOld = (d, s) => Math.abs(d - 2 * s);

        ////linq solution:
        //public static int TwiceAsOld(int dadYears, int sonYears) => Math.Abs(dadYears - (sonYears * 2));

        static int diff = 0;
        public static int twiceAsOld(int dadYears, int sonYears)
        {
            diff = 0;
            diff = ((sonYears * 2) - dadYears);
            if (diff > 0)  // if the difference is bigger than 0 it returns diff withput any changes.
            {
                return diff;
            }
            else
            {
                return diff * -1; // if "diff" is smaller than 0 ie: negative (below 0) it's multiplyed by -1 to change the number to positiive.
            }
        }

        [TestMethod]
        public void Test1()
        {
            Assert.AreEqual(30, twiceAsOld(30, 0));
            Assert.AreEqual(16, twiceAsOld(30, 7));
            Assert.AreEqual(15, twiceAsOld(45, 30));
        }
        [TestMethod]
        public void Test2()
        {
            Assert.AreEqual(30, twiceAsOld(30, 0));
        }
    }        
}
