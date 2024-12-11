using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diner
{
    public class DishNode
    {
        private DishNode next;
        private Dish dish;

        public DishNode Next
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

        public Dish Dish
        {
            get
            {
                return this.dish;
            }
        }

        public DishNode(Dish dish) 
        {
            this.dish = dish;
        }
    }
}
