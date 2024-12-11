using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Speedway.Test
{
    [TestClass]
    public class RiderTest
    {
        [TestMethod]
        public void TestConstructorIncreasesJerseyNumber()
        {
            Rider riderA = new Rider("Jason", "Crump");

            int jerseyNumber = riderA.JerseyNumber;

            Assert.AreEqual(jerseyNumber, riderA.JerseyNumber);

            Rider riderB = new Rider("Tomasz", "Gollob");

            Assert.AreEqual(jerseyNumber, riderA.JerseyNumber);
            Assert.AreEqual(jerseyNumber + 1, riderB.JerseyNumber);

            Rider riderC = new Rider("Tony", "Rickardsson");

            Assert.AreEqual(jerseyNumber, riderA.JerseyNumber);
            Assert.AreEqual(jerseyNumber + 1, riderB.JerseyNumber);
            Assert.AreEqual(jerseyNumber + 2, riderC.JerseyNumber);

            Rider riderD = new Rider("Nicki", "Pedersen");

            Assert.AreEqual(jerseyNumber, riderA.JerseyNumber);
            Assert.AreEqual(jerseyNumber + 1, riderB.JerseyNumber);
            Assert.AreEqual(jerseyNumber + 2, riderC.JerseyNumber);
            Assert.AreEqual(jerseyNumber + 3, riderD.JerseyNumber);
        }

            [TestMethod]
        public void TestConstructor()
        {
            Rider rider = new Rider("Jason", "Crump");

            Assert.AreEqual("Jason", rider.FirstName);
            Assert.AreEqual("Crump", rider.LastName);
            Assert.AreEqual(0.0, rider.Distance, 0.001);
        }

        [TestMethod]
        public void TestToString()
        {
            Rider rider = new Rider("Tony", "Rickardsson");
            int jerseyNumber = rider.JerseyNumber;

            Assert.AreEqual($"#{jerseyNumber} Rickardsson", rider.ToString());
        }

        [TestMethod]
        public void TestSetMotorcycle()
        {
            Rider rider = new Rider("Nicki", "Pedersen");

            Assert.AreEqual("Nicki", rider.FirstName);
            Assert.AreEqual("Pedersen", rider.LastName);
            Assert.AreEqual(0.0, rider.Distance, 0.001);
            Assert.AreEqual(null, rider.Motorcycle);

            Motorcycle motorcycle = new Motorcycle("Jawa", 70, 90);

            rider.Motorcycle = motorcycle;

            Assert.AreEqual("Nicki", rider.FirstName);
            Assert.AreEqual("Pedersen", rider.LastName);
            Assert.AreEqual(0.0, rider.Distance, 0.001);
            Assert.AreEqual(motorcycle, rider.Motorcycle);

            rider.Motorcycle = null;

            Assert.AreEqual("Nicki", rider.FirstName);
            Assert.AreEqual("Pedersen", rider.LastName);
            Assert.AreEqual(0.0, rider.Distance, 0.001);
            Assert.AreEqual(null, rider.Motorcycle);
        }

        [TestMethod]
        public void TestRide()
        {
            Rider rider = new Rider("Nicki", "Pedersen");

            Assert.AreEqual("Nicki", rider.FirstName);
            Assert.AreEqual("Pedersen", rider.LastName);
            Assert.AreEqual(0.0, rider.Distance, 0.001);
            Assert.AreEqual(null, rider.Motorcycle);

            Motorcycle motorcycle = new Motorcycle("GM", 68, 81.5);
            Assert.AreEqual(21.5, motorcycle.MetersPerSecond);

            rider.Motorcycle = motorcycle;

            Assert.AreEqual("Nicki", rider.FirstName);
            Assert.AreEqual("Pedersen", rider.LastName);
            Assert.AreEqual(0.0, rider.Distance, 0.001);
            Assert.AreEqual(motorcycle, rider.Motorcycle);

            rider.Ride(1);

            Assert.AreEqual("Nicki", rider.FirstName);
            Assert.AreEqual("Pedersen", rider.LastName);
            Assert.AreEqual(21.5, rider.Distance, 0.001);
            Assert.AreEqual(motorcycle, rider.Motorcycle);

            rider.Ride(2);

            Assert.AreEqual("Nicki", rider.FirstName);
            Assert.AreEqual("Pedersen", rider.LastName);
            Assert.AreEqual(64.5, rider.Distance, 0.001);
            Assert.AreEqual(motorcycle, rider.Motorcycle);

            rider.Ride(1);

            Assert.AreEqual("Nicki", rider.FirstName);
            Assert.AreEqual("Pedersen", rider.LastName);
            Assert.AreEqual(86.0, rider.Distance, 0.001);
            Assert.AreEqual(motorcycle, rider.Motorcycle);

            rider.Ride(6);

            Assert.AreEqual("Nicki", rider.FirstName);
            Assert.AreEqual("Pedersen", rider.LastName);
            Assert.AreEqual(215.0, rider.Distance, 0.001);
            Assert.AreEqual(motorcycle, rider.Motorcycle);
        }

        [TestMethod]
        public void TestRideWithNegativeTime()
        {
            Rider rider = new Rider("Bartosz", "Zmarzlik");

            Assert.AreEqual("Bartosz", rider.FirstName);
            Assert.AreEqual("Zmarzlik", rider.LastName);
            Assert.AreEqual(0.0, rider.Distance, 0.001);
            Assert.AreEqual(null, rider.Motorcycle);

            Motorcycle motorcycle = new Motorcycle("Jawa", 71, 70);
            Assert.AreEqual(28.0, motorcycle.MetersPerSecond);

            rider.Motorcycle = motorcycle;

            Assert.AreEqual("Bartosz", rider.FirstName);
            Assert.AreEqual("Zmarzlik", rider.LastName);
            Assert.AreEqual(0.0, rider.Distance, 0.001);
            Assert.AreEqual(motorcycle, rider.Motorcycle);

            rider.Ride(5);

            Assert.AreEqual("Bartosz", rider.FirstName);
            Assert.AreEqual("Zmarzlik", rider.LastName);
            Assert.AreEqual(140.0, rider.Distance, 0.001);
            Assert.AreEqual(motorcycle, rider.Motorcycle);

            rider.Ride(0);

            Assert.AreEqual("Bartosz", rider.FirstName);
            Assert.AreEqual("Zmarzlik", rider.LastName);
            Assert.AreEqual(140.0, rider.Distance, 0.001);
            Assert.AreEqual(motorcycle, rider.Motorcycle);

            rider.Ride(-1);

            Assert.AreEqual("Bartosz", rider.FirstName);
            Assert.AreEqual("Zmarzlik", rider.LastName);
            Assert.AreEqual(140.0, rider.Distance, 0.001);
            Assert.AreEqual(motorcycle, rider.Motorcycle);
        }

        [TestMethod]
        public void TestRideWithoutMotorcycle()
        {
            Rider rider = new Rider("Tai", "Woffinden");

            Assert.AreEqual("Tai", rider.FirstName);
            Assert.AreEqual("Woffinden", rider.LastName);
            Assert.AreEqual(0.0, rider.Distance, 0.001);
            Assert.AreEqual(null, rider.Motorcycle);

            rider.Ride(5);

            Assert.AreEqual("Tai", rider.FirstName);
            Assert.AreEqual("Woffinden", rider.LastName);
            Assert.AreEqual(0.0, rider.Distance, 0.001);
            Assert.AreEqual(null, rider.Motorcycle);

            Motorcycle motorcycle = new Motorcycle("GM", 85, 97.5);
            Assert.AreEqual(17.5, motorcycle.MetersPerSecond);

            rider.Motorcycle = motorcycle;

            Assert.AreEqual("Tai", rider.FirstName);
            Assert.AreEqual("Woffinden", rider.LastName);
            Assert.AreEqual(0.0, rider.Distance, 0.001);
            Assert.AreEqual(motorcycle, rider.Motorcycle);

            rider.Ride(3);

            Assert.AreEqual("Tai", rider.FirstName);
            Assert.AreEqual("Woffinden", rider.LastName);
            Assert.AreEqual(52.5, rider.Distance, 0.001);
            Assert.AreEqual(motorcycle, rider.Motorcycle);

            rider.Motorcycle = null;

            Assert.AreEqual("Tai", rider.FirstName);
            Assert.AreEqual("Woffinden", rider.LastName);
            Assert.AreEqual(52.5, rider.Distance, 0.001);
            Assert.AreEqual(null, rider.Motorcycle);

            rider.Ride(7);

            Assert.AreEqual("Tai", rider.FirstName);
            Assert.AreEqual("Woffinden", rider.LastName);
            Assert.AreEqual(52.5, rider.Distance, 0.001);
            Assert.AreEqual(null, rider.Motorcycle);
        }
    }
}
