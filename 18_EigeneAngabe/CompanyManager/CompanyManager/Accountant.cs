using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManager
{
    public class Accountant : Worker
    {
        public Accountant(string name, double workedHours, double baseSalary)
            :base(name, workedHours, baseSalary)
        {
        }

        public Accountant(string name, double workedHours)
            : base(name, workedHours)
        {
        }

        public override double CalculateSalary()
        {
            return base.BaseSalary + 2 * base.WorkedHours;
        }

        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine($"I am the Accountant!");
        }
    }
}
