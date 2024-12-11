using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diner.Test
{
    [TestClass]
    public class DishNodeTest
    {
        [TestMethod]
        public void TestConstructor()
        {
            Dish dish = new Dish("Spaghetti Carbonara", Course.Main, 10.20);

            DishNode node = new DishNode(dish);

            Assert.AreEqual(dish, node.Dish);
            Assert.AreEqual(null, node.Next);
        }

        [TestMethod]
        public void TestNext()
        {
            Dish dishBruschetta = new Dish("Bruschetta", Course.Entree, 3.50);
            Dish dishAntipasti = new Dish("Antipasti", Course.Entree, 5.90);

            DishNode node = new DishNode(dishBruschetta);
            DishNode nodeOther = new DishNode(dishAntipasti);

            Assert.AreEqual(dishBruschetta, node.Dish);
            Assert.AreEqual(null, node.Next);
            Assert.AreEqual(dishAntipasti, nodeOther.Dish);
            Assert.AreEqual(null, nodeOther.Next);

            node.Next = nodeOther;

            Assert.AreEqual(dishBruschetta, node.Dish);
            Assert.AreEqual(nodeOther, node.Next);
            Assert.AreEqual(dishAntipasti, nodeOther.Dish);
            Assert.AreEqual(null, nodeOther.Next);

            node.Next = null;

            Assert.AreEqual(dishBruschetta, node.Dish);
            Assert.AreEqual(null, node.Next);
            Assert.AreEqual(dishAntipasti, nodeOther.Dish);
            Assert.AreEqual(null, nodeOther.Next);
        }
    }
}
