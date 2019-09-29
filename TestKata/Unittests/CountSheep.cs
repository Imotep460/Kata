using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace TestKata.Unittests
{
    /// <summary>
    /// Consider an array of sheep where some sheep may be missing from their place. We need a function that counts the number of sheep present in the array (true means present).
    /// For example,
    /// [true,  true,  true,  false,
    /// true,  true,  true,  true ,
    /// true,  false, true,  false,
    /// true,  false, false, true ,
    /// true,  true,  true,  true ,
    /// false, false, true,  true]
    /// The correct answer would be 17.
    /// Hint: Don't forget to check for bad values like null/undefined
    /// </summary>
 

    [TestClass]
    public class CountSheep
    {
        // Linq solution
        public int CountSheep1(bool[] sheeps) => sheeps.Where(c => c).Count();

        // Linq solution
        public int CountSheep2(bool[] sheeps)
        {
            return sheeps.Count(s => s);
        }

        // Ordinary solution
        public int CountSheep3(bool[] sheeps)
        {
            int count = 0;
            foreach (bool sheep in sheeps)
            {
                if(sheep)
                {
                    count++;
                }
            }
            return count;
        }

        [TestMethod]
        public void TestMethod1()
        {
            var sheeps = new bool[] { true, false, true };
            Assert.AreEqual(2, CountSheep1(sheeps));
        }

        [TestMethod]
        public void TestMethod2()
        {
            var sheeps = new bool[] { true, true, true, false,
                                      true, true, true, true,
                                      true, false, true, false,
                                      true, false, false, true,
                                      true, true, true, true,
                                      false, false, true, true };
            Assert.AreEqual(17, CountSheep1(sheeps));
        }

        [TestMethod]
        public void TestMethod3()
        {
            var sheeps = new bool[] { true, false, true };
            Assert.AreEqual(2, CountSheep2(sheeps));
        }

        [TestMethod]
        public void TestMethod4()
        {
            var sheeps = new bool[] { true, true, true, false,
                                      true, true, true, true,
                                      true, false, true, false,
                                      true, false, false, true,
                                      true, true, true, true,
                                      false, false, true, true };
            Assert.AreEqual(17, CountSheep2(sheeps));
        }

        [TestMethod]
        public void TestMethod5()
        {
            var sheeps = new bool[] { true, false, true };
            Assert.AreEqual(2, CountSheep3(sheeps));
        }

        [TestMethod]
        public void TestMethod6()
        {
            var sheeps = new bool[] { true, true, true, false,
                                      true, true, true, true,
                                      true, false, true, false,
                                      true, false, false, true,
                                      true, true, true, true,
                                      false, false, true, true };
            Assert.AreEqual(17, CountSheep3(sheeps));
        }
    }
}
