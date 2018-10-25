using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestKata
{

    [TestClass]
    public class UnitTest1
    {
        //Linq sulution:
        //
        //public static int Number(List<int[]> peopleListInOut)
        //{
        //    return peopleListInOut.Sum(Item => Item[0] - Item[1]);
        //}

        static public int counter = 0;
        static int[] busStop = new int[] { };
        private int Number(List<int[]> peopleListInOut)
        {
            counter = 0;
            for (int i = 0; i < peopleListInOut.Count; i++)
            {
                busStop = peopleListInOut[i];

                counter = counter + busStop[0];
                counter = counter - busStop[1];
            }
            return counter;
        }

        [TestMethod]
        public void FirstTest()
        {
            List<int[]> peopleList = new List<int[]>()
            {
                new []{10,0},
                new []{3,5},
                new []{5,8}
            };
            Assert.AreEqual(5, Number(peopleList));
        }

        

        [TestMethod]
        public void SecondTest()
        {
            List<int[]> peopleList = new List<int[]>()
            {
                new []{3,0},
                new []{9,1},
                new []{4,10},
                new []{12,2},
                new []{6,1},
                new []{7,10}
            };
            Assert.AreEqual(17, Number(peopleList));
        }
        [TestMethod]
        public void ThridTest()
        {
            List<int[]> peopleList = new List<int[]>()
            {
                new []{3,0},
                new []{9,1},
                new []{4,8},
                new []{12,2},
                new []{6,1},
                new []{7,8}
            };
            Assert.AreEqual(21, Number(peopleList));
        }
    }
}
