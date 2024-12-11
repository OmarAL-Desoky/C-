using Microsoft.VisualStudio.TestTools.UnitTesting;
using BicyclesUe;

namespace Bicycles.Test
{
    [TestClass]
    public class BicycleTest
    {
        [TestMethod]
        public void TestConstructorIncreasesFrameId()
        {
            Bicycle bicycle = new Bicycle("KTM", "Trekking");

            int frameIdExpected = bicycle.FrameId;

            bicycle = new Bicycle("Pinarello", "Road");

            frameIdExpected++;
            Assert.AreEqual(frameIdExpected, bicycle.FrameId);

            bicycle = new Bicycle("KTM", "Mountain");

            frameIdExpected++;
            Assert.AreEqual(frameIdExpected, bicycle.FrameId);

            bicycle = new Bicycle("Puch", "Road");

            frameIdExpected++;
            Assert.AreEqual(frameIdExpected, bicycle.FrameId);

            bicycle = new Bicycle("Cube", "City");

            frameIdExpected++;
            Assert.AreEqual(frameIdExpected, bicycle.FrameId);

            bicycle = new Bicycle("KTM", "City");

            frameIdExpected++;
            Assert.AreEqual(frameIdExpected, bicycle.FrameId);
        }

        [TestMethod]
        public void TestConstructorRoadBike()
        {
            Bicycle bicycle = new Bicycle("Pinarello", "Road");
            Assert.AreEqual("Pinarello", bicycle.Brand);
            Assert.AreEqual(0, bicycle.Mileage);
            Assert.AreEqual("Road", bicycle.Type);
        }

        [TestMethod]
        public void TestConstructorTrekkingBike()
        {
            Bicycle bicycle = new Bicycle("KTM", "Trekking");
            Assert.AreEqual("KTM", bicycle.Brand);
            Assert.AreEqual(0, bicycle.Mileage);
            Assert.AreEqual("Trekking", bicycle.Type);
        }

        [TestMethod]
        public void TestConstructorCityBike()
        {
            Bicycle bicycle = new Bicycle("Puch", "City");
            Assert.AreEqual("Puch", bicycle.Brand);
            Assert.AreEqual(0, bicycle.Mileage);
            Assert.AreEqual("City", bicycle.Type);
        }

        [TestMethod]
        public void TestConstructorMountainBike()
        {
            Bicycle bicycle = new Bicycle("Scott", "Mountain");
            Assert.AreEqual("Scott", bicycle.Brand);
            Assert.AreEqual(0, bicycle.Mileage);
            Assert.AreEqual("Mountain", bicycle.Type);
        }

        [TestMethod]
        public void TestConstructorWrongType()
        {
            Bicycle bicycle = new Bicycle("Cannondale", "Haxi");
            Assert.AreEqual("Cannondale", bicycle.Brand);
            Assert.AreEqual(0, bicycle.Mileage);
            Assert.AreEqual("City", bicycle.Type);
        }

        [TestMethod]
        public void TestConstructorEmptyType()
        {
            Bicycle bicycle = new Bicycle("Puch", "");
            Assert.AreEqual("Puch", bicycle.Brand);
            Assert.AreEqual(0, bicycle.Mileage);
            Assert.AreEqual("City", bicycle.Type);
        }

        [TestMethod]
        public void TestConstructorNullType()
        {
            Bicycle bicycle = new Bicycle("KTM", null);
            Assert.AreEqual("KTM", bicycle.Brand);
            Assert.AreEqual(0, bicycle.Mileage);
            Assert.AreEqual("City", bicycle.Type);
        }

        [TestMethod]
        public void TestTypeSetterLegalValue()
        {
            Bicycle bicycle = new Bicycle("Puch", "Road");

            int frameIdExpected = bicycle.FrameId;
            Assert.AreEqual("Puch", bicycle.Brand);
            Assert.AreEqual(0, bicycle.Mileage);
            Assert.AreEqual("Road", bicycle.Type);

            bicycle.Type = "Trekking";

            Assert.AreEqual(frameIdExpected, bicycle.FrameId);
            Assert.AreEqual("Puch", bicycle.Brand);
            Assert.AreEqual(0, bicycle.Mileage);
            Assert.AreEqual("Trekking", bicycle.Type);
        }

