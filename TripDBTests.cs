using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Tests
{
    [TestClass()]
    public class TripDBTests
    {
        [TestMethod()]
        public void TripDBTest()
        {
            TripDB tripDB = new TripDB();
            int p = tripDB.getNoOfPayer();
            int n = tripDB.getNoOfTrip();
            Assert.AreEqual(p, 0);
            Assert.AreEqual(n, 0);
        }

        [TestMethod()]
        public void addTripTest()
        {
            TripDB tripDB = new TripDB();
            int before = tripDB.getNoOfTrip();
            int tripID= tripDB.addTrip(3);
            int after = tripDB.getNoOfTrip();
            Assert.AreEqual(before + 1, after);
            Assert.AreEqual(tripID, before);
        }

        [TestMethod()]
        public void addPayerTest()
        {
            TripDB tripDB = new TripDB();
            int tripID = tripDB.addTrip(2);
            int payerId1= tripDB.addPayer(tripID, 0, 1);
            int payerId2 = tripDB.addPayer(tripID, 1, 1);
            Assert.AreEqual(payerId1 + 1, payerId2);
        }

        [TestMethod()]
        public void getNoOfTripTest()
        {
            TripDB tripDB = new TripDB();
            int tripID = tripDB.addTrip(3);
            int n = tripDB.getNoOfTrip();
            Assert.AreEqual(n , 1);
        }

        [TestMethod()]
        public void getNoOfPayerTest()
        {
            TripDB tripDB = new TripDB();
            int tripID = tripDB.addTrip(3);
            int payerId1 = tripDB.addPayer(tripID, 0, 1);
            int payerId2 = tripDB.addPayer(tripID, 1, 1);
            int payerId3 = tripDB.addPayer(tripID, 2, 1);
            int p = tripDB.getNoOfPayer();
            Assert.AreEqual(p, 3);
        }

        [TestMethod()]
        public void getPriceArrayTest()
        {
            TripDB tripDB = new TripDB();
            int tripID = tripDB.addTrip(1);
            int payerId1 = tripDB.addPayer(tripID, 0, 3);
            tripDB.addPrice(payerId1, 0, 1.0);
            tripDB.addPrice(payerId1, 1, 2.0);
            tripDB.addPrice(payerId1, 2, 3.0);
            double[] priceArray = tripDB.getPriceArray(payerId1);
            double[] input = new double[] { 1.0, 2.0, 3.0 };
            CollectionAssert.AreEqual(input, priceArray);
        }

        [TestMethod()]
        public void getPayerArrayTest()
        {
            TripDB tripDB = new TripDB();
            int tripID = tripDB.addTrip(3);
            int payerId1 = tripDB.addPayer(tripID, 0, 1);
            int payerId2 = tripDB.addPayer(tripID, 1, 1);
            int payerId3 = tripDB.addPayer(tripID, 2, 1);
            int[] input = new int[] { payerId1, payerId2, payerId3};
            int[] payers= tripDB.getPayerArray(tripID);
            CollectionAssert.AreEqual(input, payers);
        }

        [TestMethod()]
        public void getTripAverageTest()
        {
            TripDB tripDB = new TripDB();
            int tripID = tripDB.addTrip(3);
            int payerId1 = tripDB.addPayer(tripID, 0, 1);
            int payerId2 = tripDB.addPayer(tripID, 1, 1);
            int payerId3 = tripDB.addPayer(tripID, 2, 1);
            tripDB.addPrice(payerId1, 0, 5.0);
            tripDB.addPrice(payerId2, 0, 10.0);
            tripDB.addPrice(payerId3, 0, 15.0);
            double average = tripDB.getTripAverage(tripID);
            Assert.AreEqual(average, 10.0);
        }

        [TestMethod()]
        public void getPayersRemainTest()
        {
            TripDB tripDB = new TripDB();
            int tripID = tripDB.addTrip(3);
            int payerId1 = tripDB.addPayer(tripID, 0, 1);
            int payerId2 = tripDB.addPayer(tripID, 1, 1);
            int payerId3 = tripDB.addPayer(tripID, 2, 1);
            tripDB.addPrice(payerId1, 0, 5.0);
            tripDB.addPrice(payerId2, 0, 10.0);
            tripDB.addPrice(payerId3, 0, 15.0);
            double[] remains = tripDB.getPayersRemain(tripID);
            double[] input = new double[] {5.0, 0, -5.0};
            CollectionAssert.AreEqual(input, remains);
        }
    }
}