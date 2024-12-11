using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Soccer;

namespace MyGenericSet.Test
{
    [TestClass]
    public class MyNodeTest
    {
        [TestMethod]
        public void TestConstructor()
        {
            SoccerPlayer player = new SoccerPlayer(20, "Zbigniew Boniek", SoccerPosition.Midfielder);

            MyNode<SoccerPlayer> node = new MyNode<SoccerPlayer>(player);

            Assert.AreEqual(player, node.Data);
            Assert.AreEqual(null, node.Next);
        }

        [TestMethod]
        public void TestNext()
        {
            string haxi = "haxi";
            string popaxi = "popaxi";

            MyNode<string> node = new MyNode<string>(haxi);
            MyNode<string> nodeOther = new MyNode<string>(popaxi);

            Assert.AreEqual(haxi, node.Data);
            Assert.AreEqual(null, node.Next);
            Assert.AreEqual(popaxi, nodeOther.Data);
            Assert.AreEqual(null, nodeOther.Next);

            node.Next = nodeOther;

            Assert.AreEqual(haxi, node.Data);
            Assert.AreEqual(nodeOther, node.Next);
            Assert.AreEqual(popaxi, nodeOther.Data);
            Assert.AreEqual(null, nodeOther.Next);

            node.Next = null;

            Assert.AreEqual(haxi, node.Data);
            Assert.AreEqual(null, node.Next);
            Assert.AreEqual(popaxi, nodeOther.Data);
            Assert.AreEqual(null, nodeOther.Next);
        }
    }
}
