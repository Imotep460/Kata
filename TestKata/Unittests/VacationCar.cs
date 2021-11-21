using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestKata.Unittests
{
    /// <summary>
    /// After a hard quarter in the office you decide to get some rest on a vacation. So you will book a flight for you and your girlfriend and try to leave all the mess behind you.
    /// You will need a rental car in order for you to get around in your vacation.The manager of the car rental makes you some good offers.
    /// Every day you rent the car costs $40. If you rent the car for 7 or more days, you get $50 off your total.Alternatively, if you rent the car for 3 or more days, you get $20 off your total.
    /// Write a code that gives out the total amount for different days(d).
    /// </summary>
    [TestClass]
    public class VacationCar
    {
        /// <summary>
        /// Calculate total cost for renting a car.
        /// </summary>
        /// <param name="d">The days the car will need to be rented for.</param>
        /// <returns>Total cost of renting the car.</returns>
        public int RentalCarCost(int d)
        {
            if(3 <= d && d < 7)
            {
                return (d * 40) - 20;
            }
            else if (d >= 7)
            {
                return (d * 40) - 50;
            }
            else
            {
                return 40 * d;
            }
        }

        public int RentalCarCost2(int d)
        {
            return d * 40 - (d > 6 ? 50 : d > 2 ? 20 : 0);
        }

        public int RentalCarCost3(int d)
        {
            return d >= 7 ? d * 40 - 50 : d >= 3 ? d * 40 - 20 : d * 40;
        }

        /// <summary>
        /// Rent a car for 1 day
        /// </summary>
        [TestMethod]
        public void TestMethod0()
        {
            Assert.AreEqual(RentalCarCost(1), 40);
            Assert.AreEqual(RentalCarCost(3), 100);
            Assert.AreEqual(RentalCarCost(7), 230);
        }

        /// <summary>
        /// Rent a car for 1 day
        /// </summary>
        [TestMethod]
        public void TestMethod3()
        {
            Assert.AreEqual(RentalCarCost2(1), 40);
            Assert.AreEqual(RentalCarCost2(3), 100);
            Assert.AreEqual(RentalCarCost2(7), 230);
        }

        /// <summary>
        /// Rent a car for 1 day
        /// </summary>
        [TestMethod]
        public void TestMethod6()
        {
            Assert.AreEqual(RentalCarCost3(1), 40);
            Assert.AreEqual(RentalCarCost3(3), 100);
            Assert.AreEqual(RentalCarCost3(7), 230);
        }
    }
}