using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleeSimulator
{
    public class Dog : Pet
    {
        private const int SECONDS_TO_ADD = 1;

        private int huntsCount;
        private DateTime timeLastHunt;

        public int HuntsCount
        {
            get
            {
                return this.huntsCount;   
            }
        }

        public Dog(string name)
            :base(name)
        {
        }

        public bool Hunt()
        {
            bool huntedSuccessfully = false;
            
            if(DateTime.Now >= this.timeLastHunt.AddSeconds(SECONDS_TO_ADD))
            {
                huntedSuccessfully = true;
                this.huntsCount++;
                this.timeLastHunt = DateTime.Now;
            }
            
            return huntedSuccessfully;
        }

        public override string ToString()
        {
            string result = base.ToString();
            result += "woof!";
            return result;
        }
    }
}
