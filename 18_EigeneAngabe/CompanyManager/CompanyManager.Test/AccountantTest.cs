namespace CompanyManager.Test;

[TestClass]
public class AccountantTest
{
    [TestMethod]
    public void TestInheritance()
    {
        Assert.AreEqual(true, typeof(IComparable<Worker>).IsAssignableFrom(typeof(Accountant)));
        Assert.AreEqual(true, typeof(Worker).IsAssignableFrom(typeof(Accountant)));
    }
    
    [TestMethod]
    public void TestConstructorValidValues()
    {
        Accountant accountant = new Accountant("John Johnson", 34);

        Assert.AreEqual("John Johnson", accountant.Name);
        Assert.AreEqual(34, accountant.WorkedHours, 0.001);
        Assert.AreEqual(3000, accountant.BaseSalary, 0.001);
    }
    
    [TestMethod]
    public void TestConstructorInvalidName()
    {
        ArgumentException ex = Assert.ThrowsException<ArgumentException>(() =>
        {
            Accountant accountant = new Accountant("J0hn J0hnson", 34, 3000);
        });

        Assert.AreEqual("Name must not contain numbers!", ex.Message);
    }
    
    [TestMethod]
    public void TestConstructorInvalidWorkingHoursNegative()
    {
        ArgumentException ex = Assert.ThrowsException<ArgumentException>(() =>
        {
            Accountant accountant = new Accountant("John Johnson", -20);
        });

        Assert.AreEqual("Working Hours must not be negative!", ex.Message);
        
        ex = Assert.ThrowsException<ArgumentException>(() =>
        {
            Accountant accountant = new Accountant("John Johnson", -1);
        });

        Assert.AreEqual("Working Hours must not be negative!", ex.Message);
        
        ex = Assert.ThrowsException<ArgumentException>(() =>
        {
            Accountant accountant = new Accountant("John Johnson", -40);
        });

        Assert.AreEqual("Working Hours must not be negative!", ex.Message);
        
        ex = Assert.ThrowsException<ArgumentException>(() =>
        {
            Accountant accountant = new Accountant("John Johnson", -41);
        });

        Assert.AreEqual("Working Hours must not be negative!", ex.Message);
    }
    
    [TestMethod]
    public void TestConstructorInvalidWorkingHoursTooMuch()
    {
        ArgumentException ex = Assert.ThrowsException<ArgumentException>(() =>
        {
            Accountant accountant = new Accountant("John Johnson", 41);
        });

        Assert.AreEqual("Working Hours must not be more than 40h!", ex.Message);
        
        ex = Assert.ThrowsException<ArgumentException>(() =>
        {
            Accountant accountant = new Accountant("John Johnson", 50);
        });

        Assert.AreEqual("Working Hours must not be more than 40h!", ex.Message);
        
        ex = Assert.ThrowsException<ArgumentException>(() =>
        {
            Accountant accountant = new Accountant("John Johnson", 40.5);
        });

        Assert.AreEqual("Working Hours must not be more than 40h!", ex.Message);
        
        ex = Assert.ThrowsException<ArgumentException>(() =>
        {
            Accountant accountant = new Accountant("John Johnson", 99);
        });

        Assert.AreEqual("Working Hours must not be more than 40h!", ex.Message);
        
        ex = Assert.ThrowsException<ArgumentException>(() =>
        {
            Accountant accountant = new Accountant("John Johnson", 9999);
        });

        Assert.AreEqual("Working Hours must not be more than 40h!", ex.Message);
    }

    [TestMethod]
    public void TestConstructorInvalidWorkingHoursZero()
    {
        ArgumentException ex = Assert.ThrowsException<ArgumentException>(() =>
        {
            Accountant accountant = new Accountant("John Johnson", 0);
        });

        Assert.AreEqual("Working Hours must not be 0!", ex.Message);
    }
    
    [TestMethod]
    public void TestCalculateSalaryWithBaseSalary()
    {
        Accountant accountantA = new Accountant("John Johnson", 20);
        Assert.AreEqual(3040, accountantA.CalculateSalary(), 0.001);
        
        Accountant accountantB = new Accountant("Felix Neuer", 39.5);
        Assert.AreEqual(3079, accountantB.CalculateSalary(), 0.001);
        
        Accountant accountantC = new Accountant("Jacob Mayrwoeger", 1);
        Assert.AreEqual(3002, accountantC.CalculateSalary(), 0.001);
        
        Accountant accountantD = new Accountant("Julian Heissinger", 13);
        Assert.AreEqual(3026, accountantD.CalculateSalary(), 0.001);
        
        Accountant accountantE = new Accountant("Omar Al Desoky", 40);
        Assert.AreEqual(3080, accountantE.CalculateSalary(), 0.001);
        
        Accountant accountantF = new Accountant("Jonas Moser", 6);
        Assert.AreEqual(3012, accountantF.CalculateSalary(), 0.001);
    }
    
