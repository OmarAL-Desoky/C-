using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcelServiceSA
{
    public interface IOrderable
    {
        double CalculatePrice();
        int CalculateWeight();
        void PrintInfo(int x);
    }
}
