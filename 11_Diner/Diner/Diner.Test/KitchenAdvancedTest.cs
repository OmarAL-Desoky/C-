using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diner.Test
{
    [TestClass]
    public class KitchenAdvancedTest
    {
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

            Dish dishBruschetta = new Dish("Bruschetta", Course.Entree, 3.50);
            kitchen.Order(dishBruschetta); //Bruschetta - Porcini

            Assert.AreEqual(2, kitchen.OpenOrderCount);
            Assert.AreEqual(0.0, kitchen.Revenue, 0.0001);
            Assert.AreEqual(dishBruschetta, kitchen.DishInPreparation);

            Dish dishCarpaccio = new Dish("Carpaccio", Course.Entree, 12.20);
            kitchen.Order(dishCarpaccio); //Bruschetta - Carpaccio - Porcini

            Assert.AreEqual(3, kitchen.OpenOrderCount);
            Assert.AreEqual(0.0, kitchen.Revenue, 0.0001);
            Assert.AreEqual(dishBruschetta, kitchen.DishInPreparation);

            Dish dishCarrettiera = new Dish("Spaghetti Alla Carrettiera", Course.Main, 8.90);
            kitchen.Order(dishCarrettiera); //Bruschetta - Carpaccio - Porcini - Carrettiera

            Assert.AreEqual(4, kitchen.OpenOrderCount);
            Assert.AreEqual(0.0, kitchen.Revenue, 0.0001);
            Assert.AreEqual(dishBruschetta, kitchen.DishInPreparation);

            Dish dishTiramisu = new Dish("Tiramisu", Course.Dessert, 4.3);
            kitchen.Order(dishTiramisu); //Bruschetta - Carpaccio - Porcini - Carrettiera - Tiramisu

            Assert.AreEqual(5, kitchen.OpenOrderCount);
            Assert.AreEqual(0.0, kitchen.Revenue, 0.0001);
            Assert.AreEqual(dishBruschetta, kitchen.DishInPreparation);

            Dish dish = kitchen.Serve(); //Bruschetta | Carpaccio - Porcini - Carrettiera - Tiramisu

            Assert.AreEqual(dishBruschetta, dish);
            Assert.AreEqual(4, kitchen.OpenOrderCount);
            Assert.AreEqual(3.5, kitchen.Revenue, 0.0001);
            Assert.AreEqual(dishCarpaccio, kitchen.DishInPreparation);

            dish = kitchen.Serve(); //Carpaccio | Porcini - Carrettiera - Tiramisu

            Assert.AreEqual(dishCarpaccio, dish);
            Assert.AreEqual(3, kitchen.OpenOrderCount);
            Assert.AreEqual(15.7, kitchen.Revenue, 0.0001);
            Assert.AreEqual(dishPorcini, kitchen.DishInPreparation);

            dish = kitchen.Serve(); //Porcini | Carrettiera - Tiramisu

            Assert.AreEqual(dishPorcini, dish);
            Assert.AreEqual(2, kitchen.OpenOrderCount);
            Assert.AreEqual(26.7, kitchen.Revenue, 0.0001);
            Assert.AreEqual(dishCarrettiera, kitchen.DishInPreparation);

            Dish dishGelato = new Dish("Gelato", Course.Dessert, 2.9);
            kitchen.Order(dishGelato); //Carrettiera - Tiramisu - Gelato

            Assert.AreEqual(3, kitchen.OpenOrderCount);
            Assert.AreEqual(26.7, kitchen.Revenue, 0.0001);
            Assert.AreEqual(dishCarrettiera, kitchen.DishInPreparation);

            Dish dishMareMonti = new Dish("Pizza Mare E Monti", Course.Main, 12.50);
            kitchen.Order(dishMareMonti); //Carrettiera - MareMonti - Tiramisu - Gelato

            Assert.AreEqual(4, kitchen.OpenOrderCount);
            Assert.AreEqual(26.7, kitchen.Revenue, 0.0001);
            Assert.AreEqual(dishCarrettiera, kitchen.DishInPreparation);

            Dish dishFocaccia = new Dish("Focaccia", Course.Entree, 5);
            kitchen.Order(dishFocaccia); //Focaccia - Carrettiera - MareMonti - Tiramisu - Gelato

            Assert.AreEqual(5, kitchen.OpenOrderCount);
            Assert.AreEqual(26.7, kitchen.Revenue, 0.0001);
            Assert.AreEqual(dishFocaccia, kitchen.DishInPreparation);

            dish = kitchen.Serve(); //Focaccia | Carrettiera - MareMonti - Tiramisu - Gelato

            Assert.AreEqual(dishFocaccia, dish);
            Assert.AreEqual(4, kitchen.OpenOrderCount);
            Assert.AreEqual(31.7, kitchen.Revenue, 0.0001);
            Assert.AreEqual(dishCarrettiera, kitchen.DishInPreparation);

            dish = kitchen.Serve(); //Carrettiera | MareMonti - Tiramisu - Gelato

            Assert.AreEqual(dishCarrettiera, dish);
            Assert.AreEqual(3, kitchen.OpenOrderCount);
            Assert.AreEqual(40.6, kitchen.Revenue, 0.0001);
            Assert.AreEqual(dishMareMonti, kitchen.DishInPreparation);

            dish = kitchen.Serve(); //MareMonti | Tiramisu - Gelato

            Assert.AreEqual(dishMareMonti, dish);
            Assert.AreEqual(2, kitchen.OpenOrderCount);
            Assert.AreEqual(53.1, kitchen.Revenue, 0.0001);
            Assert.AreEqual(dishTiramisu, kitchen.DishInPreparation);

            dish = kitchen.Serve(); //Tiramisu | Gelato

            Assert.AreEqual(dishTiramisu, dish);
            Assert.AreEqual(1, kitchen.OpenOrderCount);
            Assert.AreEqual(57.4, kitchen.Revenue, 0.0001);
            Assert.AreEqual(dishGelato, kitchen.DishInPreparation);

            dish = kitchen.Serve(); //Gelato |

            Assert.AreEqual(dishGelato, dish);
            Assert.AreEqual(0, kitchen.OpenOrderCount);
            Assert.AreEqual(60.3, kitchen.Revenue, 0.0001);
            Assert.AreEqual(null, kitchen.DishInPreparation);
        }
    }
}