    [TestMethod]
    public void TestCalculateSalaryOtherBaseSalary()
    {
        Accountant accountantA = new Accountant("John Johnson", 20, 2500);
        Assert.AreEqual(2540, accountantA.CalculateSalary(), 0.001);
        
        Accountant accountantB = new Accountant("Felix Neuer", 39.5, 4000);
        Assert.AreEqual(4079, accountantB.CalculateSalary(), 0.001);
        
        Accountant accountantC = new Accountant("Jacob Mayrwoeger", 1, 1955);
        Assert.AreEqual(1957, accountantC.CalculateSalary(), 0.001);
        
        Accountant accountantD = new Accountant("Julian Heissinger", 13, 30);
        Assert.AreEqual(56, accountantD.CalculateSalary(), 0.001);
        
        Accountant accountantE = new Accountant("Omar Al Desoky", 40, 4129);
        Assert.AreEqual(4209, accountantE.CalculateSalary(), 0.001);
        
        Accountant accountantF = new Accountant("Jonas Moser", 6, 2000);
        Assert.AreEqual(2012, accountantF.CalculateSalary(), 0.001);
    }
    
    [TestMethod]
    public void TestWorkValidNumbers() 
    {
        //Accountant accountantA = new Accountant("John Johnson", 20);
        //Assert.AreEqual(45,accountantA.Work(25)); 
        
        Accountant accountantB = new Accountant("Michal Karpowicz", 20);
        Assert.AreEqual(21,accountantB.Work(1)); 
        
        /*Accountant accountantC = new Accountant("Julian Heissinger", 600);
        Assert.AreEqual(720,accountantC.Work(120)); 
        
        Accountant accountantD = new Accountant("Jacob Mayrwoeger", 34);
        Assert.AreEqual(124,accountantD.Work(90)); 
        
        Accountant accountantE = new Accountant("Omar Al Desoky", 1001);
        Assert.AreEqual(1301,accountantE.Work(300)); */
    }

    [TestMethod]
    public void TestWorkInvalidNumber()
    {
        Accountant accountant = new Accountant("John Johnson", 20);
        ArgumentException ex = Assert.ThrowsException<ArgumentException>(() =>
        {
            accountant.Work(-1);
        });
        Assert.AreEqual("Working Hours must not be negative!", ex.Message);
    }
    
    [TestMethod]
    public void TestEquals()
    {
        Accountant accountantA = new Accountant("John Johnson", 20);
        Accountant accountantB = new Accountant("Jonas Moser", 20);
        Accountant accountantC = new Accountant("Julian Heissinger", 25);

        accountantA.Work(20);
        
        Assert.AreEqual(true, accountantA.Equals(accountantA));
        Assert.AreEqual(false, accountantA.Equals(accountantB));
        Assert.AreEqual(false, accountantA.Equals(accountantC));
        
        Assert.AreEqual(false, accountantB.Equals(accountantA));
        Assert.AreEqual(true, accountantB.Equals(accountantB));
        Assert.AreEqual(false, accountantB.Equals(accountantC));
        
        Assert.AreEqual(false, accountantC.Equals(accountantA));
        Assert.AreEqual(false, accountantC.Equals(accountantB));
        Assert.AreEqual(true, accountantC.Equals(accountantC));
    }
    
    [TestMethod]
    public void TestCompareTo()
    {
        Worker accountantA = new Accountant("John Johnson", 20);
        Worker accountantB = new Accountant("Jonas Moser", 20);
        Worker accountantC = new Accountant("Julian Heissinger", 25);

        accountantA.Work(10);
        accountantB.Work(5);
        
        Assert.AreEqual(0, accountantA.CompareTo(accountantA));
        Assert.AreEqual(1, accountantA.CompareTo(accountantB));
        Assert.AreEqual(1, accountantA.CompareTo(accountantC));

        Assert.AreEqual(-1,accountantB.CompareTo(accountantA));
        Assert.AreEqual(0, accountantB.CompareTo(accountantB));
        Assert.AreEqual(0, accountantB.CompareTo(accountantC));

        Assert.AreEqual(-1,accountantC.CompareTo(accountantA));
        Assert.AreEqual(0, accountantC.CompareTo(accountantB));
        Assert.AreEqual(0, accountantC.CompareTo(accountantC));
    }
}