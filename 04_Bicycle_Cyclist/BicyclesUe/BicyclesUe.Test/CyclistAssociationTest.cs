using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using BicyclesUe;

namespace Bicycles.Test
{
    [TestClass]
    public class CyclistAssociationTest
    {
        [TestMethod]
        public void TestAddBicycle()
        {
            Bicycle bikeRaleighMountain = new Bicycle("Raleigh", "Mountain");
            int frameIdRaleighMountain = bikeRaleighMountain.FrameId;
            Bicycle bikeYetiMountain = new Bicycle("Yeti", "Mountain");
            int frameIdYetiMountain = bikeYetiMountain.FrameId;
            Bicycle bikeRaleighRoad = new Bicycle("Raleigh", "Road");
            int frameIdRaleighRoad = bikeRaleighRoad.FrameId;
            Bicycle bikePinarelloRoad = new Bicycle("Pinarello", "Road");
            int frameIdPinarelloRoad = bikePinarelloRoad.FrameId;

            Cyclist cyclistTomac = new Cyclist("John Tomac", "Yeti Cycles");

            Assert.AreEqual(0, cyclistTomac.BicycleCount);
            Assert.AreEqual(false, cyclistTomac.HasBicycle(frameIdRaleighMountain));
            Assert.AreEqual(false, cyclistTomac.HasBicycle(frameIdYetiMountain));
            Assert.AreEqual(false, cyclistTomac.HasBicycle(frameIdRaleighRoad));
            Assert.AreEqual(false, cyclistTomac.HasBicycle(frameIdPinarelloRoad));

            bool isAddSuccessful = cyclistTomac.AddBicycle(bikeRaleighMountain);

            Assert.AreEqual(true, isAddSuccessful);
            Assert.AreEqual(1, cyclistTomac.BicycleCount);
            Assert.AreEqual(true, cyclistTomac.HasBicycle(frameIdRaleighMountain));
            Assert.AreEqual(false, cyclistTomac.HasBicycle(frameIdYetiMountain));
            Assert.AreEqual(false, cyclistTomac.HasBicycle(frameIdRaleighRoad));
            Assert.AreEqual(false, cyclistTomac.HasBicycle(frameIdPinarelloRoad));

            isAddSuccessful = cyclistTomac.AddBicycle(bikeRaleighRoad);

            Assert.AreEqual(true, isAddSuccessful);
            Assert.AreEqual(2, cyclistTomac.BicycleCount);
            Assert.AreEqual(true, cyclistTomac.HasBicycle(frameIdRaleighMountain));
            Assert.AreEqual(false, cyclistTomac.HasBicycle(frameIdYetiMountain));
            Assert.AreEqual(true, cyclistTomac.HasBicycle(frameIdRaleighRoad));
            Assert.AreEqual(false, cyclistTomac.HasBicycle(frameIdPinarelloRoad));

            isAddSuccessful = cyclistTomac.AddBicycle(bikeRaleighRoad); //duplicate!

            Assert.AreEqual(false, isAddSuccessful);
            Assert.AreEqual(2, cyclistTomac.BicycleCount);
            Assert.AreEqual(true, cyclistTomac.HasBicycle(frameIdRaleighMountain));
            Assert.AreEqual(false, cyclistTomac.HasBicycle(frameIdYetiMountain));
            Assert.AreEqual(true, cyclistTomac.HasBicycle(frameIdRaleighRoad));
            Assert.AreEqual(false, cyclistTomac.HasBicycle(frameIdPinarelloRoad));

            isAddSuccessful = cyclistTomac.AddBicycle(bikeYetiMountain);

            Assert.AreEqual(true, isAddSuccessful);
            Assert.AreEqual(3, cyclistTomac.BicycleCount);
            Assert.AreEqual(true, cyclistTomac.HasBicycle(frameIdRaleighMountain));
            Assert.AreEqual(true, cyclistTomac.HasBicycle(frameIdYetiMountain));
            Assert.AreEqual(true, cyclistTomac.HasBicycle(frameIdRaleighRoad));
            Assert.AreEqual(false, cyclistTomac.HasBicycle(frameIdPinarelloRoad));

            isAddSuccessful = cyclistTomac.AddBicycle(bikePinarelloRoad); //too many bikes

            Assert.AreEqual(false, isAddSuccessful);
            Assert.AreEqual(3, cyclistTomac.BicycleCount);
            Assert.AreEqual(true, cyclistTomac.HasBicycle(frameIdRaleighMountain));
            Assert.AreEqual(true, cyclistTomac.HasBicycle(frameIdYetiMountain));
            Assert.AreEqual(true, cyclistTomac.HasBicycle(frameIdRaleighRoad));
            Assert.AreEqual(false, cyclistTomac.HasBicycle(frameIdPinarelloRoad));
        }

