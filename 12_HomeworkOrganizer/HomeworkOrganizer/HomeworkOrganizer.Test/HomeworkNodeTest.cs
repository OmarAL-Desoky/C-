using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeworkOrganizer.Test
{
    [TestClass]
    public class HomeworkNodeTest
    {
        [TestMethod]
        public void TestConstructor()
        {
            Homework homework = new Homework(141520, "SEW", "RPN-Calculator", new DateTime(2022, 3, 13, 23, 55, 0));

            HomeworkNode node = new HomeworkNode(homework);

            Assert.AreEqual(homework, node.Homework);
            Assert.AreEqual(null, node.Next);
        }

        [TestMethod]
        public void TestNext()
        {
            Homework homeworkSew = new Homework(141520, "SEW", "RPN-Calculator", new DateTime(2022, 3, 13, 23, 55, 0));
            Homework homeworkKids = new Homework(137694, "KIDS", "Penguin Visualization", new DateTime(2022, 1, 11, 8, 0, 0));

            HomeworkNode node = new HomeworkNode(homeworkSew);
            HomeworkNode nodeOther = new HomeworkNode(homeworkKids);

            Assert.AreEqual(homeworkSew, node.Homework);
            Assert.AreEqual(null, node.Next);
            Assert.AreEqual(homeworkKids, nodeOther.Homework);
            Assert.AreEqual(null, nodeOther.Next);

            node.Next = nodeOther;

            Assert.AreEqual(homeworkSew, node.Homework);
            Assert.AreEqual(nodeOther, node.Next);
            Assert.AreEqual(homeworkKids, nodeOther.Homework);
            Assert.AreEqual(null, nodeOther.Next);

            node.Next = null;

            Assert.AreEqual(homeworkSew, node.Homework);
            Assert.AreEqual(null, node.Next);
            Assert.AreEqual(homeworkKids, nodeOther.Homework);
            Assert.AreEqual(null, nodeOther.Next);
        }
    }
}
