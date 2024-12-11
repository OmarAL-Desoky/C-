using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogBook;

namespace LogBook.Test
{
    [TestClass]
    public class DriversLogTest
    {
        [TestMethod]
        public void TestAddAndGetTripsInCorrectOrder()
        {
            DriversLog driversLog = new DriversLog();

            Trip tripA = new Trip("Regensburg", 233);
            Trip tripB = new Trip("Leonding", "Bibione", 513);
            Trip tripC = new Trip("Hagenberg", 23);
            Trip tripD = new Trip("Lodsch", 766);
            Trip tripE = new Trip("Gallspach", "Linz", 57);
            Trip tripF = new Trip("Leonding", 11);
            Trip tripG = new Trip("Gallspach", "Lodz", 802);
            Trip tripH = new Trip("Wilhering", "Lustenau", 441);

            Trip[] trips = driversLog.Trips;

            Assert.AreEqual(0, trips.Length);

            driversLog.AddTrip(tripA);

            trips = driversLog.Trips;

            Assert.AreEqual(1, trips.Length);
            Assert.AreEqual("Linz", trips[0].Origin);
            Assert.AreEqual("Regensburg", trips[0].Destination);
            Assert.AreEqual(233, trips[0].Distance);

            driversLog.AddTrip(tripB);

            trips = driversLog.Trips;

            Assert.AreEqual(2, trips.Length);
            Assert.AreEqual("Leonding", trips[0].Origin);
            Assert.AreEqual("Bibione", trips[0].Destination);
            Assert.AreEqual(513, trips[0].Distance);
            Assert.AreEqual("Linz", trips[1].Origin);
            Assert.AreEqual("Regensburg", trips[1].Destination);
            Assert.AreEqual(233, trips[1].Distance);

            driversLog.AddTrip(tripC);

            trips = driversLog.Trips;

            Assert.AreEqual(3, trips.Length);
            Assert.AreEqual("Leonding", trips[0].Origin);
            Assert.AreEqual("Bibione", trips[0].Destination);
            Assert.AreEqual(513, trips[0].Distance);
            Assert.AreEqual("Linz", trips[1].Origin);
            Assert.AreEqual("Regensburg", trips[1].Destination);
            Assert.AreEqual(233, trips[1].Distance);
            Assert.AreEqual("Linz", trips[2].Origin);
            Assert.AreEqual("Hagenberg", trips[2].Destination);
            Assert.AreEqual(23, trips[2].Distance);

            driversLog.AddTrip(tripD);

            trips = driversLog.Trips;

            Assert.AreEqual(4, trips.Length);
            Assert.AreEqual("Linz", trips[0].Origin);
            Assert.AreEqual("Lodsch", trips[0].Destination);
            Assert.AreEqual(766, trips[0].Distance);
            Assert.AreEqual("Leonding", trips[1].Origin);
            Assert.AreEqual("Bibione", trips[1].Destination);
            Assert.AreEqual(513, trips[1].Distance);
            Assert.AreEqual("Linz", trips[2].Origin);
            Assert.AreEqual("Regensburg", trips[2].Destination);
            Assert.AreEqual(233, trips[2].Distance);
            Assert.AreEqual("Linz", trips[3].Origin);
            Assert.AreEqual("Hagenberg", trips[3].Destination);
            Assert.AreEqual(23, trips[3].Distance);

            driversLog.AddTrip(tripE);

            trips = driversLog.Trips;

            Assert.AreEqual(5, trips.Length);
            Assert.AreEqual("Linz", trips[0].Origin);
            Assert.AreEqual("Lodsch", trips[0].Destination);
            Assert.AreEqual(766, trips[0].Distance);
            Assert.AreEqual("Leonding", trips[1].Origin);
            Assert.AreEqual("Bibione", trips[1].Destination);
            Assert.AreEqual(513, trips[1].Distance);
            Assert.AreEqual("Linz", trips[2].Origin);
            Assert.AreEqual("Regensburg", trips[2].Destination);
            Assert.AreEqual(233, trips[2].Distance);
            Assert.AreEqual("Gallspach", trips[3].Origin);
            Assert.AreEqual("Linz", trips[3].Destination);
            Assert.AreEqual(57, trips[3].Distance);
            Assert.AreEqual("Linz", trips[4].Origin);
            Assert.AreEqual("Hagenberg", trips[4].Destination);
            Assert.AreEqual(23, trips[4].Distance);

            driversLog.AddTrip(tripF);

            trips = driversLog.Trips;

            Assert.AreEqual(6, trips.Length);
            Assert.AreEqual("Linz", trips[0].Origin);
            Assert.AreEqual("Lodsch", trips[0].Destination);
            Assert.AreEqual(766, trips[0].Distance);
            Assert.AreEqual("Leonding", trips[1].Origin);
            Assert.AreEqual("Bibione", trips[1].Destination);
            Assert.AreEqual(513, trips[1].Distance);
            Assert.AreEqual("Linz", trips[2].Origin);
            Assert.AreEqual("Regensburg", trips[2].Destination);
            Assert.AreEqual(233, trips[2].Distance);
            Assert.AreEqual("Gallspach", trips[3].Origin);
            Assert.AreEqual("Linz", trips[3].Destination);
            Assert.AreEqual(57, trips[3].Distance);
            Assert.AreEqual("Linz", trips[4].Origin);
            Assert.AreEqual("Hagenberg", trips[4].Destination);
            Assert.AreEqual(23, trips[4].Distance);
            Assert.AreEqual("Linz", trips[5].Origin);
            Assert.AreEqual("Leonding", trips[5].Destination);
            Assert.AreEqual(11, trips[5].Distance);

            driversLog.AddTrip(tripG);

            trips = driversLog.Trips;

            Assert.AreEqual(7, trips.Length);
            Assert.AreEqual("Gallspach", trips[0].Origin);
            Assert.AreEqual("Lodz", trips[0].Destination);
            Assert.AreEqual(802, trips[0].Distance);
            Assert.AreEqual("Linz", trips[1].Origin);
            Assert.AreEqual("Lodsch", trips[1].Destination);
            Assert.AreEqual(766, trips[1].Distance);
            Assert.AreEqual("Leonding", trips[2].Origin);
            Assert.AreEqual("Bibione", trips[2].Destination);
            Assert.AreEqual(513, trips[2].Distance);
            Assert.AreEqual("Linz", trips[3].Origin);
            Assert.AreEqual("Regensburg", trips[3].Destination);
            Assert.AreEqual(233, trips[3].Distance);
            Assert.AreEqual("Gallspach", trips[4].Origin);
            Assert.AreEqual("Linz", trips[4].Destination);
            Assert.AreEqual(57, trips[4].Distance);
            Assert.AreEqual("Linz", trips[5].Origin);
            Assert.AreEqual("Hagenberg", trips[5].Destination);
            Assert.AreEqual(23, trips[5].Distance);
            Assert.AreEqual("Linz", trips[6].Origin);
            Assert.AreEqual("Leonding", trips[6].Destination);
            Assert.AreEqual(11, trips[6].Distance);

            driversLog.AddTrip(tripH);

            trips = driversLog.Trips;

            Assert.AreEqual(8, trips.Length);
            Assert.AreEqual("Gallspach", trips[0].Origin);
            Assert.AreEqual("Lodz", trips[0].Destination);
            Assert.AreEqual(802, trips[0].Distance);
            Assert.AreEqual("Linz", trips[1].Origin);
            Assert.AreEqual("Lodsch", trips[1].Destination);
            Assert.AreEqual(766, trips[1].Distance);
            Assert.AreEqual("Leonding", trips[2].Origin);
            Assert.AreEqual("Bibione", trips[2].Destination);
            Assert.AreEqual(513, trips[2].Distance);
            Assert.AreEqual("Wilhering", trips[3].Origin);
            Assert.AreEqual("Lustenau", trips[3].Destination);
            Assert.AreEqual(441, trips[3].Distance);
            Assert.AreEqual("Linz", trips[4].Origin);
            Assert.AreEqual("Regensburg", trips[4].Destination);
            Assert.AreEqual(233, trips[4].Distance);
            Assert.AreEqual("Gallspach", trips[5].Origin);
            Assert.AreEqual("Linz", trips[5].Destination);
            Assert.AreEqual(57, trips[5].Distance);
            Assert.AreEqual("Linz", trips[6].Origin);
            Assert.AreEqual("Hagenberg", trips[6].Destination);
            Assert.AreEqual(23, trips[6].Distance);
            Assert.AreEqual("Linz", trips[7].Origin);
            Assert.AreEqual("Leonding", trips[7].Destination);
            Assert.AreEqual(11, trips[7].Distance);
        }

