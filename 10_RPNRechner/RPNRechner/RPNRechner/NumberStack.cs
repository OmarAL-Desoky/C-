using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPNRechner
{
    public class NumberStack
    {
        private NumberNode head;

        public bool IsEmpty
        {
            get
            { 
                return this.head == null;
            }
        }

        public void Push(double number)
        {
            NumberNode result = new NumberNode(number);
            result.Next = this.head;
            this.head = result;
        }

        public double Pop()
        {
            double number = Peek();
            this.head = this.head.Next;

            return number;
        }

        public double Peek()
        {
            if (this.IsEmpty)
            {
                throw new InvalidOperationException("There are no elements in the stack!");
            }

            return this.head.Number;
        }
    }
}
