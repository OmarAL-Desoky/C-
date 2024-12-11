using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soccer
{
    public class MySet<T>
    {
        private MyNode<T> head;

        public int Count
        {
            get
            {
                int count = 0;

                MyNode<T> searcher = this.head;

                while(searcher != null)
                {
                    count++;
                    searcher = searcher.Next;
                }

                return count;
            }
        }

        public bool Add(T nodeToAdd)
        {
            bool addedNode = false;
            MyNode<T> myNodeToAdd = new MyNode<T>(nodeToAdd);

            if(this.head == null)
            {
                this.head = myNodeToAdd;
                addedNode = true;
            }
            else
            {
                if(!Contains(nodeToAdd))
                {
                    MyNode<T> searcher = this.head;

                    while (searcher.Next != null)
                    {
                        searcher = searcher.Next;
                    }

                    searcher.Next = myNodeToAdd;
                    addedNode = true;
                }
            }

            return addedNode;
        }

        public bool Contains(T nodeToCheck)
        {
            bool containsNode = false;

            MyNode<T> searcher = this.head;

            while (searcher != null && !containsNode)
            {
                if(searcher.Data.Equals(nodeToCheck))
                {
                    containsNode = true;
                }

                searcher = searcher.Next;
            }

            return containsNode;
        }

        public bool Remove(T nodeToRemove)
        {
            bool removedNode = false;

            if(this.head != null)
            {
                MyNode<T> searcher = this.head;

                if (this.head.Data.Equals(nodeToRemove))
                {
                    this.head = this.head.Next;
                    removedNode = true;
                }
                else
                {
                    while (searcher.Next != null && !searcher.Next.Data.Equals(nodeToRemove))
                    {
                        searcher = searcher.Next;
                    }

                    if (searcher.Next != null)
                    {
                        searcher.Next = searcher.Next.Next;
                        removedNode = true;
                    }
                }
            }

            return removedNode;
        } 

        public bool IsSubsetOf(MySet<T> mySet)
        {
            bool isSubset = true;
            return isSubset;
        }

        public bool IsSupersetOf(MySet<T> mySet)
        {
            bool isSuperset = true;

            MyNode<T> searcherOfSmallSet = mySet.head;
            MyNode<T> searcherOfBigSet = this.head;

            while (searcherOfSmallSet != null && !isSuperset)
            {
                if (!Contains(searcherOfBigSet.Data))
                {
                    isSuperset = false;
                }

                searcherOfBigSet = searcherOfBigSet.Next;
                searcherOfSmallSet = searcherOfSmallSet.Next;
            }

            return isSuperset;
        }
    }
}