        [TestMethod]
        public void TestGetTripsReturnsClone()
        {
            DriversLog driversLog = new DriversLog();

            Trip tripA = new Trip("Regensburg", 233);
            Trip tripB = new Trip("Leonding", "Bibione", 513);
            Trip tripC = new Trip("Hagenberg", 23);

            driversLog.AddTrip(tripA);
            driversLog.AddTrip(tripB);
            driversLog.AddTrip(tripC);

            Trip[] tripsBefore = driversLog.Trips;

            tripsBefore[0] = null;
            tripsBefore[1] = new Trip("Haxi", "Popaxi", 123);
            tripsBefore[2] = null;

            Trip[] tripsAfter = driversLog.Trips;

            Assert.AreEqual("Leonding", tripsAfter[0].Origin);
            Assert.AreEqual("Bibione", tripsAfter[0].Destination);
            Assert.AreEqual(513, tripsAfter[0].Distance);
            Assert.AreEqual("Linz", tripsAfter[1].Origin);
            Assert.AreEqual("Regensburg", tripsAfter[1].Destination);
            Assert.AreEqual(233, tripsAfter[1].Distance);
            Assert.AreEqual("Linz", tripsAfter[2].Origin);
            Assert.AreEqual("Hagenberg", tripsAfter[2].Destination);
            Assert.AreEqual(23, tripsAfter[2].Distance);
        }

