using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcelService
{
    public class BreadthFirstAggregator : IProductAggregator
    {
        public List<Product> GetAllProductsFromParcel(Parcel parcel)
        {
            List<Product> products = new List<Product>();
            Queue<Parcel> parcelList = new Queue<Parcel>();
            parcelList.Enqueue(parcel);

            while(parcelList.Count > 0)
            {
                Parcel curr = parcelList.Dequeue();
                
                foreach(IOrderable orderable in curr.Orderables)
                {
                    if(orderable is Product p)
                    {
                        products.Add(p);
                    }

                    if(orderable is Parcel pa)
                    {
                        parcelList.Enqueue(pa);
                    }
                }
            }

            return products;
        }
    }
}
