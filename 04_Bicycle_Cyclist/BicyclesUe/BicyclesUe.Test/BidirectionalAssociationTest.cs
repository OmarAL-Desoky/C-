using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using BicyclesUe;

namespace Bicycles.Test
{
    [TestClass]
    public class BidirectionalAssociationTest
    {
        [TestMethod]
        public void TestBicycleToCyclist()
        {
            Bicycle bicycle = new Bicycle("Cannondale", "Road");

            Assert.AreEqual(null, bicycle.Owner);

            Cyclist cyclist = new Cyclist("Lance Armstrong", "Motorola");

            Assert.AreEqual(0, cyclist.BicycleCount);
            Assert.AreEqual(false, cyclist.HasBicycle(bicycle.FrameId));

            bicycle.Owner = cyclist;

            Assert.AreEqual(cyclist, bicycle.Owner);
            Assert.AreEqual(1, cyclist.BicycleCount);
            Assert.AreEqual(true, cyclist.HasBicycle(bicycle.FrameId));

            bicycle.Owner = null;

            Assert.AreEqual(null, bicycle.Owner);
            Assert.AreEqual(0, cyclist.BicycleCount);
            Assert.AreEqual(false, cyclist.HasBicycle(bicycle.FrameId));
        }

        [TestMethod]
        public void TestBicycleToCyclistManyBikes()
        {
            Bicycle bikeCannondaleMountain = new Bicycle("Cannondale", "Mountain");
            Bicycle bikeYetiMountain = new Bicycle("Yeti", "Mountain");
            Bicycle bikePuchCity = new Bicycle("Puch", "City");
            Bicycle bikePinarelloRoad = new Bicycle("Pinarello", "Road");

            Cyclist cyclist = new Cyclist("Lance Armstrong");

            Assert.AreEqual(null, bikeCannondaleMountain.Owner);
            Assert.AreEqual(null, bikeYetiMountain.Owner);
            Assert.AreEqual(null, bikePuchCity.Owner);
            Assert.AreEqual(null, bikePinarelloRoad.Owner);
            Assert.AreEqual(false, cyclist.HasBicycle(bikeCannondaleMountain.FrameId));
            Assert.AreEqual(false, cyclist.HasBicycle(bikeYetiMountain.FrameId));
            Assert.AreEqual(false, cyclist.HasBicycle(bikePuchCity.FrameId));
            Assert.AreEqual(false, cyclist.HasBicycle(bikePinarelloRoad.FrameId));
            Assert.AreEqual(0, cyclist.BicycleCount);

            bikeCannondaleMountain.Owner = cyclist;
            bikeYetiMountain.Owner = cyclist;
            bikePuchCity.Owner = cyclist;
            bikePinarelloRoad.Owner = cyclist;

            Assert.AreEqual(cyclist, bikeCannondaleMountain.Owner);
            Assert.AreEqual(cyclist, bikeYetiMountain.Owner);
            Assert.AreEqual(cyclist, bikePuchCity.Owner);
            Assert.AreEqual(null, bikePinarelloRoad.Owner);
            Assert.AreEqual(true, cyclist.HasBicycle(bikeCannondaleMountain.FrameId));
            Assert.AreEqual(true, cyclist.HasBicycle(bikeYetiMountain.FrameId));
            Assert.AreEqual(true, cyclist.HasBicycle(bikePuchCity.FrameId));
            Assert.AreEqual(false, cyclist.HasBicycle(bikePinarelloRoad.FrameId));
            Assert.AreEqual(3, cyclist.BicycleCount);

            bikePuchCity.Owner = null;
            bikePinarelloRoad.Owner = cyclist;

            Assert.AreEqual(cyclist, bikeCannondaleMountain.Owner);
            Assert.AreEqual(cyclist, bikeYetiMountain.Owner);
            Assert.AreEqual(null, bikePuchCity.Owner);
            Assert.AreEqual(cyclist, bikePinarelloRoad.Owner);
            Assert.AreEqual(true, cyclist.HasBicycle(bikeCannondaleMountain.FrameId));
            Assert.AreEqual(true, cyclist.HasBicycle(bikeYetiMountain.FrameId));
            Assert.AreEqual(false, cyclist.HasBicycle(bikePuchCity.FrameId));
            Assert.AreEqual(true, cyclist.HasBicycle(bikePinarelloRoad.FrameId));
            Assert.AreEqual(3, cyclist.BicycleCount);
        }