        [TestMethod]
        public void TestAddTripWithDuplicateId()
        {
            DriversLog driversLog = new DriversLog();

            Trip tripA = new Trip("Hagenberg", 23);
            Trip tripB = new Trip("Leonding", "Bibione", 513);

            driversLog.AddTrip(tripA);
            driversLog.AddTrip(tripB);

            ArgumentException ex = Assert.ThrowsException<ArgumentException>(() =>
            {
                driversLog.AddTrip(tripA);
            });

            Assert.AreEqual($"Log already contains a trip with ID {tripA.TripId}!", ex.Message);
        }

        [TestMethod]
        public void TestAddLotsOfTripsAreInCorrectOrder()
        {
            Random randomNumberGenerator = new Random();

            DriversLog driversLog = new DriversLog();

            int elementsCount = randomNumberGenerator.Next(1, 1000);

            for(int i = 0; i < elementsCount; i++)
            {
                Trip trip = new Trip("Haxitown", "Popaxity", randomNumberGenerator.Next(1, 1000));

                driversLog.AddTrip(trip);
            }

            Trip[] trips = driversLog.Trips;

            Assert.AreEqual(elementsCount, trips.Length);

            int lastDistance = trips[0].Distance;

            for(int i = 1; i < trips.Length; i++)
            {
                Assert.AreEqual(true, trips[i].Distance <= lastDistance);

                lastDistance = trips[i].Distance;
            }
        }

        [TestMethod]
        public void TestShortestTrip()
        {
            DriversLog driversLog = new DriversLog();

            Trip tripA = new Trip("Regensburg", 233);
            Trip tripB = new Trip("Leonding", "Bibione", 513);
            Trip tripC = new Trip("Hagenberg", 23);
            Trip tripD = new Trip("Lodsch", 766);
            Trip tripE = new Trip("Gallspach", "Linz", 57);
            Trip tripF = new Trip("Leonding", 11);
            Trip tripG = new Trip("Gallspach", "Lodz", 802);
            Trip tripH = new Trip("Wilhering", "Lustenau", 441);

            Assert.AreEqual(null, driversLog.ShortestTrip);

            driversLog.AddTrip(tripA);

            Assert.AreEqual("Linz", driversLog.ShortestTrip.Origin);
            Assert.AreEqual("Regensburg", driversLog.ShortestTrip.Destination);
            Assert.AreEqual(233, driversLog.ShortestTrip.Distance);

            driversLog.AddTrip(tripB);

            Assert.AreEqual("Linz", driversLog.ShortestTrip.Origin);
            Assert.AreEqual("Regensburg", driversLog.ShortestTrip.Destination);
            Assert.AreEqual(233, driversLog.ShortestTrip.Distance);

            driversLog.AddTrip(tripC);

            Assert.AreEqual("Linz", driversLog.ShortestTrip.Origin);
            Assert.AreEqual("Hagenberg", driversLog.ShortestTrip.Destination);
            Assert.AreEqual(23, driversLog.ShortestTrip.Distance);

            driversLog.AddTrip(tripD);

            Assert.AreEqual("Linz", driversLog.ShortestTrip.Origin);
            Assert.AreEqual("Hagenberg", driversLog.ShortestTrip.Destination);
            Assert.AreEqual(23, driversLog.ShortestTrip.Distance);

            driversLog.AddTrip(tripE);

            Assert.AreEqual("Linz", driversLog.ShortestTrip.Origin);
            Assert.AreEqual("Hagenberg", driversLog.ShortestTrip.Destination);
            Assert.AreEqual(23, driversLog.ShortestTrip.Distance);

            driversLog.AddTrip(tripF);

            Assert.AreEqual("Linz", driversLog.ShortestTrip.Origin);
            Assert.AreEqual("Leonding", driversLog.ShortestTrip.Destination);
            Assert.AreEqual(11, driversLog.ShortestTrip.Distance);

            driversLog.AddTrip(tripG);

            Assert.AreEqual("Linz", driversLog.ShortestTrip.Origin);
            Assert.AreEqual("Leonding", driversLog.ShortestTrip.Destination);
            Assert.AreEqual(11, driversLog.ShortestTrip.Distance);

            driversLog.AddTrip(tripH);

            Assert.AreEqual("Linz", driversLog.ShortestTrip.Origin);
            Assert.AreEqual("Leonding", driversLog.ShortestTrip.Destination);
            Assert.AreEqual(11, driversLog.ShortestTrip.Distance);
        }