        [TestMethod]
        public void TestTypeSetterIllegalValue()
        {
            Bicycle bicycle = new Bicycle("Puch", "Road");

            int frameIdExpected = bicycle.FrameId;
            Assert.AreEqual("Puch", bicycle.Brand);
            Assert.AreEqual(0, bicycle.Mileage);
            Assert.AreEqual("Road", bicycle.Type);

            bicycle.Type = "Tandem";

            Assert.AreEqual(frameIdExpected, bicycle.FrameId);
            Assert.AreEqual("Puch", bicycle.Brand);
            Assert.AreEqual(0, bicycle.Mileage);
            Assert.AreEqual("City", bicycle.Type);
        }

        [TestMethod]
        public void TestTypeSetterNull()
        {
            Bicycle bicycle = new Bicycle("Puch", "Road");

            int frameIdExpected = bicycle.FrameId;
            Assert.AreEqual("Puch", bicycle.Brand);
            Assert.AreEqual(0, bicycle.Mileage);
            Assert.AreEqual("Road", bicycle.Type);

            bicycle.Type = null;

            Assert.AreEqual(frameIdExpected, bicycle.FrameId);
            Assert.AreEqual("Puch", bicycle.Brand);
            Assert.AreEqual(0, bicycle.Mileage);
            Assert.AreEqual("City", bicycle.Type);
        }

        [TestMethod]
        public void TestBrandSetter()
        {
            Bicycle bicycle = new Bicycle("KTM", "Mountain");

            int frameIdExpected = bicycle.FrameId;
            Assert.AreEqual("KTM", bicycle.Brand);
            Assert.AreEqual(0, bicycle.Mileage);
            Assert.AreEqual("Mountain", bicycle.Type);

            bicycle.Brand = "Cannondale";

            Assert.AreEqual(frameIdExpected, bicycle.FrameId);
            Assert.AreEqual("Cannondale", bicycle.Brand);
            Assert.AreEqual(0, bicycle.Mileage);
            Assert.AreEqual("Mountain", bicycle.Type);
        }

        [TestMethod]
        public void TestToString()
        {
            Bicycle bicycle = new Bicycle("Pinarello", "Road");

            int frameIdExpected = bicycle.FrameId;

            Assert.AreEqual($"#{frameIdExpected} - Road Bike by Pinarello (Mileage: 0 km)", bicycle.ToString());
        }

        [TestMethod]
        public void TestToStringWithTypeChange()
        {
            Bicycle bicycle = new Bicycle("Pinarello", "Road");

            int frameIdExpected = bicycle.FrameId;

            bicycle.Type = "Trekking";

            Assert.AreEqual($"#{frameIdExpected} - Trekking Bike by Pinarello (Mileage: 0 km)", bicycle.ToString());
        }

        [TestMethod]
        public void TestToStringWithBrandChange()
        {
            Bicycle bicycle = new Bicycle("Pinarello", "Road");

            int frameIdExpected = bicycle.FrameId;

            bicycle.Brand = "Puch";

            Assert.AreEqual($"#{frameIdExpected} - Road Bike by Puch (Mileage: 0 km)", bicycle.ToString());
        }

        [TestMethod]
        public void TestRide()
        {
            Bicycle bicycle = new Bicycle("Pinarello", "Road");

            bicycle.Ride(42);

            Assert.AreEqual(42, bicycle.Mileage);
        }

        [TestMethod]
        public void TestRideMultipleCalls()
        {
            Bicycle bicycle = new Bicycle("Pinarello", "Road");

            bicycle.Ride(114);
            bicycle.Ride(80);
            bicycle.Ride(46);

            Assert.AreEqual(240, bicycle.Mileage);
        }

        [TestMethod]
        public void TestRideNegativeDistance()
        {
            Bicycle bicycle = new Bicycle("Pinarello", "Road");

            bicycle.Ride(-1);

            Assert.AreEqual(0, bicycle.Mileage);
        }

        [TestMethod]
        public void TestRideMultipleCallsNegativeDistance()
        {
            Bicycle bicycle = new Bicycle("Pinarello", "Road");

            bicycle.Ride(100);
            bicycle.Ride(-50);
            bicycle.Ride(23);

            Assert.AreEqual(123, bicycle.Mileage);
        }

        [TestMethod]
        public void TestRideChangesToString()
        {
            Bicycle bicycle = new Bicycle("Pinarello", "Road");
            int frameIdExpected = bicycle.FrameId;

            bicycle.Ride(78);

            Assert.AreEqual($"#{frameIdExpected} - Road Bike by Pinarello (Mileage: 78 km)", bicycle.ToString());
        }
    }
}
