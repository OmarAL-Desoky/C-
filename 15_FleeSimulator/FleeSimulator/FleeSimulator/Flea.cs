using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleeSimulator
{
    public class Flea
    {
        private Pet petInfested;
        private int bitesCount;

        public Pet PetInfested
        {
            get
            {
                return this.petInfested;
            }
        }

        public int BitesCount
        {
            get
            {
                return this.bitesCount;
            }
        }

        public int BitePet(int bites)
        {
            if(this.petInfested == null)
            {
                bites = 0;   
            }
            else
            {
                if(this.petInfested.BitesRemaining < bites)
                {
                    bites = this.petInfested.BitesRemaining;
                }

                this.bitesCount += bites;
                this.petInfested.DoGetBitten(bites);
            }

            return bites;
        }

        public void JumpOnPet(Pet pet)
        {
            this.petInfested = pet;
        }

        public override string ToString()
        {
            string result = "I'm a flea!";
            return result;
        }
    }
}
