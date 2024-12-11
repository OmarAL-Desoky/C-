using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soccer
{
    public class MyNode<T>
    {
        private MyNode<T> next;
        private T data;

        public MyNode<T> Next
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

        public T Data
        {
            get
            {
                return this.data;
            }
        }

        public MyNode(T data)
        {
            this.data = data;
        }
    }
}
