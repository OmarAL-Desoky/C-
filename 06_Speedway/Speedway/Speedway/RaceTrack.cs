using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Speedway
{
    public class RaceTrack
    {
        private const int MIN_TRACK_LENGTH = 260;
        private const int MAX_TRACK_LENGTH = 450;
        private const int DEFAULT_TRACK_LENGTH = 383;
        private const int RIDERS_LENGTH = 4;

        private double trackLength;
        private Rider[] riders;

        public double TrackLength
        {
            get
            {
                return this.trackLength;
            }
            private set
            {
                if (!(MIN_TRACK_LENGTH <= value && value <= MAX_TRACK_LENGTH))
                {
                    value = DEFAULT_TRACK_LENGTH;
                }
                
                this.trackLength = value;
            }
        }

        public double RaceDistance
        {
            get
            {
                return this.trackLength * 4;
            }
        }

        public int RidersCount
        {
            get
            {
                int counter = 0;

                for(int i = 0; i < this.riders.Length; i++)
                {
                    if (this.riders[i] != null)
                    {
                        counter++;
                    }
                }

                return counter;
            }
        }

        public bool IsFinished
        {
            get
            {
                bool result = true;

                for(int i = 0; i < this.riders.Length && result; i++)
                {
                    if (riders[i] != null && !HasRiderFinished(riders[i]))
                    {
                        result = false;
                    }
                }

                return result;
            }
        }

        public RaceTrack()
            : this(DEFAULT_TRACK_LENGTH)
        {
        }

        public RaceTrack(double length)
        {
            this.TrackLength = length;
            this.riders = new Rider[RIDERS_LENGTH];
        }

        public bool HasRider(int jerseyNumber)
        {
            bool hasRider = false;

            for(int i = 0; i < this.riders.Length && !hasRider; i++)
            {
                if (riders[i] != null && (riders[i].JerseyNumber == jerseyNumber))
                {
                    hasRider = true;
                }
            }

            return hasRider;
        }

        public void Race()
        {
            if (this.RidersCount == RIDERS_LENGTH)
            {
                for(int i = 0; i < this.riders.Length; i++)
                {
                    if (!HasRiderFinished(riders[i]))
                    {
                        riders[i].Ride(1);
                    }
                }
            }
        }

        public bool HasRiderFinished(Rider rider)
        {
            bool hasFinished = false;

            if (rider.Distance >= this.RaceDistance)
            {
                hasFinished = true;
            }

            return hasFinished;
        }

        public bool RegisterRider(Rider rider)
        {
            bool added_rider = false;

            if (!HasRider(rider.JerseyNumber)) 
            {
                for(int i = 0; i < this.riders.Length && !added_rider; i++)
                {
                    if (riders[i] == null)
                    {
                        riders[i] = rider;
                        added_rider = true;
                    }
                }
            }

            return added_rider;
        }

        public bool UnregisterRider(int jerseyNumber)
        {
            bool removed_rider = false;

            for (int i = 0; i < this.riders.Length && !removed_rider; i++)
            {
                if (this.riders[i] != null && (this.riders[i].JerseyNumber == jerseyNumber))
                {
                    this.riders[i] = null;
                    removed_rider = true;
                }
            }

            return removed_rider;
        }
    }
}
