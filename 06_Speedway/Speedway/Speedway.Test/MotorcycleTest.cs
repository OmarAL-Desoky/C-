using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Speedway.Test
{
    [TestClass]
    public class MotorcycleTest
    {
        [TestMethod]
        public void TestConstructorValidValues()
        {
            Motorcycle motorcycle = new Motorcycle("Jawa", 70, 80);

            Assert.AreEqual("Jawa", motorcycle.Brand);
            Assert.AreEqual(70, motorcycle.HorsePower);
            Assert.AreEqual(80.0, motorcycle.Weight, 0.001);
        }

        [TestMethod]
        public void TestConstructorWeightTooLow()
        {
            Motorcycle motorcycle = new Motorcycle("Jawa", 80, 60.0);

            Assert.AreEqual("Jawa", motorcycle.Brand);
            Assert.AreEqual(80, motorcycle.HorsePower);
            Assert.AreEqual(78.0, motorcycle.Weight, 0.001);
        }

        [TestMethod]
        public void TestConstructorHorsePowerTooLow()
        {
            Motorcycle motorcycle = new Motorcycle("Jawa", 59, 78.0);

            Assert.AreEqual("Jawa", motorcycle.Brand);
            Assert.AreEqual(60, motorcycle.HorsePower);
            Assert.AreEqual(78.0, motorcycle.Weight, 0.001);
        }

        [TestMethod]
        public void TestConstructorHorsePowerTooHigh()
        {
            Motorcycle motorcycle = new Motorcycle("Jawa", 81, 78.0);

            Assert.AreEqual("Jawa", motorcycle.Brand);
            Assert.AreEqual(80, motorcycle.HorsePower);
            Assert.AreEqual(78.0, motorcycle.Weight, 0.001);
        }

        [TestMethod]
        public void TestWeightSetValidValue()
        {
            Motorcycle motorcycle = new Motorcycle("GM", 60, 83.0);

            Assert.AreEqual("GM", motorcycle.Brand);
            Assert.AreEqual(60, motorcycle.HorsePower);
            Assert.AreEqual(83.0, motorcycle.Weight, 0.001);

            motorcycle.Weight = 92.5;

            Assert.AreEqual("GM", motorcycle.Brand);
            Assert.AreEqual(60, motorcycle.HorsePower);
            Assert.AreEqual(92.5, motorcycle.Weight, 0.001);
        }

        [TestMethod]
        public void TestWeightSetValueTooLow()
        {
            Motorcycle motorcycle = new Motorcycle("GM", 75, 83.0);

            Assert.AreEqual("GM", motorcycle.Brand);
            Assert.AreEqual(75, motorcycle.HorsePower);
            Assert.AreEqual(83.0, motorcycle.Weight, 0.001);

            motorcycle.Weight = 77.9;

            Assert.AreEqual("GM", motorcycle.Brand);
            Assert.AreEqual(75, motorcycle.HorsePower);
            Assert.AreEqual(78.0, motorcycle.Weight, 0.001);
        }

        [TestMethod]
        public void TestHorsePowerSetValueTooLow()
        {
            Motorcycle motorcycle = new Motorcycle("GM", 70, 79.0);

            Assert.AreEqual("GM", motorcycle.Brand);
            Assert.AreEqual(70, motorcycle.HorsePower);
            Assert.AreEqual(79.0, motorcycle.Weight, 0.001);

            motorcycle.HorsePower = 13;

            Assert.AreEqual("GM", motorcycle.Brand);
            Assert.AreEqual(60, motorcycle.HorsePower);
            Assert.AreEqual(79.0, motorcycle.Weight, 0.001);
        }

        [TestMethod]
        public void TestHorsePowerSetValueTooHigh()
        {
            Motorcycle motorcycle = new Motorcycle("Jawa", 65, 78.5);

            Assert.AreEqual("Jawa", motorcycle.Brand);
            Assert.AreEqual(65, motorcycle.HorsePower);
            Assert.AreEqual(78.5, motorcycle.Weight, 0.001);

            motorcycle.HorsePower = 100;

            Assert.AreEqual("Jawa", motorcycle.Brand);
            Assert.AreEqual(80, motorcycle.HorsePower);
            Assert.AreEqual(78.5, motorcycle.Weight, 0.001);
        }

        [TestMethod]
        public void TestMetersPerSecond()
        {
            Motorcycle motorcycle = new Motorcycle("Jawa", 75, 90.5);

            Assert.AreEqual(19.5, motorcycle.MetersPerSecond, 0.001); //35 + 75 - 90.5
        }

        [TestMethod]
        public void TestMetersPerSecondWeightChanges()
        {
            Motorcycle motorcycle = new Motorcycle("GM", 75, 87.0);

            Assert.AreEqual(23.0, motorcycle.MetersPerSecond, 0.001); //35 + 75 - 87.0

            motorcycle.Weight = 89.0;

            Assert.AreEqual(21.0, motorcycle.MetersPerSecond, 0.001); //35 + 75 - 89.0

            motorcycle.Weight = 10.0;

            Assert.AreEqual(32.0, motorcycle.MetersPerSecond, 0.001); //35 + 75 - 78.0
        }

        [TestMethod]
        public void TestMetersPerSecondWeightTooHigh()
        {
            Motorcycle motorcycle = new Motorcycle("Jawa", 65, 150.0);

            Assert.AreEqual(0.0, motorcycle.MetersPerSecond, 0.001); //35 + 75 - 150.0
        }

        [TestMethod]
        public void TestMetersPerSecondHorsePowerChanges()
        {
            Motorcycle motorcycle = new Motorcycle("Jawa", 65, 79.0);

            Assert.AreEqual(21.0, motorcycle.MetersPerSecond, 0.001); //35 + 65 - 79.0

            motorcycle.HorsePower = 75;

            Assert.AreEqual(31.0, motorcycle.MetersPerSecond, 0.001); //35 + 75 - 79.0

            motorcycle.HorsePower = 50;

            Assert.AreEqual(16.0, motorcycle.MetersPerSecond, 0.001); //35 + 60 - 79.0

            motorcycle.HorsePower = 99;

            Assert.AreEqual(36.0, motorcycle.MetersPerSecond, 0.001); //35 + 80 - 79.0
        }
    }
}
