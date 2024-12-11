namespace CompanyManager.Test;

[TestClass]
public class SysAdminTest
{
    [TestMethod]
    public void TestInheritance()
    {
        Assert.AreEqual(true, typeof(IComparable<Worker>).IsAssignableFrom(typeof(SysAdmin)));
        Assert.AreEqual(true, typeof(Worker).IsAssignableFrom(typeof(SysAdmin)));
    }
    
    [TestMethod]
    public void TestConstructorValidValues()
    {
        SysAdmin programmer = new SysAdmin("John Johnson", 34);

        Assert.AreEqual("John Johnson", programmer.Name);
        Assert.AreEqual(34, programmer.WorkedHours, 0.001);
        Assert.AreEqual(3000, programmer.BaseSalary, 0.001);
    }
    
    [TestMethod]
    public void TestConstructorInvalidName()
    {
        ArgumentException ex = Assert.ThrowsException<ArgumentException>(() =>
        {
            SysAdmin programmer = new SysAdmin("J0hn J0hnson", 34, 3000);
        });

        Assert.AreEqual("Name must not contain numbers!", ex.Message);
    }
    
    [TestMethod]
    public void TestConstructorInvalidWorkingHoursNegative()
    {
        ArgumentException ex = Assert.ThrowsException<ArgumentException>(() =>
        {
            SysAdmin programmer = new SysAdmin("John Johnson", -20);
        });

        Assert.AreEqual("Working Hours must not be negative!", ex.Message);
        
        ex = Assert.ThrowsException<ArgumentException>(() =>
        {
            SysAdmin programmer = new SysAdmin("John Johnson", -1);
        });

        Assert.AreEqual("Working Hours must not be negative!", ex.Message);
        
        ex = Assert.ThrowsException<ArgumentException>(() =>
        {
            SysAdmin programmer = new SysAdmin("John Johnson", -40);
        });

        Assert.AreEqual("Working Hours must not be negative!", ex.Message);
        
        ex = Assert.ThrowsException<ArgumentException>(() =>
        {
            SysAdmin programmer = new SysAdmin("John Johnson", -41);
        });

        Assert.AreEqual("Working Hours must not be negative!", ex.Message);
    }
    
    [TestMethod]
    public void TestConstructorInvalidWorkingHoursTooMuch()
    {
        ArgumentException ex = Assert.ThrowsException<ArgumentException>(() =>
        {
            SysAdmin programmer = new SysAdmin("John Johnson", 41);
        });

        Assert.AreEqual("Working Hours must not be more than 40h!", ex.Message);
        
        ex = Assert.ThrowsException<ArgumentException>(() =>
        {
            SysAdmin programmer = new SysAdmin("John Johnson", 50);
        });

        Assert.AreEqual("Working Hours must not be more than 40h!", ex.Message);
        
        ex = Assert.ThrowsException<ArgumentException>(() =>
        {
            SysAdmin programmer = new SysAdmin("John Johnson", 40.5);
        });

        Assert.AreEqual("Working Hours must not be more than 40h!", ex.Message);
        
        ex = Assert.ThrowsException<ArgumentException>(() =>
        {
            SysAdmin programmer = new SysAdmin("John Johnson", 99);
        });

        Assert.AreEqual("Working Hours must not be more than 40h!", ex.Message);
        
        ex = Assert.ThrowsException<ArgumentException>(() =>
        {
            SysAdmin programmer = new SysAdmin("John Johnson", 9999);
        });

        Assert.AreEqual("Working Hours must not be more than 40h!", ex.Message);
    }

    [TestMethod]
    public void TestConstructorInvalidWorkingHoursZero()
    {
        ArgumentException ex = Assert.ThrowsException<ArgumentException>(() =>
        {
            SysAdmin programmer = new SysAdmin("John Johnson", 0);
        });

        Assert.AreEqual("Working Hours must not be 0!", ex.Message);
    }
    
    [TestMethod]
    public void TestCalculateSalaryWithBaseSalary()
    {
        SysAdmin sysAdminA = new SysAdmin("John Johnson", 20);
        Assert.AreEqual(3040, sysAdminA.CalculateSalary(), 0.001);
        
        SysAdmin sysAdminB = new SysAdmin("Felix Neuer", 39.5);
        Assert.AreEqual(3079, sysAdminB.CalculateSalary(), 0.001);
        
        SysAdmin sysAdminC = new SysAdmin("Jacob Mayrwoeger", 1);
        Assert.AreEqual(3002, sysAdminC.CalculateSalary(), 0.001);
        
        SysAdmin sysAdminD = new SysAdmin("Julian Heissinger", 13);
        Assert.AreEqual(3026, sysAdminD.CalculateSalary(), 0.001);
        
        SysAdmin sysAdminE = new SysAdmin("Omar Al Desoky", 40);
        Assert.AreEqual(3080, sysAdminE.CalculateSalary(), 0.001);
        
        SysAdmin sysAdminF = new SysAdmin("Jonas Moser", 6);
        Assert.AreEqual(3012, sysAdminF.CalculateSalary(), 0.001);
    }
    
