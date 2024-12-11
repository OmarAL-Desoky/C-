using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BicyclesUe
{
    public class Cyclist
    {
        const int AMOUNT_OF_BICYCLES = 3;

        const string DEFAULT_TEAM = "None";

        private string name;
        private string team;
        private Bicycle[] bicycles;

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        public string Team
        {
            get
            {
                return this.team;
            }
            set
            {
                if(string.IsNullOrEmpty(value))
                {
                    value = DEFAULT_TEAM;
                }

                this.team = value;
            }
        }
        public int BicycleCount
        {
            get
            {
                int bicycleCount = 0;

                for (int i = 0; i < this.bicycles.Length; i++)
                {
                    if (this.bicycles[i] != null)
                    {
                        bicycleCount++;
                    }
                }

                return bicycleCount;
            }
        }

        public int TotalMileage
        {
            get
            {
                int totalMileage = 0;

                for (int i = 0; i < this.bicycles.Length; i++)
                {
                    if(this.bicycles[i] != null)
                    {
                        totalMileage += this.bicycles[i].Mileage;
                    }
                }

                return totalMileage;
            }
        }

        public Cyclist(string name)
            :this(name, DEFAULT_TEAM)
        {
        }

        public Cyclist(string name, string team)
        {
            this.Name = name;
            this.Team = team;
            this.bicycles = new Bicycle[AMOUNT_OF_BICYCLES];
        }

        public bool HasBicycle(int frameId)
        {
            bool hasBicycle = false;

            for(int i = 0; i < this.bicycles.Length && !hasBicycle; i++)
            {
                if (this.bicycles[i] != null && this.bicycles[i].FrameId == frameId)
                {
                    hasBicycle = true;
                }
            }

            return hasBicycle;
        }

        public bool AddBicycle(Bicycle bicycle)
        {
            bool addedBicycle = false;

            if(!HasBicycle(bicycle.FrameId))
            {
                for (int i = 0; i < this.bicycles.Length && !addedBicycle; i++)
                {
                    if (this.bicycles[i] == null)
                    {
                        this.bicycles[i] = bicycle;
                        addedBicycle = true;
                    }
                }
            }

            return addedBicycle;
        }

        public bool RemoveBicycle(int frameId)
        {
            bool removedBicycle = false;

            for (int i = 0; i < this.bicycles.Length; i++)
            {
                if (this.bicycles[i] != null && this.bicycles[i].FrameId == frameId)
                {
                    this.bicycles[i] = null;
                    removedBicycle = true;
                }
            }

            return removedBicycle;
        }

        public override string ToString()
        {
            string result = $"{this.name} (Team: {this.team})";

            if(BicycleCount > 0)
            {
                result += $", {this.BicycleCount} bike(s) owned";
            }
            
            return result;
        }
    }
}
