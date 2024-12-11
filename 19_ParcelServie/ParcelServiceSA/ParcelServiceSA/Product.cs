using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcelServiceSA
{
    public class Product : IOrderable
    {
        private int id;
        private string name;
        private double price;
        private int weight;

        public int Id
        {
            get 
            { 
                return this.id; 
            }
            private set
            {
                if(value < 100 || value > 999)
                {
                    throw new ArgumentException("Id must be exactly three digits long!");
                }

                this.id = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if(string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name must not be null or empty!");
                }

                this.name = value;
            }
        }

        public double Price
        {
            get
            {
                return this.price;
            }
            private set
            {
                if(value < 0)
                {
                    throw new ArgumentException("Price must not be negative!");
                }

                this.price = value;
            }
        }

        public int Weight
        {
            get
            {
                return this.weight;
            }
            private set
            {
                if(value < 1)
                {
                    throw new ArgumentException("Weight must be at least 1 gram!");
                }

                this.weight = value;
            }
        }

        public Product(int id, string name, double price, int weight)
        {
            this.Id = id;
            this.Name = name;
            this.Price = price;
            this.Weight = weight;
        }

        public double CalculatePrice()
        {
            return this.price;
        }

        public int CalculateWeight()
        {
            return this.weight;
        }

        public void PrintInfo(int x)
        {
            
        }

        public override bool Equals(object? obj)
        {
            return obj is Product product &&
                   Id == product.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

        public override string ToString()
        {
            double actWeight = (double)this.weight / 1000;
            string result = $"#{this.id} {this.name} ({actWeight:f2}kg) - {this.price:f2}$";
            return result;
        }
    }
}
