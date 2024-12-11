using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcelService.Test
{
    [TestClass]
    public class ParcelPriceComparerTest
    {
        [TestMethod]
        public void TestComparator()
        {
            Parcel parcelA = new Parcel();
            Parcel parcelB = new Parcel();
            Parcel parcelC = new Parcel();
            Parcel parcelD = new Parcel();

            parcelA.AddToParcel(new Product(254, "First Aid Kit", 12.99, 200));
            parcelA.AddToParcel(new Product(379, "Silicone Baking Mat", 9.99, 100));

            parcelB.AddToParcel(new Product(623, "Pocket Knife", 18.99, 200));
            parcelB.AddToParcel(new Product(359, "Fitness Tracker", 59.99, 300));

            parcelC.AddToParcel(new Product(312, "Earbuds", 45.99, 100));

            List<Parcel> parcels = new List<Parcel>();
            parcels.Add(parcelA);
            parcels.Add(parcelB);
            parcels.Add(parcelC);
            parcels.Add(parcelD);

            Random rng = new Random();
            parcels = parcels.OrderBy(_ => rng.Next()).ToList();

            parcels.Sort(new ParcelPriceComparer());

            Assert.AreEqual(parcelD, parcels[0]);
            Assert.AreEqual(parcelA, parcels[1]);
            Assert.AreEqual(parcelC, parcels[2]);
            Assert.AreEqual(parcelB, parcels[3]);
        }
    }
}
