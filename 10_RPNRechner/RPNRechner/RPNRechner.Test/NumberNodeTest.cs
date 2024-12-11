using Microsoft.VisualStudio.TestTools.UnitTesting;
using RPNRechner;

namespace RpnCalculator.Test
{
    [TestClass]
    public class NumberNodeTest
    {
        [TestMethod]
        public void TestConstructorGettersAndSetters()
        {
            NumberNode node = new NumberNode(12.3);

            Assert.AreEqual(12.3, node.Number);
            Assert.AreEqual(null, node.Next);

            NumberNode otherNode = new NumberNode(7);

            Assert.AreEqual(7, otherNode.Number);
            Assert.AreEqual(null, otherNode.Next);

            node.Next = otherNode;

            Assert.AreEqual(12.3, node.Number);
            Assert.AreEqual(otherNode, node.Next);

            Assert.AreEqual(7, otherNode.Number);
            Assert.AreEqual(null, otherNode.Next);
        }
    }
}
