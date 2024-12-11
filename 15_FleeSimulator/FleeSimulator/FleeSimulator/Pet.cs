using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleeSimulator
{
    public abstract class Pet
    {
        private const int MAX_BITES = 100;

        private string name;
        private int bitesRemaining;

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if(string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name must not be null or empty!");
                }

                this.name = value;
            }
        }

        public int BitesRemaining
        {
            get
            {
                return this.bitesRemaining;
            }
            private set
            {
                this.bitesRemaining = value;
            }
        } 

        public Pet(string name)
        {
            this.Name = name;
            this.bitesRemaining = MAX_BITES;
        }

        public int DoGetBitten(int count)
        {
            if(count < 0)
            {
                throw new ArgumentException("Bites must not be negative!");
            }

            if(count <= this.bitesRemaining)
            {
                this.bitesRemaining -= count;
            } 
            else
            {
                count = this.bitesRemaining;
                this.bitesRemaining = 0;
            }

            return count;
        }

        public override string ToString()
        {
            string result = $"I'm {this.name}, ";
            return result;
        }
    }
}
