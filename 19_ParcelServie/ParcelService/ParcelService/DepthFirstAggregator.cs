using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcelService 
{
    public class DepthFirstAggregator : IProductAggregator
    {
        public List<Product> GetAllProductsFromParcel(Parcel parcel)
        {
            List<Product> products = new List<Product>();

            for(int i = 0; i < parcel.Orderables.Count; i++)
            {
                if(parcel.Orderables[i] is Product p)
                {
                    products.Add(p);
                }

                if(parcel.Orderables[i] is Parcel pa)
                {
                    products.AddRange(GetAllProductsFromParcel(pa));
                }
            }

            return products;
        }
    }
}
