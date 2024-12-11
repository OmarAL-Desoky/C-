using LogBook;

namespace DriversLog.Test
{
    [TestClass]
    public class TripTest
    {
        [TestMethod]
        public void TestShortConstructor()
        {
            Trip trip = new Trip("Regensburg", 233);

            Assert.AreEqual("Linz", trip.Origin);
            Assert.AreEqual("Regensburg", trip.Destination);
            Assert.AreEqual(233, trip.Distance);
        }

        [TestMethod]
        public void TestLongConstructor()
        {
            Trip trip = new Trip("Leonding", "Bibione", 513);

            Assert.AreEqual("Leonding", trip.Origin);
            Assert.AreEqual("Bibione", trip.Destination);
            Assert.AreEqual(513, trip.Distance);
        }

        [TestMethod]
        public void TestConstructorIncreasesTripId()
        {
            Trip tripA = new Trip("Regensburg", 233);
            int tripId = tripA.TripId;

            Assert.AreEqual(tripId, tripA.TripId);

            Trip tripB = new Trip("Leonding", "Bibione", 513);

            Assert.AreEqual(tripId, tripA.TripId);
            Assert.AreEqual(tripId + 1, tripB.TripId);

            Trip tripC = new Trip("Gallspach", "Lodz",  802);

            Assert.AreEqual(tripId, tripA.TripId);
            Assert.AreEqual(tripId + 1, tripB.TripId);
            Assert.AreEqual(tripId + 2, tripC.TripId);

            Trip tripD = new Trip("Hagenberg", 23);

            Assert.AreEqual(tripId, tripA.TripId);
            Assert.AreEqual(tripId + 1, tripB.TripId);
            Assert.AreEqual(tripId + 2, tripC.TripId);
            Assert.AreEqual(tripId + 3, tripD.TripId);
        }

        [TestMethod]
        public void TestShortTripFuelConsumed()
        {
            Trip trip = new Trip("Leonding", 11);

            Assert.AreEqual(0.77, trip.FuelConsumed, 0.001);
        }

        [TestMethod]
        public void TestLongTripFuelConsumed()
        {
            Trip trip = new Trip("Gallspach", "Lodz", 802);

            Assert.AreEqual(56.14, trip.FuelConsumed, 0.001);
        }

        [TestMethod]
        public void TestSetOriginChangesOrigin()
        {
            Trip trip = new Trip("Gallspach", "Lodz", 802);

            Assert.AreEqual("Gallspach", trip.Origin);
            Assert.AreEqual("Lodz", trip.Destination);
            Assert.AreEqual(802, trip.Distance);

            trip.Origin = "Goispoch";

            Assert.AreEqual("Goispoch", trip.Origin);
            Assert.AreEqual("Lodz", trip.Destination);
            Assert.AreEqual(802, trip.Distance);
        }

        [TestMethod]
        public void TestSetDestinationChangesDestination()
        {
            Trip trip = new Trip("Lodsch", 766);

            Assert.AreEqual("Linz", trip.Origin);
            Assert.AreEqual("Lodsch", trip.Destination);
            Assert.AreEqual(766, trip.Distance);

            trip.Destination = "Lodz";

            Assert.AreEqual("Linz", trip.Origin);
            Assert.AreEqual("Lodz", trip.Destination);
            Assert.AreEqual(766, trip.Distance);
        }

        [TestMethod]
        public void TestShortConstructorToString()
        {
            Trip trip = new Trip("Regensburg", 233);

            Assert.AreEqual($"Trip {trip.TripId}: Drove 233 km from Linz to Regensburg (16,31 litres)", trip.ToString());
        }

        [TestMethod]
        public void TestLongConstructorToString()
        {
            Trip trip = new Trip("Leonding", "Bibione", 513);

            Assert.AreEqual($"Trip {trip.TripId}: Drove 513 km from Leonding to Bibione (35,91 litres)", trip.ToString());
        }

