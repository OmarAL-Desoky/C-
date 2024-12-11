using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using FleeSimulator;

namespace FleaSimulator.Test
{
    [TestClass]
    public class DogTest
    {
        [TestMethod]
        public void TestInheritance()
        {
            Pet dog = new Dog("Fido");
            Assert.AreEqual(true, dog is Pet);
        }

        [TestMethod]
        public void TestConstructorInitialRemainingBites()
        {
            Pet dog = new Dog("Laika");

            Assert.AreEqual(100, dog.BitesRemaining);
        }

        [TestMethod]
        public void TestDoGetBitten()
        {
            Pet dog = new Dog("Rex");

            Assert.AreEqual(100, dog.BitesRemaining);

            int bites = dog.DoGetBitten(20);

            Assert.AreEqual(20, bites);
            Assert.AreEqual(80, dog.BitesRemaining);

            bites = dog.DoGetBitten(42);

            Assert.AreEqual(42, bites);
            Assert.AreEqual(38, dog.BitesRemaining);

            bites = dog.DoGetBitten(36);

            Assert.AreEqual(36, bites);
            Assert.AreEqual(2, dog.BitesRemaining);

            bites = dog.DoGetBitten(2);

            Assert.AreEqual(2, bites);
            Assert.AreEqual(0, dog.BitesRemaining);
        }

        [TestMethod]
        public void TestDoGetBittenMoreBitesThanRemaining()
        {
            Pet dog = new Dog("Bello");

            Assert.AreEqual(100, dog.BitesRemaining);

            int bites = dog.DoGetBitten(45);

            Assert.AreEqual(45, bites);
            Assert.AreEqual(55, dog.BitesRemaining);

            bites = dog.DoGetBitten(70);

            Assert.AreEqual(55, bites);
            Assert.AreEqual(0, dog.BitesRemaining);

            bites = dog.DoGetBitten(1);

            Assert.AreEqual(0, bites);
            Assert.AreEqual(0, dog.BitesRemaining);
        }

        [TestMethod]
        public void TestDoGetBittenVeryManyBites()
        {
            Pet dog = new Dog("Idefix");

            Assert.AreEqual(100, dog.BitesRemaining);

            int bites = dog.DoGetBitten(101);

            Assert.AreEqual(100, bites);
            Assert.AreEqual(0, dog.BitesRemaining);
        }

        [TestMethod]
        public void TestDoGetBittenNegativeValue()
        {
            Pet dog = new Dog("Aleks");

            Assert.AreEqual(100, dog.BitesRemaining);

            ArgumentException ex = Assert.ThrowsException<ArgumentException>(() =>
            {
                dog.DoGetBitten(-1);
            });

            Assert.AreEqual(100, dog.BitesRemaining);
            Assert.AreEqual("Bites must not be negative!", ex.Message);
        }

        [TestMethod]
        public void TestConstructor()
        {
            Dog dog = new Dog("Reksio");

            Assert.AreEqual("Reksio", dog.Name);
            Assert.AreEqual(0, dog.HuntsCount);
        }

        [TestMethod]
        public void TestConstructorEmptyName()
        {
            ArgumentException ex = Assert.ThrowsException<ArgumentException>(() =>
            {
                Dog dog = new Dog("");
            });

            Assert.AreEqual("Name must not be null or empty!", ex.Message);
        }

        [TestMethod]
        public void TestConstructorNullName()
        {
            ArgumentException ex = Assert.ThrowsException<ArgumentException>(() =>
            {
                Dog dog = new Dog(null);
            });

            Assert.AreEqual("Name must not be null or empty!", ex.Message);
        }

        [TestMethod]
        public void TestToString()
        {
            Dog dog = new Dog("Sparky");

            Assert.AreEqual("I'm Sparky, woof!", dog.ToString());
        }

        [TestMethod]
        public void TestHuntFirstTime()
        {
            Dog dog = new Dog("Wuffi");

            bool isHunting = dog.Hunt();

            Assert.AreEqual(true, isHunting);
            Assert.AreEqual(1, dog.HuntsCount);
        }

        [TestMethod]
        public void TestHuntTwoTimesWithoutBreak()
        {
            Dog dog = new Dog("Lassie");

            bool isHunting = dog.Hunt();
            isHunting = dog.Hunt();

            Assert.AreEqual(false, isHunting);
            Assert.AreEqual(1, dog.HuntsCount);
        }

        [TestMethod]
        public void TestHuntTwoTimesWithShortBreak()
        {
            Dog dog = new Dog("Beethoven");

            bool isHunting = dog.Hunt();
            //N.B.: Breakpoints around here can lead to incorrect results!
            Thread.Sleep(900);
            isHunting = dog.Hunt();

            Assert.AreEqual(false, isHunting);
            Assert.AreEqual(1, dog.HuntsCount);
        }

        [TestMethod]
        public void TestHuntTwoTimesWithLongBreak()
        {
            Dog dog = new Dog("Cheddar");

            bool isHunting = dog.Hunt();
            //N.B.: Breakpoints around here can lead to incorrect results!
            Thread.Sleep(1100);
            isHunting = dog.Hunt();

            Assert.AreEqual(true, isHunting);
            Assert.AreEqual(2, dog.HuntsCount);
        }
    }
}
