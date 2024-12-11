using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcelService
{
    public class Parcel : IOrderable, IComparable<Parcel>
    {
        private List<IOrderable> orderables;

        public List<IOrderable> Orderables
        {
            get
            {
                return new List<IOrderable>(this.orderables);
            }
        }
        
        public Parcel()
        {
            this.orderables = new List<IOrderable>();
        }

        public void AddToParcel(IOrderable toAdd)
        {
            this.orderables.Add(toAdd);
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
        
        public int CompareTo(Parcel other)
        {
            return -this.CalculateWeight().CompareTo(other.CalculateWeight());
        }
        
        public double CalculatePrice()
        {
            double price = 0.0;   
            
            foreach (IOrderable currOrderable in this.orderables)
            {
                price += currOrderable.CalculatePrice();
            }

            return price;
        }

        public int CalculateWeight()
        {
            int weight = 100;

            foreach (IOrderable currOrderable in this.orderables)
            {
                weight += currOrderable.CalculateWeight();
            }

            return weight;
        }

        public void PrintInfo(int x)
        {

        }

        public override string ToString()
        {
            string result = $"Parcel ({(double)this.CalculateWeight()/1000:f2}kg) - {this.CalculatePrice():f2}$";
            return result;
        }
    }
}
