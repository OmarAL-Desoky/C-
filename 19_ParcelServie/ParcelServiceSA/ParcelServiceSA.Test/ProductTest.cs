using static System.Net.Mime.MediaTypeNames;
using ParcelServiceSA;

namespace ParcelService.Test
{
    [TestClass]
    public class ProductTest
    {
        [TestInitialize()]
        public void StartUp()
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
        }

        [TestMethod]
        public void TestInheritance()
        {
            Product product = new Product(254, "First Aid Kit", 12.99, 200);

            Assert.AreEqual(true, product is IOrderable);
        }

        [TestMethod]
        public void TestConstructorWithValidValues()
        {
            Product product = new Product(254, "First Aid Kit", 12.99, 200);

            Assert.AreEqual(254, product.Id);
            Assert.AreEqual("First Aid Kit", product.Name);
            Assert.AreEqual(12.99, product.Price, 0.001);
            Assert.AreEqual(200, product.Weight);
        }

        [TestMethod]
        public void TestConstructorWithIdTooLow()
        {
            ArgumentException e = Assert.ThrowsException<ArgumentException>(() =>
            {
                Product product = new Product(99, "First Aid Kit", 12.99, 200);
            });

            Assert.AreEqual("Id must be exactly three digits long!", e.Message);
        }

        [TestMethod]
        public void TestConstructorWithIdTooLarge()
        {
            ArgumentException e = Assert.ThrowsException<ArgumentException>(() =>
            {
                Product product = new Product(1000, "First Aid Kit", 12.99, 200);
            });

            Assert.AreEqual("Id must be exactly three digits long!", e.Message);
        }

        [TestMethod]
        public void TestConstructorWithPriceTooLow()
        {
            ArgumentException e = Assert.ThrowsException<ArgumentException>(() =>
            {
                Product product = new Product(254, "First Aid Kit", -0.01, 200);
            });

            Assert.AreEqual("Price must not be negative!", e.Message);
        }

        [TestMethod]
        public void TestConstructorWithWeightTooLow()
        {
            ArgumentException e = Assert.ThrowsException<ArgumentException>(() =>
            {
                Product product = new Product(254, "First Aid Kit", 12.99, 0);
            });

            Assert.AreEqual("Weight must be at least 1 gram!", e.Message);
        }

        [TestMethod]
        public void TestConstructorWithEmptyName()
        {
            ArgumentException e = Assert.ThrowsException<ArgumentException>(() =>
            {
                Product product = new Product(254, "", 12.99, 200);
            });

            Assert.AreEqual("Name must not be null or empty!", e.Message);
        }

        [TestMethod]
        public void TestConstructorWithNullName()
        {
            ArgumentException e = Assert.ThrowsException<ArgumentException>(() =>
            {
                Product product = new Product(254, null, 12.99, 200);
            });

            Assert.AreEqual("Name must not be null or empty!", e.Message);
        }

        [TestMethod]
        public void TestEquality()
        {
            Product productA = new Product(254, "First Aid Kit", 12.99, 200);
            Product productB = new Product(254, "Second Aid Kit", 13.99, 400);
            Product productC = new Product(255, "First Aid Kit", 12.99, 200);

            Assert.AreEqual(true, productA.Equals(productA));
            Assert.AreEqual(true, productA.Equals(productB));
            Assert.AreEqual(false, productA.Equals(productC));
            Assert.AreEqual(false, productB.Equals(productC));
        }

        [TestMethod]
        public void TestCalculatePrice()
        {
            Product product = new Product(254, "First Aid Kit", 12.99, 200);

            Assert.AreEqual(12.99, product.CalculatePrice(), 0.001);
        }

        [TestMethod]
        public void TestCalculateWeight()
        {
            Product product = new Product(254, "First Aid Kit", 12.99, 200);

            Assert.AreEqual(200, product.CalculateWeight());
        }

        [TestMethod]
        public void TestToString()
        {
            Product product = new Product(254, "First Aid Kit", 12.99, 200);

            Assert.AreEqual("#254 First Aid Kit (0.20kg) - 12.99$", product.ToString());
        }
    }
}