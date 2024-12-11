using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FractionsAdvanced.Test
{
    [TestClass]
    public class FractionsTest
    {
        [TestMethod]
        public void TestGreatestCommonDivisor()
        {
            Assert.AreEqual(1, Fraction.CalculateGreatestCommonDivisor(11213, 19937));
            Assert.AreEqual(3, Fraction.CalculateGreatestCommonDivisor(1701, 3768));
            Assert.AreEqual(13, Fraction.CalculateGreatestCommonDivisor(12987, 32903));
            Assert.AreEqual(24, Fraction.CalculateGreatestCommonDivisor(1224, 2712));
        }

        [TestMethod]
        public void TestConstructorWithoutParameters()
        {
            Fraction fraction = new Fraction();

            Assert.AreEqual(1, fraction.Numerator);
            Assert.AreEqual(1, fraction.Denominator);
            Assert.AreEqual(1.0, fraction.Quotient, 0.01);
        }

        [TestMethod]
        public void TestConstructorWithValidParameters()
        {
            Fraction fraction = new Fraction(20, 60);

            Assert.AreEqual(20, fraction.Numerator);
            Assert.AreEqual(60, fraction.Denominator);
            Assert.AreEqual(0.333, fraction.Quotient, 0.001);
        }

        [TestMethod]
        public void TestSetNumeratorWithValidParameter()
        {
            Fraction fraction = new Fraction(20, 60);

            fraction.Numerator = 19;

            Assert.AreEqual(19, fraction.Numerator);
            Assert.AreEqual(60, fraction.Denominator);
            Assert.AreEqual(0.316, fraction.Quotient, 0.001);
        }

        [TestMethod]
        public void TestSetDenominatorWithValidParameter()
        {
            Fraction fraction = new Fraction(19, 60);

            fraction.Denominator = 74;

            Assert.AreEqual(19, fraction.Numerator);
            Assert.AreEqual(74, fraction.Denominator);
            Assert.AreEqual(0.256, fraction.Quotient, 0.001);
        }

        [TestMethod]
        public void TestSetNumeratorWithVeryLowParameter()
        {
            Fraction fraction = new Fraction(3, 5);

            Assert.AreEqual(3, fraction.Numerator);
            Assert.AreEqual(5, fraction.Denominator);
            Assert.AreEqual(0.6, fraction.Quotient, 0.001);

            fraction.Numerator = 0;

            Assert.AreEqual(0, fraction.Numerator);
            Assert.AreEqual(5, fraction.Denominator);
            Assert.AreEqual(0.0, fraction.Quotient, 0.001);

            fraction.Numerator = 100;

            Assert.AreEqual(100, fraction.Numerator);
            Assert.AreEqual(5, fraction.Denominator);
            Assert.AreEqual(20.0, fraction.Quotient, 0.001);
        }

        [TestMethod]
        public void TestSetNumeratorWithInvalidParameter()
        {
            Fraction fraction = new Fraction(3, 5);

            fraction.Numerator = -1;

            Assert.AreEqual(0, fraction.Numerator);
            Assert.AreEqual(5, fraction.Denominator);
            Assert.AreEqual(0.0, fraction.Quotient, 0.001);
        }

        [TestMethod]
        public void TestSetDenominatorWithVeryLowParameter()
        {
            Fraction fraction = new Fraction(12, 34);

            Assert.AreEqual(12, fraction.Numerator);
            Assert.AreEqual(34, fraction.Denominator);
            Assert.AreEqual(0.352, fraction.Quotient, 0.001);

            fraction.Denominator = 0;

            Assert.AreEqual(12, fraction.Numerator);
            Assert.AreEqual(1, fraction.Denominator);
            Assert.AreEqual(12.0, fraction.Quotient, 0.001);

            fraction.Denominator = 56;

            Assert.AreEqual(12, fraction.Numerator);
            Assert.AreEqual(56, fraction.Denominator);
            Assert.AreEqual(0.214, fraction.Quotient, 0.001);
        }

        [TestMethod]
        public void TestSetDenominatorWithInvalidParameter()
        {
            Fraction fraction = new Fraction(12, 34);

            fraction.Denominator = -34;

            Assert.AreEqual(12, fraction.Numerator);
            Assert.AreEqual(1, fraction.Denominator);
            Assert.AreEqual(12.0, fraction.Quotient, 0.001);
        }

        [TestMethod]
        public void TestShortenMultipleTimesDoesNotChangeValues()
        {
            Fraction fraction = new Fraction(20, 60);

            Assert.AreEqual(20, fraction.Numerator);
            Assert.AreEqual(60, fraction.Denominator);
            Assert.AreEqual(0.333, fraction.Quotient, 0.001);

            fraction.Shorten();

            Assert.AreEqual(1, fraction.Numerator);
            Assert.AreEqual(3, fraction.Denominator);
            Assert.AreEqual(0.333, fraction.Quotient, 0.001);

            fraction.Shorten();
            fraction.Shorten();
            fraction.Shorten();
            fraction.Shorten();
            fraction.Shorten();
            fraction.Shorten();

            Assert.AreEqual(1, fraction.Numerator);
            Assert.AreEqual(3, fraction.Denominator);
            Assert.AreEqual(0.333, fraction.Quotient, 0.001);
        }

        [TestMethod]
        public void TestShortenLargeValues()
        {
            Fraction fraction = new Fraction(12987, 32903);

            Assert.AreEqual(12987, fraction.Numerator);
            Assert.AreEqual(32903, fraction.Denominator);
            Assert.AreEqual(0.394, fraction.Quotient, 0.001);

            fraction.Shorten();

            Assert.AreEqual(999, fraction.Numerator);
            Assert.AreEqual(2531, fraction.Denominator);
            Assert.AreEqual(0.394, fraction.Quotient, 0.001);
        }

        [TestMethod]
        public void TestShortenPrimeNumbers()
        {
            Fraction fraction = new Fraction(11213, 19937);

            Assert.AreEqual(11213, fraction.Numerator);
            Assert.AreEqual(19937, fraction.Denominator);
            Assert.AreEqual(0.562, fraction.Quotient, 0.001);

            fraction.Shorten();

            Assert.AreEqual(11213, fraction.Numerator);
            Assert.AreEqual(19937, fraction.Denominator);
            Assert.AreEqual(0.562, fraction.Quotient, 0.001);
        }

        [TestMethod]
        public void TestToStringEmptyConstructor()
        {
            Fraction fraction = new Fraction();
            Assert.AreEqual("1/1", fraction.ToString());
        }

        [TestMethod]
        public void TestToString()
        {
            Fraction fraction = new Fraction(3, 4);
            Assert.AreEqual("3/4", fraction.ToString());
        }

        [TestMethod]
        public void TestToStringNumeratorChanges()
        {
            Fraction fraction = new Fraction(3, 4);
            fraction.Numerator = 50;
            Assert.AreEqual("50/4", fraction.ToString());
        }

        [TestMethod]
        public void TestToStringDenominatorChanges()
        {
            Fraction fraction = new Fraction(50, 4);
            fraction.Denominator = 200;
            Assert.AreEqual("50/200", fraction.ToString());
        }

        [TestMethod]
        public void TestToStringShorten()
        {
            Fraction fraction = new Fraction(50, 200);
            fraction.Shorten();
            Assert.AreEqual("1/4", fraction.ToString());
        }

        [TestMethod]
        public void TestAdditionSameDenominator()
        {
            Fraction fractionA = new Fraction(1, 5);
            Fraction fractionB = new Fraction(2, 5);

            fractionA.Add(fractionB);
            fractionA.Shorten();
            Assert.AreEqual("3/5", fractionA.ToString());
            Assert.AreEqual("2/5", fractionB.ToString());
            Assert.AreEqual(0.6, fractionA.Quotient, 0.001);
            Assert.AreEqual(0.4, fractionB.Quotient, 0.001);
        }

        [TestMethod]
        public void TestAdditionDifferentDenominator()
        {
            Fraction fractionA = new Fraction(3, 4);
            Fraction fractionB = new Fraction(3, 8);

            fractionA.Add(fractionB);
            fractionA.Shorten();
            Assert.AreEqual("9/8", fractionA.ToString());
            Assert.AreEqual("3/8", fractionB.ToString());
            Assert.AreEqual(1.125, fractionA.Quotient, 0.001);
            Assert.AreEqual(0.375, fractionB.Quotient, 0.001);
        }

        [TestMethod]
        public void TestSubtractionSameDenominator()
        {
            Fraction fractionA = new Fraction(3, 4);
            Fraction fractionB = new Fraction(1, 4);

            fractionA.Subtract(fractionB);
            fractionA.Shorten();

            Assert.AreEqual("1/2", fractionA.ToString());
            Assert.AreEqual("1/4", fractionB.ToString());
            Assert.AreEqual(0.5, fractionA.Quotient, 0.001);
            Assert.AreEqual(0.25, fractionB.Quotient, 0.001);
        }

        [TestMethod]
        public void TestSubtractionDifferentDenominator()
        {
            Fraction fractionA = new Fraction(3, 4);
            Fraction fractionB = new Fraction(1, 4);

            fractionA.Subtract(fractionB);
            fractionA.Shorten();

            Assert.AreEqual("1/2", fractionA.ToString());
            Assert.AreEqual("1/4", fractionB.ToString());
            Assert.AreEqual(0.5, fractionA.Quotient, 0.001);
            Assert.AreEqual(0.25, fractionB.Quotient, 0.001);
        }

        [TestMethod]
        public void TestMultiplication()
        {
            Fraction fractionA = new Fraction(1, 2);
            Fraction fractionB = new Fraction(2, 5);

            fractionA.Multiply(fractionB);
            fractionA.Shorten();

            Assert.AreEqual("1/5", fractionA.ToString());
            Assert.AreEqual("2/5", fractionB.ToString());
            Assert.AreEqual(0.2, fractionA.Quotient, 0.001);
            Assert.AreEqual(0.4, fractionB.Quotient, 0.001);
        }

        [TestMethod]
        public void TestDivision()
        {
            Fraction fractionA = new Fraction(1, 2);
            Fraction fractionB = new Fraction(1, 6);

            fractionA.Divide(fractionB);
            fractionA.Shorten();

            Assert.AreEqual("3/1", fractionA.ToString());
            Assert.AreEqual("1/6", fractionB.ToString());
            Assert.AreEqual(3.0, fractionA.Quotient, 0.001);
            Assert.AreEqual(0.166, fractionB.Quotient, 0.001);
        }
    }
}
