using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace CompanyManager.Test;

[TestClass]
public class WorkerTest
{
    [TestMethod]
    public void TestIsAbstract()
    {
        Assert.AreEqual(true, typeof(Worker).IsAbstract);
    }
    
    [TestMethod]
    public void TestInheritance()
    {
        Assert.AreEqual(true, typeof(IComparable<Worker>).IsAssignableFrom(typeof(Worker)));
    }
    
    [TestMethod]
    public void TestIsValidCatalogNumbers()
    {
        Assert.AreEqual(true, Worker.IsValidCatalogNumber(1000));
        Assert.AreEqual(true, Worker.IsValidCatalogNumber(50));
        Assert.AreEqual(true, Worker.IsValidCatalogNumber(999));
        Assert.AreEqual(true, Worker.IsValidCatalogNumber(1));
        Assert.AreEqual(true, Worker.IsValidCatalogNumber(31));
        Assert.AreEqual(true, Worker.IsValidCatalogNumber(920));
        Assert.AreEqual(true, Worker.IsValidCatalogNumber(3));
        Assert.AreEqual(true, Worker.IsValidCatalogNumber(540));
    }
    
    [TestMethod]
    public void TestIsInvalidCatalogNumbers()
    {
        Assert.AreEqual(false, Worker.IsValidCatalogNumber(-10));
        Assert.AreEqual(false, Worker.IsValidCatalogNumber(-99999));
        Assert.AreEqual(false, Worker.IsValidCatalogNumber(999999));
        Assert.AreEqual(false, Worker.IsValidCatalogNumber(0));
        Assert.AreEqual(false, Worker.IsValidCatalogNumber(1001));
        Assert.AreEqual(false, Worker.IsValidCatalogNumber(1200));
        Assert.AreEqual(false, Worker.IsValidCatalogNumber(-0));
        Assert.AreEqual(false, Worker.IsValidCatalogNumber(2400));
        Assert.AreEqual(false, Worker.IsValidCatalogNumber(-451));
    }
}