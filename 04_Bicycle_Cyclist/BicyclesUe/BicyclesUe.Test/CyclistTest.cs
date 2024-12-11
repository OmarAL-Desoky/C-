using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using BicyclesUe;

namespace Bicycles.Test
{
    [TestClass]
    public class CyclistTest
    {
        [TestMethod]
        public void TestConstructorNameOnly()
        {
            Cyclist cyclist = new Cyclist("Lance Armstrong");

            Assert.AreEqual("Lance Armstrong", cyclist.Name);
            Assert.AreEqual("None", cyclist.Team);
        }

        [TestMethod]
        public void TestConstructor()
        {
            Cyclist cyclist = new Cyclist("Jan Ullrich", "Doping Squad");

            Assert.AreEqual("Jan Ullrich", cyclist.Name);
            Assert.AreEqual("Doping Squad", cyclist.Team);
        }

        [TestMethod]
        public void TestConstructorTeamEmpty()
        {
            Cyclist cyclist = new Cyclist("Jens Voigt", "");

            Assert.AreEqual("Jens Voigt", cyclist.Name);
            Assert.AreEqual("None", cyclist.Team);
        }

        [TestMethod]
        public void TestConstructorTeamNull()
        {
            Cyclist cyclist = new Cyclist("Fausto Coppi", null);

            Assert.AreEqual("Fausto Coppi", cyclist.Name);
            Assert.AreEqual("None", cyclist.Team);
        }

        [TestMethod]
        public void TestSetName()
        {
            Cyclist cyclist = new Cyclist("Langer Armstark", "Discovery Channel");

            Assert.AreEqual("Langer Armstark", cyclist.Name);
            Assert.AreEqual("Discovery Channel", cyclist.Team);

            cyclist.Name = "Lance Armstrong";

            Assert.AreEqual("Lance Armstrong", cyclist.Name);
            Assert.AreEqual("Discovery Channel", cyclist.Team);
        }

        [TestMethod]
        public void TestSetTeam()
        {
            Cyclist cyclist = new Cyclist("Mario Cippollini", "Discovery Channel");

            Assert.AreEqual("Mario Cippollini", cyclist.Name);
            Assert.AreEqual("Discovery Channel", cyclist.Team);

            cyclist.Team = "Squadra Azzurra";

            Assert.AreEqual("Mario Cippollini", cyclist.Name);
            Assert.AreEqual("Squadra Azzurra", cyclist.Team);
        }

        [TestMethod]
        public void TestSetTeamEmpty()
        {
            Cyclist cyclist = new Cyclist("Lance Armstrong", "Discovery Channel");

            Assert.AreEqual("Lance Armstrong", cyclist.Name);
            Assert.AreEqual("Discovery Channel", cyclist.Team);

            cyclist.Team = "";

            Assert.AreEqual("Lance Armstrong", cyclist.Name);
            Assert.AreEqual("None", cyclist.Team);
        }

        [TestMethod]
        public void TestSetTeamNull()
        {
            Cyclist cyclist = new Cyclist("Lance Armstrong", "Discovery Channel");

            Assert.AreEqual("Lance Armstrong", cyclist.Name);
            Assert.AreEqual("Discovery Channel", cyclist.Team);

            cyclist.Team = null;

            Assert.AreEqual("Lance Armstrong", cyclist.Name);
            Assert.AreEqual("None", cyclist.Team);
        }

        [TestMethod]
        public void TestToString()
        {
            Cyclist cyclist = new Cyclist("Lance Armstrong", "Discovery Channel");

            Assert.AreEqual("Lance Armstrong (Team: Discovery Channel)", cyclist.ToString());
        }

        [TestMethod]
        public void TestToStringAfterTeamChange()
        {
            Cyclist cyclist = new Cyclist("Mario Cippollini");

            Assert.AreEqual("Mario Cippollini (Team: None)", cyclist.ToString());

            cyclist.Team = "Squadra Azzurra";

            Assert.AreEqual("Mario Cippollini (Team: Squadra Azzurra)", cyclist.ToString());
        }

        [TestMethod]
        public void TestToStringAfterNameChange()
        {
            Cyclist cyclist = new Cyclist("Langer Armstark", null);

            Assert.AreEqual("Langer Armstark (Team: None)", cyclist.ToString());

            cyclist.Name = "Lance Armstrong";

            Assert.AreEqual("Lance Armstrong (Team: None)", cyclist.ToString());
        }
    }
}
