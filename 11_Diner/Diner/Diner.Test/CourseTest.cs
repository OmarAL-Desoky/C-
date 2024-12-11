namespace Diner.Test
{
    [TestClass]
    public class CourseTest
    {
        [TestMethod]
        public void TestOrdinalValues()
        {
            Assert.AreEqual(0, (int)Course.Entree);
            Assert.AreEqual(1, (int)Course.Main);
            Assert.AreEqual(2, (int)Course.Dessert);
        }
    }
}