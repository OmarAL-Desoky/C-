using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace PartyCalendar.Test
{
    [TestClass]
    public class PartyTest
    {
        [TestMethod]
        public void TestConstructor()
        {
            Person organizer = new Person("Max", "Mustermann");
            DateTime date = new DateTime(2021, 5, 23);

            Party party = new Party("Meisterfeier", date, organizer, 100);

            Assert.AreEqual("Meisterfeier", party.Title);
            Assert.AreEqual(date, party.Date);
            Assert.AreEqual(organizer, party.Organizer);
            Assert.AreEqual(100, party.MaxParticipantCount);
            Assert.AreEqual(0, party.ParticipantCount);
        }

        [TestMethod]
        public void TestSetters()
        {
            Person organizer = new Person("Max", "Mustermann");
            DateTime date = new DateTime(2021, 5, 23);

            Party party = new Party("Meisterfeier", date, organizer, 100);

            party.Title = "Aufraeumparty";
            party.Date = party.Date.AddDays(1);

            Assert.AreEqual("Aufraeumparty", party.Title);
            Assert.AreEqual(date.AddDays(1), party.Date);
            Assert.AreEqual(organizer, party.Organizer);
            Assert.AreEqual(100, party.MaxParticipantCount);
            Assert.AreEqual(0, party.ParticipantCount);
        }

        [TestMethod]
        public void TestRegister()
        {
            Person organizer = new Person("Sally", "Sixpack");
            DateTime date = new DateTime(2020, 7, 4);

            Party party = new Party("Binary Barbecue", date, organizer, 2);
            Assert.AreEqual(0, party.ParticipantCount);

            Person participantA = new Person("John", "Taxpayer", "j.taxpayer@live.com");
            Assert.AreEqual(0, participantA.PartyCount);

            Person participantB = new Person("Mary", "Major");
            Assert.AreEqual(0, participantB.PartyCount);

            Person participantC = new Person("Jane", "Doe", "jane@doe.com");
            Assert.AreEqual(0, participantC.PartyCount);

            bool isRegistrationASuccessful = party.Register(participantA);
            Assert.AreEqual(true, isRegistrationASuccessful);
            Assert.AreEqual(1, participantA.PartyCount);
            Assert.AreEqual(0, party.FindRegistration(participantA.Id));
            Assert.AreEqual(true, party.IsRegistered(participantA.Id));
            Assert.AreEqual(1, party.ParticipantCount);

            bool isRegistrationBSuccessful = party.Register(participantB);
            Assert.AreEqual(true, isRegistrationBSuccessful);
            Assert.AreEqual(1, participantB.PartyCount);
            Assert.AreEqual(1, party.FindRegistration(participantB.Id));
            Assert.AreEqual(true, party.IsRegistered(participantB.Id));
            Assert.AreEqual(2, party.ParticipantCount);

            bool isRegistrationCSuccessful = party.Register(participantC);
            Assert.AreEqual(false, isRegistrationCSuccessful);
            Assert.AreEqual(0, participantC.PartyCount);
            Assert.AreEqual(-1, party.FindRegistration(participantC.Id));
            Assert.AreEqual(false, party.IsRegistered(participantC.Id));
            Assert.AreEqual(2, party.ParticipantCount);
        }

        [TestMethod]
        public void TestRegisterDuplicates()
        {
            Person organizer = new Person("Butler", "James");
            DateTime date = new DateTime(2021, 12, 31);

            Party party = new Party("Dinner For One", date, organizer, 2);
            Assert.AreEqual(0, party.ParticipantCount);

            Person participant = new Person("Miss", "Sophie");
            Assert.AreEqual(0, participant.PartyCount);

            bool isRegistrationSuccessful = party.Register(participant);
            Assert.AreEqual(true, isRegistrationSuccessful);
            Assert.AreEqual(1, participant.PartyCount);
            Assert.AreEqual(0, party.FindRegistration(participant.Id));
            Assert.AreEqual(true, party.IsRegistered(participant.Id));
            Assert.AreEqual(1, party.ParticipantCount);

            isRegistrationSuccessful = party.Register(participant);
            Assert.AreEqual(false, isRegistrationSuccessful);
            Assert.AreEqual(1, participant.PartyCount);
            Assert.AreEqual(0, party.FindRegistration(participant.Id));
            Assert.AreEqual(true, party.IsRegistered(participant.Id));
            Assert.AreEqual(1, party.ParticipantCount);
        }

        [TestMethod]
        public void TestRegisterTooManyEvents()
        {
            Person organizer = new Person("Thomas", "Brezina");
            DateTime date = new DateTime(1993, 9, 17);

            Person participant = new Person("Gretl", "Sauerkraut", "sauer@cloud.com");
            Assert.AreEqual(0, participant.PartyCount);

            bool isRegistrationSuccessful = false;
            Party party = null;

            for (int i = 0; i < 5; i++)
            {
                party = new Party("Tom Turbo Detektivclub " + i, date, organizer, 20);

                isRegistrationSuccessful = party.Register(participant);
                Assert.AreEqual(true, isRegistrationSuccessful);
                Assert.AreEqual(i + 1, participant.PartyCount);
                Assert.AreEqual(0, party.FindRegistration(participant.Id));
                Assert.AreEqual(true, party.IsRegistered(participant.Id));
                Assert.AreEqual(1, party.ParticipantCount);
            }

            party = new Party("Tom Turbo Detektivclub 6", date, organizer, 20);

            isRegistrationSuccessful = party.Register(participant);
            Assert.AreEqual(false, isRegistrationSuccessful);
            Assert.AreEqual(5, participant.PartyCount);
            Assert.AreEqual(-1, party.FindRegistration(participant.Id));
            Assert.AreEqual(false, party.IsRegistered(participant.Id));
            Assert.AreEqual(0, party.ParticipantCount);
        }

        [TestMethod]
        public void TestUnregister()
        {
            Person organizer = new Person("Jan", "Novak", "novak@budejovice.cz");
            DateTime date = new DateTime(2019, 12, 13);

            Party party = new Party("Java & Jazz Party", date, organizer, 3);
            Assert.AreEqual(0, party.ParticipantCount);

            Person participantA = new Person("Juan", "Perez");
            Assert.AreEqual(0, participantA.PartyCount);

            Person participantB = new Person("Marko", "Markovic", "markymark@gmail.com");
            Assert.AreEqual(0, participantB.PartyCount);

            Person participantC = new Person("Kalle", "Svensson", "kalle@ikea.com");
            Assert.AreEqual(0, participantC.PartyCount);

            Person participantD = new Person("Bob", "Smith");
            Assert.AreEqual(0, participantD.PartyCount);

            bool isRegistrationASuccessful = party.Register(participantA);
            Assert.AreEqual(true, isRegistrationASuccessful);
            Assert.AreEqual(1, participantA.PartyCount);
            Assert.AreEqual(0, party.FindRegistration(participantA.Id));
            Assert.AreEqual(true, party.IsRegistered(participantA.Id));
            Assert.AreEqual(1, party.ParticipantCount);

            bool isRegistrationBSuccessful = party.Register(participantB);
            Assert.AreEqual(true, isRegistrationBSuccessful);
            Assert.AreEqual(1, participantB.PartyCount);
            Assert.AreEqual(1, party.FindRegistration(participantB.Id));
            Assert.AreEqual(true, party.IsRegistered(participantB.Id));
            Assert.AreEqual(2, party.ParticipantCount);

            bool isRegistrationCSuccessful = party.Register(participantC);
            Assert.AreEqual(true, isRegistrationCSuccessful);
            Assert.AreEqual(1, participantC.PartyCount);
            Assert.AreEqual(2, party.FindRegistration(participantC.Id));
            Assert.AreEqual(true, party.IsRegistered(participantC.Id));
            Assert.AreEqual(3, party.ParticipantCount);

            bool isRegistrationDSuccessful = party.Register(participantD);
            Assert.AreEqual(false, isRegistrationDSuccessful);
            Assert.AreEqual(0, participantD.PartyCount);
            Assert.AreEqual(-1, party.FindRegistration(participantD.Id));
            Assert.AreEqual(false, party.IsRegistered(participantD.Id));
            Assert.AreEqual(3, party.ParticipantCount);

            bool isUnregistrationBSuccessful = party.Unregister(participantB);
            Assert.AreEqual(true, isUnregistrationBSuccessful);
            Assert.AreEqual(0, participantB.PartyCount);
            Assert.AreEqual(-1, party.FindRegistration(participantB.Id));
            Assert.AreEqual(false, party.IsRegistered(participantB.Id));
            Assert.AreEqual(2, party.ParticipantCount);

            isRegistrationDSuccessful = party.Register(participantD);
            Assert.AreEqual(true, isRegistrationDSuccessful);
            Assert.AreEqual(1, participantD.PartyCount);
            Assert.AreEqual(1, party.FindRegistration(participantD.Id));
            Assert.AreEqual(true, party.IsRegistered(participantD.Id));
            Assert.AreEqual(3, party.ParticipantCount);

            bool isUnregistrationASuccessful = party.Unregister(participantA);
            Assert.AreEqual(true, isUnregistrationASuccessful);
            Assert.AreEqual(0, participantA.PartyCount);
            Assert.AreEqual(-1, party.FindRegistration(participantA.Id));
            Assert.AreEqual(false, party.IsRegistered(participantA.Id));
            Assert.AreEqual(2, party.ParticipantCount);

            isRegistrationBSuccessful = party.Register(participantB);
            Assert.AreEqual(true, isRegistrationBSuccessful);
            Assert.AreEqual(1, participantB.PartyCount);
            Assert.AreEqual(0, party.FindRegistration(participantB.Id));
            Assert.AreEqual(true, party.IsRegistered(participantB.Id));
            Assert.AreEqual(3, party.ParticipantCount);

            isUnregistrationASuccessful = party.Unregister(participantA);
            Assert.AreEqual(false, isUnregistrationASuccessful);
            Assert.AreEqual(0, participantA.PartyCount);
            Assert.AreEqual(-1, party.FindRegistration(participantA.Id));
            Assert.AreEqual(false, party.IsRegistered(participantA.Id));
            Assert.AreEqual(3, party.ParticipantCount);
        }

        [TestMethod]
        public void TestCancel()
        {
            Person organizer = new Person("Jan", "Novak", "novak@budejovice.cz");
            DateTime date = new DateTime(2020, 2, 3);

            Party party = new Party("Java & Jazz Party", date, organizer, 3);
            Assert.AreEqual(0, party.ParticipantCount);

            Person participantA = new Person("Juan", "Perez");
            Assert.AreEqual(0, participantA.PartyCount);

            Person participantB = new Person("Marko", "Markovic", "markymark@gmail.com");
            Assert.AreEqual(0, participantB.PartyCount);

            Person participantC = new Person("Kalle", "Svensson", "kalle@ikea.com");
            Assert.AreEqual(0, participantC.PartyCount);

            bool isRegistrationASuccessful = party.Register(participantA);
            Assert.AreEqual(true, isRegistrationASuccessful);
            Assert.AreEqual(1, participantA.PartyCount);
            Assert.AreEqual(0, party.FindRegistration(participantA.Id));
            Assert.AreEqual(true, party.IsRegistered(participantA.Id));
            Assert.AreEqual(1, party.ParticipantCount);

            bool isRegistrationBSuccessful = party.Register(participantB);
            Assert.AreEqual(true, isRegistrationBSuccessful);
            Assert.AreEqual(1, participantB.PartyCount);
            Assert.AreEqual(1, party.FindRegistration(participantB.Id));
            Assert.AreEqual(true, party.IsRegistered(participantB.Id));
            Assert.AreEqual(2, party.ParticipantCount);

            Assert.AreEqual(false, party.IsCancelled);

            party.Cancel();

            Assert.AreEqual(true, party.IsCancelled);

            Assert.AreEqual(0, participantA.PartyCount);
            Assert.AreEqual(0, participantB.PartyCount);

            bool isRegistrationCSuccessful = party.Register(participantC);
            Assert.AreEqual(false, isRegistrationCSuccessful);
            Assert.AreEqual(0, participantC.PartyCount);
            Assert.AreEqual(-1, party.FindRegistration(participantC.Id));
            Assert.AreEqual(false, party.IsRegistered(participantC.Id));
        }

        [TestMethod]
        public void TestToString()
        {
            Person organizer = new Person("Jan", "Novak", "novak@budejovice.cz");
            DateTime date = new DateTime(2020, 2, 3);

            Party party = new Party("Java & Jazz Party", date, organizer, 2);

            Assert.AreEqual("3.2.2020 - Java & Jazz Party (0/2)", party.ToString());

            Person participantA = new Person("Juan", "Perez");
            party.Register(participantA);

            Assert.AreEqual("3.2.2020 - Java & Jazz Party (1/2)", party.ToString());

            Person participantB = new Person("Marko", "Markovic", "markymark@gmail.com");
            party.Register(participantB);

            Assert.AreEqual("3.2.2020 - Java & Jazz Party (2/2)", party.ToString());

            Person participantC = new Person("Kalle", "Svensson", "kalle@ikea.com");
            party.Register(participantC);

            Assert.AreEqual("3.2.2020 - Java & Jazz Party (2/2)", party.ToString());

            party.Unregister(participantA);

            Assert.AreEqual("3.2.2020 - Java & Jazz Party (1/2)", party.ToString());

            date = new DateTime(2021, 5, 23);
            party = new Party("Meisterfeier", date, organizer, 100);

            Assert.AreEqual("23.5.2021 - Meisterfeier (0/100)", party.ToString());
        }
    }
}
