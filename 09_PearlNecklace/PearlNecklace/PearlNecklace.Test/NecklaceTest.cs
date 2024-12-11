using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace PearlNecklace.Test
{
    [TestClass]
    public class NecklaceTest
    {
        [TestMethod]
        public void Count_NewEmptyBand_ShouldReturnZero()
        {
            Necklace necklace = new Necklace();
            Assert.AreEqual(0, necklace.Count);
        }

        [TestMethod]
        public void Count_AddOne_ShouldReturn1()
        {
            Necklace necklace = new Necklace();
            necklace.AddPearl(new Pearl("Red", 1.5));
            Assert.AreEqual(1, necklace.Count);
        }

        [TestMethod]
        public void Count_InsertMany_ShouldReturnCorrectNumber()
        {
            Necklace necklace = new Necklace();
            necklace.AddPearl(new Pearl("Red", 1.5));
            necklace.AddPearl(new Pearl("Blue", 2));
            necklace.AddPearl(new Pearl("Blue", 3));
            necklace.AddPearl(new Pearl("Red", 4.0));
            necklace.AddPearl(new Pearl("Green", 5.1));
            necklace.AddPearl(new Pearl("Blue", 6));
            necklace.AddPearl(new Pearl("Red", 7));
            Assert.AreEqual(7, necklace.Count);
        }

        [TestMethod]
        public void Count_InsertNull_ShouldReturnCorrectNumber()
        {
            Necklace necklace = new Necklace();
            necklace.AddPearl(new Pearl("Red", 1.5));
            necklace.AddPearl(new Pearl("Blue", 2));
            necklace.AddPearl(new Pearl("Blue", 3));
            necklace.AddPearl(new Pearl("Red", 4.0));
            necklace.AddPearl(new Pearl("Green", 5.1));
            necklace.AddPearl(new Pearl("Blue", 6));
            necklace.AddPearl(new Pearl("Red", 7));

            necklace.AddPearl(null);
            Assert.AreEqual(7, necklace.Count);
        }

        [TestMethod]
        public void Count_InsertInvalidPearl_ShouldReturnCorrectNumber()
        {
            Necklace necklace = new Necklace();
            necklace.AddPearl(new Pearl("Black", 2.3));

            Assert.AreEqual(0, necklace.Count);

            necklace.AddPearl(new Pearl("Red", 1.5));
            necklace.AddPearl(new Pearl("Blue", 1.7));
            necklace.AddPearl(new Pearl("White", 2.3));
            necklace.AddPearl(new Pearl("Blue", 3));
            necklace.AddPearl(new Pearl("Red", 4.0));
            necklace.AddPearl(new Pearl("Green", 5.1));
            necklace.AddPearl(new Pearl("Blue", 6));
            necklace.AddPearl(new Pearl("Red", 7));

            Assert.AreEqual(7, necklace.Count);
        }

        [TestMethod]
        public void GetPearlAtPosition_FirstPos_ShouldReturnPearlAtFirstPos()
        {
            Necklace necklace = new Necklace();
            Pearl pearl = new Pearl("Red", 1.5);
            necklace.AddPearl(pearl);

            Pearl pearlRetrieved = necklace.GetPearlAtPosition(0);
            Assert.AreEqual(pearl, pearlRetrieved);
        }

        [TestMethod]
        public void GetNumberOfColoredPearls_InsertOneOfSameColor_ShouldReturn1()
        {
            Necklace necklace = new Necklace();
            Pearl pearl = new Pearl("Red", 1.5);
            necklace.AddPearl(pearl);
            int count = necklace.GetCountOfColoredPearls("Red");
            Assert.AreEqual(1, count);
        }

        [TestMethod]
        public void GetNumberOfColoredPearls_InsertDifferentColor_ShouldReturn0()
        {
            Necklace necklace = new Necklace();
            Pearl pearl = new Pearl("Red", 1.5);
            necklace.AddPearl(pearl);
            int count = necklace.GetCountOfColoredPearls("Blue");
            Assert.AreEqual(0, count);
        }

        [TestMethod]
        public void GetNumberOfColoredPearls_InsertInvalidColor_ShouldReturn0()
        {
            Necklace necklace = new Necklace();

            necklace.AddPearl(new Pearl("Red", 1.5));
            necklace.AddPearl(new Pearl("Blue", 1.7));
            necklace.AddPearl(new Pearl("White", 2.3));
            necklace.AddPearl(new Pearl("Blue", 3));
            necklace.AddPearl(new Pearl("Red", 4.0));
            necklace.AddPearl(new Pearl("Yellow", 5.1));
            necklace.AddPearl(new Pearl("Blue", 6));
            necklace.AddPearl(new Pearl("Black", 7));

            Assert.AreEqual(0, necklace.GetCountOfColoredPearls("White"));
            Assert.AreEqual(0, necklace.GetCountOfColoredPearls("Yellow"));
            Assert.AreEqual(0, necklace.GetCountOfColoredPearls("Black"));
        }

        [TestMethod]
        public void GetNumberOfColoredPearls_InsertManyOfColorRed_ShouldReturnCorrectNumber()
        {
            Necklace necklace = new Necklace();
            necklace.AddPearl(new Pearl("Red", 1.5));
            necklace.AddPearl(new Pearl("Blue", 2));
            necklace.AddPearl(new Pearl("Blue", 3));
            necklace.AddPearl(new Pearl("Red", 4.0));
            necklace.AddPearl(new Pearl("Green", 5.1));
            necklace.AddPearl(new Pearl("Blue", 6));
            necklace.AddPearl(new Pearl("Red", 7));
            int count = necklace.GetCountOfColoredPearls("Red");
            Assert.AreEqual(3, count);
        }

        [TestMethod]
        public void GetNumberOfColoredPearls_InsertManyOfColorBlue_ShouldReturnCorrectNumber()
        {
            Necklace necklace = new Necklace();
            necklace.AddPearl(new Pearl("Red", 1.5));
            necklace.AddPearl(new Pearl("Blue", 2));
            necklace.AddPearl(new Pearl("Blue", 3));
            necklace.AddPearl(new Pearl("Red", 4.0));
            necklace.AddPearl(new Pearl("Green", 5.1));
            necklace.AddPearl(new Pearl("Blue", 6));
            necklace.AddPearl(new Pearl("Red", 7));
            int count = necklace.GetCountOfColoredPearls("Blue");
            Assert.AreEqual(3, count);
        }

        [TestMethod]
        public void GetNumberOfColoredPearls_InsertOneOfColorGreen_ShouldReturnCorrectNumber()
        {
            Necklace necklace = new Necklace();
            necklace.AddPearl(new Pearl("Red", 1.5));
            necklace.AddPearl(new Pearl("Blue", 2));
            necklace.AddPearl(new Pearl("Blue", 3));
            necklace.AddPearl(new Pearl("Red", 4.0));
            necklace.AddPearl(new Pearl("Green", 5.1));
            necklace.AddPearl(new Pearl("Blue", 6));
            necklace.AddPearl(new Pearl("Red", 7));
            int count = necklace.GetCountOfColoredPearls("Green");
            Assert.AreEqual(1, count);
        }

        [TestMethod]
        public void GetNumberOfColoredPearls_ColorIsNull_ShouldReturn0()
        {
            Necklace necklace = new Necklace();
            necklace.AddPearl(new Pearl("Red", 1.5));
            necklace.AddPearl(new Pearl("Blue", 2));
            necklace.AddPearl(new Pearl("Blue", 3));
            necklace.AddPearl(new Pearl("Red", 4.0));
            necklace.AddPearl(new Pearl("Green", 5.1));
            necklace.AddPearl(new Pearl("Blue", 6));
            necklace.AddPearl(new Pearl("Red", 7));

            int count = necklace.GetCountOfColoredPearls(null);
            Assert.AreEqual(0, count);
        }

        [TestMethod]
        public void GetPearlAtPosition_InsertMany_ShouldReturnCorrectPearlAtPos0()
        {
            Necklace necklace = new Necklace();
            necklace.AddPearl(new Pearl("Red", 1.5));
            necklace.AddPearl(new Pearl("Blue", 2));
            necklace.AddPearl(new Pearl("Blue", 3));
            necklace.AddPearl(new Pearl("Red", 4.0));
            necklace.AddPearl(new Pearl("Green", 5.1));
            necklace.AddPearl(new Pearl("Blue", 6));
            Pearl pearl = new Pearl("Red", 7);
            necklace.AddPearl(pearl);
            Pearl getPearl = necklace.GetPearlAtPosition(0);
            Assert.AreEqual(pearl, getPearl);
        }

        [TestMethod]
        public void GetPearlAtPosition_InsertMany_ShouldReturnCorrectPearlAtPos4()
        {
            Necklace necklace = new Necklace();
            necklace.AddPearl(new Pearl("Red", 1.5));
            necklace.AddPearl(new Pearl("Blue", 2));
            Pearl pearl = new Pearl("Blue", 3);
            necklace.AddPearl(pearl);
            necklace.AddPearl(new Pearl("Red", 4.0));
            necklace.AddPearl(new Pearl("Green", 5.1));
            necklace.AddPearl(new Pearl("Blue", 6));
            necklace.AddPearl(new Pearl("Red", 7));

            Pearl pearlRetrieved = necklace.GetPearlAtPosition(4);
            Assert.AreEqual(pearl, pearlRetrieved);
        }

        [TestMethod]
        public void GetPearlAtPosition_InsertMany_ShouldReturnCorrectPearlAtPos6()
        {
            Necklace necklace = new Necklace();
            Pearl pearl = new Pearl("Red", 1.5);
            necklace.AddPearl(pearl);
            necklace.AddPearl(new Pearl("Blue", 2));
            necklace.AddPearl(new Pearl("Blue", 3));
            necklace.AddPearl(new Pearl("Red", 4.0));
            necklace.AddPearl(new Pearl("Green", 5.1));
            necklace.AddPearl(new Pearl("Blue", 6));
            necklace.AddPearl(new Pearl("Red", 7));

            Pearl pearlRetrieved = necklace.GetPearlAtPosition(6);
            Assert.AreEqual(pearl, pearlRetrieved);
        }

        [TestMethod]
        public void GetPearlAtPosition_OutOfIndex_ShouldReturnNull()
        {
            Necklace necklace = new Necklace();
            necklace.AddPearl(new Pearl("Red", 1.5));
            necklace.AddPearl(new Pearl("Blue", 2));
            necklace.AddPearl(new Pearl("Blue", 3));
            necklace.AddPearl(new Pearl("Red", 4.0));
            necklace.AddPearl(new Pearl("Green", 5.1));
            necklace.AddPearl(new Pearl("Blue", 6));
            necklace.AddPearl(new Pearl("Red", 7));

            Pearl pearlRetrieved = necklace.GetPearlAtPosition(7);
            Assert.AreEqual(null, pearlRetrieved);
        }

        [TestMethod]
        public void GetPearlAtPosition_NegativeIndex_ShouldReturnNull()
        {
            Necklace necklace = new Necklace();
            necklace.AddPearl(new Pearl("Red", 1.5));
            necklace.AddPearl(new Pearl("Blue", 2));
            necklace.AddPearl(new Pearl("Blue", 3));
            necklace.AddPearl(new Pearl("Red", 4.0));
            necklace.AddPearl(new Pearl("Green", 5.1));
            necklace.AddPearl(new Pearl("Blue", 6));
            necklace.AddPearl(new Pearl("Red", 7));

            Pearl pearlRetrieved = necklace.GetPearlAtPosition(-1);
            Assert.AreEqual(null, pearlRetrieved);
        }

        [TestMethod]
        public void RemovePearl_RemoveFirst_ShouldReturnPearlWith7Weight()
        {
            Necklace necklace = new Necklace();
            necklace.AddPearl(new Pearl("Red", 1.5));
            necklace.AddPearl(new Pearl("Blue", 2));
            necklace.AddPearl(new Pearl("Blue", 3));
            necklace.AddPearl(new Pearl("Red", 4.0));
            necklace.AddPearl(new Pearl("Green", 5.1));
            necklace.AddPearl(new Pearl("Blue", 6));
            necklace.AddPearl(new Pearl("Red", 7));

            Pearl pearl = necklace.RemovePearl();
            Assert.AreEqual(7, pearl.Weight, 0.001);
        }

        [TestMethod]
        public void RemovePearl_RemoveFromEmptyList_ShouldReturnNull()
        {
            Necklace necklace = new Necklace();

            Pearl pearl = necklace.RemovePearl();
            Assert.AreEqual(null, pearl);
        }

        [TestMethod]
        public void GetTotalWeight_FromEmptyList_ShouldReturn0()
        {
            Necklace necklace = new Necklace();

            double totalWeight = necklace.TotalWeight;
            Assert.AreEqual(0, totalWeight);
        }

        [TestMethod]
        public void GetTotalWeight_FromFilledList_ShouldReturnCorrectWeight()
        {
            Necklace necklace = new Necklace();
            necklace.AddPearl(new Pearl("Red", 1.5));
            necklace.AddPearl(new Pearl("Blue", 2));
            necklace.AddPearl(new Pearl("Blue", 3));
            necklace.AddPearl(new Pearl("Red", 4.0));
            necklace.AddPearl(new Pearl("Green", 5.1));
            necklace.AddPearl(new Pearl("Blue", 6));
            necklace.AddPearl(new Pearl("Red", 7));

            double totalWeight = necklace.TotalWeight;
            Assert.AreEqual(28.6, totalWeight, 0.01);
        }

        [TestMethod]
        public void RemoveAll_FromFilledList_ShouldReturnCorrectWeightAndCount()
        {
            Necklace necklace = new Necklace();
            necklace.AddPearl(new Pearl("Red", 1.5));
            necklace.AddPearl(new Pearl("Blue", 2));
            necklace.AddPearl(new Pearl("Blue", 3));
            necklace.AddPearl(new Pearl("Red", 4.0));
            necklace.AddPearl(new Pearl("Green", 5.1));
            necklace.AddPearl(new Pearl("Blue", 6));
            necklace.AddPearl(new Pearl("Red", 7));

            Assert.AreEqual(28.6, necklace.TotalWeight, 0.01);
            Assert.AreEqual(7, necklace.Count);

            necklace.RemoveAllPearls();

            Assert.AreEqual(0.0, necklace.TotalWeight, 0.01);
            Assert.AreEqual(0, necklace.Count);

            necklace.AddPearl(new Pearl("Blue", 2.3));
            necklace.AddPearl(new Pearl("Red", 1.6));
            necklace.AddPearl(new Pearl("Blue", 8.3));

            Assert.AreEqual(12.2, necklace.TotalWeight, 0.01);
            Assert.AreEqual(3, necklace.Count);

            necklace.RemoveAllPearls();

            Assert.AreEqual(0.0, necklace.TotalWeight, 0.01);
            Assert.AreEqual(0, necklace.Count);
        }

        [TestMethod]
        public void ToString_FromEmptyList_ShouldReturnCorrectRepresentation()
        {
            Necklace necklace = new Necklace();
            Assert.AreEqual("", necklace.ToString());
        }

        [TestMethod]
        public void ToString_FromFilledList_ShouldReturnCorrectRepresentation()
        {
            Necklace necklace = new Necklace();
            necklace.AddPearl(new Pearl("Red", 1.5));

            Assert.AreEqual("(r)", necklace.ToString());

            necklace.AddPearl(new Pearl("Blue", 2.6));
            necklace.AddPearl(new Pearl("Blue", 3));
            necklace.AddPearl(new Pearl("Red", 1.7));
            necklace.AddPearl(new Pearl("Green", 5.1));
            necklace.AddPearl(new Pearl("Blue", 2.4));
            necklace.AddPearl(new Pearl("Green", 1.3));
            necklace.AddPearl(new Pearl("Red", 5));

            Assert.AreEqual("(R)-(g)-(b)-(G)-(r)-(B)-(B)-(r)", necklace.ToString());

            necklace.RemovePearl();

            Assert.AreEqual("(g)-(b)-(G)-(r)-(B)-(B)-(r)", necklace.ToString());
        }
    }
}
