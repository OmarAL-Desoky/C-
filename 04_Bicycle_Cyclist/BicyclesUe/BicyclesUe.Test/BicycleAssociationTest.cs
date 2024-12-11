using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using BicyclesUe;

namespace Bicycles.Test
{
    [TestClass]
    public class BicycleAssociationTest
    {
        [TestMethod]
        public void TestSetOwner()
        {
            Bicycle bicycle = new Bicycle("Pinarello", "Road");

            Assert.AreEqual(null, bicycle.Owner);

            Cyclist cyclist = new Cyclist("Jan Ullrich", "Doping United");

            bicycle.Owner = cyclist;

            Assert.AreEqual(cyclist, bicycle.Owner);
        }

        [TestMethod]
        public void TestSetOwnerChangeOwner()
        {
            Bicycle bicycle = new Bicycle("Pinarello", "Road");

            Assert.AreEqual(null, bicycle.Owner);

            Cyclist cyclistUllrich = new Cyclist("Jan Ullrich", "Doping United");

            bicycle.Owner = cyclistUllrich;

            Assert.AreEqual(cyclistUllrich, bicycle.Owner);

            Cyclist cyclistArmstrong = new Cyclist("Lance Armstrong");

            bicycle.Owner = cyclistArmstrong;

            Assert.AreEqual(cyclistArmstrong, bicycle.Owner);
        }

        [TestMethod]
        public void TestSetOwnerRemoveOwner()
        {
            Bicycle bicycle = new Bicycle("Pinarello", "Road");

            Assert.AreEqual(null, bicycle.Owner);

            Cyclist cyclist = new Cyclist("Jan Ullrich", "Doping United");

            bicycle.Owner = cyclist;

            Assert.AreEqual(cyclist, bicycle.Owner);

            bicycle.Owner = null;

            Assert.AreEqual(null, bicycle.Owner);
        }

        [TestMethod]
        public void TestToString()
        {
            Bicycle bicycle = new Bicycle("Pinarello", "Road");
            int frameIdExpected = bicycle.FrameId;

            Assert.AreEqual($"#{frameIdExpected} - Road Bike by Pinarello (Mileage: 0 km)", bicycle.ToString());

            Cyclist cyclist = new Cyclist("Lance Armstrong");
            bicycle.Owner = cyclist;

            Assert.AreEqual($"#{frameIdExpected} - Road Bike by Pinarello (Mileage: 0 km), owned by Lance Armstrong", bicycle.ToString());
        }

        [TestMethod]
        public void TestToStringChangeOwner()
        {
            Bicycle bicycle = new Bicycle("Trek", "City");
            int frameIdExpected = bicycle.FrameId;

            Assert.AreEqual($"#{frameIdExpected} - City Bike by Trek (Mileage: 0 km)", bicycle.ToString());

            Cyclist cyclistArmstrong = new Cyclist("Lance Armstrong");
            bicycle.Owner = cyclistArmstrong;

            Assert.AreEqual($"#{frameIdExpected} - City Bike by Trek (Mileage: 0 km), owned by Lance Armstrong", bicycle.ToString());

            Cyclist cyclistUllrich = new Cyclist("Jan Ullrich", "Doping United");
            bicycle.Owner = cyclistUllrich;

            Assert.AreEqual($"#{frameIdExpected} - City Bike by Trek (Mileage: 0 km), owned by Jan Ullrich", bicycle.ToString());
        }

        [TestMethod]
        public void TestToStringRemoveOwner()
        {
            Bicycle bicycle = new Bicycle("KTM", "Mountain");
            int frameIdExpected = bicycle.FrameId;

            Assert.AreEqual($"#{frameIdExpected} - Mountain Bike by KTM (Mileage: 0 km)", bicycle.ToString());

            Cyclist cyclist = new Cyclist("Lance Armstrong");
            bicycle.Owner = cyclist;

            Assert.AreEqual($"#{frameIdExpected} - Mountain Bike by KTM (Mileage: 0 km), owned by Lance Armstrong", bicycle.ToString());

            bicycle.Owner = null;

            Assert.AreEqual($"#{frameIdExpected} - Mountain Bike by KTM (Mileage: 0 km)", bicycle.ToString());
        }

