using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParcelServiceSA;

namespace ParcelService.Test
{
    [TestClass]
    public class ParcelTest
    {
        [TestMethod]
        public void TestInheritance()
        {
            Parcel parcel = new Parcel();

            Assert.AreEqual(true, parcel is IOrderable);
        }

        [TestMethod]
        public void TestEmptyParcelHasNoPriceAndMinimumWeight()
        {
            Parcel parcel = new Parcel();

            Assert.AreEqual(0, parcel.CalculatePrice(), 0.001);
            Assert.AreEqual(100, parcel.CalculateWeight());
        }

        [TestMethod]
        public void TestEmptyParcelToString()
        {
            Parcel parcel = new Parcel();

            Assert.AreEqual("Parcel (0.10kg) - 0.00$", parcel.ToString());
        }

        [TestMethod]
        public void TestEmptyParcelGetOrderables()
        {
            Parcel parcel = new Parcel();

            Assert.AreEqual(0, parcel.Orderables.Count);
        }

        [TestMethod]
        public void TestEmptyParcelContainsProduct()
        {
            Parcel parcel = new Parcel();

            Assert.AreEqual(false, parcel.ContainsProduct(254));
        }

        [TestMethod]
        public void TestParcelAddProductsChangesPriceAndWeight()
        {
            Parcel parcel = new Parcel();
            Product productA = new Product(254, "First Aid Kit", 12.99, 200);

            parcel.AddToParcel(productA);

            Assert.AreEqual(12.99, parcel.CalculatePrice(), 0.001);
            Assert.AreEqual(300, parcel.CalculateWeight());

            Product productB = new Product(379, "Silicone Baking Mat", 9.99, 100);

            parcel.AddToParcel(productB);

            Assert.AreEqual(22.98, parcel.CalculatePrice(), 0.001);
            Assert.AreEqual(400, parcel.CalculateWeight());
        }

        [TestMethod]
        public void TestParcelAddProductsChangesToString()
        {
            Parcel parcel = new Parcel();
            Product productA = new Product(254, "First Aid Kit", 12.99, 200);

            parcel.AddToParcel(productA);

            Assert.AreEqual("Parcel (0.30kg) - 12.99$", parcel.ToString());

            Product productB = new Product(379, "Silicone Baking Mat", 9.99, 100);

            parcel.AddToParcel(productB);

            Assert.AreEqual("Parcel (0.40kg) - 22.98$", parcel.ToString());
        }

        [TestMethod]
        public void TestParcelAddParcelsAndProductsChangesPriceAndWeight()
        {
            Parcel parcel = new Parcel();

            Product productA = new Product(254, "First Aid Kit", 12.99, 200);
            Product productB = new Product(379, "Silicone Baking Mat", 9.99, 100);
            Parcel parcelA = new Parcel();
            parcelA.AddToParcel(productA);
            parcelA.AddToParcel(productB);

            parcel.AddToParcel(parcelA);

            Assert.AreEqual(22.98, parcel.CalculatePrice(), 0.001);
            Assert.AreEqual(500, parcel.CalculateWeight());

            Product productC = new Product(623, "Pocket Knife", 18.99, 200);
            Product productD = new Product(359, "Fitness Tracker", 59.99, 300);
            Parcel parcelB = new Parcel();
            parcelB.AddToParcel(productC);
            parcelB.AddToParcel(productD);

            parcel.AddToParcel(parcelB);

            Assert.AreEqual(101.96, parcel.CalculatePrice(), 0.001);
            Assert.AreEqual(1100, parcel.CalculateWeight());

            Product productE = new Product(312, "Earbuds", 45.99, 100);

            parcel.AddToParcel(productE);

            Assert.AreEqual(147.95, parcel.CalculatePrice(), 0.001);
            Assert.AreEqual(1200, parcel.CalculateWeight());
        }

