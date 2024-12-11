using System;

namespace Fractions
{
    class Program
    {
        //Set this to true to stop the program on errors:
        private static bool stopOnError = false;

        private static bool containsErrors = false;

        static void Main(string[] args)
        {
            Console.WriteLine("=== Testing GCD calculation. ===");
            TestGreatestCommonDivisor();
            Console.WriteLine("=== Testing constructor and setters. ===");
            TestConstructorAndSetters();
            Console.WriteLine("=== Testing shortening. ===");
            TestShorten();
            Console.WriteLine("=== Testing toString. ===");
            TestToString();
            Console.WriteLine("=== Testing addition. ===");
            TestAddition();
            Console.WriteLine("=== Testing subtraction. ===");
            TestSubtraction();
            Console.WriteLine("=== Testing multiplication. ===");
            TestMultiplication();
            Console.WriteLine("=== Testing division. ===");
            TestDivision();

            Console.WriteLine();

            if (!containsErrors)
            {
                Console.WriteLine("Good job! :)");
            }
            else
            {
                Console.WriteLine("There are still errors in your solution. :(");
            }
        }

        public static void TestGreatestCommonDivisor()
        {
            AssertEquals(1, Fraction.CalculateGreatestCommonDivisor(11213, 19937));
            AssertEquals(3, Fraction.CalculateGreatestCommonDivisor(1701, 3768));
            AssertEquals(13, Fraction.CalculateGreatestCommonDivisor(12987, 32903));
            AssertEquals(24, Fraction.CalculateGreatestCommonDivisor(1224, 2712));
        }

        public static void TestConstructorAndSetters()
        {
            Fraction fraction = new Fraction();
            AssertEquals(1, fraction.Numerator);
            AssertEquals(1, fraction.Denominator);
            AssertEquals(1.0, fraction.Quotient, 0.01);

            fraction = new Fraction(20, 60);

            AssertEquals(20, fraction.Numerator);
            AssertEquals(60, fraction.Denominator);
            AssertEquals(0.333, fraction.Quotient, 0.001);

            fraction.Numerator = 19;

            AssertEquals(19, fraction.Numerator);
            AssertEquals(60, fraction.Denominator);
            AssertEquals(0.316, fraction.Quotient, 0.001);

            fraction.Denominator = 74;

            AssertEquals(19, fraction.Numerator);
            AssertEquals(74, fraction.Denominator);
            AssertEquals(0.256, fraction.Quotient, 0.001);

            fraction = new Fraction(3, 5);

            AssertEquals(3, fraction.Numerator);
            AssertEquals(5, fraction.Denominator);
            AssertEquals(0.6, fraction.Quotient, 0.001);

            fraction.Numerator = 0;

            AssertEquals(0, fraction.Numerator);
            AssertEquals(5, fraction.Denominator);
            AssertEquals(0.0, fraction.Quotient, 0.001);

            fraction.Numerator = 100;

            AssertEquals(100, fraction.Numerator);
            AssertEquals(5, fraction.Denominator);
            AssertEquals(20.0, fraction.Quotient, 0.001);

            fraction.Numerator = -1;

            AssertEquals(0, fraction.Numerator);
            AssertEquals(5, fraction.Denominator);
            AssertEquals(0.0, fraction.Quotient, 0.001);

            fraction = new Fraction(12, 34);

            AssertEquals(12, fraction.Numerator);
            AssertEquals(34, fraction.Denominator);
            AssertEquals(0.352, fraction.Quotient, 0.001);

            fraction.Denominator = 0;

            AssertEquals(12, fraction.Numerator);
            AssertEquals(1, fraction.Denominator);
            AssertEquals(12.0, fraction.Quotient, 0.001);

            fraction.Denominator = 56;

            AssertEquals(12, fraction.Numerator);
            AssertEquals(56, fraction.Denominator);
            AssertEquals(0.214, fraction.Quotient, 0.001);

            fraction.Denominator = -34;

            AssertEquals(12, fraction.Numerator);
            AssertEquals(1, fraction.Denominator);
            AssertEquals(12.0, fraction.Quotient, 0.001);
        }

        public static void TestShorten()
        {
            Fraction fraction = new Fraction(20, 60);

            AssertEquals(20, fraction.Numerator);
            AssertEquals(60, fraction.Denominator);
            AssertEquals(0.333, fraction.Quotient, 0.001);

            fraction.Shorten();

            AssertEquals(1, fraction.Numerator);
            AssertEquals(3, fraction.Denominator);
            AssertEquals(0.333, fraction.Quotient, 0.001);

            fraction.Shorten();
            fraction.Shorten();
            fraction.Shorten();
            fraction.Shorten();
            fraction.Shorten();
            fraction.Shorten();

            AssertEquals(1, fraction.Numerator);
            AssertEquals(3, fraction.Denominator);
            AssertEquals(0.333, fraction.Quotient, 0.001);

            fraction = new Fraction(12987, 32903);

            AssertEquals(12987, fraction.Numerator);
            AssertEquals(32903, fraction.Denominator);
            AssertEquals(0.394, fraction.Quotient, 0.001);

            fraction.Shorten();

            AssertEquals(999, fraction.Numerator);
            AssertEquals(2531, fraction.Denominator);
            AssertEquals(0.394, fraction.Quotient, 0.001);

            fraction = new Fraction(11213, 19937);

            AssertEquals(11213, fraction.Numerator);
            AssertEquals(19937, fraction.Denominator);
            AssertEquals(0.562, fraction.Quotient, 0.001);

            fraction.Shorten();

            AssertEquals(11213, fraction.Numerator);
            AssertEquals(19937, fraction.Denominator);
            AssertEquals(0.562, fraction.Quotient, 0.001);
        }

