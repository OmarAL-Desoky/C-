using Diner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Diner.Test
{
    [TestClass]
    public class DishTest
    {
        [TestMethod]
        public void TestConstructorEntree()
        {
            Dish dish = new Dish("Bruschetta", Course.Entree, 3.50);

            Assert.AreEqual("Bruschetta", dish.Name);
            Assert.AreEqual(Course.Entree, dish.Course);
            Assert.AreEqual(3.5, dish.Price, 0.0001);
        }

        [TestMethod]
        public void TestConstructorMainDish()
        {
            Dish dish = new Dish("Spaghetti Carbonara", Course.Main, 10.20);

            Assert.AreEqual("Spaghetti Carbonara", dish.Name);
            Assert.AreEqual(Course.Main, dish.Course);
            Assert.AreEqual(10.2, dish.Price, 0.0001);
        }

        [TestMethod]
        public void TestConstructorDessert()
        {
            Dish dish = new Dish("Tiramisu", Course.Dessert, 4.3);

            Assert.AreEqual("Tiramisu", dish.Name);
            Assert.AreEqual(Course.Dessert, dish.Course);
            Assert.AreEqual(4.3, dish.Price, 0.0001);
        }

        [TestMethod]
        public void TestConstructorWithPriceZero()
        {
            ArgumentException ex = Assert.ThrowsException<ArgumentException>(() =>
            {
                Dish dish = new Dish("Spaghetti Carbonara", Course.Main, 0.0);
            });

            Assert.AreEqual("Price must be greater than 0!", ex.Message);
        }

        [TestMethod]
        public void TestConstructorWithNegativePrice()
        {
            ArgumentException ex = Assert.ThrowsException<ArgumentException>(() =>
            {
                Dish dish = new Dish("Bruschetta", Course.Entree, -3.50);
            });

            Assert.AreEqual("Price must be greater than 0!", ex.Message);
        }

        [TestMethod]
        public void TestConstructorWithNameNull()
        {
            ArgumentException ex = Assert.ThrowsException<ArgumentException>(() =>
            {
                Dish dish = new Dish(null, Course.Dessert, 4.3);
            });

            Assert.AreEqual("Name must not be null or empty!", ex.Message);
        }

        [TestMethod]
        public void TestConstructorWithEmptyName()
        {
            ArgumentException ex = Assert.ThrowsException<ArgumentException>(() =>
            {
                Dish dish = new Dish("", Course.Main, 10.20);
            });

            Assert.AreEqual("Name must not be null or empty!", ex.Message);
        }
    }
}
