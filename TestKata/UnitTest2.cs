using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestKata
{
//<summary>
//Your function takes two arguments:
//current father's age (years)
//current age of his son(years)
//Сalculate how many years ago the father was twice as old as his son(or in how many years he will be twice as old).
//</summary>

    [TestClass]
    public class UnitTest2
    {
        //linq solution:
        //public static int TwiceAsOld(int dadYears, int sonYears) => Math.Abs(dadYears - (sonYears * 2));

        static int diff = 0;
        int TwiceAsOld(int dadYears, int sonYears)
        {
            diff = 0;
            diff = ((sonYears * 2) - dadYears);
            if (diff > 0)  // if the difference is bigger than 0 it returns diff withput any changes.
            {
                return diff;
            }
            else
            {
                return diff * -1; // if "diff" is smaller than negative (below 0) it multiplys by -1 to change the number to positiive.
            }

        }

        [TestMethod]
        public void Test1()
        {
            Assert.AreEqual(30, TwiceAsOld(30, 0));
            Assert.AreEqual(16, TwiceAsOld(30, 7));
            Assert.AreEqual(15, TwiceAsOld(45, 30));
        }
        [TestMethod]
        public void Test2()
        {
            Assert.AreEqual(30, TwiceAsOld(30, 0));
        }
    }
        
}
