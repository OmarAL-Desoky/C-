using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circle
{
    internal class Circle
    {
        private const string DEFAULT_COLOR = "blue";
        private const int MIN_NUMBER = 0;
        private const int DEFAULT_NUMBER = 1;

        private int x;
        private int y;
        private double radius;
        private string color;

        public int X
        {
            get
            {
                return this.x; 
            }
            private set
            {
                if(value < MIN_NUMBER)
                {
                    value = MIN_NUMBER;
                }

                this.x = value;
            }
        }

        public int Y
        {
            get
            {
                return this.y;
            }
            private set
            {
                if (value < MIN_NUMBER)
                {
                    value = MIN_NUMBER;
                }

                this.y = value;
            }
        }

        public double Radius
        {
            get
            {
                return this.radius;
            }
            set
            {
                if(value < DEFAULT_NUMBER)
                {
                    value = DEFAULT_NUMBER;
                }

                this.radius = value;
            }
        }

        public string Color
        {
            get
            {
                return this.color;
            }
            set
            {
                if(string.IsNullOrEmpty(value))
                {
                    value = DEFAULT_COLOR;
                }

                this.color = value;
            }
        }

        public double Area
        {
            get
            {
                double result = Math.Pow(this.Radius, 2) * Math.PI;
                return result;
            }   
        }

        public double Circumference
        {
            get
            {
                double result = 2 * this.Radius * Math.PI;
                return result;
            }
        }

        public Circle()
            :this(MIN_NUMBER, MIN_NUMBER, DEFAULT_NUMBER)
        {
        }

        public Circle(int x, int y, double radius)
            :this(x, y, radius, DEFAULT_COLOR)
        {
        }

        public Circle(int x, int y, double radius, string color)
        {
            this.X = x;
            this.Y = y;
            this.Radius = radius;
            this.Color = color;
        }

        public double CalculateDistanceTo(Circle circle)
        {
            int x = this.X - circle.X;
            int y = this.Y - circle.Y;

            double distance = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
            return distance;
        }

        public bool IsBiggerThan(Circle circle)
        {
            bool isBigger = false;

            if(this.Area > circle.Area)
            {
                isBigger = true;
            }

            return isBigger;
        }

        public bool IsOverlapping(Circle circle)
        {
            double sum = this.Radius + circle.Radius;
            bool isOverlapping = false;

            if(sum > this.CalculateDistanceTo(circle))
            {
                isOverlapping = true;
            }

            return isOverlapping;
        }

        public bool MoveTo(int x, int y)
        {
            bool isSuccessful = false;

            if(x >= MIN_NUMBER && y >= MIN_NUMBER)
            {
                this.X = x;
                this.Y = y;

                isSuccessful = true;
            }

            return isSuccessful;
        }
    }
}
