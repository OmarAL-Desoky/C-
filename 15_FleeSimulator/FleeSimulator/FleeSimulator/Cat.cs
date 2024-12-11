using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleeSimulator
{
    public class Cat : Pet
    {
        private int treesClimbedCount;
        private bool isOnTree;

        public int TreesClimbedCount
        {
            get
            {
                return this.treesClimbedCount;
            }
        }

        public Cat(string name)
            :base(name)
        {
        }

        public bool ClimbUp()
        {
            bool climbedUp = false;

            if(!this.isOnTree)
            {
                climbedUp = true;
                this.isOnTree = true;
                this.treesClimbedCount++;
            }

            return climbedUp;
        }

        public bool ClimbDown()
        {
            bool climbedDown = false;

            if(this.isOnTree)
            {
                climbedDown = true;
                this.isOnTree = false;
            }

            return climbedDown;
        }

        public override string ToString()
        {
            string result = base.ToString();
            result += "meow!";
            return result;
        }
    }
}
