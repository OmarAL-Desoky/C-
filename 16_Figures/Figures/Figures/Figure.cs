using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures
{
    public abstract class Figure : IComparable<Figure>
    {
        private Color color;

        public Color Color
        {
            get 
            { 
                return this.color; 
            }
        }

        public abstract double Area
        {
            get;
        }

        public abstract double Circumference
        {
            get;
        }

        public Figure(Color color)
        {
            this.color = color;
        }

        public int CompareTo(Figure other)
        {
            return -this.Area.CompareTo(other.Area);
        }
    }
}
