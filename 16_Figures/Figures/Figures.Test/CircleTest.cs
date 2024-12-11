using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Figures.Test
{
    [TestClass]
    public class CircleTest
    {
        [TestMethod]
        public void TestInheritance()
        {
            Assert.AreEqual(true, typeof(IComparable<Figure>).IsAssignableFrom(typeof(Circle)));
            Assert.AreEqual(false, typeof(IFoldable).IsAssignableFrom(typeof(Circle)));
            Assert.AreEqual(true, typeof(Figure).IsAssignableFrom(typeof(Circle)));
        }

        [TestMethod]
        public void TestConstructor()
        {
            Circle circle = new Circle(Color.Green, 5.5);

            Assert.AreEqual(Color.Green, circle.Color);
            Assert.AreEqual(5.5, circle.Radius, 0.001);
        }

        [TestMethod]
        public void TestConstructorInvalidSize()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                Circle circle = new Circle(Color.Green, -100.0);
            });
        }

        [TestMethod]
        public void TestArea()
        {
            Circle circle = new Circle(Color.Red, 7.5);

            Assert.AreEqual(176.714587, circle.Area, 0.001);
        }

        [TestMethod]
        public void TestCircumference()
        {
            Circle circle = new Circle(Color.Blue, 12);

            Assert.AreEqual(75.3982237, circle.Circumference, 0.001);
        }

        [TestMethod]
        public void TestComparable()
        {
            List<Figure> figures = new List<Figure>();

            Circle circleXL = new Circle(Color.Blue, 400);
            Circle circleL = new Circle(Color.Red, 255.55);
            Circle circleM = new Circle(Color.Blue, 123.456);
            Circle circleS = new Circle(Color.Red, 10.0);

            figures.Add(circleL);
            figures.Add(circleM);
            figures.Add(circleS);
            figures.Add(circleXL);

            figures = figures.OrderBy(x => Random.Shared.Next()).ToList();

            figures.Sort();

            Assert.AreEqual(circleXL, figures[0]);
            Assert.AreEqual(circleL, figures[1]);
            Assert.AreEqual(circleM, figures[2]);
            Assert.AreEqual(circleS, figures[3]);
        }
    }
}
