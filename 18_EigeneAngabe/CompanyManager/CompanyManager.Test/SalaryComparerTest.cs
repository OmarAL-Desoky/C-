namespace CompanyManager.Test;

[TestClass]
public class SalaryComparerTest
{
    [TestMethod]
    public void TestComparison()
    {
        Programmer programmer = new Programmer("Johannes Neuson", 35, 2);
        SysAdmin sysAdmin = new SysAdmin("Lurin Toplanek", 35);
        Accountant accountant = new Accountant("Maxi Neumayer", 36);

        SalaryComparer comparator = new SalaryComparer(2);

        Assert.AreEqual(0, comparator.Compare(programmer, programmer));
        Assert.AreEqual(-1, comparator.Compare(programmer, sysAdmin));
        Assert.AreEqual(-1, comparator.Compare(programmer, accountant));

        Assert.AreEqual(1, comparator.Compare(sysAdmin, programmer));
        Assert.AreEqual(0, comparator.Compare(sysAdmin, sysAdmin));
        Assert.AreEqual(-1, comparator.Compare(sysAdmin, accountant));

        Assert.AreEqual(1, comparator.Compare(accountant, programmer));
        Assert.AreEqual(1, comparator.Compare(accountant, sysAdmin));
        Assert.AreEqual(0, comparator.Compare(accountant, accountant));
    }
}