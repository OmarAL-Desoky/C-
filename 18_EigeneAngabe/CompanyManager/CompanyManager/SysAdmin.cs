using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManager
{
    public class SysAdmin : Worker
    {
        private int taskCount;
        private int helpedWorkers;

        public int TaskCount
        {
            get
            {
                return this.taskCount;
            }
            set
            {
                this.taskCount += value;
            }
        }

        public int HelpedWorkers
        {
            get
            {
                return this.helpedWorkers;
            }
        }

        public SysAdmin(string name, double workedHours, double baseSalary)
            : base(name, workedHours, baseSalary)
        {
        }

        public SysAdmin(string name, double workedHours)
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
            Console.WriteLine($"I am the Sysadmin and helped {this.helpedWorkers} Workers!");
        }

        public bool UpdateSystem()
        {
            return false;
        }

        public int HelpWorkers()
        {
            return 0;
        }
    }
}
