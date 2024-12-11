using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcelService
{
    public class ParcelPriceComparer : IComparer<Parcel>
    {
        public int Compare(Parcel parcel, Parcel other)
        {
            return parcel.CalculatePrice().CompareTo(other.CalculatePrice());
        }
    }
}
