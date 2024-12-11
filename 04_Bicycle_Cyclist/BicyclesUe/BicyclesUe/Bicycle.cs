using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BicyclesUe
{
    public class Bicycle
    {
        const string DEFAULT_TYPE = "City";
        const string MOUNTAIN = "Mountain";
        const string ROAD = "Road";
        const string TREKKING = "Trekking";

        const int DEFAULT_MILEAGE = 0;

        private static int counter = -1;
        private int frameId;
        private string brand;
        private string type;
        private int mileage;
        private Cyclist owner;

        public Cyclist Owner
        {
            get
            {
                return this.owner;
            }
            set
            {
                if(this.owner != value)
                {
                    this.mileage = DEFAULT_MILEAGE;
                }

                this.owner = value;
            }
        }

        public int FrameId
        {
            get
            {
                return this.frameId;
            }
        }

        public int FrameIdCounter(int frameIdCounter)
        {
            frameIdCounter++;
            counter = frameIdCounter;

            return counter;
        }

        public string Brand
        {
            get
            {
                return this.brand;
            }
            set
            {
                this.brand = value;
            }
        }

        public string Type
        {
            get
            {
                return this.type;
            }
            set
            {
                if(value != MOUNTAIN && value != ROAD && value != TREKKING)
                {
                    value = DEFAULT_TYPE;
                }

                this.type = value;
            }
        }

        public int Mileage
        {
            get
            {
                return this.mileage;
            }
        }

        public override string ToString()
        {
            string result = $"#{this.frameId} - {this.type} Bike by {this.brand} (Mileage: {this.mileage} km)";
            
            if(this.owner != null )
            {
                result += $", owned by {this.owner.Name}";
            }
            
            return result;
        }

        public Bicycle(string brand, string type)
        {
            this.Brand = brand;
            this.Type = type;
            this.frameId = FrameIdCounter(counter);
            this.mileage = DEFAULT_MILEAGE;
        }

        public void Ride(int distanceTraveled)
        {
            if(distanceTraveled > 0)
            {
                this.mileage += distanceTraveled;
            }
        }
    }
}
