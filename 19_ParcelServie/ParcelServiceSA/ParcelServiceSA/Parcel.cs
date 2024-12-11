using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcelServiceSA
{
    public class Parcel : IOrderable, IComparable<Parcel>
    {
        private const int DEFAULT_PARCEL_WEIGHT = 100;
        private List<IOrderable> orderables;

        public List<IOrderable> Orderables
        {
            get
            {
                return new List<IOrderable>(this.orderables);
            }
        }

        public void AddToParcel(IOrderable orderable)
        {
            this.orderables.Add(orderable);
        }

        public bool ContainsProduct(int id)
        {
            bool containsP = false;

            for (int i = 0; i < this.orderables.Count && !containsP; i++)
            {
                if (this.orderables[i] is Product p && p.Id == id || this.orderables[i] is Parcel parcel && parcel.ContainsProduct(id))
                {
                    containsP = true;
                }
            }

            return containsP;
        }

        public Parcel()
        {
            this.orderables = new List<IOrderable>();
        }

        public double CalculatePrice()
        {
            double priceSum = 0;

            foreach (IOrderable currOrderable in this.orderables)
            {
                priceSum += currOrderable.CalculatePrice();
            }

            return priceSum;
        }

        public int CalculateWeight()
        {
            int weight = DEFAULT_PARCEL_WEIGHT;

            foreach (IOrderable currOrderable in this.orderables)
            {
                weight += currOrderable.CalculateWeight();
            }

            return weight;
        }

        public override string ToString()
        {
            string result = $"Parcel ({(double)this.CalculateWeight() / 1000:f2}kg) - {this.CalculatePrice():f2}$";
            return result;
        }

        public void PrintInfo(int x)
        {

        }

        public int CompareTo(Parcel? other)
        {
            return -this.CalculateWeight().CompareTo(other.CalculateWeight());
        }
    }
}
