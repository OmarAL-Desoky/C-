using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FleeSimulator;

namespace FleaSimulator.Test
{
    [TestClass]
    public class FleaTest
    {
        [TestMethod]
        public void TestConstructor()
        {
            Flea flea = new Flea();

            Assert.AreEqual(0, flea.BitesCount);
            Assert.AreEqual(null, flea.PetInfested);
        }

        [TestMethod]
        public void TestToString()
        {
            Flea flea = new Flea();

            Assert.AreEqual("I'm a flea!", flea.ToString());
        }

        [TestMethod]
        public void TestJumpOnPet()
        {
            Flea flea = new Flea();

            Cat cat = new Cat("Stinka");
            flea.JumpOnPet(cat);

            Assert.AreEqual(cat, flea.PetInfested);

            Dog dog = new Dog("Reksio");
            flea.JumpOnPet(dog);

            Assert.AreEqual(dog, flea.PetInfested);
        }

        [TestMethod]
        public void TestBiteNoPet()
        {
            Flea flea = new Flea();

            int bites = flea.BitePet(5);

            Assert.AreEqual(0, bites);
            Assert.AreEqual(0, flea.BitesCount);
        }

        [TestMethod]
        public void TestBiteOnePet()
        {
            Flea flea = new Flea();

            Cat cat = new Cat("Toska");
            flea.JumpOnPet(cat);

            Assert.AreEqual(0, flea.BitesCount);
            Assert.AreEqual(100, cat.BitesRemaining);

            int bites = flea.BitePet(10);

            Assert.AreEqual(10, bites);
            Assert.AreEqual(10, flea.BitesCount);
            Assert.AreEqual(90, cat.BitesRemaining);

            bites = flea.BitePet(77);

            Assert.AreEqual(77, bites);
            Assert.AreEqual(87, flea.BitesCount);
            Assert.AreEqual(13, cat.BitesRemaining);

            bites = flea.BitePet(13);

            Assert.AreEqual(13, bites);
            Assert.AreEqual(100, flea.BitesCount);
            Assert.AreEqual(0, cat.BitesRemaining);
        }

        [TestMethod]
        public void TestBiteOnePetMoreThanRemaining()
        {
            Flea flea = new Flea();

            Dog dog = new Dog("Rin Tin Tin");
            flea.JumpOnPet(dog);

            Assert.AreEqual(0, flea.BitesCount);
            Assert.AreEqual(100, dog.BitesRemaining);

            int bites = flea.BitePet(85);

            Assert.AreEqual(85, bites);
            Assert.AreEqual(85, flea.BitesCount);
            Assert.AreEqual(15, dog.BitesRemaining);

            bites = flea.BitePet(20);

            Assert.AreEqual(15, bites);
            Assert.AreEqual(100, flea.BitesCount);
            Assert.AreEqual(0, dog.BitesRemaining);

            bites = flea.BitePet(3);

            Assert.AreEqual(0, bites);
            Assert.AreEqual(100, flea.BitesCount);
            Assert.AreEqual(0, dog.BitesRemaining);
        }

        [TestMethod]
        public void TestBiteOnePetJumpDownBiteNothing()
        {
            Flea flea = new Flea();

            Cat cat = new Cat("Stinka");
            flea.JumpOnPet(cat);

            Assert.AreEqual(0, flea.BitesCount);
            Assert.AreEqual(100, cat.BitesRemaining);

            int bites = flea.BitePet(50);

            Assert.AreEqual(50, bites);
            Assert.AreEqual(50, flea.BitesCount);
            Assert.AreEqual(50, cat.BitesRemaining);

            flea.JumpOnPet(null);

            bites = flea.BitePet(30);

            Assert.AreEqual(0, bites);
            Assert.AreEqual(50, flea.BitesCount);
            Assert.AreEqual(50, cat.BitesRemaining);
        }

