using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FractionsAdvanced
{
    public class Fraction
    {
        private int numerator;
        private int denominator;

        public int Numerator
        {
            get
            {
                return this.numerator;
            }
            set
            {
                if (value < 0)
                {
                    value = 0;
                }

                this.numerator = value;
            }
        }

        public int Denominator
        {
            get
            {
                return this.denominator;
            }
            set
            {
                if (value <= 0)
                {
                    value = 1;
                }

                this.denominator = value;
            }
        }

        public double Quotient
        {
            get
            {
                return (double)this.Numerator / this.Denominator;
            }
        }

        public Fraction()
            : this(1, 1)
        {
        }

        public Fraction(int numerator, int denominator)
        {
            this.Numerator = numerator;
            this.Denominator = denominator;
        }

        public void Add(Fraction originalFractionB)
        {
            Fraction fractionB = originalFractionB;

            if (this.Denominator != fractionB.Denominator)
            {
                int numberToMultiplyWith = 0;

                if (this.Denominator < fractionB.Denominator)
                {
                    numberToMultiplyWith = fractionB.Denominator / this.Denominator;

                    this.Numerator *= numberToMultiplyWith;
                    this.Denominator *= numberToMultiplyWith;
                }
                else
                {
                    numberToMultiplyWith = this.Denominator / fractionB.Denominator;

                    fractionB.Numerator *= numberToMultiplyWith;
                    fractionB.Denominator *= numberToMultiplyWith;

                }
            }

            this.Numerator += fractionB.Numerator;
        }

        public void Subtract(Fraction originalFractionB)
        {
            Fraction fractionB = originalFractionB;

            if (this.Denominator != fractionB.Denominator)
            {
                int numberToMultiplyWith = 0;

                if (this.Denominator < fractionB.Denominator)
                {
                    numberToMultiplyWith = fractionB.Denominator / this.Denominator;

                    this.Numerator *= numberToMultiplyWith;
                    this.Denominator *= numberToMultiplyWith;
                }
                else
                {
                    numberToMultiplyWith = this.Denominator / fractionB.Denominator;

                    fractionB.Numerator *= numberToMultiplyWith;
                    fractionB.Denominator *= numberToMultiplyWith;
                }
            }

            this.Numerator -= fractionB.Numerator;
        }

        public void Multiply(Fraction originalFractionB)
        {
            this.Numerator *= originalFractionB.Numerator;
            this.Denominator *= originalFractionB.Denominator;
        }

        public void MultiplyWithNumber(int number)
        {
            this.Numerator *= number;
        }

        public void Divide(Fraction originalFractionB)
        {
            this.Numerator *= originalFractionB.Denominator;
            this.Denominator *= originalFractionB.Numerator;
        }

        public void Shorten()
        {
            int ggt = CalculateGreatestCommonDivisor(this.Numerator, this.Denominator);

            this.Numerator /= ggt;
            this.Denominator /= ggt;
        }

        public override string ToString()
        {
            return $"{this.Numerator}/{this.Denominator}";
        }

        public static int CalculateGreatestCommonDivisor(int firstNumber, int secondNumber)
        {
            int rest = 0;

            do
            {
                rest = firstNumber % secondNumber;

                if (rest != 0)
                {
                    firstNumber = secondNumber;
                    secondNumber = rest;
                }

            } while (rest != 0);

            return secondNumber;
        }

        public static Fraction operator + (Fraction fractionA, Fraction fractionB)
        {
            Fraction result = new Fraction(fractionA.Numerator, fractionA.Denominator);
            result.Add(fractionB);
            result.Shorten();
            
            return result;
        }

        public static Fraction operator + (Fraction fraction, int number)
        {
            Fraction result = new Fraction(number, 1);
            fraction.Add(result);
            fraction.Shorten();

            return fraction;
        }

        public static Fraction operator - (Fraction fractionA, Fraction fractionB)
        {
            Fraction result = new Fraction(fractionA.Numerator, fractionA.Denominator);
            result.Subtract(fractionB);
            result.Shorten();

            return result;
        }

        public static Fraction operator * (Fraction fractionA, Fraction fractionB)
        {
            Fraction result = new Fraction(fractionA.Numerator, fractionA.Denominator);
            result.Multiply(fractionB);
            result.Shorten();

            return result;
        }

        public static Fraction operator / (Fraction fractionA, Fraction fractionB)
        {
            Fraction result = new Fraction(fractionA.Numerator, fractionA.Denominator);
            result.Divide(fractionB);
            result.Shorten();

            return result;
        }

        public static Fraction operator * (Fraction fraction, int number)
        {
            Fraction result = new Fraction(fraction.Numerator, fraction.Denominator);
            result.MultiplyWithNumber(number);
            result.Shorten();

            return result;
        }

        public static Fraction operator ++ (Fraction fraction)
        {
            Fraction other = new Fraction(1, 1);
            fraction.Add(other);
            fraction.Shorten();

            return fraction;
        }

        public static bool operator == (Fraction fractionA, Fraction fractionB)
        {
            bool isEqual = false;

            fractionA.Shorten();
            fractionB.Shorten();

            if (fractionA.Numerator == fractionB.Numerator && fractionA.Denominator == fractionB.Denominator)
            {
                isEqual = true;
            }

            return isEqual;
        }

        public static bool operator != (Fraction fractionA, Fraction fractionB)
        {
            bool isEqual = false;

            fractionA.Shorten();
            fractionB.Shorten();

            if (fractionA.Numerator != fractionB.Numerator && fractionA.Denominator != fractionB.Denominator)
            {
                isEqual = true;
            }

            return isEqual;
        }

        public static bool operator < (Fraction fractionA, Fraction fractionB)
        {
            bool result = false;

            double fractionAQuotient = fractionA.Quotient;
            double fractionBQuotient = fractionB.Quotient;

            if (fractionAQuotient < fractionBQuotient)
            {
                result = true;
            }

            return result;
        }

        public static bool operator <= (Fraction fractionA, Fraction fractionB)
        {
            bool result = false;

            double fractionAQuotient = fractionA.Quotient;
            double fractionBQuotient = fractionB.Quotient;

            if (fractionAQuotient <= fractionBQuotient)
            {
                result = true;
            }

            return result;
        }

        public static bool operator > (Fraction fractionA, Fraction fractionB)
        {
            bool result = false;

            double fractionAQuotient = fractionA.Quotient;
            double fractionBQuotient = fractionB.Quotient;

            if (fractionAQuotient > fractionBQuotient)
            {
                result = true;
            }

            return result;
        }

        public static bool operator >= (Fraction fractionA, Fraction fractionB)
        {
            bool result = false;

            double fractionAQuotient = fractionA.Quotient;
            double fractionBQuotient = fractionB.Quotient;

            if (fractionAQuotient >= fractionBQuotient)
            {
                result = true;
            }

            return result;
        }
    }
}
