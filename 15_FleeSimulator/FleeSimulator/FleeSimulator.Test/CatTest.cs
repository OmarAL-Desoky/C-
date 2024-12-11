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
    public class CatTest
    {
        [TestMethod]
        public void TestInheritance()
        {
            Cat cat = new Cat("Stinka");
            Assert.AreEqual(true, cat is Pet);
        }

        [TestMethod]
        public void TestConstructorInitialRemainingBites()
        {
            Pet cat = new Cat("Stinka");

            Assert.AreEqual(100, cat.BitesRemaining);
        }

        [TestMethod]
        public void TestDoGetBitten()
        {
            Pet cat = new Cat("Hexi");

            Assert.AreEqual(100, cat.BitesRemaining);

            int bites = cat.DoGetBitten(40);

            Assert.AreEqual(40, bites);
            Assert.AreEqual(60, cat.BitesRemaining);

            bites = cat.DoGetBitten(25);

            Assert.AreEqual(25, bites);
            Assert.AreEqual(35, cat.BitesRemaining);

            bites = cat.DoGetBitten(35);

            Assert.AreEqual(35, bites);
            Assert.AreEqual(0, cat.BitesRemaining);
        }

        [TestMethod]
        public void TestDoGetBittenMoreBitesThanRemaining()
        {
            Pet cat = new Cat("Gustav");

            Assert.AreEqual(100, cat.BitesRemaining);

            int bites = cat.DoGetBitten(70);

            Assert.AreEqual(70, bites);
            Assert.AreEqual(30, cat.BitesRemaining);

            bites = cat.DoGetBitten(31);

            Assert.AreEqual(30, bites);
            Assert.AreEqual(0, cat.BitesRemaining);

            bites = cat.DoGetBitten(10);

            Assert.AreEqual(0, bites);
            Assert.AreEqual(0, cat.BitesRemaining);
        }

        [TestMethod]
        public void TestDoGetBittenVeryManyBites()
        {
            Pet cat = new Cat("Minka");

            Assert.AreEqual(100, cat.BitesRemaining);

            int bites = cat.DoGetBitten(300);

            Assert.AreEqual(100, bites);
            Assert.AreEqual(0, cat.BitesRemaining);
        }

        [TestMethod]
        public void TestDoGetBittenNegativeValue()
        {
            Pet cat = new Cat("Zelda");

            Assert.AreEqual(100, cat.BitesRemaining);

            ArgumentException ex = Assert.ThrowsException<ArgumentException>(() =>
            {
                cat.DoGetBitten(-10);
            });

            Assert.AreEqual(100, cat.BitesRemaining);
            Assert.AreEqual("Bites must not be negative!", ex.Message);
        }

        [TestMethod]
        public void TestConstructorCorrectName()
        {
            Cat cat = new Cat("Lilu");

            Assert.AreEqual("Lilu", cat.Name);
            Assert.AreEqual(0, cat.TreesClimbedCount);
        }

        [TestMethod]
        public void TestConstructorEmptyName()
        {
            ArgumentException ex = Assert.ThrowsException<ArgumentException>(() =>
            {
                Cat cat = new Cat("");
            });

            Assert.AreEqual("Name must not be null or empty!", ex.Message);
        }

        [TestMethod]
        public void TestConstructorNullName()
        {
            ArgumentException ex = Assert.ThrowsException<ArgumentException>(() =>
            {
                Cat cat = new Cat(null);
            });

            Assert.AreEqual("Name must not be null or empty!", ex.Message);
        }

        [TestMethod]
        public void TestToString()
        {
            Cat cat = new Cat("Stinka");

            Assert.AreEqual("I'm Stinka, meow!", cat.ToString());
        }

        [TestMethod]
        public void TestClimbUpFromGround()
        {
            Cat cat = new Cat("Toska");

            bool hasClimbed = cat.ClimbUp();

            Assert.AreEqual(true, hasClimbed);
            Assert.AreEqual(1, cat.TreesClimbedCount);
        }

        [TestMethod]
        public void TestClimbUpFromTree()
        {
            Cat cat = new Cat("Garfield");

            bool hasClimbed = cat.ClimbUp();
            hasClimbed = cat.ClimbUp();

            Assert.AreEqual(false, hasClimbed);
            Assert.AreEqual(1, cat.TreesClimbedCount);
        }

        [TestMethod]
        public void TestClimbDownFromGround()
        {
            Cat cat = new Cat("Tom");

            bool hasClimbed = cat.ClimbDown();

            Assert.AreEqual(false, hasClimbed);
            Assert.AreEqual(0, cat.TreesClimbedCount);
        }

        [TestMethod]
        public void TestClimbDownFromTree()
        {
            Cat cat = new Cat("Barney");

            bool hasClimbed = cat.ClimbUp();
            hasClimbed = cat.ClimbDown();

            Assert.AreEqual(true, hasClimbed);
            Assert.AreEqual(1, cat.TreesClimbedCount);
        }

        [TestMethod]
        public void TestClimbUpDownUp()
        {
            Cat cat = new Cat("Tigger");

            bool hasClimbed = cat.ClimbUp();
            hasClimbed = cat.ClimbDown();
            hasClimbed = cat.ClimbUp();

            Assert.AreEqual(true, hasClimbed);
            Assert.AreEqual(2, cat.TreesClimbedCount);
        }

        [TestMethod]
        public void TestClimbMultipleTrees()
        {
            Cat cat = new Cat("Monty");

            for (int i = 0; i < 10; i++)
            {
                bool hasClimbed = cat.ClimbUp();

                Assert.AreEqual(true, hasClimbed);

                hasClimbed = cat.ClimbDown();

                Assert.AreEqual(true, hasClimbed);

                Assert.AreEqual(i + 1, cat.TreesClimbedCount);
            }
        }
    }
}
