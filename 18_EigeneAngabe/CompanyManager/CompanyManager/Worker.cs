using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManager
{
    public abstract class Worker : IComparable<Worker>
    {
        private static int catalogNumberCounter;
        
        private string name;
        private double baseSalary;
        private double workedHours;
        private int catalogNumber;

        private const double BASE_SALARY = 3000.0;
        private const int MAX_WORKERS_COUNT = 1000;

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if(!IsValidName(value))
                {
                    throw new ArgumentException("Name must not contain numbers!");
                }

                this.name = value;
            }
        }

        private bool IsValidName(string name)
        {
            bool isValid = true;

            for(int i = 0; i < name.Length && isValid; i++)
            {
                if (name[i] != ' ')
                {
                    if (!(('A' <= name[i] && name[i] <= 'Z') || ('a' <= name[i] && name[i] <= 'z')))
                    {
                        isValid = false;
                    }
                }
            }

            return isValid;
        }

        public double BaseSalary
        {
            get
            {
                return this.baseSalary;
            }
        }

        public double WorkedHours
        {
            get
            {
                return this.workedHours;
            }
            private set
            {
                if(value < 0)
                {
                    throw new ArgumentException("Working Hours must not be negative!");
                }

                if(value > 40)
                {
                    throw new ArgumentException("Working Hours must not be more than 40h!");
                }

                if(value == 0)
                {
                    throw new ArgumentException("Working Hours must not be 0!");
                }

                this.workedHours = value;
            }
        }

        public int CatalogNumber
        {
            get
            {
                return this.catalogNumber;
            }
        }

        public Worker(string name, double workedHours, double baseSalary)
        {
            this.Name = name;
            this.baseSalary = baseSalary;
            this.WorkedHours = workedHours;

            this.catalogNumber = (catalogNumberCounter++);
        }

        public Worker(string name, double workedHours)
            :this (name, workedHours, BASE_SALARY)
        {
        }
        
        public int CompareTo(Worker? worker)
        {
            return -worker.workedHours.CompareTo(this.workedHours);
        }

        public override bool Equals(object? obj)
        {
            return obj is Worker worker &&
                   catalogNumber == worker.catalogNumber;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(catalogNumber);
        }

        public double Work(double hours)
        {
            if(hours < 0)
            {
                throw new ArgumentException("Working Hours must not be negative!");
            }

            double result = hours + this.workedHours;
            this.WorkedHours = hours + this.workedHours;

            return result;
        }

        public abstract double CalculateSalary();

        public virtual void PrintInfo()
        {
            Console.WriteLine($"Hello, I'm {this.name}, earn {CalculateSalary()}€!");
        }

        public static bool IsValidCatalogNumber(int catalogNumber)
        {
            return MAX_WORKERS_COUNT >= catalogNumber && catalogNumber >= 1;
        }
    }
}