        [TestMethod]
        public void TestAverageTripDistanceWithEmptyDriversLog()
        {
            DriversLog driversLog = new DriversLog();

            InvalidOperationException ex = Assert.ThrowsException<InvalidOperationException>(() =>
            {
                double average = driversLog.AverageTripDistance;
            });

            Assert.AreEqual("No trips logged yet!", ex.Message);
        }

        [TestMethod]
        public void TestAverageTripDistance()
        {
            DriversLog driversLog = new DriversLog();

            Trip tripA = new Trip("Regensburg", 233);
            Trip tripB = new Trip("Leonding", "Bibione", 513);
            Trip tripC = new Trip("Hagenberg", 23);
            Trip tripD = new Trip("Lodsch", 766);
            Trip tripE = new Trip("Gallspach", "Linz", 57);
            Trip tripF = new Trip("Leonding", 11);
            Trip tripG = new Trip("Gallspach", "Lodz", 802);
            Trip tripH = new Trip("Wilhering", "Lustenau", 441);

            driversLog.AddTrip(tripA);

            Assert.AreEqual(233.0, driversLog.AverageTripDistance, 0.001);

            driversLog.AddTrip(tripB);

            Assert.AreEqual(373.0, driversLog.AverageTripDistance, 0.001);

            driversLog.AddTrip(tripC);

            Assert.AreEqual(256.333, driversLog.AverageTripDistance, 0.001);

            driversLog.AddTrip(tripD);

            Assert.AreEqual(383.75, driversLog.AverageTripDistance, 0.001);

            driversLog.AddTrip(tripE);

            Assert.AreEqual(318.4, driversLog.AverageTripDistance, 0.001);

            driversLog.AddTrip(tripF);

            Assert.AreEqual(267.166, driversLog.AverageTripDistance, 0.001);

            driversLog.AddTrip(tripG);

            Assert.AreEqual(343.571, driversLog.AverageTripDistance, 0.001);

            driversLog.AddTrip(tripH);

            Assert.AreEqual(355.75, driversLog.AverageTripDistance, 0.001);
        }

        [TestMethod]
        public void TestTotalFuelConsumed()
        {
            DriversLog driversLog = new DriversLog();

            Trip tripA = new Trip("Regensburg", 233);
            Trip tripB = new Trip("Leonding", "Bibione", 513);
            Trip tripC = new Trip("Hagenberg", 23);
            Trip tripD = new Trip("Lodsch", 766);
            Trip tripE = new Trip("Gallspach", "Linz", 57);
            Trip tripF = new Trip("Leonding", 11);
            Trip tripG = new Trip("Gallspach", "Lodz", 802);
            Trip tripH = new Trip("Wilhering", "Lustenau", 441);

            Assert.AreEqual(0.0, driversLog.TotalFuelConsumed, 0.001);

            driversLog.AddTrip(tripA);

            Assert.AreEqual(16.31, driversLog.TotalFuelConsumed, 0.001);

            driversLog.AddTrip(tripB);

            Assert.AreEqual(52.22, driversLog.TotalFuelConsumed, 0.001);

            driversLog.AddTrip(tripC);

            Assert.AreEqual(53.83, driversLog.TotalFuelConsumed, 0.001);

            driversLog.AddTrip(tripD);

            Assert.AreEqual(107.45, driversLog.TotalFuelConsumed, 0.001);

            driversLog.AddTrip(tripE);

            Assert.AreEqual(111.44, driversLog.TotalFuelConsumed, 0.001);

            driversLog.AddTrip(tripF);

            Assert.AreEqual(112.21, driversLog.TotalFuelConsumed, 0.001);

            driversLog.AddTrip(tripG);

            Assert.AreEqual(168.35, driversLog.TotalFuelConsumed, 0.001);

            driversLog.AddTrip(tripH);

            Assert.AreEqual(199.22, driversLog.TotalFuelConsumed, 0.001);
        }

