using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diner
{
    public class Dish
    {
        private string name;
        private Course course;
        private double price;

        public string Name
        {
            get
            {
                return this.name;
            }
            private set 
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name must not be null or empty!");
                }

                this.name = value; 
            }
        }

        public Course Course
        {
            get
            {
                return this.course;
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
                if (value <= 0)
                {
                    throw new ArgumentException("Price must be greater than 0!");
                }

                this.price = value;
            }
        }


        public Dish(string name, Course course, double price) 
        {
            this.course = course;
            this.Name = name;
            this.Price = price;
        }
    }
}
