using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManager
{
    public class SalaryComparer : IComparer<Worker>
    {
        private double hours;
 
        public SalaryComparer(double hours)
        {
            this.hours = hours;
        } 

        public int Compare(Worker? x, Worker? y)
        {
            return -x.WorkedHours.CompareTo(y.WorkedHours);
        }
    }
}
