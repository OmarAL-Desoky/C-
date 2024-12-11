using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Speedway
{
    public class Motorcycle
    {
        private const int MIN_PS = 60;
        private const int MAX_PS = 80;

        private const double MIN_WEIGHT = 78;

        private string brand;
        private int horsePower;
        private double weight;

        public string Brand
        {
            get
            {
                return this.brand;
            }
        }

        public int HorsePower
        {
            get
            {
                return this.horsePower;
            }
            set
            {
                if(value < MIN_PS)
                {
                    value = MIN_PS;
                }
                else if(MAX_PS < value)
                {
                    value = MAX_PS;
                }

                this.horsePower = value;
            }
        }

        public double Weight
        {
            get
            {
                return this.weight;
            }
            set
            {
                if(value < MIN_WEIGHT)
                {
                    value = MIN_WEIGHT;
                }

                this.weight = value;
            }
        }

        public double MetersPerSecond
        {
            get
            {
                double result = 35 + this.horsePower - this.weight;
                
                if(result < 0)
                {
                    result = 0;
                }

                return result;
            }
        }

        public Motorcycle(string brand, int horsePower, double weight)
        {
            this.brand = brand;
            this.HorsePower = horsePower;
            this.Weight = weight;
        }
    }
}
