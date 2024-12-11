using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcelService.Test
{
    [TestClass]
    public class IProductAggregatorTest
    {
        [TestMethod]
    public void TestBreadthFirstWithEmptyParcel()
        {
            IProductAggregator productAggregator = new BreadthFirstAggregator();

            Parcel parcel = new Parcel();

            List<Product> products = productAggregator.GetAllProductsFromParcel(parcel);

            Assert.AreEqual(0, products.Count);
        }

        [TestMethod]
    public void TestBreadthFirstWithShallowParcel()
        {
            IProductAggregator productAggregator = new BreadthFirstAggregator();

            Parcel parcel = new Parcel();
            Product productA = new Product(254, "First Aid Kit", 12.99, 200);
            parcel.AddToParcel(productA);
            Product productB = new Product(379, "Silicone Baking Mat", 9.99, 100);
            parcel.AddToParcel(productB);

            List<Product> products = productAggregator.GetAllProductsFromParcel(parcel);

            Assert.AreEqual(2, products.Count);
            Assert.AreEqual(productA, products[0]);
            Assert.AreEqual(productB, products[1]);
        }

        [TestMethod]
    public void TestBreadthFirstWithNestedParcel()
        {
            IProductAggregator productAggregator = new BreadthFirstAggregator();

            Parcel parcel = new Parcel();

            Parcel parcelA = new Parcel();
            Product productA = new Product(482, "Water Bottle", 13.99, 300);
            parcelA.AddToParcel(productA);
            Product productB = new Product(719, "Travel Pillow", 19.99, 600);
            parcelA.AddToParcel(productB);
            parcel.AddToParcel(parcelA);

            Product productC = new Product(631, "Yoga Mat", 29.99, 1000);
            parcel.AddToParcel(productC);

            Parcel parcelB = new Parcel();
            Product productD = new Product(758, "Bluetooth Speaker", 39.99, 750);
            parcelB.AddToParcel(productD);
            Product productE = new Product(526, "Resistance Bands", 24.99, 500);
            parcelB.AddToParcel(productE);
            Product productF = new Product(193, "Kitchen Scale", 12.99, 300);
            parcelB.AddToParcel(productF);
            parcel.AddToParcel(parcelB);

            Parcel parcelC = new Parcel();
            parcel.AddToParcel(parcelC);

            Parcel parcelCA = new Parcel();
            Product productG = new Product(312, "Earbuds", 45.99, 100);
            parcelCA.AddToParcel(productG);
            parcelC.AddToParcel(parcelCA);

            Parcel parcelCAA = new Parcel();
            Product productH = new Product(254, "First Aid Kit", 12.99, 200);
            parcelCAA.AddToParcel(productH);
            Product productI = new Product(379, "Silicone Baking Mat", 9.99, 100);
            parcelCAA.AddToParcel(productI);
            parcelCA.AddToParcel(parcelCAA);

            Parcel parcelCB = new Parcel();
            Product productJ = new Product(623, "Pocket Knife", 18.99, 200);
            parcelCB.AddToParcel(productJ);
            Product productK = new Product(359, "Fitness Tracker", 59.99, 300);
            parcelCB.AddToParcel(productK);
            parcelC.AddToParcel(parcelCB);

            //Parcel (5.05kg) - 289.89$
            //    +---Parcel (1.00kg) - 33.98$ //Added to queue - First Parcel
            //        +---#482 Water Bottle (0.30kg) - 13.99$ //Second Product
            //        +---#719 Travel Pillow (0.60kg) - 19.99$ //Third Product
            //    +---#631 Yoga Mat (1.00kg) - 29.99$ //First Product
            //    +---Parcel (1.65kg) - 77.97$ //Added to queue - Second Parcel
            //        +---#758 Bluetooth Speaker (0.75kg) - 39.99$ //Fourth Product
            //        +---#526 Resistance Bands (0.50kg) - 24.99$ //Fifth Product
            //        +---#193 Kitchen Scale (0.30kg) - 12.99$ //Sixth Product
            //    +---Parcel (1.30kg) - 147.95$ //Added to queue - Third Parcel
            //        +---Parcel (0.60kg) - 68.97$ //Added to queue - Fourth Parcel
            //            +---#312 Earbuds (0.10kg) - 45.99$ //Seventh Product
            //            +---Parcel (0.40kg) - 22.98$ //Added to queue - Sixth Parcel
            //                +---#254 First Aid Kit (0.20kg) - 12.99$ //Tenth Product
            //                +---#379 Silicone Baking Mat (0.10kg) - 9.99$ //Eleventh Product
            //        +---Parcel (0.60kg) - 78.98$ //Added to queue - Fifth Parcel
            //            +---#623 Pocket Knife (0.20kg) - 18.99$ //Eighth Product
            //            +---#359 Fitness Tracker (0.30kg) - 59.99$ //Ninth Product

            List<Product> products = productAggregator.GetAllProductsFromParcel(parcel);
            Assert.AreEqual(11, products.Count);
            Assert.AreEqual(productC, products[0]);
            Assert.AreEqual(productA, products[1]);
            Assert.AreEqual(productB, products[2]);
            Assert.AreEqual(productD, products[3]);
            Assert.AreEqual(productE, products[4]);
            Assert.AreEqual(productF, products[5]);
            Assert.AreEqual(productG, products[6]);
            Assert.AreEqual(productJ, products[7]);
            Assert.AreEqual(productK, products[8]);
            Assert.AreEqual(productH, products[9]);
            Assert.AreEqual(productI, products[10]);
        }

        [TestMethod]
    public void TestDepthFirstWithEmptyParcel()
        {
            IProductAggregator productAggregator = new DepthFirstAggregator();

            Parcel parcel = new Parcel();

            List<Product> products = productAggregator.GetAllProductsFromParcel(parcel);

            Assert.AreEqual(0, products.Count);
        }

        [TestMethod]
    public void TestDepthFirstWithShallowParcel()
        {
            IProductAggregator productAggregator = new DepthFirstAggregator();

            Parcel parcel = new Parcel();
            Product productA = new Product(254, "First Aid Kit", 12.99, 200);
            parcel.AddToParcel(productA);
            Product productB = new Product(379, "Silicone Baking Mat", 9.99, 100);
            parcel.AddToParcel(productB);

            List<Product> products = productAggregator.GetAllProductsFromParcel(parcel);

            Assert.AreEqual(2, products.Count);
            Assert.AreEqual(productA, products[0]);
            Assert.AreEqual(productB, products[1]);
        }

        [TestMethod]
    public void TestDepthFirstWithNestedParcel()
        {
            IProductAggregator productAggregator = new DepthFirstAggregator();

            Parcel parcel = new Parcel();

            Parcel parcelA = new Parcel();
            Product productA = new Product(482, "Water Bottle", 13.99, 300);
            parcelA.AddToParcel(productA);
            Product productB = new Product(719, "Travel Pillow", 19.99, 600);
            parcelA.AddToParcel(productB);
            parcel.AddToParcel(parcelA);

            Product productC = new Product(631, "Yoga Mat", 29.99, 1000);
            parcel.AddToParcel(productC);

            Parcel parcelB = new Parcel();
            Product productD = new Product(758, "Bluetooth Speaker", 39.99, 750);
            parcelB.AddToParcel(productD);
            Product productE = new Product(526, "Resistance Bands", 24.99, 500);
            parcelB.AddToParcel(productE);
            Product productF = new Product(193, "Kitchen Scale", 12.99, 300);
            parcelB.AddToParcel(productF);
            parcel.AddToParcel(parcelB);

            Parcel parcelC = new Parcel();
            parcel.AddToParcel(parcelC);

            Parcel parcelCA = new Parcel();
            Product productG = new Product(312, "Earbuds", 45.99, 100);
            parcelCA.AddToParcel(productG);
            parcelC.AddToParcel(parcelCA);

            Parcel parcelCAA = new Parcel();
            Product productH = new Product(254, "First Aid Kit", 12.99, 200);
            parcelCAA.AddToParcel(productH);
            Product productI = new Product(379, "Silicone Baking Mat", 9.99, 100);
            parcelCAA.AddToParcel(productI);
            parcelCA.AddToParcel(parcelCAA);

            Parcel parcelCB = new Parcel();
            Product productJ = new Product(623, "Pocket Knife", 18.99, 200);
            parcelCB.AddToParcel(productJ);
            Product productK = new Product(359, "Fitness Tracker", 59.99, 300);
            parcelCB.AddToParcel(productK);
            parcelC.AddToParcel(parcelCB);

            //Parcel (5.05kg) - 289.89$
            //    +---Parcel (1.00kg) - 33.98$ //First Parcel
            //        +---#482 Water Bottle (0.30kg) - 13.99$ //First Product
            //        +---#719 Travel Pillow (0.60kg) - 19.99$ //Second Product
            //    +---#631 Yoga Mat (1.00kg) - 29.99$ //Third Product
            //    +---Parcel (1.65kg) - 77.97$ //Second Parcel
            //        +---#758 Bluetooth Speaker (0.75kg) - 39.99$ //Fourth Product
            //        +---#526 Resistance Bands (0.50kg) - 24.99$ //Fifth Product
            //        +---#193 Kitchen Scale (0.30kg) - 12.99$ //Sixth Product
            //    +---Parcel (1.30kg) - 147.95$ //Third Parcel
            //        +---Parcel (0.60kg) - 68.97$ //Fourth Parcel
            //            +---#312 Earbuds (0.10kg) - 45.99$ //Seventh Product
            //            +---Parcel (0.40kg) - 22.98$ //Sixth Parcel
            //                +---#254 First Aid Kit (0.20kg) - 12.99$ //Eighth Product
            //                +---#379 Silicone Baking Mat (0.10kg) - 9.99$ //Ninth Product
            //        +---Parcel (0.60kg) - 78.98$ //Seventh Parcel
            //            +---#623 Pocket Knife (0.20kg) - 18.99$ //Tenth Product
            //            +---#359 Fitness Tracker (0.30kg) - 59.99$ //Eleventh Product

            List<Product> products = productAggregator.GetAllProductsFromParcel(parcel);
            Assert.AreEqual(11, products.Count);
            Assert.AreEqual(productA, products[0]);
            Assert.AreEqual(productB, products[1]);
            Assert.AreEqual(productC, products[2]);
            Assert.AreEqual(productD, products[3]);
            Assert.AreEqual(productE, products[4]);
            Assert.AreEqual(productF, products[5]);
            Assert.AreEqual(productG, products[6]);
            Assert.AreEqual(productH, products[7]);
            Assert.AreEqual(productI, products[8]);
            Assert.AreEqual(productJ, products[9]);
            Assert.AreEqual(productK, products[10]);
        }
    }
}
