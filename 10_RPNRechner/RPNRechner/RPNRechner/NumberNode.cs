using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPNRechner
{
    public class NumberNode
    {
        private NumberNode next;
        private double number;

        public NumberNode Next
        {
            get
            {
                return this.next;
            }
            set
            {
                this.next = value;
            }
        }

        public double Number
        {
            get
            {
                return this.number;
            }
        }

        public NumberNode(double number)
        {
            this.number = number;
        }
    }
}