        public static void TestToString()
        {
            Fraction fraction = new Fraction();
            AssertEquals("1/1", fraction.ToString());

            fraction = new Fraction(3, 4);
            AssertEquals("3/4", fraction.ToString());

            fraction.Numerator = 50;
            AssertEquals("50/4", fraction.ToString());

            fraction.Denominator = 200;
            AssertEquals("50/200", fraction.ToString());

            fraction.Shorten();
            AssertEquals("1/4", fraction.ToString());

            fraction.Shorten();
            AssertEquals("1/4", fraction.ToString());
        }

        public static void TestAddition()
        {
            Fraction fractionA = new Fraction(1, 5);
            Fraction fractionB = new Fraction(2, 5);

            fractionA.Add(fractionB);
            fractionA.Shorten();
            AssertEquals("3/5", fractionA.ToString());
            AssertEquals("2/5", fractionB.ToString());
            AssertEquals(0.6, fractionA.Quotient, 0.001);
            AssertEquals(0.4, fractionB.Quotient, 0.001);

            fractionA = new Fraction(3, 4);
            fractionB = new Fraction(3, 8);

            fractionA.Add(fractionB);
            fractionA.Shorten();
            AssertEquals("9/8", fractionA.ToString());
            AssertEquals("3/8", fractionB.ToString());
            AssertEquals(1.125, fractionA.Quotient, 0.001);
            AssertEquals(0.375, fractionB.Quotient, 0.001);
        }

        public static void TestSubtraction()
        {
            Fraction fractionA = new Fraction(3, 4);
            Fraction fractionB = new Fraction(1, 4);

            fractionA.Subtract(fractionB);
            fractionA.Shorten();

            AssertEquals("1/2", fractionA.ToString());
            AssertEquals("1/4", fractionB.ToString());
            AssertEquals(0.5, fractionA.Quotient, 0.001);
            AssertEquals(0.25, fractionB.Quotient, 0.001);

            fractionA = new Fraction(1, 2);
            fractionB = new Fraction(1, 6);

            fractionA.Subtract(fractionB);
            fractionA.Shorten();

            AssertEquals("1/3", fractionA.ToString());
            AssertEquals("1/6", fractionB.ToString());
            AssertEquals(0.333, fractionA.Quotient, 0.001);
            AssertEquals(0.166, fractionB.Quotient, 0.001);

            fractionA = new Fraction(10, 12);
            fractionB = new Fraction(3, 12);

            fractionA.Subtract(fractionB);
            fractionA.Shorten();
            fractionB.Shorten();

            AssertEquals("7/12", fractionA.ToString());
            AssertEquals("1/4", fractionB.ToString());
            AssertEquals(0.583, fractionA.Quotient, 0.001);
            AssertEquals(0.25, fractionB.Quotient, 0.001);
        }

        public static void TestMultiplication()
        {
            Fraction fractionA = new Fraction(3, 4);
            Fraction fractionB = new Fraction(1, 4);

            fractionA.Multiply(fractionB);
            fractionA.Shorten();

            AssertEquals("3/16", fractionA.ToString());
            AssertEquals("1/4", fractionB.ToString());
            AssertEquals(0.1875, fractionA.Quotient, 0.001);
            AssertEquals(0.25, fractionB.Quotient, 0.001);

            fractionA = new Fraction(1, 2);
            fractionB = new Fraction(2, 5);

            fractionA.Multiply(fractionB);
            fractionA.Shorten();

            AssertEquals("1/5", fractionA.ToString());
            AssertEquals("2/5", fractionB.ToString());
            AssertEquals(0.2, fractionA.Quotient, 0.001);
            AssertEquals(0.4, fractionB.Quotient, 0.001);

            fractionA = new Fraction(1, 3);
            fractionB = new Fraction(9, 16);

            fractionA.Multiply(fractionB);
            fractionA.Shorten();

            AssertEquals("3/16", fractionA.ToString());
            AssertEquals("9/16", fractionB.ToString());
            AssertEquals(0.1875, fractionA.Quotient, 0.001);
            AssertEquals(0.562, fractionB.Quotient, 0.001);
        }

        public static void TestDivision()
        {
            Fraction fractionA = new Fraction(1, 2);
            Fraction fractionB = new Fraction(1, 6);

            fractionA.Divide(fractionB);
            fractionA.Shorten();

            AssertEquals("3/1", fractionA.ToString());
            AssertEquals("1/6", fractionB.ToString());
            AssertEquals(3.0, fractionA.Quotient, 0.001);
            AssertEquals(0.166, fractionB.Quotient, 0.001);

            fractionA = new Fraction(12, 18);
            fractionB = new Fraction(500, 100);

            fractionA.Divide(fractionB);
            fractionA.Shorten();

            AssertEquals("2/15", fractionA.ToString());
            AssertEquals("500/100", fractionB.ToString());
            AssertEquals(0.133, fractionA.Quotient, 0.001);
            AssertEquals(5.0, fractionB.Quotient, 0.001);
        }

        private static void AssertEquals(Object expected, Object actual)
        {
            if (!expected.Equals(actual))
            {
                RaiseErrorFlag();
                Console.WriteLine($"Expected \"{expected}\" but received \"{actual}\" instead!");
            }
        }

        private static void AssertEquals(double expected, double actual, double delta)
        {
            double difference = Math.Abs(expected - actual);
            if (delta < difference)
            {
                RaiseErrorFlag();
                Console.WriteLine($"Expected \"{expected}\" but received \"{actual}\" instead!");
            }
        }

        private static void RaiseErrorFlag()
        {
            containsErrors = true;

            if (stopOnError)
            {
                throw new Exception();
            }
        }
    }
}