    [TestMethod]
    public void TestCalculateSalaryOtherBaseSalary()
    {
        SysAdmin sysAdminA = new SysAdmin("John Johnson", 20, 2500);
        Assert.AreEqual(2540, sysAdminA.CalculateSalary(), 0.001);
        
        SysAdmin sysAdminB = new SysAdmin("Felix Neuer", 39.5, 4000);
        Assert.AreEqual(4079, sysAdminB.CalculateSalary(), 0.001);
        
        SysAdmin sysAdminC = new SysAdmin("Jacob Mayrwoeger", 1, 1955);
        Assert.AreEqual(1957, sysAdminC.CalculateSalary(), 0.001);
        
        SysAdmin sysAdminD = new SysAdmin("Julian Heissinger", 13, 30);
        Assert.AreEqual(56, sysAdminD.CalculateSalary(), 0.001);
        
        SysAdmin sysAdminE = new SysAdmin("Omar Al Desoky", 40, 4129);
        Assert.AreEqual(4209, sysAdminE.CalculateSalary(), 0.001);
        
        SysAdmin sysAdminF = new SysAdmin("Jonas Moser", 6, 2000);
        Assert.AreEqual(2012, sysAdminF.CalculateSalary(), 0.001);
    }
    
    [TestMethod]
    public void TestWorkValidNumbers() 
    {
        //SysAdmin sysAdminA = new SysAdmin("John Johnson", 20);
        //Assert.AreEqual(45,sysAdminA.Work(25)); 
        
        SysAdmin sysAdminB = new SysAdmin("Michal Karpowicz", 20);
        Assert.AreEqual(21,sysAdminB.Work(1)); 
        
        /*SysAdmin sysAdminC = new SysAdmin("Julian Heissinger", 600);
        Assert.AreEqual(720,sysAdminC.Work(120)); 
        
        SysAdmin sysAdminD = new SysAdmin("Jacob Mayrwoeger", 34);
        Assert.AreEqual(124,sysAdminD.Work(90)); 
        
        SysAdmin sysAdminE = new SysAdmin("Omar Al Desoky", 1001);
        Assert.AreEqual(1301,sysAdminE.Work(300)); */
    }

    [TestMethod]
    public void TestWorkInvalidNumber()
    {
        SysAdmin sysAdmin = new SysAdmin("John Johnson", 20);
        ArgumentException ex = Assert.ThrowsException<ArgumentException>(() =>
        {
            sysAdmin.Work(-1);
        });
        Assert.AreEqual("Working Hours must not be negative!", ex.Message);
    }
    
    [TestMethod]
    public void TestEquals()
    {
        SysAdmin sysAdminA = new SysAdmin("John Johnson", 20);
        SysAdmin sysAdminB = new SysAdmin("Jonas Moser", 20);
        SysAdmin sysAdminC = new SysAdmin("Julian Heissinger", 25);

        sysAdminA.Work(20);
        
        Assert.AreEqual(true, sysAdminA.Equals(sysAdminA));
        Assert.AreEqual(false, sysAdminA.Equals(sysAdminB));
        Assert.AreEqual(false, sysAdminA.Equals(sysAdminC));
        
        Assert.AreEqual(false, sysAdminB.Equals(sysAdminA));
        Assert.AreEqual(true, sysAdminB.Equals(sysAdminB));
        Assert.AreEqual(false, sysAdminB.Equals(sysAdminC));
        
        Assert.AreEqual(false, sysAdminC.Equals(sysAdminA));
        Assert.AreEqual(false, sysAdminC.Equals(sysAdminB));
        Assert.AreEqual(true, sysAdminC.Equals(sysAdminC));
    }
    
    [TestMethod]
    public void TestCompareTo()
    {
        Worker sysAdminA = new SysAdmin("John Johnson", 20);
        Worker sysAdminB = new SysAdmin("Jonas Moser", 20);
        Worker sysAdminC = new SysAdmin("Julian Heissinger", 25);

        sysAdminA.Work(10);
        sysAdminB.Work(5);
        
        Assert.AreEqual(0, sysAdminA.CompareTo(sysAdminA));
        Assert.AreEqual(1, sysAdminA.CompareTo(sysAdminB));
        Assert.AreEqual(1, sysAdminA.CompareTo(sysAdminC));

        Assert.AreEqual(-1, sysAdminB.CompareTo(sysAdminA));
        Assert.AreEqual(0, sysAdminB.CompareTo(sysAdminB));
        Assert.AreEqual(0, sysAdminB.CompareTo(sysAdminC));

        Assert.AreEqual(-1,sysAdminC.CompareTo(sysAdminA));
        Assert.AreEqual(0,sysAdminC.CompareTo(sysAdminB));
        Assert.AreEqual(0, sysAdminC.CompareTo(sysAdminC));
    }
}