using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Kata description
//Number of people in the bus
//There is a bus moving in the city, and it takes and drop some people in each bus stop.

//You are provided with a list(or array) of integer arrays(or tuples). Each integer array has two items which represent number of people get into bus(The first item) and number of people get off the bus(The second item) in a bus stop.

//Your task is to return number of people who are still in the bus after the last bus station(after the last array). Even though it is the last bus stop, the bus is not empty and some people are still in the bus, and they are probably sleeping there :D

//Take a look on the test cases.

//Please keep in mind that the test cases ensure that the number of people in the bus is always >= 0. So the return integer can't be negative.


//The second value in the first integer array is 0, since the bus is empty in the first bus stop.

namespace TestKata
{

    [TestClass]
    public class BusStatus
    {
        ////Linq sulution:

        //public static int Number(List<int[]> peopleListInOut)
        //{
        //    return peopleListInOut.Sum(Item => Item[0] - Item[1]);
        //}

        // Note: that the Linq solution does not exclude negative integers.

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

        // Note that the solution above does not exclude negative integers.

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
