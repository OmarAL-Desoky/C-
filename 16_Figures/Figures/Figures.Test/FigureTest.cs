using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures.Test
{
    [TestClass]
    public class FigureTest
    {
        [TestMethod]
        public void TestIsAbstract()
        {
            Assert.AreEqual(true, typeof(Figure).IsAbstract);
        }

        [TestMethod]
        public void TestInheritance()
        {
            Assert.AreEqual(true, typeof(IComparable<Figure>).IsAssignableFrom(typeof(Figure)));
            Assert.AreEqual(false, typeof(IFoldable).IsAssignableFrom(typeof(Figure)));
        }
    }
}
