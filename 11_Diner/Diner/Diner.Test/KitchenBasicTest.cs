using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diner.Test
{
    [TestClass]
    public class KitchenBasicTest
    {
        [TestMethod]
        public void TestNoOrders()
        {
            Kitchen kitchen = new Kitchen();

            Assert.AreEqual(0, kitchen.OpenOrderCount);
            Assert.AreEqual(0.0, kitchen.Revenue, 0.0001);
            Assert.AreEqual(null, kitchen.DishInPreparation);
            Assert.AreEqual(null, kitchen.Serve());
        }

        [TestMethod]
        public void TestOrderOneDish()
        {
            Kitchen kitchen = new Kitchen();

            Assert.AreEqual(0, kitchen.OpenOrderCount);
            Assert.AreEqual(0.0, kitchen.Revenue, 0.0001);
            Assert.AreEqual(null, kitchen.DishInPreparation);

            Dish dishCarbonara = new Dish("Spaghetti Carbonara", Course.Main, 10.20);
            kitchen.Order(dishCarbonara);

            Assert.AreEqual(1, kitchen.OpenOrderCount);
            Assert.AreEqual(0.0, kitchen.Revenue, 0.0001);
            Assert.AreEqual(dishCarbonara, kitchen.DishInPreparation);

            Dish dish = kitchen.Serve();

            Assert.AreEqual(dishCarbonara, dish);
            Assert.AreEqual(0, kitchen.OpenOrderCount);
            Assert.AreEqual(10.2, kitchen.Revenue, 0.0001);
            Assert.AreEqual(null, kitchen.DishInPreparation);

            dish = kitchen.Serve();

            Assert.AreEqual(null, dish);
            Assert.AreEqual(0, kitchen.OpenOrderCount);
            Assert.AreEqual(10.2, kitchen.Revenue, 0.0001);
            Assert.AreEqual(null, kitchen.DishInPreparation);
        }

        [TestMethod]
        public void TestOrderServeMultipleDishes()
        {
            Kitchen kitchen = new Kitchen();

            Assert.AreEqual(0, kitchen.OpenOrderCount);
            Assert.AreEqual(0.0, kitchen.Revenue, 0.0001);
            Assert.AreEqual(null, kitchen.DishInPreparation);

            Dish dishPorcini = new Dish("Pizza Porcini", Course.Main, 11);
            kitchen.Order(dishPorcini); //Porcini

            Assert.AreEqual(1, kitchen.OpenOrderCount);
            Assert.AreEqual(0.0, kitchen.Revenue, 0.0001);
            Assert.AreEqual(dishPorcini, kitchen.DishInPreparation);

            Dish dishPuttanesca = new Dish("Spaghetti Alla Puttanesca", Course.Main, 10.40);
            kitchen.Order(dishPuttanesca); //Porcini - Puttanesca

            Assert.AreEqual(2, kitchen.OpenOrderCount);
            Assert.AreEqual(0.0, kitchen.Revenue, 0.0001);
            Assert.AreEqual(dishPorcini, kitchen.DishInPreparation);

            Dish dishCarrettiera = new Dish("Spaghetti Alla Carrettiera", Course.Main, 8.90);
            kitchen.Order(dishCarrettiera); //Porcini - Puttanesca - Carrettiera

            Assert.AreEqual(3, kitchen.OpenOrderCount);
            Assert.AreEqual(0.0, kitchen.Revenue, 0.0001);
            Assert.AreEqual(dishPorcini, kitchen.DishInPreparation);

            Dish dishMareMonti = new Dish("Pizza Mare E Monti", Course.Main, 12.50);
            kitchen.Order(dishMareMonti); //Porcini - Puttanesca - Carrettiera - MareMonti

            Assert.AreEqual(4, kitchen.OpenOrderCount);
            Assert.AreEqual(0.0, kitchen.Revenue, 0.0001);
            Assert.AreEqual(dishPorcini, kitchen.DishInPreparation);

            Dish dish = kitchen.Serve(); //Porcini | Puttanesca - Carrettiera - MareMonti

            Assert.AreEqual(dishPorcini, dish);
            Assert.AreEqual(3, kitchen.OpenOrderCount);
            Assert.AreEqual(11.0, kitchen.Revenue, 0.0001);
            Assert.AreEqual(dishPuttanesca, kitchen.DishInPreparation);

            dish = kitchen.Serve(); //Puttanesca | Carrettiera - MareMonti

            Assert.AreEqual(dishPuttanesca, dish);
            Assert.AreEqual(2, kitchen.OpenOrderCount);
            Assert.AreEqual(21.4, kitchen.Revenue, 0.0001);
            Assert.AreEqual(dishCarrettiera, kitchen.DishInPreparation);

            dish = kitchen.Serve(); //Carrettiera | MareMonti

            Assert.AreEqual(dishCarrettiera, dish);
            Assert.AreEqual(1, kitchen.OpenOrderCount);
            Assert.AreEqual(30.3, kitchen.Revenue, 0.0001);
            Assert.AreEqual(dishMareMonti, kitchen.DishInPreparation);

            Dish dishMargherita = new Dish("Pizza Margherita", Course.Main, 8.0);
            kitchen.Order(dishMargherita); //MareMonti - Margherita

            Assert.AreEqual(2, kitchen.OpenOrderCount);
            Assert.AreEqual(30.3, kitchen.Revenue, 0.0001);
            Assert.AreEqual(dishMareMonti, kitchen.DishInPreparation);

            dish = kitchen.Serve(); //MareMonti | Margherita

            Assert.AreEqual(dishMareMonti, dish);
            Assert.AreEqual(1, kitchen.OpenOrderCount);
            Assert.AreEqual(42.8, kitchen.Revenue, 0.0001);
            Assert.AreEqual(dishMargherita, kitchen.DishInPreparation);

            dish = kitchen.Serve(); //Margherita |

            Assert.AreEqual(dishMargherita, dish);
            Assert.AreEqual(0, kitchen.OpenOrderCount);
            Assert.AreEqual(50.8, kitchen.Revenue, 0.0001);
            Assert.AreEqual(null, kitchen.DishInPreparation);

            Dish dishArrabiata = new Dish("Pasta Arrabiata", Course.Main, 8.8);
            kitchen.Order(dishArrabiata); //Arrabiata

            Assert.AreEqual(1, kitchen.OpenOrderCount);
            Assert.AreEqual(50.8, kitchen.Revenue, 0.0001);
            Assert.AreEqual(dishArrabiata, kitchen.DishInPreparation);

            dish = kitchen.Serve(); //Arrabiata |

            Assert.AreEqual(dishArrabiata, dish);
            Assert.AreEqual(0, kitchen.OpenOrderCount);
            Assert.AreEqual(59.6, kitchen.Revenue, 0.0001);
            Assert.AreEqual(null, kitchen.DishInPreparation);
        }
    }
}
