using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace FractionsAdvanced.Test
{
    [TestClass]
    public class FractionsOperatorsTest
    {
        [TestMethod]
        public void TestAddFraction()
        {
            Fraction fractionA = new Fraction(3, 16);
            Fraction fractionB = new Fraction(10, 32);

            Fraction sum = fractionA + fractionB;

            Assert.AreEqual(1, sum.Numerator);
            Assert.AreEqual(2, sum.Denominator);
            Assert.AreEqual(0.5, sum.Quotient, 0.001);
        }

        [TestMethod]
        public void TestAddNumber()
        {
            Fraction fraction = new Fraction(7, 8);

            Fraction sum = fraction + 5;

            Assert.AreEqual(47, sum.Numerator);
            Assert.AreEqual(8, sum.Denominator);
            Assert.AreEqual(5.875, sum.Quotient, 0.001);
        }

        [TestMethod]
        public void TestSubtract()
        {
            Fraction fractionA = new Fraction();
            Fraction fractionB = new Fraction(25, 100);

            Fraction difference = fractionA - fractionB;

            Assert.AreEqual(3, difference.Numerator);
            Assert.AreEqual(4, difference.Denominator);
            Assert.AreEqual(0.75, difference.Quotient, 0.001);
        }

        [TestMethod]
        public void TestMultiplyFactor()
        {
            Fraction fractionA = new Fraction(4, 10);
            Fraction fractionB = new Fraction(25, 35);

            Fraction product = fractionA * fractionB;

            Assert.AreEqual(2, product.Numerator);
            Assert.AreEqual(7, product.Denominator);
            Assert.AreEqual(0.285, product.Quotient, 0.001);
        }

        [TestMethod]
        public void TestMultiplyNumber()
        {
            Fraction fraction = new Fraction(4, 10);

            Fraction product = fraction * 7;

            Assert.AreEqual(14, product.Numerator);
            Assert.AreEqual(5, product.Denominator);
            Assert.AreEqual(2.8, product.Quotient, 0.001);
        }

        [TestMethod]
        public void TestDivide()
        {
            Fraction fractionA = new Fraction(7, 9);
            Fraction fractionB = new Fraction(3, 12);

            Fraction product = fractionA / fractionB;

            Assert.AreEqual(28, product.Numerator);
            Assert.AreEqual(9, product.Denominator);
            Assert.AreEqual(3.111, product.Quotient, 0.001);
        }

        [TestMethod]
        public void TestEquals()
        {
            Fraction fractionA = new Fraction(3, 9);
            Fraction fractionB = new Fraction(10, 30);

            Assert.AreEqual(true, fractionA == fractionB);
            Assert.AreEqual(false, fractionA != fractionB);
        }

        [TestMethod]
        public void TestNotEquals()
        {
            Fraction fractionA = new Fraction(3, 7);
            Fraction fractionB = new Fraction(10, 30);

            Assert.AreEqual(false, fractionA == fractionB);
            Assert.AreEqual(true, fractionA != fractionB);
        }

        [TestMethod]
        public void TestGreaterLesserThan()
        {
            Fraction fractionA = new Fraction(30, 60);
            Fraction fractionB = new Fraction(6, 8);
            Fraction fractionC = new Fraction(1, 2);

            Assert.AreEqual(true, fractionA < fractionB);
            Assert.AreEqual(true, fractionA <= fractionB);
            Assert.AreEqual(false, fractionA > fractionB);
            Assert.AreEqual(false, fractionA >= fractionB);

            Assert.AreEqual(false, fractionA < fractionC);
            Assert.AreEqual(true, fractionA <= fractionC);
            Assert.AreEqual(false, fractionA > fractionC);
            Assert.AreEqual(true, fractionA >= fractionC);

            Assert.AreEqual(false, fractionB < fractionA);
            Assert.AreEqual(false, fractionB <= fractionA);
            Assert.AreEqual(true, fractionB > fractionA);
            Assert.AreEqual(true, fractionB >= fractionA);

            Assert.AreEqual(false, fractionB < fractionC);
            Assert.AreEqual(false, fractionB <= fractionC);
            Assert.AreEqual(true, fractionB > fractionC);
            Assert.AreEqual(true, fractionB >= fractionC);

            Assert.AreEqual(false, fractionC < fractionA);
            Assert.AreEqual(true, fractionC <= fractionA);
            Assert.AreEqual(false, fractionC > fractionA);
            Assert.AreEqual(true, fractionC >= fractionA);

            Assert.AreEqual(true, fractionC < fractionB);
            Assert.AreEqual(true, fractionC <= fractionB);
            Assert.AreEqual(false, fractionC > fractionB);
            Assert.AreEqual(false, fractionC >= fractionB);
        }

        [TestMethod]
        public void TestIncrement()
        {
            Fraction fraction = new Fraction(7, 13);
            fraction++;

            Assert.AreEqual(20, fraction.Numerator);
            Assert.AreEqual(13, fraction.Denominator);
            Assert.AreEqual(1.538, fraction.Quotient, 0.001);
        }
    }
}