        [TestMethod]
        public void TestRemoveBicycle()
        {
            Bicycle bikePinarelloRoad = new Bicycle("Pinarello", "Road");
            int frameIdPinarelloRoad = bikePinarelloRoad.FrameId;
            Bicycle bikePuchCity = new Bicycle("Puch", "City");
            int frameIdPuchCity = bikePuchCity.FrameId;
            Bicycle bikeTrekRoad = new Bicycle("Trek", "Road");
            int frameIdTrekRoad = bikeTrekRoad.FrameId;
            Bicycle bikeKtmTrekking = new Bicycle("KTM", "Trekking");
            int frameIdKtmTrekking = bikeKtmTrekking.FrameId;

            int frameIdInvalid = frameIdKtmTrekking + 1;

            Cyclist cyclistArmstrong = new Cyclist("Lance Armstrong", "Motorola");

            cyclistArmstrong.AddBicycle(bikePinarelloRoad);
            cyclistArmstrong.AddBicycle(bikePuchCity);
            cyclistArmstrong.AddBicycle(bikeTrekRoad);

            Assert.AreEqual(3, cyclistArmstrong.BicycleCount);
            Assert.AreEqual(true, cyclistArmstrong.HasBicycle(frameIdPinarelloRoad));
            Assert.AreEqual(true, cyclistArmstrong.HasBicycle(frameIdPuchCity));
            Assert.AreEqual(true, cyclistArmstrong.HasBicycle(frameIdTrekRoad));
            Assert.AreEqual(false, cyclistArmstrong.HasBicycle(frameIdKtmTrekking));

            bool isRemoveSuccessful = cyclistArmstrong.RemoveBicycle(frameIdPinarelloRoad);

            Assert.AreEqual(true, isRemoveSuccessful);
            Assert.AreEqual(2, cyclistArmstrong.BicycleCount);
            Assert.AreEqual(false, cyclistArmstrong.HasBicycle(frameIdPinarelloRoad));
            Assert.AreEqual(true, cyclistArmstrong.HasBicycle(frameIdPuchCity));
            Assert.AreEqual(true, cyclistArmstrong.HasBicycle(frameIdTrekRoad));
            Assert.AreEqual(false, cyclistArmstrong.HasBicycle(frameIdKtmTrekking));

            isRemoveSuccessful = cyclistArmstrong.RemoveBicycle(frameIdInvalid);

            Assert.AreEqual(false, isRemoveSuccessful);
            Assert.AreEqual(2, cyclistArmstrong.BicycleCount);
            Assert.AreEqual(false, cyclistArmstrong.HasBicycle(frameIdPinarelloRoad));
            Assert.AreEqual(true, cyclistArmstrong.HasBicycle(frameIdPuchCity));
            Assert.AreEqual(true, cyclistArmstrong.HasBicycle(frameIdTrekRoad));
            Assert.AreEqual(false, cyclistArmstrong.HasBicycle(frameIdKtmTrekking));

            cyclistArmstrong.AddBicycle(bikeKtmTrekking);

            Assert.AreEqual(3, cyclistArmstrong.BicycleCount);
            Assert.AreEqual(false, cyclistArmstrong.HasBicycle(frameIdPinarelloRoad));
            Assert.AreEqual(true, cyclistArmstrong.HasBicycle(frameIdPuchCity));
            Assert.AreEqual(true, cyclistArmstrong.HasBicycle(frameIdTrekRoad));
            Assert.AreEqual(true, cyclistArmstrong.HasBicycle(frameIdKtmTrekking));

            isRemoveSuccessful = cyclistArmstrong.RemoveBicycle(frameIdTrekRoad);

            Assert.AreEqual(true, isRemoveSuccessful);
            Assert.AreEqual(2, cyclistArmstrong.BicycleCount);
            Assert.AreEqual(false, cyclistArmstrong.HasBicycle(frameIdPinarelloRoad));
            Assert.AreEqual(true, cyclistArmstrong.HasBicycle(frameIdPuchCity));
            Assert.AreEqual(false, cyclistArmstrong.HasBicycle(frameIdTrekRoad));
            Assert.AreEqual(true, cyclistArmstrong.HasBicycle(frameIdKtmTrekking));

            isRemoveSuccessful = cyclistArmstrong.RemoveBicycle(frameIdTrekRoad);

            Assert.AreEqual(false, isRemoveSuccessful);
            Assert.AreEqual(2, cyclistArmstrong.BicycleCount);
            Assert.AreEqual(false, cyclistArmstrong.HasBicycle(frameIdPinarelloRoad));
            Assert.AreEqual(true, cyclistArmstrong.HasBicycle(frameIdPuchCity));
            Assert.AreEqual(false, cyclistArmstrong.HasBicycle(frameIdTrekRoad));
            Assert.AreEqual(true, cyclistArmstrong.HasBicycle(frameIdKtmTrekking));

            cyclistArmstrong.RemoveBicycle(frameIdPuchCity);
            cyclistArmstrong.RemoveBicycle(frameIdKtmTrekking);

            Assert.AreEqual(0, cyclistArmstrong.BicycleCount);
            Assert.AreEqual(false, cyclistArmstrong.HasBicycle(frameIdPinarelloRoad));
            Assert.AreEqual(false, cyclistArmstrong.HasBicycle(frameIdPuchCity));
            Assert.AreEqual(false, cyclistArmstrong.HasBicycle(frameIdTrekRoad));
            Assert.AreEqual(false, cyclistArmstrong.HasBicycle(frameIdKtmTrekking));
        }

