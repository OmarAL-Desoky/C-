using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcelService
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
                if(value.ToString().Length != 3)
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
            this.Name = name;
            this.Id = id;
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
            Console.WriteLine(ToString());
        }

        public override string ToString()
        {
            string result = $"#{this.id} {this.name} ({(double)this.weight/1000:f2}kg) - {this.price}$";
            return result;
        }

        public override bool Equals(object? obj)
        {
            return obj is Product product &&
                   id == product.id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(id);
        }
    }
}
