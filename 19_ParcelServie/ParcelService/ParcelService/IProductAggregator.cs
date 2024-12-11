using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcelService
{
    public interface IProductAggregator
    {
        List<Product> GetAllProductsFromParcel(Parcel parcel);
    }
}
