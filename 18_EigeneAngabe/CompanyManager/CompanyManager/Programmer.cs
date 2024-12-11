using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManager
{
    public class Programmer : Worker
    {
        private const double BASE_SALARY = 3000.0;
        private int coffePerHour;

        public int CoffePerHour
        {
            get 
            { 
                return this.coffePerHour; 
            }
        }

        public Programmer(string name, double workedHours, double baseSalary, int coffePerHour)
            : base(name, workedHours, baseSalary)
        {
            this.coffePerHour = coffePerHour;
        }

        public Programmer(string name, double workedHours, int coffePerHour)
            : base(name, workedHours)
        {
            this.coffePerHour = coffePerHour;
        }

        public override double CalculateSalary()
        {
            return 0;
        }

        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine($"I am the Programmer and drink {this.coffePerHour} Coffe/h");
        }
    }
}