        [TestMethod]
        public void TestBiteMultiplePets()
        {
            Flea flea = new Flea();

            Cat stinka = new Cat("Stinka");
            Dog bello = new Dog("Bello");
            Cat lilu = new Cat("Lilu");

            flea.JumpOnPet(stinka);

            Assert.AreEqual(0, flea.BitesCount);
            Assert.AreEqual(100, stinka.BitesRemaining);
            Assert.AreEqual(100, bello.BitesRemaining);
            Assert.AreEqual(100, lilu.BitesRemaining);

            int bites = flea.BitePet(25);

            Assert.AreEqual(25, bites);
            Assert.AreEqual(25, flea.BitesCount);
            Assert.AreEqual(75, stinka.BitesRemaining);
            Assert.AreEqual(100, bello.BitesRemaining);
            Assert.AreEqual(100, lilu.BitesRemaining);

            flea.JumpOnPet(bello);

            bites = flea.BitePet(130);

            Assert.AreEqual(100, bites);
            Assert.AreEqual(125, flea.BitesCount);
            Assert.AreEqual(75, stinka.BitesRemaining);
            Assert.AreEqual(0, bello.BitesRemaining);
            Assert.AreEqual(100, lilu.BitesRemaining);

            flea.JumpOnPet(stinka);

            bites = flea.BitePet(10);

            Assert.AreEqual(10, bites);
            Assert.AreEqual(135, flea.BitesCount);
            Assert.AreEqual(65, stinka.BitesRemaining);
            Assert.AreEqual(0, bello.BitesRemaining);
            Assert.AreEqual(100, lilu.BitesRemaining);

            flea.JumpOnPet(lilu);

            bites = flea.BitePet(75);

            Assert.AreEqual(75, bites);
            Assert.AreEqual(210, flea.BitesCount);
            Assert.AreEqual(65, stinka.BitesRemaining);
            Assert.AreEqual(0, bello.BitesRemaining);
            Assert.AreEqual(25, lilu.BitesRemaining);

            bites = flea.BitePet(300);

            Assert.AreEqual(25, bites);
            Assert.AreEqual(235, flea.BitesCount);
            Assert.AreEqual(65, stinka.BitesRemaining);
            Assert.AreEqual(0, bello.BitesRemaining);
            Assert.AreEqual(0, lilu.BitesRemaining);

            flea.JumpOnPet(stinka);

            bites = flea.BitePet(5);

            Assert.AreEqual(5, bites);
            Assert.AreEqual(240, flea.BitesCount);
            Assert.AreEqual(60, stinka.BitesRemaining);
            Assert.AreEqual(0, bello.BitesRemaining);
            Assert.AreEqual(0, lilu.BitesRemaining);

            bites = flea.BitePet(60);

            Assert.AreEqual(60, bites);
            Assert.AreEqual(300, flea.BitesCount);
            Assert.AreEqual(0, stinka.BitesRemaining);
            Assert.AreEqual(0, bello.BitesRemaining);
            Assert.AreEqual(0, lilu.BitesRemaining);
        }

        [TestMethod]
        public void TestMultipleFleas()
        {
            Flea fleaA = new Flea();
            Flea fleaB = new Flea();

            Cat cat = new Cat("Hexi");

            fleaA.JumpOnPet(cat);
            fleaB.JumpOnPet(cat);

            Assert.AreEqual(0, fleaA.BitesCount);
            Assert.AreEqual(0, fleaB.BitesCount);
            Assert.AreEqual(100, cat.BitesRemaining);

            int bitesA = fleaA.BitePet(30);
            int bitesB = fleaB.BitePet(20);

            Assert.AreEqual(30, bitesA);
            Assert.AreEqual(20, bitesB);
            Assert.AreEqual(30, fleaA.BitesCount);
            Assert.AreEqual(20, fleaB.BitesCount);
            Assert.AreEqual(50, cat.BitesRemaining);

            bitesA = fleaA.BitePet(10);
            bitesB = fleaB.BitePet(1);

            Assert.AreEqual(10, bitesA);
            Assert.AreEqual(1, bitesB);
            Assert.AreEqual(40, fleaA.BitesCount);
            Assert.AreEqual(21, fleaB.BitesCount);
            Assert.AreEqual(39, cat.BitesRemaining);

            bitesA = fleaA.BitePet(50);
            bitesB = fleaB.BitePet(5);

            Assert.AreEqual(39, bitesA);
            Assert.AreEqual(0, bitesB);
            Assert.AreEqual(79, fleaA.BitesCount);
            Assert.AreEqual(21, fleaB.BitesCount);
            Assert.AreEqual(0, cat.BitesRemaining);
        }

        [TestMethod]
        public void TestBiteNegativeValue()
        {
            Flea flea = new Flea();

            Dog dog = new Dog("Toto");
            flea.JumpOnPet(dog);

            ArgumentException ex = Assert.ThrowsException<ArgumentException>(() =>
            {
                flea.BitePet(-30);
            });

            Assert.AreEqual("Bites must not be negative!", ex.Message);
        }
    }
}
