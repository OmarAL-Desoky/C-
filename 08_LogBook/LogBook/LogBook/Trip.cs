using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogBook
{
    public class Trip
    {
        private const string DEFAULT_ORIGIN = "Linz";

        private static int tripIdCounter = -1;
        private int tripId;
        private string origin;
        private string destination;
        private int distance;

        public int TripId
        {
            get
            {
                return this.tripId;
            }
        }

        public string Origin
        {
            get
            {
                return this.origin;
            }
            set
            {
                if (!IsValid(value))
                {
                    throw new ArgumentException("Origin must not be null or empty and contain only letters!");
                }

                this.origin = value;
            }
        }

        public string Destination
        {
            get
            {
                return this.destination;
            }
            set
            {
                if (!IsValid(value))
                {
                    throw new ArgumentException("Destination must not be null or empty and contain only letters!");
                }

                this.destination = value;
            }
        }

        public bool IsValid(string word)
        {
            bool isValid = true;

            if(string.IsNullOrEmpty(word) || !ContainsOnlyLetters(word))
            {
                isValid = false;
            }

            return isValid;
        }

        public bool ContainsOnlyLetters(string word)
        {
            bool containsOnlyLetters = true;

            for (int i = 0; i < word.Length && containsOnlyLetters; i++)
            {
                if (!('A' <= word[i] && word[i] <= 'Z' || 'a' <= word[i] && word[i] <= 'z')) 
                { 
                    containsOnlyLetters = false;
                }
            }

            return containsOnlyLetters;
        }

        public int Distance
        {
            get
            {
                return this.distance;
            }
        }

        public double FuelConsumed
        {
            get
            {
                return ((double)this.distance / 100) * 7;
            }
        }

        public Trip(string destination, int distance)
            :this(DEFAULT_ORIGIN, destination, distance)
        {
        }

        public Trip(string origin, string destination, int distance)
        {
            this.Origin = origin;
            this.Destination = destination;
            this.tripId = (tripIdCounter++);

            if(distance < 1)
            {
                throw new ArgumentException("Distance must not be smaller than 1!");
            }

            this.distance += distance;
        }

        public Trip CreateReturnTrip()
        {
            Trip returnTrip = new Trip(this.destination, this.origin, this.distance);
            return returnTrip;
        }

        public override string ToString()
        {
            string result = $"Trip {this.tripId}: Drove {this.distance} km from {this.origin} to {this.destination} ({this.FuelConsumed, 0:f2} litres)";
            return result;
        }
    }
}
