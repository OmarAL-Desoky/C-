using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace PartyCalendar.Test
{
    [TestClass]
    public class EmailTest
    {
        [TestMethod]
        public void TestValidMailAddresses()
        {
            Person person = new Person("Justin", "Biber", "justin@yahoo.com");
            Assert.AreEqual("justin@yahoo.com", person.EmailAddress);

            person.EmailAddress ="justin.biber@yahoo.com";
            Assert.AreEqual("justin.biber@yahoo.com", person.EmailAddress);

            person.EmailAddress ="biber@example.me.org";
            Assert.AreEqual("biber@example.me.org", person.EmailAddress);

            person = new Person("Justin", "Biber", "jay_bib@mail.co.uk");
            Assert.AreEqual("jay_bib@mail.co.uk", person.EmailAddress);
        }

        [TestMethod]
        public void TestInvalidMailAddresses()
        {
            Person person = new Person("Justin", "Biber", "@yahoo.com"); //no local part
            Assert.AreEqual("", person.EmailAddress);

            person.EmailAddress = "justin.biber.yahoo.com";  // separator = @ missing - no domain part
            Assert.AreEqual("", person.EmailAddress);

            person = new Person("Justin", "Biber", ".justin.biber@yahoo.com");  // beginning dot is not allowed
            Assert.AreEqual("", person.EmailAddress);

            person.EmailAddress = "justin..biber@yahoo.com"; // two dots consecutive
            Assert.AreEqual("", person.EmailAddress);

            person = new Person("Justin", "Biber", "justin.biber@.yahoo.com"); // domain part must not start with .
            Assert.AreEqual("", person.EmailAddress);

            person.EmailAddress = "justin@.example.me.org"; // domain must not start with dot
            Assert.AreEqual("", person.EmailAddress);

            person = new Person("Justin", "Biber", "justin@example.me.org."); // domain must not end with dot
            Assert.AreEqual("", person.EmailAddress);

            person.EmailAddress = "justinexample.me.org@"; // domain must not end with separator
            Assert.AreEqual("", person.EmailAddress);

            person.EmailAddress = "ju$tin@biber.org"; // only _ and . are allowed apart from digits and letters
            Assert.AreEqual("", person.EmailAddress);

            person = new Person("Justin", "Biber", "justin@biber@com"); // only one @ is allowed
            Assert.AreEqual("", person.EmailAddress);
        }
    }
}
