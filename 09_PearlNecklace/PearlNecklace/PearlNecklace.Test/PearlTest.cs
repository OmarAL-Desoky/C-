using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PearlNecklace.Test
{
    [TestClass]
    public class PearlTest
    {
        [TestMethod]
        public void Constructor_NewRedPearl_ShouldReturnCorrectColorAndWeight()
        {
            Pearl pearl = new Pearl("Red", 1.7);
            Assert.AreEqual("Red", pearl.Color);
            Assert.AreEqual(1.7, pearl.Weight);
        }

        [TestMethod]
        public void Constructor_NewGreenPearl_ShouldReturnCorrectColorAndWeight()
        {
            Pearl pearl = new Pearl("Green", 2.3);
            Assert.AreEqual("Green", pearl.Color);
            Assert.AreEqual(2.3, pearl.Weight);
        }

        [TestMethod]
        public void Constructor_NewBluePearl_ShouldReturnCorrectColorAndWeight()
        {
            Pearl pearl = new Pearl("Blue", 0.3);
            Assert.AreEqual("Blue", pearl.Color);
            Assert.AreEqual(0.3, pearl.Weight);
        }

        [TestMethod]
        public void Constructor_InvalidColor_ShouldReturnUnknownColor()
        {
            Pearl pearl = new Pearl("Yellow", -10);
            Assert.AreEqual("Unknown", pearl.Color);
        }

        [TestMethod]
        public void Constructor_InvalidColor_ShouldReturnZeroWeight()
        {
            Pearl pearl = new Pearl("Yellow", 1.3);
            Assert.AreEqual(0, pearl.Weight);
        }

        [TestMethod]
        public void Constructor_WrongWeight_ShouldReturnZero()
        {
            Pearl pearl = new Pearl("Red", -10);
            Assert.AreEqual(0.0, pearl.Weight, 0.001);
        }

        [TestMethod]
        public void Constructor_NullReference_ShouldReturnUnknownColor()
        {
            Pearl pearl = new Pearl(null, -10);
            Assert.AreEqual("Unknown", pearl.Color);
        }

        [TestMethod]
        public void Constructor_NullReference_ShouldReturnZero()
        {
            Pearl pearl = new Pearl(null, -10);
            Assert.AreEqual(0, pearl.Weight);
        }

        [TestMethod]
        public void ToString_SmallPearls_ShouldReturnCorrectRepresentation()
        {
            Pearl pearl = new Pearl("Red", 1.7);
            Assert.AreEqual("(r)", pearl.ToString());

            pearl = new Pearl("Green", 2.49);
            Assert.AreEqual("(g)", pearl.ToString());

            pearl = new Pearl("Blue", 0.3);
            Assert.AreEqual("(b)", pearl.ToString());
        }

        [TestMethod]
        public void ToString_LargePearls_ShouldReturnCorrectRepresentation()
        {
            Pearl pearl = new Pearl("Red", 12.34);
            Assert.AreEqual("(R)", pearl.ToString());

            pearl = new Pearl("Green", 2.5);
            Assert.AreEqual("(G)", pearl.ToString());

            pearl = new Pearl("Blue", 4);
            Assert.AreEqual("(B)", pearl.ToString());
        }

        [TestMethod]
        public void Constructor_NewPearl_NextShouldBeNull()
        {
            Pearl pearl = new Pearl("Blue", 2.5);
            Assert.AreEqual(null, pearl.Next);
        }

        [TestMethod]
        public void SetNext_OtherPearl_NextShouldBeOtherPearl()
        {
            Pearl pearl = new Pearl("Blue", 2.5);
            Pearl pearlOther = new Pearl("Red", 1.8);

            Assert.AreEqual(null, pearl.Next);
            Assert.AreEqual(null, pearlOther.Next);

            pearl.Next = pearlOther;

            Assert.AreEqual(pearlOther, pearl.Next);
            Assert.AreEqual(null, pearlOther.Next);
        }

        [TestMethod]
        public void SetNext_Null_NextShouldBeNull()
        {
            Pearl pearl = new Pearl("Blue", 2.5);
            Pearl pearlOther = new Pearl("Red", 1.8);

            Assert.AreEqual(null, pearl.Next);
            Assert.AreEqual(null, pearlOther.Next);

            pearl.Next = pearlOther;

            pearl.Next = null;

            Assert.AreEqual(null, pearl.Next);
            Assert.AreEqual(null, pearlOther.Next);
        }
    }
}
