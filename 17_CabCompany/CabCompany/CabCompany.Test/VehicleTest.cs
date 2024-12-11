using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace CabCompany.Test
{
    [TestClass]
    public class VehicleTest
    {
        [TestMethod]
        public void TestIsAbstract()
        {
            Assert.AreEqual(true, typeof(Vehicle).IsAbstract);
        }

        [TestMethod]
        public void TestInheritance()
        {
            Assert.AreEqual(true, typeof(IComparable<Vehicle>).IsAssignableFrom(typeof(Vehicle)));
            Assert.AreEqual(false, typeof(IFuelable).IsAssignableFrom(typeof(Vehicle)));
        }

        [TestMethod]
        public void TestIsValidLicensePlateValidValues()
        {
            Assert.AreEqual(true, Vehicle.IsValidLicensePlate("GR-221CH"));
            Assert.AreEqual(true, Vehicle.IsValidLicensePlate("LL-SKV97"));
            Assert.AreEqual(true, Vehicle.IsValidLicensePlate("W-ARUM7"));
            Assert.AreEqual(true, Vehicle.IsValidLicensePlate("L-EXUS01"));
            Assert.AreEqual(true, Vehicle.IsValidLicensePlate("S-UPR41"));
            Assert.AreEqual(true, Vehicle.IsValidLicensePlate("PL-4T1N"));
            Assert.AreEqual(true, Vehicle.IsValidLicensePlate("L-484PG"));
            Assert.AreEqual(true, Vehicle.IsValidLicensePlate("FR-33D0M"));
        }

        [TestMethod]
        public void TestIsValidLicensePlateInvalidValues()
        {
            //Must only contain digits and upper case letters:
            Assert.AreEqual(false, Vehicle.IsValidLicensePlate("GR-221cH"));
            Assert.AreEqual(false, Vehicle.IsValidLicensePlate("Gr-221CH"));
            Assert.AreEqual(false, Vehicle.IsValidLicensePlate("LL-$KV97"));
            Assert.AreEqual(false, Vehicle.IsValidLicensePlate("W!-ARUM7"));

            //Must contain exactly one dash:
            Assert.AreEqual(false, Vehicle.IsValidLicensePlate("-L-484PG"));
            Assert.AreEqual(false, Vehicle.IsValidLicensePlate("I--ABC12"));
            Assert.AreEqual(false, Vehicle.IsValidLicensePlate("WE-LS3-4"));
            Assert.AreEqual(false, Vehicle.IsValidLicensePlate("SUPR41"));

            //Left part must contain one or two symbols:
            Assert.AreEqual(false, Vehicle.IsValidLicensePlate("-33D0M"));
            Assert.AreEqual(false, Vehicle.IsValidLicensePlate("LIN-484PG"));
            Assert.AreEqual(false, Vehicle.IsValidLicensePlate("LINZ-484PG"));

            //If left part contains one digit, right side must have 5 or 6 symbols:
            Assert.AreEqual(false, Vehicle.IsValidLicensePlate("W-ARUM"));
            Assert.AreEqual(false, Vehicle.IsValidLicensePlate("L-12ABC34"));

            //If left part contains two digits, right side must have 4 or 5 symbols:
            Assert.AreEqual(false, Vehicle.IsValidLicensePlate("WL-V97"));
            Assert.AreEqual(false, Vehicle.IsValidLicensePlate("WL-SK1974"));
        }
    }
}
