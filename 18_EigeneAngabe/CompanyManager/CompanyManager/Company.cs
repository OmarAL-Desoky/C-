using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManager
{
    public class Company
    {
        private List<Worker> workers;

        public int WorkerCount
        {
            get
            {
                return 0;
            }
        }

        public double TotalSalaryToPay
        {
            get
            {
                return 0;
            }
        }

        public bool HireWorker(Worker worker)
        {
            return false;
        }

        public bool FireWorker(int catalogNumber)
        {
            return true;
        }

        public void SortWorkersByCatalogNumber()
        {

        }
    }
}
