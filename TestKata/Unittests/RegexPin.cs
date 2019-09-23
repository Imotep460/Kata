using System;
//using System.Text;
//using System.Collections.Generic;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using System.Text.RegularExpressions;

//namespace TestKata.Unittests
//{
//    /// <summary>
//    /// Summary description for RegexPin
//    /// </summary>
//    [TestClass]
//    public class RegexPin
//    {
//        public bool ValidatePin(string pin)
//        {
//            Regex regex = new Regex("^[0-9]{4,6}");
//        }

//        [TestMethod]
//        public void TestMethod1()
//        {
//            Assert.AreEqual(false, ValidatePin("1"), "Wrong output for \"1\"");
//            Assert.AreEqual(false, ValidatePin("12"), "Wrong output for \"12\"");
//            Assert.AreEqual(false, ValidatePin("123"), "Wrong output for \"123\"");
//            Assert.AreEqual(false, ValidatePin("12345"), "Wrong output for \"12345\"");
//            Assert.AreEqual(false, ValidatePin("1234567"), "Wrong output for \"1234567\"");
//            Assert.AreEqual(false, ValidatePin("-1234"), "Wrong output for \"-1234\"");
//            Assert.AreEqual(false, ValidatePin("1.234"), "Wrong output for \"1.234\"");
//            Assert.AreEqual(false, ValidatePin("-1.234"), "Wrong output for \"-1.234\"");
//            Assert.AreEqual(false, ValidatePin("00000000"), "Wrong output for \"00000000\"");
//        }
//    }
//}
