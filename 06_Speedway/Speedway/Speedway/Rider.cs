using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Speedway
{
    public class Rider
    {
        private static int jerseyNumberCounter = -1;
        private int jerseyNumber;
        private string firstName;
        private string lastName;
        private double distance = 0;
        private Motorcycle motorcycle;

        public int JerseyNumber
        {
            get
            {
                return this.jerseyNumber;
            }
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }
        }

        public double Distance
        {
            get
            {
                return this.distance;
            }
        }

        public Motorcycle Motorcycle
        {
            get
            {
                return this.motorcycle;
            }
            set
            {
                this.motorcycle = value;
            }
        }

        public Rider(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.jerseyNumber = jerseyNumberCounter++;
        }

        public void Ride(int secondsRide)
        {
            if (this.motorcycle != null)
            {
                double result = (secondsRide * this.motorcycle.MetersPerSecond);
                
                if (result > 0)
                {
                    this.distance += result;
                }
            }
        }

        public override string ToString()
        {
            string result = $"#{this.jerseyNumber} {this.lastName}";
            return result;
        }
    }
}