        [TestMethod]
        public void TestSetOriginChangesToString()
        {
            Trip trip = new Trip("Gdansk", 1082);

            Assert.AreEqual($"Trip {trip.TripId}: Drove 1082 km from Linz to Gdansk (75,74 litres)", trip.ToString());

            trip.Origin = "Stoistodt";

            Assert.AreEqual($"Trip {trip.TripId}: Drove 1082 km from Stoistodt to Gdansk (75,74 litres)", trip.ToString());
        }

        [TestMethod]
        public void TestSetDestinationChangesToString()
        {
            Trip trip = new Trip("Gallspach", "Lenz", 57);

            Assert.AreEqual($"Trip {trip.TripId}: Drove 57 km from Gallspach to Lenz (3,99 litres)", trip.ToString());

            trip.Destination = "Linz";

            Assert.AreEqual($"Trip {trip.TripId}: Drove 57 km from Gallspach to Linz (3,99 litres)", trip.ToString());
        }

        [TestMethod]
        public void TestShortConstructorWithNullDestination()
        {
            ArgumentException ex = Assert.ThrowsException<ArgumentException>(() =>
            {
                Trip trip = new Trip(null, 57);
            });

            Assert.AreEqual("Destination must not be null or empty and contain only letters!", ex.Message);
        }

        [TestMethod]
        public void TestShortConstructorWithEmptyDestination()
        {
            ArgumentException ex = Assert.ThrowsException<ArgumentException>(() =>
            {
                Trip trip = new Trip("", 1082);
            });

            Assert.AreEqual("Destination must not be null or empty and contain only letters!", ex.Message);
        }

        [TestMethod]
        public void TestShortConstructorWithWhitespaceInDestination()
        {
            ArgumentException ex = Assert.ThrowsException<ArgumentException>(() =>
            {
                Trip trip = new Trip("Leon Ding", 11);
            });

            Assert.AreEqual("Destination must not be null or empty and contain only letters!", ex.Message);
        }

        [TestMethod]
        public void TestShortConstructorWithDigitInDestination()
        {
            ArgumentException ex = Assert.ThrowsException<ArgumentException>(() =>
            {
                Trip trip = new Trip("Leond1ng", 11);
            });

            Assert.AreEqual("Destination must not be null or empty and contain only letters!", ex.Message);
        }

        [TestMethod]
        public void TestShortConstructorWithSpecialSymbolInDestination()
        {
            ArgumentException ex = Assert.ThrowsException<ArgumentException>(() =>
            {
                Trip trip = new Trip("Gall$pach", 57);
            });

            Assert.AreEqual("Destination must not be null or empty and contain only letters!", ex.Message);
        }

        [TestMethod]
        public void TestLongConstructorWithNullDestination()
        {
            ArgumentException ex = Assert.ThrowsException<ArgumentException>(() =>
            {
                Trip trip = new Trip("Gallspach", null, 57);
            });

            Assert.AreEqual("Destination must not be null or empty and contain only letters!", ex.Message);
        }

        [TestMethod]
        public void TestLongConstructorWithEmptyDestination()
        {
            ArgumentException ex = Assert.ThrowsException<ArgumentException>(() =>
            {
                Trip trip = new Trip("Gdansk", "", 1082);
            });

            Assert.AreEqual("Destination must not be null or empty and contain only letters!", ex.Message);
        }

        [TestMethod]
        public void TestLongConstructorWithWhitespaceInDestination()
        {
            ArgumentException ex = Assert.ThrowsException<ArgumentException>(() =>
            {
                Trip trip = new Trip("Leonding", "Stoi Stodt", 11);
            });

            Assert.AreEqual("Destination must not be null or empty and contain only letters!", ex.Message);
        }

        [TestMethod]
        public void TestLongConstructorWithDigitInDestination()
        {
            ArgumentException ex = Assert.ThrowsException<ArgumentException>(() =>
            {
                Trip trip = new Trip("Stoistodt", "Gd4nsk", 1082);
            });

            Assert.AreEqual("Destination must not be null or empty and contain only letters!", ex.Message);
        }

        [TestMethod]
        public void TestLongConstructorWithSpecialSymbolInDestination()
        {
            ArgumentException ex = Assert.ThrowsException<ArgumentException>(() =>
            {
                Trip trip = new Trip("Gallspach", "L!nz", 57);
            });

            Assert.AreEqual("Destination must not be null or empty and contain only letters!", ex.Message);
        }