        [TestMethod]
        public void TestParcelAddParcelsAndProductsChangesToString()
        {
            Parcel parcel = new Parcel();

            Product productA = new Product(254, "First Aid Kit", 12.99, 200);
            Product productB = new Product(379, "Silicone Baking Mat", 9.99, 100);
            Parcel parcelA = new Parcel();
            parcelA.AddToParcel(productA);
            parcelA.AddToParcel(productB);

            parcel.AddToParcel(parcelA);

            Assert.AreEqual("Parcel (0.50kg) - 22.98$", parcel.ToString());

            Product productC = new Product(623, "Pocket Knife", 18.99, 200);
            Product productD = new Product(359, "Fitness Tracker", 59.99, 300);
            Parcel parcelB = new Parcel();
            parcelB.AddToParcel(productC);
            parcelB.AddToParcel(productD);

            parcel.AddToParcel(parcelB);

            Assert.AreEqual("Parcel (1.10kg) - 101.96$", parcel.ToString());

            Product productE = new Product(312, "Earbuds", 45.99, 100);

            parcel.AddToParcel(productE);

            Assert.AreEqual("Parcel (1.20kg) - 147.95$", parcel.ToString());
        }

        [TestMethod]
        public void TestGetOrderables()
        {
            Parcel parcel = new Parcel();

            Product productA = new Product(254, "First Aid Kit", 12.99, 200);
            Product productB = new Product(379, "Silicone Baking Mat", 9.99, 100);
            Parcel parcelA = new Parcel();
            parcelA.AddToParcel(productA);
            parcelA.AddToParcel(productB);

            List<IOrderable> orderables = parcelA.Orderables;

            Assert.AreEqual(2, orderables.Count);
            Assert.AreEqual(productA, orderables[0]);
            Assert.AreEqual(productB, orderables[1]);

            parcel.AddToParcel(parcelA);

            orderables = parcel.Orderables;

            Assert.AreEqual(1, orderables.Count);
            Assert.AreEqual(parcelA, orderables[0]);

            Product productC = new Product(623, "Pocket Knife", 18.99, 200);
            Product productD = new Product(359, "Fitness Tracker", 59.99, 300);
            Parcel parcelB = new Parcel();
            parcelB.AddToParcel(productC);
            parcelB.AddToParcel(productD);

            orderables = parcelB.Orderables;

            Assert.AreEqual(2, orderables.Count);
            Assert.AreEqual(productC, orderables[0]);
            Assert.AreEqual(productD, orderables[1]);

            parcel.AddToParcel(parcelB);

            orderables = parcel.Orderables;

            Assert.AreEqual(2, orderables.Count);
            Assert.AreEqual(parcelA, orderables[0]);
            Assert.AreEqual(parcelB, orderables[1]);

            Product productE = new Product(312, "Earbuds", 45.99, 100);

            parcel.AddToParcel(productE);

            orderables = parcel.Orderables;

            Assert.AreEqual(3, orderables.Count);
            Assert.AreEqual(parcelA, orderables[0]);
            Assert.AreEqual(parcelB, orderables[1]);
            Assert.AreEqual(productE, orderables[2]);
        }

        [TestMethod]
        public void TestGetOrderablesReturnsClone()
        {
            Parcel parcel = new Parcel();
            Product productA = new Product(254, "First Aid Kit", 12.99, 200);
            parcel.AddToParcel(productA);

            List<IOrderable> orderables = parcel.Orderables;
            orderables.Clear();

            Assert.AreEqual(1, parcel.Orderables.Count);
        }

