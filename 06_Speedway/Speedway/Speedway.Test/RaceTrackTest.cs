using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Speedway.Test
{
    [TestClass]
    public class RaceTrackTest
    {
        [TestMethod]
        public void TestConstructorNoParameters()
        {
            RaceTrack raceTrack = new RaceTrack();
            Assert.AreEqual(383.0, raceTrack.TrackLength, 0.001);
            Assert.AreEqual(1532.0, raceTrack.RaceDistance, 0.001); //383 * 4
        }

        [TestMethod]
        public void TestConstructorValidParameters()
        {
            RaceTrack raceTrack = new RaceTrack(260);
            Assert.AreEqual(260.0, raceTrack.TrackLength, 0.001);
            Assert.AreEqual(1040.0, raceTrack.RaceDistance, 0.001); //260 * 4

            raceTrack = new RaceTrack(450);
            Assert.AreEqual(450.0, raceTrack.TrackLength, 0.001);
            Assert.AreEqual(1800.0, raceTrack.RaceDistance, 0.001); //450 * 4

            raceTrack = new RaceTrack(307.5);
            Assert.AreEqual(307.5, raceTrack.TrackLength, 0.001);
            Assert.AreEqual(1230.0, raceTrack.RaceDistance, 0.001); //307.5 * 4
        }

        [TestMethod]
        public void TestConstructorInvalidParameters()
        {
            RaceTrack raceTrack = new RaceTrack(259);
            Assert.AreEqual(383.0, raceTrack.TrackLength, 0.001);

            raceTrack = new RaceTrack(0);
            Assert.AreEqual(383.0, raceTrack.TrackLength, 0.001);

            raceTrack = new RaceTrack(-123);
            Assert.AreEqual(383.0, raceTrack.TrackLength, 0.001);

            raceTrack = new RaceTrack(451);
            Assert.AreEqual(383.0, raceTrack.TrackLength, 0.001);

            raceTrack = new RaceTrack(999);
            Assert.AreEqual(383.0, raceTrack.TrackLength, 0.001);
        }

        [TestMethod]
        public void TestRegisterUnregister()
        {
            RaceTrack raceTrack = new RaceTrack();

            Rider riderA = new Rider("Andreas", "Jonsson");
            Rider riderB = new Rider("Leigh", "Adams");
            Rider riderC = new Rider("Maciej", "Janowski");
            Rider riderD = new Rider("Emil", "Sayfutdinov");
            Rider riderE = new Rider("Hans", "Nielsen");

            Assert.AreEqual(0, raceTrack.RidersCount);
            Assert.AreEqual(false, raceTrack.HasRider(riderA.JerseyNumber));
            Assert.AreEqual(false, raceTrack.HasRider(riderB.JerseyNumber));
            Assert.AreEqual(false, raceTrack.HasRider(riderC.JerseyNumber));
            Assert.AreEqual(false, raceTrack.HasRider(riderD.JerseyNumber));
            Assert.AreEqual(false, raceTrack.HasRider(riderE.JerseyNumber));

            bool isRegisterASuccessful = raceTrack.RegisterRider(riderA);

            Assert.AreEqual(true, isRegisterASuccessful);

            Assert.AreEqual(1, raceTrack.RidersCount);
            Assert.AreEqual(true, raceTrack.HasRider(riderA.JerseyNumber));
            Assert.AreEqual(false, raceTrack.HasRider(riderB.JerseyNumber));
            Assert.AreEqual(false, raceTrack.HasRider(riderC.JerseyNumber));
            Assert.AreEqual(false, raceTrack.HasRider(riderD.JerseyNumber));
            Assert.AreEqual(false, raceTrack.HasRider(riderE.JerseyNumber));

            bool isRegisterBSuccessful = raceTrack.RegisterRider(riderB);

            Assert.AreEqual(true, isRegisterBSuccessful);

            Assert.AreEqual(2, raceTrack.RidersCount);
            Assert.AreEqual(true, raceTrack.HasRider(riderA.JerseyNumber));
            Assert.AreEqual(true, raceTrack.HasRider(riderB.JerseyNumber));
            Assert.AreEqual(false, raceTrack.HasRider(riderC.JerseyNumber));
            Assert.AreEqual(false, raceTrack.HasRider(riderD.JerseyNumber));
            Assert.AreEqual(false, raceTrack.HasRider(riderE.JerseyNumber));

            isRegisterBSuccessful = raceTrack.RegisterRider(riderB); //register duplicate

            Assert.AreEqual(false, isRegisterBSuccessful);

            Assert.AreEqual(2, raceTrack.RidersCount);
            Assert.AreEqual(true, raceTrack.HasRider(riderA.JerseyNumber));
            Assert.AreEqual(true, raceTrack.HasRider(riderB.JerseyNumber));
            Assert.AreEqual(false, raceTrack.HasRider(riderC.JerseyNumber));
            Assert.AreEqual(false, raceTrack.HasRider(riderD.JerseyNumber));
            Assert.AreEqual(false, raceTrack.HasRider(riderE.JerseyNumber));

            bool isRegisterCSuccessful = raceTrack.RegisterRider(riderC);

            Assert.AreEqual(true, isRegisterCSuccessful);

            Assert.AreEqual(3, raceTrack.RidersCount);
            Assert.AreEqual(true, raceTrack.HasRider(riderA.JerseyNumber));
            Assert.AreEqual(true, raceTrack.HasRider(riderB.JerseyNumber));
            Assert.AreEqual(true, raceTrack.HasRider(riderC.JerseyNumber));
            Assert.AreEqual(false, raceTrack.HasRider(riderD.JerseyNumber));
            Assert.AreEqual(false, raceTrack.HasRider(riderE.JerseyNumber));

            bool isRegisterDSuccessful = raceTrack.RegisterRider(riderD);

            Assert.AreEqual(true, isRegisterDSuccessful);

            Assert.AreEqual(4, raceTrack.RidersCount);
            Assert.AreEqual(true, raceTrack.HasRider(riderA.JerseyNumber));
            Assert.AreEqual(true, raceTrack.HasRider(riderB.JerseyNumber));
            Assert.AreEqual(true, raceTrack.HasRider(riderC.JerseyNumber));
            Assert.AreEqual(true, raceTrack.HasRider(riderD.JerseyNumber));
            Assert.AreEqual(false, raceTrack.HasRider(riderE.JerseyNumber));

            bool isRegisterESuccessful = raceTrack.RegisterRider(riderE); //too many riders!

            Assert.AreEqual(false, isRegisterESuccessful);

            Assert.AreEqual(4, raceTrack.RidersCount);
            Assert.AreEqual(true, raceTrack.HasRider(riderA.JerseyNumber));
            Assert.AreEqual(true, raceTrack.HasRider(riderB.JerseyNumber));
            Assert.AreEqual(true, raceTrack.HasRider(riderC.JerseyNumber));
            Assert.AreEqual(true, raceTrack.HasRider(riderD.JerseyNumber));
            Assert.AreEqual(false, raceTrack.HasRider(riderE.JerseyNumber));

            bool isUnregisterCSuccessful = raceTrack.UnregisterRider(riderC.JerseyNumber);

            Assert.AreEqual(true, isUnregisterCSuccessful);

            Assert.AreEqual(3, raceTrack.RidersCount);
            Assert.AreEqual(true, raceTrack.HasRider(riderA.JerseyNumber));
            Assert.AreEqual(true, raceTrack.HasRider(riderB.JerseyNumber));
            Assert.AreEqual(false, raceTrack.HasRider(riderC.JerseyNumber));
            Assert.AreEqual(true, raceTrack.HasRider(riderD.JerseyNumber));
            Assert.AreEqual(false, raceTrack.HasRider(riderE.JerseyNumber));

            bool isUnregisterESuccessful = raceTrack.UnregisterRider(riderE.JerseyNumber); //unregister not registered rider

            Assert.AreEqual(false, isUnregisterESuccessful);

            Assert.AreEqual(3, raceTrack.RidersCount);
            Assert.AreEqual(true, raceTrack.HasRider(riderA.JerseyNumber));
            Assert.AreEqual(true, raceTrack.HasRider(riderB.JerseyNumber));
            Assert.AreEqual(false, raceTrack.HasRider(riderC.JerseyNumber));
            Assert.AreEqual(true, raceTrack.HasRider(riderD.JerseyNumber));
            Assert.AreEqual(false, raceTrack.HasRider(riderE.JerseyNumber));

            isRegisterESuccessful = raceTrack.RegisterRider(riderE);

            Assert.AreEqual(true, isRegisterESuccessful);

            Assert.AreEqual(4, raceTrack.RidersCount);
            Assert.AreEqual(true, raceTrack.HasRider(riderA.JerseyNumber));
            Assert.AreEqual(true, raceTrack.HasRider(riderB.JerseyNumber));
            Assert.AreEqual(false, raceTrack.HasRider(riderC.JerseyNumber));
            Assert.AreEqual(true, raceTrack.HasRider(riderD.JerseyNumber));
            Assert.AreEqual(true, raceTrack.HasRider(riderE.JerseyNumber));

            isRegisterASuccessful = raceTrack.RegisterRider(riderA); //another duplicate

            Assert.AreEqual(false, isRegisterASuccessful);

            Assert.AreEqual(4, raceTrack.RidersCount);
            Assert.AreEqual(true, raceTrack.HasRider(riderA.JerseyNumber));
            Assert.AreEqual(true, raceTrack.HasRider(riderB.JerseyNumber));
            Assert.AreEqual(false, raceTrack.HasRider(riderC.JerseyNumber));
            Assert.AreEqual(true, raceTrack.HasRider(riderD.JerseyNumber));
            Assert.AreEqual(true, raceTrack.HasRider(riderE.JerseyNumber));

            bool isUnregisterASuccessful = raceTrack.UnregisterRider(riderA.JerseyNumber);

            Assert.AreEqual(true, isUnregisterASuccessful);

            Assert.AreEqual(3, raceTrack.RidersCount);
            Assert.AreEqual(false, raceTrack.HasRider(riderA.JerseyNumber));
            Assert.AreEqual(true, raceTrack.HasRider(riderB.JerseyNumber));
            Assert.AreEqual(false, raceTrack.HasRider(riderC.JerseyNumber));
            Assert.AreEqual(true, raceTrack.HasRider(riderD.JerseyNumber));
            Assert.AreEqual(true, raceTrack.HasRider(riderE.JerseyNumber));
        }

        [TestMethod]
        public void TestRegisterUnregisterDuplicate()
        {
            RaceTrack raceTrack = new RaceTrack();

            Rider riderA = new Rider("Andreas", "Jonsson");
            Rider riderB = new Rider("Leigh", "Adams");
            Rider riderC = new Rider("Maciej", "Janowski");
            Rider riderD = new Rider("Emil", "Sayfutdinov");

            Assert.AreEqual(true, raceTrack.RegisterRider(riderA));
            Assert.AreEqual(true, raceTrack.RegisterRider(riderB));
            Assert.AreEqual(true, raceTrack.RegisterRider(riderC));
            Assert.AreEqual(true, raceTrack.RegisterRider(riderD));

            Assert.AreEqual(4, raceTrack.RidersCount);
            Assert.AreEqual(true, raceTrack.HasRider(riderA.JerseyNumber));
            Assert.AreEqual(true, raceTrack.HasRider(riderB.JerseyNumber));
            Assert.AreEqual(true, raceTrack.HasRider(riderC.JerseyNumber));
            Assert.AreEqual(true, raceTrack.HasRider(riderD.JerseyNumber));

            Assert.AreEqual(true, raceTrack.UnregisterRider(riderB.JerseyNumber));

            Assert.AreEqual(3, raceTrack.RidersCount);
            Assert.AreEqual(true, raceTrack.HasRider(riderA.JerseyNumber));
            Assert.AreEqual(false, raceTrack.HasRider(riderB.JerseyNumber));
            Assert.AreEqual(true, raceTrack.HasRider(riderC.JerseyNumber));
            Assert.AreEqual(true, raceTrack.HasRider(riderD.JerseyNumber));

            Assert.AreEqual(false, raceTrack.RegisterRider(riderD));

            Assert.AreEqual(3, raceTrack.RidersCount);
            Assert.AreEqual(true, raceTrack.HasRider(riderA.JerseyNumber));
            Assert.AreEqual(false, raceTrack.HasRider(riderB.JerseyNumber));
            Assert.AreEqual(true, raceTrack.HasRider(riderC.JerseyNumber));
            Assert.AreEqual(true, raceTrack.HasRider(riderD.JerseyNumber));
        }

        [TestMethod]
        public void TestRace()
        {
            RaceTrack raceTrack = new RaceTrack(310);

            Rider riderA = new Rider("Billy", "Hamill");
            riderA.Motorcycle = new Motorcycle("Jawa", 65, 80);
            Rider riderB = new Rider("Jaroslaw", "Hampel");
            riderB.Motorcycle = new Motorcycle("GM", 67, 82.4);
            Rider riderC = new Rider("Jason", "Doyle");
            riderC.Motorcycle = new Motorcycle("Jawa", 80, 89.5);
            Rider riderD = new Rider("Artem", "Laguta");
            riderD.Motorcycle = new Motorcycle("GM", 73, 81);

            raceTrack.RegisterRider(riderA);
            raceTrack.RegisterRider(riderB);
            raceTrack.RegisterRider(riderC);
            raceTrack.RegisterRider(riderD);

            raceTrack.Race();

            Assert.AreEqual(20.0, riderA.Distance, 0.001);
            Assert.AreEqual(19.6, riderB.Distance, 0.001);
            Assert.AreEqual(25.5, riderC.Distance, 0.001);
            Assert.AreEqual(27.0, riderD.Distance, 0.001);

            raceTrack.Race();
            raceTrack.Race();
            raceTrack.Race();

            Assert.AreEqual(80.0, riderA.Distance, 0.001);
            Assert.AreEqual(78.4, riderB.Distance, 0.001);
            Assert.AreEqual(102.0, riderC.Distance, 0.001);
            Assert.AreEqual(108.0, riderD.Distance, 0.001);

            for (int i = 0; i < 20; i++)
            {
                raceTrack.Race();
            }

            Assert.AreEqual(480.0, riderA.Distance, 0.001);
            Assert.AreEqual(470.4, riderB.Distance, 0.001);
            Assert.AreEqual(612.0, riderC.Distance, 0.001);
            Assert.AreEqual(648.0, riderD.Distance, 0.001);
        }

        [TestMethod]
        public void TestRaceNotEnoughRiders()
        {
            RaceTrack raceTrack = new RaceTrack(420);

            Rider riderA = new Rider("Niels-Kristian", "Iversen");
            riderA.Motorcycle = new Motorcycle("GM", 71, 83);
            Rider riderB = new Rider("Chris", "Holder");
            riderB.Motorcycle = new Motorcycle("Jawa", 77, 89.5);
            Rider riderC = new Rider("Matej", "Zagar");
            riderC.Motorcycle = new Motorcycle("GM", 66, 79);
            Rider riderD = new Rider("Fredrik", "Lindgren");
            riderD.Motorcycle = new Motorcycle("GM", 80, 92.1);

            raceTrack.RegisterRider(riderA);
            raceTrack.RegisterRider(riderB);
            raceTrack.RegisterRider(riderC);

            Assert.AreEqual(3, raceTrack.RidersCount);

            raceTrack.Race();
            raceTrack.Race();
            raceTrack.Race();
            raceTrack.Race();

            Assert.AreEqual(0.0, riderA.Distance, 0.001);
            Assert.AreEqual(0.0, riderB.Distance, 0.001);
            Assert.AreEqual(0.0, riderC.Distance, 0.001);
            Assert.AreEqual(0.0, riderD.Distance, 0.001);

            raceTrack.RegisterRider(riderD);

            Assert.AreEqual(4, raceTrack.RidersCount);

            raceTrack.Race();
            raceTrack.Race();
            raceTrack.Race();
            raceTrack.Race();
            raceTrack.Race();

            Assert.AreEqual(115.0, riderA.Distance, 0.001);
            Assert.AreEqual(112.5, riderB.Distance, 0.001);
            Assert.AreEqual(110.0, riderC.Distance, 0.001);
            Assert.AreEqual(114.5, riderD.Distance, 0.001);

            raceTrack.UnregisterRider(riderB.JerseyNumber);

            Assert.AreEqual(3, raceTrack.RidersCount);

            raceTrack.Race();
            raceTrack.Race();

            Assert.AreEqual(115.0, riderA.Distance, 0.001);
            Assert.AreEqual(112.5, riderB.Distance, 0.001);
            Assert.AreEqual(110.0, riderC.Distance, 0.001);
            Assert.AreEqual(114.5, riderD.Distance, 0.001);
        }

        [TestMethod]
        public void TestRaceFinish()
        {
            RaceTrack raceTrack = new RaceTrack(377);

            Assert.AreEqual(1508.0, raceTrack.RaceDistance, 0.001);

            Rider riderA = new Rider("Ryan", "Sullivan");
            riderA.Motorcycle = new Motorcycle("Jawa", 78, 87.7);
            Rider riderB = new Rider("Hans N.", "Andersen");
            riderB.Motorcycle = new Motorcycle("Jawa", 70, 83);
            Rider riderC = new Rider("Tommy", "Knudsen");
            riderC.Motorcycle = new Motorcycle("GM", 66, 79.5);
            Rider riderD = new Rider("Krzysztof", "Kasprzak");
            riderD.Motorcycle = new Motorcycle("Jawa", 79, 85.5);

            raceTrack.RegisterRider(riderA);
            raceTrack.RegisterRider(riderB);
            raceTrack.RegisterRider(riderC);
            raceTrack.RegisterRider(riderD);

            for (int i = 0; i < 10; i++)
            {
                raceTrack.Race();
            }

            Assert.AreEqual(false, raceTrack.IsFinished);
            Assert.AreEqual(253.0, riderA.Distance, 0.001);
            Assert.AreEqual(220.0, riderB.Distance, 0.001);
            Assert.AreEqual(215.0, riderC.Distance, 0.001);
            Assert.AreEqual(285.0, riderD.Distance, 0.001);

            for (int i = 0; i < 30; i++)
            {
                raceTrack.Race();
            }

            Assert.AreEqual(false, raceTrack.IsFinished);
            Assert.AreEqual(1012.0, riderA.Distance, 0.001);
            Assert.AreEqual(880.0, riderB.Distance, 0.001);
            Assert.AreEqual(860.0, riderC.Distance, 0.001);
            Assert.AreEqual(1140.0, riderD.Distance, 0.001);

            for (int i = 0; i < 15; i++)
            {
                raceTrack.Race();
            }

            Assert.AreEqual(false, raceTrack.IsFinished);
            Assert.AreEqual(1391.5, riderA.Distance, 0.001);
            Assert.AreEqual(1210.0, riderB.Distance, 0.001);
            Assert.AreEqual(1182.5, riderC.Distance, 0.001);
            Assert.AreEqual(1510.5, riderD.Distance, 0.001); //has finished

            for (int i = 0; i < 10; i++)
            {
                raceTrack.Race();
            }

            Assert.AreEqual(false, raceTrack.IsFinished);
            Assert.AreEqual(1518.0, riderA.Distance, 0.001); //has finished
            Assert.AreEqual(1430.0, riderB.Distance, 0.001);
            Assert.AreEqual(1397.5, riderC.Distance, 0.001);
            Assert.AreEqual(1510.5, riderD.Distance, 0.001); //has finished

            for (int i = 0; i < 5; i++)
            {
                raceTrack.Race();
            }

            Assert.AreEqual(false, raceTrack.IsFinished);
            Assert.AreEqual(1518.0, riderA.Distance, 0.001); //has finished
            Assert.AreEqual(1518.0, riderB.Distance, 0.001); //has finished
            Assert.AreEqual(1505.0, riderC.Distance, 0.001);
            Assert.AreEqual(1510.5, riderD.Distance, 0.001); //has finished

            raceTrack.Race();

            Assert.AreEqual(true, raceTrack.IsFinished);
            Assert.AreEqual(1518.0, riderA.Distance, 0.001); //has finished
            Assert.AreEqual(1518.0, riderB.Distance, 0.001); //has finished
            Assert.AreEqual(1526.5, riderC.Distance, 0.001); //has finished
            Assert.AreEqual(1510.5, riderD.Distance, 0.001); //has finished
        }
    }
}
