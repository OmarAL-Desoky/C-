using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabCompany
{
    public abstract class Vehicle : IComparable<Vehicle>
    {
        private string licensePlate;
        private double basePricePerKm;
        private double mileage;
        private double turnover;
        private bool isFree;

        public string LicensePlate
        {
            get
            {
                return this.licensePlate;
            }
            private set
            {
                this.licensePlate = value;
            }
        }

        public double BasePricePerKm
        {
            get
            {
                return this.basePricePerKm;
            }
        }

        public double Mileage
        {
            get
            {
                return this.mileage;
            }
        }

        public double Turnover
        {
            get
            {
                return this.turnover;
            }
        }

        public bool IsFree
        {
            get
            {
                return this.isFree;
            }
        }

        public Vehicle(string licensePlate, double basePricePerKm)
        {
            this.LicensePlate = licensePlate;
            this.basePricePerKm = basePricePerKm;
        }

        public abstract double CalculatePriceForRoute(double y);

        public int CompareTo(Vehicle other)
        {
            return this.CompareTo(other);
        }

        public void EndRoute()
        {

        }

        public override bool Equals(object? obj)
        {
            return obj is Vehicle vehicle &&
                   licensePlate == vehicle.licensePlate;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(licensePlate);
        }

        public bool StartRoute(double distance)
        {
            return false;
        }

        public static bool IsValidLicensePlate(string licensePlate)
        {
            //Must only contain digits and upper case letters
            ContainsOnlyDigitsAndUpperCaseLetters(licensePlate);

            //Must contain exactly one dash
            ContainsOnlyOneDash(licensePlate);

            //Left part must contain one or two symbols
            IsLeftPartValid(licensePlate);

            //If left part contains one digit, right side must have 5 or 6 symbols
            IsRightPartValidIfLeftPartContainsOneDigit(licensePlate);

            //If left part contains two digits, right side must have 4 or 5 symbols
            return false;
        }

        public static bool ContainsOnlyDigitsAndUpperCaseLetters(string licensePlate)
        {
            bool containsOnlyDigitsAndUpperCaseLetters = true;

            for(int i = 0; i < licensePlate.Length && containsOnlyDigitsAndUpperCaseLetters; i++)
            {
                if (!(0 <= licensePlate[i] && licensePlate[i] <= 9) && !('A' <= licensePlate[i] && licensePlate[i] <= 'Z'))
                {
                    containsOnlyDigitsAndUpperCaseLetters = false;
                }
            }

            return containsOnlyDigitsAndUpperCaseLetters;
        }

        public static bool ContainsOnlyOneDash(string licensePlate)
        {
            int countOfDashes = 0;

            for(int i = 0; i < licensePlate.Length; i++)
            {
                if (licensePlate[i] == '-')
                {
                    countOfDashes++;
                }
            }

            return countOfDashes == 1;
        }

        public static bool IsLeftPartValid(string licensePlate)
        {
            int countOfSymbolsOfLeftPart = 0;
            bool isLeftPartFinished = false;

            for (int i = 0; i < licensePlate.Length && !isLeftPartFinished; i++)
            {
                countOfSymbolsOfLeftPart++;
                isLeftPartFinished = licensePlate[i] == '-';
            }

            return countOfSymbolsOfLeftPart == 1 || countOfSymbolsOfLeftPart == 2;
        }

        public static bool IsRightPartValidIfLeftPartContainsOneDigit(string licensePlate)
        {
            bool isRightPartValidIfLeftPartContainsOneDigit = false;
            bool startRightPart = false;

            for(int i = 0; i < licensePlate.Length; i++)
            {
                if (licensePlate[i] == '-')
                {
                    startRightPart = true;
                }
            }
        }
    }
}
