using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace PearlNecklace
{
    public class Pearl
    {
        private const string RED = "Red";
        private const string GREEN = "Green";
        private const string BLUE = "Blue";
        private const string DEFAULT_COLOR = "Unknown";

        private const double UPPER_LETTER_MIN_WEIGHT = 2.5;

        private Pearl next;
        private string color;
        private double weight;

        public Pearl Next
        {
            get
            {
                return this.next;
            }
            set
            {
                this.next = value;
            }
        }

        public string Color
        {
            get
            {
                return this.color;
            }
            private set
            {
                if (!(value == RED || value == GREEN || value == BLUE))
                {
                    value = DEFAULT_COLOR;
                    this.Weight = 0.0;
                }

                this.color = value;
            }
        }

        public double Weight
        {
            get
            {
                return this.weight;
            }
            private set
            {
                if (value < 0)
                {
                    value = 0;
                }

                this.weight = value;
            }
        }

        public Pearl(string color, double weight)
        {
            this.Weight = weight;
            this.Color = color;
        }

        public override string ToString()
        {
            string result = $"({GetFirstLetter})";
            return result;
        }

        public char GetFirstLetter
        {
            get
            {
                char result = this.color[0];

                if (this.weight < UPPER_LETTER_MIN_WEIGHT)
                {
                    result = char.ToLower(this.color[0]);
                }

                return result;
            }
        }
    }
}