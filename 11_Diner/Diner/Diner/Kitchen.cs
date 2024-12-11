using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diner
{
    public class Kitchen
    {
        private DishNode head;
        private double revenue;

        public double Revenue
        {
            get
            {
                return this.revenue;
            }
        }

        public Dish DishInPreparation
        {
            get
            {
                Dish result = null;

                if(this.head != null)
                {
                    result = this.head.Dish;
                }

                return result;
            }
        }

        public int OpenOrderCount
        {
            get
            {
                DishNode searcher = this.head;
                int count = 0;

                while (searcher != null)
                {
                    count++;
                    searcher = searcher.Next;
                }

                return count;
            }
        }

        public void Order(Dish dish)
        {
            DishNode dishNode = new DishNode(dish);

            if (this.head == null)
            {
                this.head = dishNode;
            }
            else
            {
                DishNode searcher = this.head;

                if (dish.Course < searcher.Dish.Course)
                {
                    dishNode.Next = searcher;
                    this.head = dishNode;
                }
                else
                {
                    while (searcher.Next != null && searcher.Next.Dish.Course <= dishNode.Dish.Course)
                    {
                        searcher = searcher.Next;
                    }

                    dishNode.Next = searcher.Next;
                    searcher.Next = dishNode;
                }
            }
        }

        public Dish Serve()
        {
            Dish result = null;

            if (this.head != null)
            {
                this.revenue += head.Dish.Price;
                result = this.head.Dish;

                this.head = this.head.Next;
            }

            return result;
        }
    }
}
