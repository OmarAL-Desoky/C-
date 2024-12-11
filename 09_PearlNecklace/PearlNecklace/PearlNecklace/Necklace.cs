using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PearlNecklace
{
    public class Necklace
    {
        private Pearl head;

        public int Count
        {
            get
            {
                Pearl searcher = this.head;
                int counter = 0;

                while (searcher != null)
                {
                    counter++;
                    searcher = searcher.Next;
                }

                return counter;
            }
        }

        public double TotalWeight
        {
            get
            {
                Pearl searcher = this.head;
                double sumWeight = 0.0;

                while (searcher != null)
                {
                    sumWeight += searcher.Weight;
                    searcher = searcher.Next;
                }

                return sumWeight;
            }
        }

        public void AddPearl(Pearl pearl)
        {
            if(pearl != null && pearl.Weight > 0)
            {
                pearl.Next = this.head;
                this.head = pearl; 
            }
        }

        public int GetCountOfColoredPearls(string color)
        {
            Pearl searcher = this.head;
            int counter = 0;  

            while(searcher != null)
            {
                if (searcher.Color == color)
                {
                    counter++;
                }

                searcher = searcher.Next;
            }

            return counter;
        }

        public Pearl GetPearlAtPosition(int position)
        {
            Pearl searcher = this.head;
            Pearl result = null;

            if(position == 0)
            {
                result = this.head;
            }
            else
            {
                while (searcher != null && position != 0)
                {
                    searcher = searcher.Next;
                    position--;
                }
            }

            return searcher;
        }

        public void RemoveAllPearls()
        {
            head = null;
        }

        public Pearl RemovePearl()
        {
            Pearl result = null;

            if(this.head != null)
            {
                result = this.head;
                this.head = this.head.Next;
            }

            return result;
        }

        public override string ToString()
        {
            Pearl searcher = this.head;
            string result = $"";

            while (searcher != null)
            {
                result += $"({searcher.GetFirstLetter})";

                if(searcher.Next != null)
                {
                    result += "-";
                }

                searcher = searcher.Next;
            }

            return result;
        }
    }
}