        [TestMethod]
        public void TestCountTripsByOrigin()
        {
            DriversLog driversLog = new DriversLog();

            Trip tripA = new Trip("Regensburg", 233);
            Trip tripB = new Trip("Leonding", "Bibione", 513);
            Trip tripC = new Trip("Hagenberg", 23);
            Trip tripD = new Trip("Lodsch", 766);
            Trip tripE = new Trip("Gallspach", "Linz", 57);
            Trip tripF = new Trip("Leonding", 11);
            Trip tripG = new Trip("Gallspach", "Lodz", 802);
            Trip tripH = new Trip("Wilhering", "Lustenau", 441);

            Assert.AreEqual(0, driversLog.CountTripsByOrigin("Gallspach"));
            Assert.AreEqual(0, driversLog.CountTripsByOrigin("Leonding"));
            Assert.AreEqual(0, driversLog.CountTripsByOrigin("Linz"));
            Assert.AreEqual(0, driversLog.CountTripsByOrigin("Wilhering"));

            driversLog.AddTrip(tripA);

            Assert.AreEqual(0, driversLog.CountTripsByOrigin("Gallspach"));
            Assert.AreEqual(0, driversLog.CountTripsByOrigin("Leonding"));
            Assert.AreEqual(1, driversLog.CountTripsByOrigin("Linz"));
            Assert.AreEqual(0, driversLog.CountTripsByOrigin("Wilhering"));

            driversLog.AddTrip(tripB);

            Assert.AreEqual(0, driversLog.CountTripsByOrigin("Gallspach"));
            Assert.AreEqual(1, driversLog.CountTripsByOrigin("Leonding"));
            Assert.AreEqual(1, driversLog.CountTripsByOrigin("Linz"));
            Assert.AreEqual(0, driversLog.CountTripsByOrigin("Wilhering"));

            driversLog.AddTrip(tripC);

            Assert.AreEqual(0, driversLog.CountTripsByOrigin("Gallspach"));
            Assert.AreEqual(1, driversLog.CountTripsByOrigin("Leonding"));
            Assert.AreEqual(2, driversLog.CountTripsByOrigin("Linz"));
            Assert.AreEqual(0, driversLog.CountTripsByOrigin("Wilhering"));

            driversLog.AddTrip(tripD);

            Assert.AreEqual(0, driversLog.CountTripsByOrigin("Gallspach"));
            Assert.AreEqual(1, driversLog.CountTripsByOrigin("Leonding"));
            Assert.AreEqual(3, driversLog.CountTripsByOrigin("Linz"));
            Assert.AreEqual(0, driversLog.CountTripsByOrigin("Wilhering"));

            driversLog.AddTrip(tripE);

            Assert.AreEqual(1, driversLog.CountTripsByOrigin("Gallspach"));
            Assert.AreEqual(1, driversLog.CountTripsByOrigin("Leonding"));
            Assert.AreEqual(3, driversLog.CountTripsByOrigin("Linz"));
            Assert.AreEqual(0, driversLog.CountTripsByOrigin("Wilhering"));

            driversLog.AddTrip(tripF);

            Assert.AreEqual(1, driversLog.CountTripsByOrigin("Gallspach"));
            Assert.AreEqual(1, driversLog.CountTripsByOrigin("Leonding"));
            Assert.AreEqual(4, driversLog.CountTripsByOrigin("Linz"));
            Assert.AreEqual(0, driversLog.CountTripsByOrigin("Wilhering"));

            driversLog.AddTrip(tripG);

            Assert.AreEqual(2, driversLog.CountTripsByOrigin("Gallspach"));
            Assert.AreEqual(1, driversLog.CountTripsByOrigin("Leonding"));
            Assert.AreEqual(4, driversLog.CountTripsByOrigin("Linz"));
            Assert.AreEqual(0, driversLog.CountTripsByOrigin("Wilhering"));

            driversLog.AddTrip(tripH);

            Assert.AreEqual(2, driversLog.CountTripsByOrigin("Gallspach"));
            Assert.AreEqual(1, driversLog.CountTripsByOrigin("Leonding"));
            Assert.AreEqual(4, driversLog.CountTripsByOrigin("Linz"));
            Assert.AreEqual(1, driversLog.CountTripsByOrigin("Wilhering"));
        }
    }
}
