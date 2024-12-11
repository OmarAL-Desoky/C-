using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fractions
{
    internal class Fraction
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
                if(value < 0)
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
            :this(1, 1)
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

            if(this.Denominator != fractionB.Denominator)
            {
                int numberToMultiplyWith = 0;

                if(this.Denominator < fractionB.Denominator)
                {
                    numberToMultiplyWith = fractionB.Denominator / this.Denominator;
                }
                else
                {
                    numberToMultiplyWith = this.Denominator / fractionB.Denominator;
                }

                this.Numerator *= numberToMultiplyWith;
                this.Denominator *= numberToMultiplyWith;
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
                }
                else
                {
                    numberToMultiplyWith = this.Denominator / fractionB.Denominator;
                }

                this.Numerator *= numberToMultiplyWith;
                this.Denominator *= numberToMultiplyWith;
            }

            this.Numerator -= fractionB.Numerator;
        }

        public void Multiply(Fraction originalFractionB)
        {
            this.Numerator *= originalFractionB.Numerator;
            this.Denominator *= originalFractionB.Denominator;
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
    }
}