        [TestMethod]
        public void TestContainsProduct()
        {
            Parcel parcel = new Parcel();

            Product productA = new Product(254, "First Aid Kit", 12.99, 200);
            Product productB = new Product(379, "Silicone Baking Mat", 9.99, 100);
            Parcel parcelA = new Parcel();
            parcelA.AddToParcel(productA);
            parcelA.AddToParcel(productB);

            parcel.AddToParcel(parcelA);

            Assert.AreEqual(true, parcel.ContainsProduct(254)); //Product A
            Assert.AreEqual(true, parcel.ContainsProduct(379)); //Product B
            Assert.AreEqual(false, parcel.ContainsProduct(623)); //Product C
            Assert.AreEqual(false, parcel.ContainsProduct(359)); //Product D
            Assert.AreEqual(false, parcel.ContainsProduct(312)); //Product E

            Assert.AreEqual(true, parcelA.ContainsProduct(254)); //Product A
            Assert.AreEqual(true, parcelA.ContainsProduct(379)); //Product B
            Assert.AreEqual(false, parcelA.ContainsProduct(623)); //Product C
            Assert.AreEqual(false, parcelA.ContainsProduct(359)); //Product D
            Assert.AreEqual(false, parcelA.ContainsProduct(312)); //Product E

            Product productC = new Product(623, "Pocket Knife", 18.99, 200);
            Product productD = new Product(359, "Fitness Tracker", 59.99, 300);
            Parcel parcelB = new Parcel();
            parcelB.AddToParcel(productC);
            parcelB.AddToParcel(productD);

            parcel.AddToParcel(parcelB);

            Assert.AreEqual(true, parcel.ContainsProduct(254)); //Product A
            Assert.AreEqual(true, parcel.ContainsProduct(379)); //Product B
            Assert.AreEqual(true, parcel.ContainsProduct(623)); //Product C
            Assert.AreEqual(true, parcel.ContainsProduct(359)); //Product D
            Assert.AreEqual(false, parcel.ContainsProduct(312)); //Product E

            Assert.AreEqual(true, parcelA.ContainsProduct(254)); //Product A
            Assert.AreEqual(true, parcelA.ContainsProduct(379)); //Product B
            Assert.AreEqual(false, parcelA.ContainsProduct(623)); //Product C
            Assert.AreEqual(false, parcelA.ContainsProduct(359)); //Product D
            Assert.AreEqual(false, parcelA.ContainsProduct(312)); //Product E

            Assert.AreEqual(false, parcelB.ContainsProduct(254)); //Product A
            Assert.AreEqual(false, parcelB.ContainsProduct(379)); //Product B
            Assert.AreEqual(true, parcelB.ContainsProduct(623)); //Product C
            Assert.AreEqual(true, parcelB.ContainsProduct(359)); //Product D
            Assert.AreEqual(false, parcelB.ContainsProduct(312)); //Product E

            Product productE = new Product(312, "Earbuds", 45.99, 100);

            parcel.AddToParcel(productE);

            Assert.AreEqual(true, parcel.ContainsProduct(254)); //Product A
            Assert.AreEqual(true, parcel.ContainsProduct(379)); //Product B
            Assert.AreEqual(true, parcel.ContainsProduct(623)); //Product C
            Assert.AreEqual(true, parcel.ContainsProduct(359)); //Product D
            Assert.AreEqual(true, parcel.ContainsProduct(312)); //Product E

            Assert.AreEqual(true, parcelA.ContainsProduct(254)); //Product A
            Assert.AreEqual(true, parcelA.ContainsProduct(379)); //Product B
            Assert.AreEqual(false, parcelA.ContainsProduct(623)); //Product C
            Assert.AreEqual(false, parcelA.ContainsProduct(359)); //Product D
            Assert.AreEqual(false, parcelA.ContainsProduct(312)); //Product E

            Assert.AreEqual(false, parcelB.ContainsProduct(254)); //Product A
            Assert.AreEqual(false, parcelB.ContainsProduct(379)); //Product B
            Assert.AreEqual(true, parcelB.ContainsProduct(623)); //Product C
            Assert.AreEqual(true, parcelB.ContainsProduct(359)); //Product D
            Assert.AreEqual(false, parcelB.ContainsProduct(312)); //Product E
        }

        [TestMethod]
        public void TestContainsProductInDeepParcel()
        {
            Parcel parcel = new Parcel();

            Assert.AreEqual(false, parcel.ContainsProduct(254));

            Parcel parcelA = new Parcel();
            parcel.AddToParcel(parcelA);
            Parcel parcelB = new Parcel();
            parcelA.AddToParcel(parcelB);
            Parcel parcelC = new Parcel();
            parcelB.AddToParcel(parcelC);
            Parcel parcelD = new Parcel();
            parcelC.AddToParcel(parcelD);

            parcelD.AddToParcel(new Product(254, "First Aid Kit", 12.99, 200));

            Assert.AreEqual(true, parcel.ContainsProduct(254));
        }

        [TestMethod]
        public void TestComparable()
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

            parcels.Sort();

            Assert.AreEqual(parcelB, parcels[0]);
            Assert.AreEqual(parcelA, parcels[1]);
            Assert.AreEqual(parcelC, parcels[2]);
            Assert.AreEqual(parcelD, parcels[3]);
        }
    }
}