        [TestMethod]
        public void TestToString()
        {
            Bicycle bikePinarelloRoad = new Bicycle("Pinarello", "Road");
            Bicycle bikeScottMountain = new Bicycle("Scott", "Mountain");
            Bicycle bikePuchCity = new Bicycle("Puch", "City");
            Bicycle trekRoad = new Bicycle("Trek", "Road");
            Bicycle bikeKtmTrekking = new Bicycle("KTM", "Trekking");

            Cyclist cyclist = new Cyclist("Fausto Coppi");
            Assert.AreEqual("Fausto Coppi (Team: None)", cyclist.ToString());

            cyclist.AddBicycle(bikePinarelloRoad);
            Assert.AreEqual("Fausto Coppi (Team: None), 1 bike(s) owned", cyclist.ToString());

            cyclist = new Cyclist("Gerhard Gehrer", "HTL Leonding Racing Team");
            Assert.AreEqual("Gerhard Gehrer (Team: HTL Leonding Racing Team)", cyclist.ToString());

            cyclist.AddBicycle(bikeScottMountain);
            cyclist.AddBicycle(bikePuchCity);
            Assert.AreEqual("Gerhard Gehrer (Team: HTL Leonding Racing Team), 2 bike(s) owned", cyclist.ToString());

            cyclist.AddBicycle(trekRoad);
            cyclist.AddBicycle(bikeKtmTrekking);
            Assert.AreEqual("Gerhard Gehrer (Team: HTL Leonding Racing Team), 3 bike(s) owned", cyclist.ToString());

            cyclist.RemoveBicycle(bikePuchCity.FrameId);
            Assert.AreEqual("Gerhard Gehrer (Team: HTL Leonding Racing Team), 2 bike(s) owned", cyclist.ToString());

            cyclist.AddBicycle(bikeKtmTrekking);
            Assert.AreEqual("Gerhard Gehrer (Team: HTL Leonding Racing Team), 3 bike(s) owned", cyclist.ToString());

            cyclist.RemoveBicycle(bikeScottMountain.FrameId);
            cyclist.RemoveBicycle(bikePuchCity.FrameId);
            cyclist.RemoveBicycle(trekRoad.FrameId);
            cyclist.RemoveBicycle(bikeKtmTrekking.FrameId);

            Assert.AreEqual("Gerhard Gehrer (Team: HTL Leonding Racing Team)", cyclist.ToString());
        }

        [TestMethod]
        public void TestTotalMileage()
        {
            Bicycle bikeTrekRoad = new Bicycle("Trek", "Road");
            Bicycle bikeRaleighMountain = new Bicycle("Raleigh", "Mountain");
            Bicycle bikePinarelloRoad = new Bicycle("Pinarello", "Road");

            Cyclist cyclistVoigt = new Cyclist("Jens Voigt");

            cyclistVoigt.AddBicycle(bikeTrekRoad);
            cyclistVoigt.AddBicycle(bikeRaleighMountain);

            Assert.AreEqual(0, cyclistVoigt.TotalMileage);

            bikeTrekRoad.Ride(25);

            Assert.AreEqual(25, cyclistVoigt.TotalMileage);

            bikeRaleighMountain.Ride(75);
            bikeTrekRoad.Ride(100);

            Assert.AreEqual(200, cyclistVoigt.TotalMileage);

            cyclistVoigt.AddBicycle(bikePinarelloRoad);

            Assert.AreEqual(200, cyclistVoigt.TotalMileage);

            bikeRaleighMountain.Ride(19);
            bikePinarelloRoad.Ride(74);
            bikeTrekRoad.Ride(97);

            Assert.AreEqual(390, cyclistVoigt.TotalMileage);

            cyclistVoigt.RemoveBicycle(bikePinarelloRoad.FrameId);

            bikePinarelloRoad.Ride(100);

            Assert.AreEqual(316, cyclistVoigt.TotalMileage);
        }
    }
}