        [TestMethod]
        public void TestToStringMileageChanges()
        {
            Bicycle bicycle = new Bicycle("KTM", "Mountain");
            int frameIdExpected = bicycle.FrameId;

            Assert.AreEqual($"#{frameIdExpected} - Mountain Bike by KTM (Mileage: 0 km)", bicycle.ToString());

            Cyclist cyclist = new Cyclist("Lance Armstrong");
            bicycle.Owner = cyclist;

            Assert.AreEqual($"#{frameIdExpected} - Mountain Bike by KTM (Mileage: 0 km), owned by Lance Armstrong", bicycle.ToString());

            bicycle.Ride(50);

            Assert.AreEqual($"#{frameIdExpected} - Mountain Bike by KTM (Mileage: 50 km), owned by Lance Armstrong", bicycle.ToString());

            bicycle.Ride(150);

            Assert.AreEqual($"#{frameIdExpected} - Mountain Bike by KTM (Mileage: 200 km), owned by Lance Armstrong", bicycle.ToString());
        }

        [TestMethod]
        public void TestToStringMileageAndOwnerChanges()
        {
            Bicycle bicycle = new Bicycle("KTM", "Mountain");
            int frameIdExpected = bicycle.FrameId;

            Assert.AreEqual($"#{frameIdExpected} - Mountain Bike by KTM (Mileage: 0 km)", bicycle.ToString());

            Cyclist cyclistArmstrong = new Cyclist("Lance Armstrong");
            bicycle.Owner = cyclistArmstrong;

            Assert.AreEqual($"#{frameIdExpected} - Mountain Bike by KTM (Mileage: 0 km), owned by Lance Armstrong", bicycle.ToString());

            bicycle.Ride(50);

            Assert.AreEqual($"#{frameIdExpected} - Mountain Bike by KTM (Mileage: 50 km), owned by Lance Armstrong", bicycle.ToString());

            Cyclist cyclistUllrich = new Cyclist("Jan Ullrich", "Doping United");
            bicycle.Owner = cyclistUllrich;

            Assert.AreEqual($"#{frameIdExpected} - Mountain Bike by KTM (Mileage: 0 km), owned by Jan Ullrich", bicycle.ToString());

            bicycle.Ride(20);

            Assert.AreEqual($"#{frameIdExpected} - Mountain Bike by KTM (Mileage: 20 km), owned by Jan Ullrich", bicycle.ToString());
        }

        [TestMethod]
        public void TestMileageResetAfterOwnerChange()
        {
            Bicycle bicycle = new Bicycle("Puch", "Trekking");

            Assert.AreEqual(0, bicycle.Mileage);

            bicycle.Ride(25);

            Assert.AreEqual(25, bicycle.Mileage);

            Cyclist cyclistArmstrong = new Cyclist("Lance Armstrong");
            bicycle.Owner = cyclistArmstrong;

            Assert.AreEqual(0, bicycle.Mileage);

            bicycle.Ride(60);

            Assert.AreEqual(60, bicycle.Mileage);

            bicycle.Ride(100);

            Assert.AreEqual(160, bicycle.Mileage);

            Cyclist cyclistUllrich = new Cyclist("Jan Ullrich", "Doping United");
            bicycle.Owner = cyclistUllrich;

            Assert.AreEqual(0, bicycle.Mileage);
        }

        [TestMethod]
        public void TestMileageDoesNotResetSameOwnerChange()
        {
            Bicycle bicycle = new Bicycle("Cannonball", "Mountain");

            Cyclist cyclistGehrer = new Cyclist("Gerhard Gehrer", "HTL Leonding Racing Team");
            bicycle.Owner = cyclistGehrer;

            bicycle.Ride(90);

            Assert.AreEqual(90, bicycle.Mileage);

            bicycle.Owner = cyclistGehrer;

            Assert.AreEqual(90, bicycle.Mileage);
        }

        [TestMethod]
        public void TestMileageResetAfterOwnerChangeToNull()
        {
            Bicycle bicycle = new Bicycle("Puch", "City");

            Assert.AreEqual(0, bicycle.Mileage);

            bicycle.Ride(11);

            Assert.AreEqual(11, bicycle.Mileage);

            Cyclist cyclistArmstrong = new Cyclist("Lance Armstrong");
            bicycle.Owner = cyclistArmstrong;

            Assert.AreEqual(0, bicycle.Mileage);

            bicycle.Ride(60);

            Assert.AreEqual(60, bicycle.Mileage);

            bicycle.Owner = null;

            Assert.AreEqual(0, bicycle.Mileage);
        }
    }
}
