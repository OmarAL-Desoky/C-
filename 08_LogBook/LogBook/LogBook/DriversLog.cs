using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogBook
{
    public class DriversLog
    {
        private const int ADD_TRIP = 1;

        private Trip[] trips;
        private int tripsCount = 0;

        public Trip[] Trips
        {
            get
            {
                Trip[] fakeTrips = new Trip[this.trips.Length];

                for(int i = 0; i < this.trips.Length; i++)
                {
                    fakeTrips[i] = this.trips[i];
                }

                return fakeTrips;
            }
        }

        public int TripsCount
        {
            get
            {
                return this.tripsCount;
            }
        }

        public DriversLog()
        {
            trips = new Trip[0];
        }

        public double AverageTripDistance
        {
            get
            {
                if (this.trips.Length == 0)
                {
                    throw new InvalidOperationException("No trips logged yet!");
                }

                double average = 0.0;

                for(int i = 0; i < this.trips.Length; i++)
                {
                    average += this.trips[i].Distance;
                }

                average /= this.trips.Length;
                return average;
            }
        }

        public Trip ShortestTrip
        {
            get
            {
                Trip shortestTrip = null;

                if (this.trips.Length != 0)
                {
                    shortestTrip = this.trips[0];
                }

                for(int i = 0; i < this.trips.Length; i++)
                {
                    if (this.trips[i] != null && this.trips[i].Distance < shortestTrip.Distance)
                    {
                        shortestTrip = this.trips[i];
                    }
                }

                return shortestTrip;
            }
        }

        public double TotalFuelConsumed
        {
            get
            {
                double result = 0.0;

                for (int i = 0; i < this.trips.Length; i++)
                {
                    result += this.trips[i].FuelConsumed;
                }

                return result;
            }
        }

        public void AddTrip(Trip trip)
        {
            if (IsInTrips(trip.TripId))
            {
                throw new ArgumentException($"Log already contains a trip with ID {trip.TripId}!");
            }

            Trip[] newTrips = new Trip[this.trips.Length + ADD_TRIP];
            
            for(int i = 0; i < this.trips.Length; i++)
            {
                newTrips[i] = this.trips[i];
            }

            if(this.trips.Length == 0)
            {
                newTrips[0] = trip;
            }
            else
            {
                bool addedTrip = false;

                for (int i = 0; i < this.trips.Length && !addedTrip; i++)
                {
                    if (trip.Distance > this.trips[i].Distance)
                    {
                        for (int j = newTrips.Length - 1; j >= i + 1; j--)
                        {
                            newTrips[j] = newTrips[j - 1];
                        }

                        newTrips[i] = trip;
                        addedTrip = true;
                    }
                }

                if (!addedTrip)
                {
                    newTrips[this.trips.Length] = trip;
                }
            }

            this.trips = newTrips;
            tripsCount++;
        }

        public bool IsInTrips(int tripId)
        {
            bool isInTrips = false;

            for(int i = 0; i < this.trips.Length && !isInTrips; i++)
            {
                isInTrips = (this.trips[i].TripId == tripId);
            }

            return isInTrips;
        }

        public int CountTripsByOrigin(string origin)
        {
            int countTripsByOrigin = 0;

            for(int i = 0; i < this.trips.Length; i++)
            {
                if(this.trips[i].Origin == origin)
                {
                    countTripsByOrigin++;
                }
            }

            return countTripsByOrigin;
        }
    }
}