        [TestMethod]
        public void TestLongConstructorWithNullOrigin()
        {
            ArgumentException ex = Assert.ThrowsException<ArgumentException>(() =>
            {
                Trip trip = new Trip(null, "Linz", 57);
            });

            Assert.AreEqual("Origin must not be null or empty and contain only letters!", ex.Message);
        }

        [TestMethod]
        public void TestLongConstructorWithEmptyOrigin()
        {
            ArgumentException ex = Assert.ThrowsException<ArgumentException>(() =>
            {
                Trip trip = new Trip("", "Gdansk", 1082);
            });

            Assert.AreEqual("Origin must not be null or empty and contain only letters!", ex.Message);
        }

        [TestMethod]
        public void TestLongConstructorWithWhitespaceInOrigin()
        {
            ArgumentException ex = Assert.ThrowsException<ArgumentException>(() =>
            {
                Trip trip = new Trip("Regens Burg", "Linz", 233);
            });

            Assert.AreEqual("Origin must not be null or empty and contain only letters!", ex.Message);
        }

        [TestMethod]
        public void TestLongConstructorWithDigitInOrigin()
        {
            ArgumentException ex = Assert.ThrowsException<ArgumentException>(() =>
            {
                Trip trip = new Trip("Sto1stodt", "Gdansk", 1082);
            });

            Assert.AreEqual("Origin must not be null or empty and contain only letters!", ex.Message);
        }

        [TestMethod]
        public void TestLongConstructorWithSpecialSymbolInOrigin()
        {
            ArgumentException ex = Assert.ThrowsException<ArgumentException>(() =>
            {
                Trip trip = new Trip("Regens&urg", "Linz", 233);
            });

            Assert.AreEqual("Origin must not be null or empty and contain only letters!", ex.Message);
        }

        [TestMethod]
        public void TestShortConstructorWithZeroDistance()
        {
            ArgumentException ex = Assert.ThrowsException<ArgumentException>(() =>
            {
                Trip trip = new Trip("Regensburg", 0);
            });

            Assert.AreEqual("Distance must not be smaller than 1!", ex.Message);
        }

        [TestMethod]
        public void TestShortConstructorWithNegativeDistance()
        {
            ArgumentException ex = Assert.ThrowsException<ArgumentException>(() =>
            {
                Trip trip = new Trip("Regensburg", -200);
            });

            Assert.AreEqual("Distance must not be smaller than 1!", ex.Message);
        }

        [TestMethod]
        public void TestLongConstructorWithZeroDistance()
        {
            ArgumentException ex = Assert.ThrowsException<ArgumentException>(() =>
            {
                Trip trip = new Trip("Leonding", "Bibione", 0);
            });

            Assert.AreEqual("Distance must not be smaller than 1!", ex.Message);
        }

        [TestMethod]
        public void TestLongConstructorWithNegativeDistance()
        {
            ArgumentException ex = Assert.ThrowsException<ArgumentException>(() =>
            {
                Trip trip = new Trip("Leonding", "Bibione", -1);
            });

            Assert.AreEqual("Distance must not be smaller than 1!", ex.Message);
        }

        [TestMethod]
        public void TestSetOriginWithNullValue()
        {
            Trip trip = new Trip("Gallspach", "Lodz", 802);

            ArgumentException ex = Assert.ThrowsException<ArgumentException>(() =>
            {
                trip.Origin = null;
            });

            Assert.AreEqual("Origin must not be null or empty and contain only letters!", ex.Message);
        }

        [TestMethod]
        public void TestSetOriginWithEmptyValue()
        {
            Trip trip = new Trip("Gallspach", "Lodz", 802);

            ArgumentException ex = Assert.ThrowsException<ArgumentException>(() =>
            {
                trip.Origin = "";
            });

            Assert.AreEqual("Origin must not be null or empty and contain only letters!", ex.Message);
        }

