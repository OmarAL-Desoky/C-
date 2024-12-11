using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PartyCalendar.Test
{
    [TestClass]
    public class PersonTest
    {
        [TestMethod]
        public void TestConstructorsAndGetters()
        {
            Person person = new Person("John", "Doe");
            int idExpected = person.Id;
            Assert.AreEqual("John", person.FirstName);
            Assert.AreEqual("Doe", person.LastName);
            Assert.AreEqual("", person.EmailAddress);

            idExpected++;

            person = new Person("Sally", "Sixpack", "s.sixpack@htl-leonding.ac.at");
            Assert.AreEqual(idExpected, person.Id);
            Assert.AreEqual("Sally", person.FirstName);
            Assert.AreEqual("Sixpack", person.LastName);
            Assert.AreEqual("s.sixpack@htl-leonding.ac.at", person.EmailAddress);

            idExpected++;

            person = new Person("Tom", "Taxpayer", "tomtax@gmail.com");
            Assert.AreEqual(idExpected, person.Id);
            Assert.AreEqual("Tom", person.FirstName);
            Assert.AreEqual("Taxpayer", person.LastName);
            Assert.AreEqual("tomtax@gmail.com", person.EmailAddress);

            //Check if calling getter another time does not change value:
            Assert.AreEqual(idExpected, person.Id);
        }

        [TestMethod]
        public void TestToString()
        {
            Person person = new Person("Haxi", "");
            int idExpected = person.Id;
            Assert.AreEqual("", person.ToString());

            person = new Person("Jane", null);
            Assert.AreEqual(++idExpected, person.Id);
            Assert.AreEqual("", person.ToString());

            person = new Person("", "Doe");
            Assert.AreEqual(++idExpected, person.Id);
            Assert.AreEqual("", person.ToString());

            person = new Person(null, "Popaxi");
            Assert.AreEqual(++idExpected, person.Id);
            Assert.AreEqual("", person.ToString());

            person = new Person("John", "Taxpayer");
            Assert.AreEqual(++idExpected, person.Id);
            Assert.AreEqual("John Taxpayer", person.ToString());

            person = new Person("Mary", "Major", "majory@gmail.com");
            Assert.AreEqual(++idExpected, person.Id);
            Assert.AreEqual("Mary Major (majory@gmail.com)", person.ToString());

            person = new Person("Jan", "", "kowal@sky.com");
            Assert.AreEqual(++idExpected, person.Id);
            Assert.AreEqual("", person.ToString());

            person = new Person("", "Kowalski", "janek@wp.pl");
            Assert.AreEqual(++idExpected, person.Id);
            Assert.AreEqual("", person.ToString());
        }

        [TestMethod]
        public void TestVisitAndUnvisit()
        {
            Person person = new Person("Richard", "Roe");

            Assert.AreEqual(0, person.PartyCount);

            bool isVisitSuccessful = person.VisitParty();

            Assert.AreEqual(1, person.PartyCount);
            Assert.AreEqual(true, isVisitSuccessful);

            Assert.AreEqual(true, person.VisitParty());
            Assert.AreEqual(true, person.VisitParty());

            Assert.AreEqual(3, person.PartyCount);

            person.UnvisitParty();

            Assert.AreEqual(2, person.PartyCount);

            Assert.AreEqual(true, person.VisitParty());
            Assert.AreEqual(true, person.VisitParty());
            Assert.AreEqual(true, person.VisitParty());

            Assert.AreEqual(5, person.PartyCount);

            isVisitSuccessful = person.VisitParty();

            Assert.AreEqual(false, isVisitSuccessful);
            Assert.AreEqual(5, person.PartyCount);

            person.UnvisitParty();

            Assert.AreEqual(4, person.PartyCount);

            Assert.AreEqual(true, person.VisitParty());
            Assert.AreEqual(5, person.PartyCount);

            person.UnvisitParty();
            person.UnvisitParty();
            person.UnvisitParty();
            person.UnvisitParty();
            person.UnvisitParty();

            Assert.AreEqual(0, person.PartyCount);

            person.UnvisitParty();

            Assert.AreEqual(0, person.PartyCount);
        }
    }
}
