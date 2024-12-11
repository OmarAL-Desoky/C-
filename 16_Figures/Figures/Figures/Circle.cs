using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures
{
    public class Circle : Figure
    {
        private double radius;

        public double Radius
        {
            get
            {
                return this.radius;
            }
            private set
            {
                if(value < 0)
                {
                    throw new ArgumentException();
                }

                this.radius = value;
            }
        }

        public override double Area
        {
            get
            {
                return Math.PI * (Math.Pow(this.radius, 2));
            }
        }

        public override double Circumference
        {
            get
            {
                return 2 * Math.PI * this.radius;
            }
        }

        public Circle(Color color, double radius)
            :base(color)
        {
            this.Radius = radius;
        }
    }
}