        [TestMethod]
        public void TestSetOriginWithWhitespaceInValue()
        {
            Trip trip = new Trip("Gallspach", "Lodz", 802);

            ArgumentException ex = Assert.ThrowsException<ArgumentException>(() =>
            {
                trip.Origin = "Gall Spach";
            });

            Assert.AreEqual("Origin must not be null or empty and contain only letters!", ex.Message);
        }

        [TestMethod]
        public void TestSetOriginWithDigitInValue()
        {
            Trip trip = new Trip("Gallspach", "Lodz", 802);

            ArgumentException ex = Assert.ThrowsException<ArgumentException>(() =>
            {
                trip.Origin = "Gall5pach";
            });

            Assert.AreEqual("Origin must not be null or empty and contain only letters!", ex.Message);
        }

        [TestMethod]
        public void TestSetOriginWithSpecialSymbolInValue()
        {
            Trip trip = new Trip("Gallspach", "Lodz", 802);

            ArgumentException ex = Assert.ThrowsException<ArgumentException>(() =>
            {
                trip.Origin = "Gallspac#";
            });

            Assert.AreEqual("Origin must not be null or empty and contain only letters!", ex.Message);
        }

        [TestMethod]
        public void TestSetDestinationWithNullValue()
        {
            Trip trip = new Trip("Gallspach", "Lodz", 802);

            ArgumentException ex = Assert.ThrowsException<ArgumentException>(() =>
            {
                trip.Destination = null;
            });

            Assert.AreEqual("Destination must not be null or empty and contain only letters!", ex.Message);
        }

        [TestMethod]
        public void TestSetDestinationWithEmptyValue()
        {
            Trip trip = new Trip("Gallspach", "Lodz", 802);

            ArgumentException ex = Assert.ThrowsException<ArgumentException>(() =>
            {
                trip.Destination = "";
            });

            Assert.AreEqual("Destination must not be null or empty and contain only letters!", ex.Message);
        }

        [TestMethod]
        public void TestSetDestinationWithWhitespaceInValue()
        {
            Trip trip = new Trip("Gallspach", "Lodz", 802);

            ArgumentException ex = Assert.ThrowsException<ArgumentException>(() =>
            {
                trip.Destination = "Lodsch ";
            });

            Assert.AreEqual("Destination must not be null or empty and contain only letters!", ex.Message);
        }

        [TestMethod]
        public void TestSetDestinationWithDigitInValue()
        {
            Trip trip = new Trip("Gallspach", "Lodz", 802);

            ArgumentException ex = Assert.ThrowsException<ArgumentException>(() =>
            {
                trip.Destination = "L0dz";
            });

            Assert.AreEqual("Destination must not be null or empty and contain only letters!", ex.Message);
        }

        [TestMethod]
        public void TestSetDestinationWithSpecialSymbolInValue()
        {
            Trip trip = new Trip("Gallspach", "Lodz", 802);

            ArgumentException ex = Assert.ThrowsException<ArgumentException>(() =>
            {
                trip.Destination = "?odz";
            });

            Assert.AreEqual("Destination must not be null or empty and contain only letters!", ex.Message);
        }

        [TestMethod]
        public void TestShortConstructorCreateReturnTrip()
        {
            Trip trip = new Trip("Regensburg", 233);

            Trip tripBack = trip.CreateReturnTrip();

            Assert.AreEqual("Linz", trip.Origin);
            Assert.AreEqual("Regensburg", trip.Destination);
            Assert.AreEqual(233, trip.Distance);

            Assert.AreEqual("Regensburg", tripBack.Origin);
            Assert.AreEqual("Linz", tripBack.Destination);
            Assert.AreEqual(233, tripBack.Distance);
        }

        [TestMethod]
        public void TestLongConstructorCreateReturnTrip()
        {
            Trip trip = new Trip("Leonding", "Bibione", 513);

            Trip tripBack = trip.CreateReturnTrip();

            Assert.AreEqual("Leonding", trip.Origin);
            Assert.AreEqual("Bibione", trip.Destination);
            Assert.AreEqual(513, trip.Distance);

            Assert.AreEqual("Bibione", tripBack.Origin);
            Assert.AreEqual("Leonding", tripBack.Destination);
            Assert.AreEqual(513, tripBack.Distance);
        }
    }
}