        [TestMethod]
        public void TestCyclistToBicycle()
        {
            Bicycle bicycle = new Bicycle("Raleigh", "Mountain");

            Assert.AreEqual(null, bicycle.Owner);

            Cyclist cyclist = new Cyclist("John Tomac", "Yeti Cycles");

            Assert.AreEqual(0, cyclist.BicycleCount);
            Assert.AreEqual(false, cyclist.HasBicycle(bicycle.FrameId));

            cyclist.AddBicycle(bicycle);

            Assert.AreEqual(cyclist, bicycle.Owner);
            Assert.AreEqual(1, cyclist.BicycleCount);
            Assert.AreEqual(true, cyclist.HasBicycle(bicycle.FrameId));

            cyclist.RemoveBicycle(bicycle.FrameId);

            Assert.AreEqual(null, bicycle.Owner);
            Assert.AreEqual(0, cyclist.BicycleCount);
            Assert.AreEqual(false, cyclist.HasBicycle(bicycle.FrameId));
        }

        [TestMethod]
        public void TestOwnershipChange()
        {
            Bicycle bicycle = new Bicycle("Raleigh", "Mountain");

            Cyclist cyclistTomac = new Cyclist("John Tomac", "Yeti Cycles");
            Cyclist cyclistGehrer = new Cyclist("Gerhard Gehrer", "HTL Leonding Racing Team");

            Assert.AreEqual(null, bicycle.Owner);
            Assert.AreEqual(0, cyclistTomac.BicycleCount);
            Assert.AreEqual(false, cyclistTomac.HasBicycle(bicycle.FrameId));
            Assert.AreEqual(0, cyclistGehrer.BicycleCount);
            Assert.AreEqual(false, cyclistGehrer.HasBicycle(bicycle.FrameId));

            bicycle.Owner = cyclistTomac;

            Assert.AreEqual(cyclistTomac, bicycle.Owner);
            Assert.AreEqual(1, cyclistTomac.BicycleCount);
            Assert.AreEqual(true, cyclistTomac.HasBicycle(bicycle.FrameId));
            Assert.AreEqual(0, cyclistGehrer.BicycleCount);
            Assert.AreEqual(false, cyclistGehrer.HasBicycle(bicycle.FrameId));

            cyclistGehrer.AddBicycle(bicycle);

            Assert.AreEqual(cyclistGehrer, bicycle.Owner);
            Assert.AreEqual(0, cyclistTomac.BicycleCount);
            Assert.AreEqual(false, cyclistTomac.HasBicycle(bicycle.FrameId));
            Assert.AreEqual(1, cyclistGehrer.BicycleCount);
            Assert.AreEqual(true, cyclistGehrer.HasBicycle(bicycle.FrameId));

            cyclistTomac.AddBicycle(bicycle);

            Assert.AreEqual(cyclistTomac, bicycle.Owner);
            Assert.AreEqual(1, cyclistTomac.BicycleCount);
            Assert.AreEqual(true, cyclistTomac.HasBicycle(bicycle.FrameId));
            Assert.AreEqual(0, cyclistGehrer.BicycleCount);
            Assert.AreEqual(false, cyclistGehrer.HasBicycle(bicycle.FrameId));

            bicycle.Owner = cyclistGehrer;

            Assert.AreEqual(cyclistGehrer, bicycle.Owner);
            Assert.AreEqual(0, cyclistTomac.BicycleCount);
            Assert.AreEqual(false, cyclistTomac.HasBicycle(bicycle.FrameId));
            Assert.AreEqual(1, cyclistGehrer.BicycleCount);
            Assert.AreEqual(true, cyclistGehrer.HasBicycle(bicycle.FrameId));
        }
    }
}
