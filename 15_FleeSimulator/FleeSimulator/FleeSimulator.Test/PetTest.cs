using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FleeSimulator;

namespace FleaSimulator.Test
{
    [TestClass]
    public class PetTest
    {
        [TestMethod]
        public void TestIsAbstract()
        {
            Assert.AreEqual(true, typeof(Pet).IsAbstract);
        }
    }
}
