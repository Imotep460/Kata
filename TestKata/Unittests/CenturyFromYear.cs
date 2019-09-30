using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestKata.Unittests
{
    /// <summary>
    /// The first century spans from the year 1 up to and including the year 100, The second - from the year 101 up to and including the year 200, etc.
    /// 
    /// Task :
    /// Given a year, return the century it is in.
    /// 
    /// Input , Output Examples ::
    /// centuryFromYear(1705)  returns(18)
    /// centuryFromYear(1900)  returns(19)
    /// centuryFromYear(1601)  returns(17)
    /// centuryFromYear(2000)  returns(20)
    /// /// </summary>

    [TestClass]
    public class CenturyFromYear
    {
        public int CenturyFromYear1(int year)
        {
            return (int)(year / 100) + ((year % 100 == 0) ? 0 : 1);
        }

        public int CenturyFromYear2(int year) => (year - 1) / 100 + 1;

        public int CenturyFromYear3(int year)
        {
            return (year - 1) / 100 + 1;
        }

        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(18, CenturyFromYear1(1705));
            Assert.AreEqual(19, CenturyFromYear1(1900));
            Assert.AreEqual(17, CenturyFromYear1(1601));
            Assert.AreEqual(20, CenturyFromYear1(2000));
        }

        [TestMethod]
        public void TestMethod2()
        {
            Assert.AreEqual(18, CenturyFromYear2(1705));
            Assert.AreEqual(19, CenturyFromYear2(1900));
            Assert.AreEqual(17, CenturyFromYear2(1601));
            Assert.AreEqual(20, CenturyFromYear2(2000));
        }

        [TestMethod]
        public void TestMethod3()
        {
            Assert.AreEqual(18, CenturyFromYear3(1705));
            Assert.AreEqual(19, CenturyFromYear3(1900));
            Assert.AreEqual(17, CenturyFromYear3(1601));
            Assert.AreEqual(20, CenturyFromYear3(2000));
        }
    }
}
