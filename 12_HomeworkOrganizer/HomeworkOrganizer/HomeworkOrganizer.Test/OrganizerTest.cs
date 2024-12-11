using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeworkOrganizer.Test
{
    [TestClass]
    public class OrganizerTest
    {
        [TestMethod]
        public void TestEmptyOrganizer()
        {
            Organizer organizer = new Organizer();

            Assert.AreEqual(null, organizer.GetHomeworkAt(0));
            Assert.AreEqual(null, organizer.GetHomeworkAt(5));
            Assert.AreEqual(0, organizer.HomeworkCount);
            Assert.AreEqual(0, organizer.GetHomeworkCountByCourse("SEW"));
            Assert.AreEqual(0, organizer.GetHomeworkCountByCourse("KIDS"));
            Assert.AreEqual(0, organizer.GetHomeworkCountByCourse("LOAL"));
            Assert.AreEqual(0, organizer.GetHomeworkCountByCourse("LINZ"));
            Assert.AreEqual(0, organizer.GetHomeworkCountBetweenDates(new DateTime(2022, 2, 14, 12, 0, 0), new DateTime(2022, 3, 10, 12, 0, 0)));
        }

        [TestMethod]
        public void TestAddHomeworkCountsCorrect()
        {
            Organizer organizer = new Organizer();

            Homework homeworkSewRpn = new Homework(141520, "SEW", "RPN-Calculator", new DateTime(2022, 3, 13, 23, 55, 0));
            organizer.AddHomework(homeworkSewRpn);
            Homework homeworkSewNecklace = new Homework(140708, "SEW", "Necklace", new DateTime(2022, 3, 6, 23, 55, 0));
            organizer.AddHomework(homeworkSewNecklace);
            Homework homeworkSewStudentMgmt = new Homework(139686, "SEW", "Student Management", new DateTime(2022, 2, 13, 23, 55, 0));
            organizer.AddHomework(homeworkSewStudentMgmt);
            Homework homeworkSewParty = new Homework(138665, "SEW", "Party Calendar", new DateTime(2022, 1, 16, 23, 55, 0));
            organizer.AddHomework(homeworkSewParty);
            Homework homeworkKidsHeart = new Homework(141617, "KIDS", "Heart Failures", new DateTime(2022, 3, 22, 8, 0, 0));
            organizer.AddHomework(homeworkKidsHeart);
            Homework homeworkKidsWater = new Homework(140929, "KIDS", "Water Potability", new DateTime(2022, 3, 1, 8, 0, 0));
            organizer.AddHomework(homeworkKidsWater);
            Homework homeworkKidsPenguins = new Homework(137694, "KIDS", "Penguin Visualization", new DateTime(2022, 1, 11, 8, 0, 0));
            organizer.AddHomework(homeworkKidsPenguins);
            Homework homeworkLoalPredicates = new Homework(128101, "LOAL", "Predicate Logic", new DateTime(2022, 3, 1, 10, 5, 0));
            organizer.AddHomework(homeworkLoalPredicates);
            Homework homeworkLoalPokedex = new Homework(128111, "LOAL", "Prolog-Pokedex", new DateTime(2022, 3, 22, 10, 5, 0));
            organizer.AddHomework(homeworkLoalPokedex);

            Assert.AreEqual(9, organizer.HomeworkCount);

            Assert.AreEqual(4, organizer.GetHomeworkCountByCourse("SEW"));
            Assert.AreEqual(3, organizer.GetHomeworkCountByCourse("KIDS"));
            Assert.AreEqual(2, organizer.GetHomeworkCountByCourse("LOAL"));
            Assert.AreEqual(0, organizer.GetHomeworkCountByCourse("LINZ"));

            Assert.AreEqual(3, organizer.GetHomeworkCountBetweenDates(new DateTime(2022, 2, 14, 12, 0, 0), new DateTime(2022, 3, 10, 12, 0, 0)));
            Assert.AreEqual(0, organizer.GetHomeworkCountBetweenDates(new DateTime(2022, 1, 1, 8, 0, 0), new DateTime(2022, 1, 11, 7, 59, 0)));
            Assert.AreEqual(8, organizer.GetHomeworkCountBetweenDates(new DateTime(2022, 1, 11, 12, 0, 0), new DateTime(2022, 4, 1, 12, 0, 0)));
            Assert.AreEqual(6, organizer.GetHomeworkCountBetweenDates(new DateTime(2022, 3, 1, 7, 0, 0), new DateTime(2022, 3, 31, 23, 59, 0)));
        }

        [TestMethod]
        public void TestIllegalDateRangeThrowsException()
        {
            Organizer organizer = new Organizer();

            Homework homeworkSewParty = new Homework(138665, "SEW", "Party Calendar", new DateTime(2022, 1, 16, 23, 55, 0));
            organizer.AddHomework(homeworkSewParty);
            Homework homeworkKidsHeart = new Homework(141617, "KIDS", "Heart Failures", new DateTime(2022, 3, 22, 8, 0, 0));
            organizer.AddHomework(homeworkKidsHeart);

            ArgumentException ex = Assert.ThrowsException<ArgumentException>(() =>
            {
                organizer.GetHomeworkCountBetweenDates(new DateTime(2022, 3, 13, 12, 0, 0), new DateTime(2022, 3, 12, 12, 0, 0));
            });

            Assert.AreEqual("From-Date must be before To-Date!", ex.Message);
        }


        [TestMethod]
        public void TestAddHomeworkPositionsCorrect()
        {
            Organizer organizer = new Organizer();

            Homework homeworkSewRpn = new Homework(141520, "SEW", "RPN-Calculator", new DateTime(2022, 3, 13, 23, 55, 0));
            organizer.AddHomework(homeworkSewRpn);
            Homework homeworkSewNecklace = new Homework(140708, "SEW", "Necklace", new DateTime(2022, 3, 6, 23, 55, 0));
            organizer.AddHomework(homeworkSewNecklace);
            Homework homeworkSewStudentMgmt = new Homework(139686, "SEW", "Student Management", new DateTime(2022, 2, 13, 23, 55, 0));
            organizer.AddHomework(homeworkSewStudentMgmt);
            Homework homeworkSewParty = new Homework(138665, "SEW", "Party Calendar", new DateTime(2022, 1, 16, 23, 55, 0));
            organizer.AddHomework(homeworkSewParty);
            Homework homeworkKidsHeart = new Homework(141617, "KIDS", "Heart Failures", new DateTime(2022, 3, 22, 8, 00, 0));
            organizer.AddHomework(homeworkKidsHeart);
            Homework homeworkKidsWater = new Homework(140929, "KIDS", "Water Potability", new DateTime(2022, 3, 1, 8, 0, 0));
            organizer.AddHomework(homeworkKidsWater);
            Homework homeworkKidsPenguins = new Homework(137694, "KIDS", "Penguin Visualization", new DateTime(2022, 1, 11, 8, 00, 0));
            organizer.AddHomework(homeworkKidsPenguins);
            Homework homeworkLoalPredicates = new Homework(128101, "LOAL", "Predicate Logic", new DateTime(2022, 3, 1, 10, 50, 0));
            organizer.AddHomework(homeworkLoalPredicates);
            Homework homeworkLoalPokedex = new Homework(128111, "LOAL", "Prolog-Pokedex", new DateTime(2022, 3, 22, 10, 50, 0));
            organizer.AddHomework(homeworkLoalPokedex);

            Assert.AreEqual(homeworkKidsPenguins, organizer.GetHomeworkAt(0));
            Assert.AreEqual(homeworkSewParty, organizer.GetHomeworkAt(1));
            Assert.AreEqual(homeworkSewStudentMgmt, organizer.GetHomeworkAt(2));
            Assert.AreEqual(homeworkKidsWater, organizer.GetHomeworkAt(3));
            Assert.AreEqual(homeworkLoalPredicates, organizer.GetHomeworkAt(4));
            Assert.AreEqual(homeworkSewNecklace, organizer.GetHomeworkAt(5));
            Assert.AreEqual(homeworkSewRpn, organizer.GetHomeworkAt(6));
            Assert.AreEqual(homeworkKidsHeart, organizer.GetHomeworkAt(7));
            Assert.AreEqual(homeworkLoalPokedex, organizer.GetHomeworkAt(8));
            Assert.AreEqual(null, organizer.GetHomeworkAt(9));
        }

        [TestMethod]
        public void TestAddHomeworkPositionsCorrectWithIndexer()
        {
            Organizer organizer = new Organizer();

            Homework homeworkSewRpn = new Homework(141520, "SEW", "RPN-Calculator", new DateTime(2022, 3, 13, 23, 55, 0));
            organizer.AddHomework(homeworkSewRpn);
            Homework homeworkSewNecklace = new Homework(140708, "SEW", "Necklace", new DateTime(2022, 3, 6, 23, 55, 0));
            organizer.AddHomework(homeworkSewNecklace);
            Homework homeworkSewStudentMgmt = new Homework(139686, "SEW", "Student Management", new DateTime(2022, 2, 13, 23, 55, 0));
            organizer.AddHomework(homeworkSewStudentMgmt);
            Homework homeworkSewParty = new Homework(138665, "SEW", "Party Calendar", new DateTime(2022, 1, 16, 23, 55, 0));
            organizer.AddHomework(homeworkSewParty);
            Homework homeworkKidsHeart = new Homework(141617, "KIDS", "Heart Failures", new DateTime(2022, 3, 22, 8, 00, 0));
            organizer.AddHomework(homeworkKidsHeart);
            Homework homeworkKidsWater = new Homework(140929, "KIDS", "Water Potability", new DateTime(2022, 3, 1, 8, 0, 0));
            organizer.AddHomework(homeworkKidsWater);
            Homework homeworkKidsPenguins = new Homework(137694, "KIDS", "Penguin Visualization", new DateTime(2022, 1, 11, 8, 00, 0));
            organizer.AddHomework(homeworkKidsPenguins);
            Homework homeworkLoalPredicates = new Homework(128101, "LOAL", "Predicate Logic", new DateTime(2022, 3, 1, 10, 50, 0));
            organizer.AddHomework(homeworkLoalPredicates);
            Homework homeworkLoalPokedex = new Homework(128111, "LOAL", "Prolog-Pokedex", new DateTime(2022, 3, 22, 10, 50, 0));
            organizer.AddHomework(homeworkLoalPokedex);

            Assert.AreEqual(homeworkKidsPenguins, organizer[0]);
            Assert.AreEqual(homeworkSewParty, organizer[1]);
            Assert.AreEqual(homeworkSewStudentMgmt, organizer[2]);
            Assert.AreEqual(homeworkKidsWater, organizer[3]);
            Assert.AreEqual(homeworkLoalPredicates, organizer[4]);
            Assert.AreEqual(homeworkSewNecklace, organizer[5]);
            Assert.AreEqual(homeworkSewRpn, organizer[6]);
            Assert.AreEqual(homeworkKidsHeart, organizer[7]);
            Assert.AreEqual(homeworkLoalPokedex, organizer[8]);
            Assert.AreEqual(null, organizer[9]);
        }

        [TestMethod]
        public void TestTurnInHomeworkReturnValueCorrect()
        {
            Organizer organizer = new Organizer();

            Homework homeworkSewRpn = new Homework(141520, "SEW", "RPN-Calculator", new DateTime(2022, 3, 13, 23, 55, 0));
            organizer.AddHomework(homeworkSewRpn);
            Homework homeworkSewNecklace = new Homework(140708, "SEW", "Necklace", new DateTime(2022, 3, 6, 23, 55, 0));
            organizer.AddHomework(homeworkSewNecklace);
            Homework homeworkSewStudentMgmt = new Homework(139686, "SEW", "Student Management", new DateTime(2022, 2, 13, 23, 55, 0));
            organizer.AddHomework(homeworkSewStudentMgmt);
            Homework homeworkSewParty = new Homework(138665, "SEW", "Party Calendar", new DateTime(2022, 1, 16, 23, 55, 0));
            organizer.AddHomework(homeworkSewParty);
            Homework homeworkKidsHeart = new Homework(141617, "KIDS", "Heart Failures", new DateTime(2022, 3, 22, 8, 00, 0));
            organizer.AddHomework(homeworkKidsHeart);
            Homework homeworkKidsWater = new Homework(140929, "KIDS", "Water Potability", new DateTime(2022, 3, 1, 8, 00, 0));
            organizer.AddHomework(homeworkKidsWater);
            Homework homeworkKidsPenguins = new Homework(137694, "KIDS", "Penguin Visualization", new DateTime(2022, 1, 11, 8, 00, 0));
            organizer.AddHomework(homeworkKidsPenguins);
            Homework homeworkLoalPredicates = new Homework(128101, "LOAL", "Predicate Logic", new DateTime(2022, 3, 1, 10, 50, 0));
            organizer.AddHomework(homeworkLoalPredicates);
            Homework homeworkLoalPokedex = new Homework(128111, "LOAL", "Prolog-Pokedex", new DateTime(2022, 3, 22, 10, 50, 0));
            organizer.AddHomework(homeworkLoalPokedex);

            Assert.AreEqual(true, organizer.TurnInHomework(138665)); //SEW - Party Calendar
            Assert.AreEqual(false, organizer.TurnInHomework(138665)); //SEW - Party Calendar
            Assert.AreEqual(true, organizer.TurnInHomework(141617)); //KIDS - Heart Failure
            Assert.AreEqual(false, organizer.TurnInHomework(123456)); //random number
            Assert.AreEqual(true, organizer.TurnInHomework(128111)); //LOAL - Prolog Pokedex
            Assert.AreEqual(false, organizer.TurnInHomework(124020)); //random number
        }

        [TestMethod]
        public void TestTurnInHomeworkCountsCorrect()
        {
            Organizer organizer = new Organizer();

            Homework homeworkSewRpn = new Homework(141520, "SEW", "RPN-Calculator", new DateTime(2022, 3, 13, 23, 55, 0));
            organizer.AddHomework(homeworkSewRpn);
            Homework homeworkSewNecklace = new Homework(140708, "SEW", "Necklace", new DateTime(2022, 3, 6, 23, 55, 0));
            organizer.AddHomework(homeworkSewNecklace);
            Homework homeworkSewStudentMgmt = new Homework(139686, "SEW", "Student Management", new DateTime(2022, 2, 13, 23, 55, 0));
            organizer.AddHomework(homeworkSewStudentMgmt);
            Homework homeworkSewParty = new Homework(138665, "SEW", "Party Calendar", new DateTime(2022, 1, 16, 23, 55, 0));
            organizer.AddHomework(homeworkSewParty);
            Homework homeworkKidsHeart = new Homework(141617, "KIDS", "Heart Failures", new DateTime(2022, 3, 22, 8, 00, 0));
            organizer.AddHomework(homeworkKidsHeart);
            Homework homeworkKidsWater = new Homework(140929, "KIDS", "Water Potability", new DateTime(2022, 3, 1, 8, 00, 0));
            organizer.AddHomework(homeworkKidsWater);
            Homework homeworkKidsPenguins = new Homework(137694, "KIDS", "Penguin Visualization", new DateTime(2022, 1, 11, 8, 00, 0));
            organizer.AddHomework(homeworkKidsPenguins);
            Homework homeworkLoalPredicates = new Homework(128101, "LOAL", "Predicate Logic", new DateTime(2022, 3, 1, 10, 50, 0));
            organizer.AddHomework(homeworkLoalPredicates);
            Homework homeworkLoalPokedex = new Homework(128111, "LOAL", "Prolog-Pokedex", new DateTime(2022, 3, 22, 10, 50, 0));
            organizer.AddHomework(homeworkLoalPokedex);

            organizer.TurnInHomework(139686); //SEW - Student Management

            Assert.AreEqual(8, organizer.HomeworkCount);

            Assert.AreEqual(3, organizer.GetHomeworkCountByCourse("SEW"));
            Assert.AreEqual(3, organizer.GetHomeworkCountByCourse("KIDS"));
            Assert.AreEqual(2, organizer.GetHomeworkCountByCourse("LOAL"));
            Assert.AreEqual(0, organizer.GetHomeworkCountByCourse("LINZ"));

            Assert.AreEqual(3, organizer.GetHomeworkCountBetweenDates(new DateTime(2022, 2, 14, 12, 0, 0), new DateTime(2022, 3, 10, 12, 0, 0)));
            Assert.AreEqual(0, organizer.GetHomeworkCountBetweenDates(new DateTime(2022, 1, 1, 8, 0, 0), new DateTime(2022, 1, 11, 7, 59, 0)));
            Assert.AreEqual(7, organizer.GetHomeworkCountBetweenDates(new DateTime(2022, 1, 11, 12, 0, 0), new DateTime(2022, 4, 1, 12, 0, 0)));
            Assert.AreEqual(6, organizer.GetHomeworkCountBetweenDates(new DateTime(2022, 3, 1, 7, 0, 0), new DateTime(2022, 3, 31, 23, 59, 0)));

            organizer.TurnInHomework(141617); //KIDS - Heart Failures

            Assert.AreEqual(7, organizer.HomeworkCount);

            Assert.AreEqual(3, organizer.GetHomeworkCountByCourse("SEW"));
            Assert.AreEqual(2, organizer.GetHomeworkCountByCourse("KIDS"));
            Assert.AreEqual(2, organizer.GetHomeworkCountByCourse("LOAL"));
            Assert.AreEqual(0, organizer.GetHomeworkCountByCourse("LINZ"));

            Assert.AreEqual(3, organizer.GetHomeworkCountBetweenDates(new DateTime(2022, 2, 14, 12, 0, 0), new DateTime(2022, 3, 10, 12, 0, 0)));
            Assert.AreEqual(0, organizer.GetHomeworkCountBetweenDates(new DateTime(2022, 1, 1, 8, 0, 0), new DateTime(2022, 1, 11, 7, 59, 0)));
            Assert.AreEqual(6, organizer.GetHomeworkCountBetweenDates(new DateTime(2022, 1, 11, 12, 0, 0), new DateTime(2022, 4, 1, 12, 0, 0)));
            Assert.AreEqual(5, organizer.GetHomeworkCountBetweenDates(new DateTime(2022, 3, 1, 7, 0, 0), new DateTime(2022, 3, 31, 23, 59, 0)));

            organizer.TurnInHomework(141617); //KIDS - Heart Failures - again

            Assert.AreEqual(7, organizer.HomeworkCount);

            Assert.AreEqual(3, organizer.GetHomeworkCountByCourse("SEW"));
            Assert.AreEqual(2, organizer.GetHomeworkCountByCourse("KIDS"));
            Assert.AreEqual(2, organizer.GetHomeworkCountByCourse("LOAL"));
            Assert.AreEqual(0, organizer.GetHomeworkCountByCourse("LINZ"));

            Assert.AreEqual(3, organizer.GetHomeworkCountBetweenDates(new DateTime(2022, 2, 14, 12, 0, 0), new DateTime(2022, 3, 10, 12, 0, 0)));
            Assert.AreEqual(0, organizer.GetHomeworkCountBetweenDates(new DateTime(2022, 1, 1, 8, 0, 0), new DateTime(2022, 1, 11, 7, 59, 0)));
            Assert.AreEqual(6, organizer.GetHomeworkCountBetweenDates(new DateTime(2022, 1, 11, 12, 0, 0), new DateTime(2022, 4, 1, 12, 0, 0)));
            Assert.AreEqual(5, organizer.GetHomeworkCountBetweenDates(new DateTime(2022, 3, 1, 7, 0, 0), new DateTime(2022, 3, 31, 23, 59, 0)));

            organizer.TurnInHomework(137694); //KIDS - Penguin Visualizations

            Assert.AreEqual(6, organizer.HomeworkCount);

            Assert.AreEqual(3, organizer.GetHomeworkCountByCourse("SEW"));
            Assert.AreEqual(1, organizer.GetHomeworkCountByCourse("KIDS"));
            Assert.AreEqual(2, organizer.GetHomeworkCountByCourse("LOAL"));
            Assert.AreEqual(0, organizer.GetHomeworkCountByCourse("LINZ"));

            Assert.AreEqual(3, organizer.GetHomeworkCountBetweenDates(new DateTime(2022, 2, 14, 12, 0, 0), new DateTime(2022, 3, 10, 12, 0, 0)));
            Assert.AreEqual(0, organizer.GetHomeworkCountBetweenDates(new DateTime(2022, 1, 1, 8, 0, 0), new DateTime(2022, 1, 11, 7, 59, 0)));
            Assert.AreEqual(6, organizer.GetHomeworkCountBetweenDates(new DateTime(2022, 1, 11, 12, 0, 0), new DateTime(2022, 4, 1, 12, 0, 0)));
            Assert.AreEqual(5, organizer.GetHomeworkCountBetweenDates(new DateTime(2022, 3, 1, 7, 0, 0), new DateTime(2022, 3, 31, 23, 59, 0)));
        }

        [TestMethod]
        public void TestTurnInHomeworkPositionsCorrect()
        {
            Organizer organizer = new Organizer();

            Homework homeworkSewRpn = new Homework(141520, "SEW", "RPN-Calculator", new DateTime(2022, 3, 13, 23, 55, 0));
            organizer.AddHomework(homeworkSewRpn);
            Homework homeworkSewNecklace = new Homework(140708, "SEW", "Necklace", new DateTime(2022, 3, 6, 23, 55, 0));
            organizer.AddHomework(homeworkSewNecklace);
            Homework homeworkSewStudentMgmt = new Homework(139686, "SEW", "Student Management", new DateTime(2022, 2, 13, 23, 55, 0));
            organizer.AddHomework(homeworkSewStudentMgmt);
            Homework homeworkSewParty = new Homework(138665, "SEW", "Party Calendar", new DateTime(2022, 1, 16, 23, 55, 0));
            organizer.AddHomework(homeworkSewParty);
            Homework homeworkKidsHeart = new Homework(141617, "KIDS", "Heart Failures", new DateTime(2022, 3, 22, 8, 00, 0));
            organizer.AddHomework(homeworkKidsHeart);
            Homework homeworkKidsWater = new Homework(140929, "KIDS", "Water Potability", new DateTime(2022, 3, 1, 8, 00, 0));
            organizer.AddHomework(homeworkKidsWater);
            Homework homeworkKidsPenguins = new Homework(137694, "KIDS", "Penguin Visualization", new DateTime(2022, 1, 11, 8, 00, 0));
            organizer.AddHomework(homeworkKidsPenguins);
            Homework homeworkLoalPredicates = new Homework(128101, "LOAL", "Predicate Logic", new DateTime(2022, 3, 1, 10, 50, 0));
            organizer.AddHomework(homeworkLoalPredicates);
            Homework homeworkLoalPokedex = new Homework(128111, "LOAL", "Prolog-Pokedex", new DateTime(2022, 3, 22, 10, 50, 0));
            organizer.AddHomework(homeworkLoalPokedex);

            organizer.TurnInHomework(140929); //KIDS - Water Potability

            Assert.AreEqual(homeworkKidsPenguins, organizer.GetHomeworkAt(0));
            Assert.AreEqual(homeworkSewParty, organizer.GetHomeworkAt(1));
            Assert.AreEqual(homeworkSewStudentMgmt, organizer.GetHomeworkAt(2));
            Assert.AreEqual(homeworkLoalPredicates, organizer.GetHomeworkAt(3));
            Assert.AreEqual(homeworkSewNecklace, organizer.GetHomeworkAt(4));
            Assert.AreEqual(homeworkSewRpn, organizer.GetHomeworkAt(5));
            Assert.AreEqual(homeworkKidsHeart, organizer.GetHomeworkAt(6));
            Assert.AreEqual(homeworkLoalPokedex, organizer.GetHomeworkAt(7));
            Assert.AreEqual(null, organizer.GetHomeworkAt(8));

            organizer.TurnInHomework(137694); //KIDS - Penguin Visualization

            Assert.AreEqual(homeworkSewParty, organizer.GetHomeworkAt(0));
            Assert.AreEqual(homeworkSewStudentMgmt, organizer.GetHomeworkAt(1));
            Assert.AreEqual(homeworkLoalPredicates, organizer.GetHomeworkAt(2));
            Assert.AreEqual(homeworkSewNecklace, organizer.GetHomeworkAt(3));
            Assert.AreEqual(homeworkSewRpn, organizer.GetHomeworkAt(4));
            Assert.AreEqual(homeworkKidsHeart, organizer.GetHomeworkAt(5));
            Assert.AreEqual(homeworkLoalPokedex, organizer.GetHomeworkAt(6));
            Assert.AreEqual(null, organizer.GetHomeworkAt(7));

            organizer.TurnInHomework(137694); //KIDS - Penguin Visualization - again

            Assert.AreEqual(homeworkSewParty, organizer.GetHomeworkAt(0));
            Assert.AreEqual(homeworkSewStudentMgmt, organizer.GetHomeworkAt(1));
            Assert.AreEqual(homeworkLoalPredicates, organizer.GetHomeworkAt(2));
            Assert.AreEqual(homeworkSewNecklace, organizer.GetHomeworkAt(3));
            Assert.AreEqual(homeworkSewRpn, organizer.GetHomeworkAt(4));
            Assert.AreEqual(homeworkKidsHeart, organizer.GetHomeworkAt(5));
            Assert.AreEqual(homeworkLoalPokedex, organizer.GetHomeworkAt(6));
            Assert.AreEqual(null, organizer.GetHomeworkAt(7));

            organizer.TurnInHomework(141520); //SEW - RPN Calculator

            Assert.AreEqual(homeworkSewParty, organizer.GetHomeworkAt(0));
            Assert.AreEqual(homeworkSewStudentMgmt, organizer.GetHomeworkAt(1));
            Assert.AreEqual(homeworkLoalPredicates, organizer.GetHomeworkAt(2));
            Assert.AreEqual(homeworkSewNecklace, organizer.GetHomeworkAt(3));
            Assert.AreEqual(homeworkKidsHeart, organizer.GetHomeworkAt(4));
            Assert.AreEqual(homeworkLoalPokedex, organizer.GetHomeworkAt(5));
            Assert.AreEqual(null, organizer.GetHomeworkAt(6));

            organizer.TurnInHomework(128111); //LOAL - Prolog Pokedex

            Assert.AreEqual(homeworkSewParty, organizer.GetHomeworkAt(0));
            Assert.AreEqual(homeworkSewStudentMgmt, organizer.GetHomeworkAt(1));
            Assert.AreEqual(homeworkLoalPredicates, organizer.GetHomeworkAt(2));
            Assert.AreEqual(homeworkSewNecklace, organizer.GetHomeworkAt(3));
            Assert.AreEqual(homeworkKidsHeart, organizer.GetHomeworkAt(4));
            Assert.AreEqual(null, organizer.GetHomeworkAt(5));
        }

        [TestMethod]
        public void TestTurnInHomeworkPositionsCorrectWithIndexer()
        {
            Organizer organizer = new Organizer();

            Homework homeworkSewRpn = new Homework(141520, "SEW", "RPN-Calculator", new DateTime(2022, 3, 13, 23, 55, 0));
            organizer.AddHomework(homeworkSewRpn);
            Homework homeworkSewNecklace = new Homework(140708, "SEW", "Necklace", new DateTime(2022, 3, 6, 23, 55, 0));
            organizer.AddHomework(homeworkSewNecklace);
            Homework homeworkSewStudentMgmt = new Homework(139686, "SEW", "Student Management", new DateTime(2022, 2, 13, 23, 55, 0));
            organizer.AddHomework(homeworkSewStudentMgmt);
            Homework homeworkSewParty = new Homework(138665, "SEW", "Party Calendar", new DateTime(2022, 1, 16, 23, 55, 0));
            organizer.AddHomework(homeworkSewParty);
            Homework homeworkKidsHeart = new Homework(141617, "KIDS", "Heart Failures", new DateTime(2022, 3, 22, 8, 00, 0));
            organizer.AddHomework(homeworkKidsHeart);
            Homework homeworkKidsWater = new Homework(140929, "KIDS", "Water Potability", new DateTime(2022, 3, 1, 8, 00, 0));
            organizer.AddHomework(homeworkKidsWater);
            Homework homeworkKidsPenguins = new Homework(137694, "KIDS", "Penguin Visualization", new DateTime(2022, 1, 11, 8, 00, 0));
            organizer.AddHomework(homeworkKidsPenguins);
            Homework homeworkLoalPredicates = new Homework(128101, "LOAL", "Predicate Logic", new DateTime(2022, 3, 1, 10, 50, 0));
            organizer.AddHomework(homeworkLoalPredicates);
            Homework homeworkLoalPokedex = new Homework(128111, "LOAL", "Prolog-Pokedex", new DateTime(2022, 3, 22, 10, 50, 0));
            organizer.AddHomework(homeworkLoalPokedex);

            organizer.TurnInHomework(140929); //KIDS - Water Potability

            Assert.AreEqual(homeworkKidsPenguins, organizer[0]);
            Assert.AreEqual(homeworkSewParty, organizer[1]);
            Assert.AreEqual(homeworkSewStudentMgmt, organizer[2]);
            Assert.AreEqual(homeworkLoalPredicates, organizer[3]);
            Assert.AreEqual(homeworkSewNecklace, organizer[4]);
            Assert.AreEqual(homeworkSewRpn, organizer[5]);
            Assert.AreEqual(homeworkKidsHeart, organizer[6]);
            Assert.AreEqual(homeworkLoalPokedex, organizer[7]);
            Assert.AreEqual(null, organizer[8]);

            organizer.TurnInHomework(137694); //KIDS - Penguin Visualization

            Assert.AreEqual(homeworkSewParty, organizer[0]);
            Assert.AreEqual(homeworkSewStudentMgmt, organizer[1]);
            Assert.AreEqual(homeworkLoalPredicates, organizer[2]);
            Assert.AreEqual(homeworkSewNecklace, organizer[3]);
            Assert.AreEqual(homeworkSewRpn, organizer.GetHomeworkAt(4));
            Assert.AreEqual(homeworkKidsHeart, organizer[5]);
            Assert.AreEqual(homeworkLoalPokedex, organizer[6]);
            Assert.AreEqual(null, organizer[7]);

            organizer.TurnInHomework(137694); //KIDS - Penguin Visualization - again

            Assert.AreEqual(homeworkSewParty, organizer[0]);
            Assert.AreEqual(homeworkSewStudentMgmt, organizer[1]);
            Assert.AreEqual(homeworkLoalPredicates, organizer[2]);
            Assert.AreEqual(homeworkSewNecklace, organizer[3]);
            Assert.AreEqual(homeworkSewRpn, organizer.GetHomeworkAt(4));
            Assert.AreEqual(homeworkKidsHeart, organizer[5]);
            Assert.AreEqual(homeworkLoalPokedex, organizer[6]);
            Assert.AreEqual(null, organizer[7]);

            organizer.TurnInHomework(141520); //SEW - RPN Calculator

            Assert.AreEqual(homeworkSewParty, organizer[0]);
            Assert.AreEqual(homeworkSewStudentMgmt, organizer[1]);
            Assert.AreEqual(homeworkLoalPredicates, organizer[2]);
            Assert.AreEqual(homeworkSewNecklace, organizer[3]);
            Assert.AreEqual(homeworkKidsHeart, organizer[4]);
            Assert.AreEqual(homeworkLoalPokedex, organizer[5]);
            Assert.AreEqual(null, organizer[6]);

            organizer.TurnInHomework(128111); //LOAL - Prolog Pokedex

            Assert.AreEqual(homeworkSewParty, organizer[0]);
            Assert.AreEqual(homeworkSewStudentMgmt, organizer[1]);
            Assert.AreEqual(homeworkLoalPredicates, organizer[2]);
            Assert.AreEqual(homeworkSewNecklace, organizer[3]);
            Assert.AreEqual(homeworkKidsHeart, organizer[4]);
            Assert.AreEqual(null, organizer[5]);
        }

        [TestMethod]
        public void TestAddTurnInHomeworkCombinationPositionsCorrect()
        {
            Organizer organizer = new Organizer();

            Homework homeworkLoalPokedex = new Homework(128111, "LOAL", "Prolog-Pokedex", new DateTime(2022, 3, 22, 10, 50, 0));
            organizer.AddHomework(homeworkLoalPokedex);
            Homework homeworkSewRpn = new Homework(141520, "SEW", "RPN-Calculator", new DateTime(2022, 3, 13, 23, 55, 0));
            organizer.AddHomework(homeworkSewRpn);
            Homework homeworkKidsWater = new Homework(140929, "KIDS", "Water Potability", new DateTime(2022, 3, 1, 8, 00, 0));
            organizer.AddHomework(homeworkKidsWater);
            Homework homeworkSewNecklace = new Homework(140708, "SEW", "Necklace", new DateTime(2022, 3, 6, 23, 55, 0));
            organizer.AddHomework(homeworkSewNecklace);

            Assert.AreEqual(homeworkKidsWater, organizer.GetHomeworkAt(0));
            Assert.AreEqual(homeworkSewNecklace, organizer.GetHomeworkAt(1));
            Assert.AreEqual(homeworkSewRpn, organizer.GetHomeworkAt(2));
            Assert.AreEqual(homeworkLoalPokedex, organizer.GetHomeworkAt(3));
            Assert.AreEqual(null, organizer.GetHomeworkAt(4));

            organizer.TurnInHomework(128111); //LOAL - Prolog-Pokedex

            Assert.AreEqual(homeworkKidsWater, organizer.GetHomeworkAt(0));
            Assert.AreEqual(homeworkSewNecklace, organizer.GetHomeworkAt(1));
            Assert.AreEqual(homeworkSewRpn, organizer.GetHomeworkAt(2));
            Assert.AreEqual(null, organizer.GetHomeworkAt(3));

            Homework homeworkSewStudentMgmt = new Homework(139686, "SEW", "Student Management", new DateTime(2022, 2, 13, 23, 55, 0));
            organizer.AddHomework(homeworkSewStudentMgmt);
            Homework homeworkKidsHeart = new Homework(141617, "KIDS", "Heart Failures", new DateTime(2022, 3, 22, 8, 00, 0));
            organizer.AddHomework(homeworkKidsHeart);

            Assert.AreEqual(homeworkSewStudentMgmt, organizer.GetHomeworkAt(0));
            Assert.AreEqual(homeworkKidsWater, organizer.GetHomeworkAt(1));
            Assert.AreEqual(homeworkSewNecklace, organizer.GetHomeworkAt(2));
            Assert.AreEqual(homeworkSewRpn, organizer.GetHomeworkAt(3));
            Assert.AreEqual(homeworkKidsHeart, organizer.GetHomeworkAt(4));
            Assert.AreEqual(null, organizer.GetHomeworkAt(5));

            organizer.TurnInHomework(139686);
            organizer.TurnInHomework(140708);
            organizer.TurnInHomework(141617);
            organizer.TurnInHomework(140929);
            organizer.TurnInHomework(141520);

            Assert.AreEqual(null, organizer.GetHomeworkAt(0));

            Homework homeworkSewParty = new Homework(138665, "SEW", "Party Calendar", new DateTime(2022, 1, 16, 23, 55, 0));
            organizer.AddHomework(homeworkSewParty);
            Homework homeworkKidsPenguins = new Homework(137694, "KIDS", "Penguin Visualization", new DateTime(2022, 1, 11, 8, 00, 0));
            organizer.AddHomework(homeworkKidsPenguins);
            Homework homeworkLoalPredicates = new Homework(128101, "LOAL", "Predicate Logic", new DateTime(2022, 3, 1, 10, 50, 0));
            organizer.AddHomework(homeworkLoalPredicates);

            Assert.AreEqual(homeworkKidsPenguins, organizer.GetHomeworkAt(0));
            Assert.AreEqual(homeworkSewParty, organizer.GetHomeworkAt(1));
            Assert.AreEqual(homeworkLoalPredicates, organizer.GetHomeworkAt(2));
            Assert.AreEqual(null, organizer.GetHomeworkAt(3));

            organizer.TurnInHomework(137694); //KIDS - Penguin Visualization

            Assert.AreEqual(homeworkSewParty, organizer.GetHomeworkAt(0));
            Assert.AreEqual(homeworkLoalPredicates, organizer.GetHomeworkAt(1));
            Assert.AreEqual(null, organizer.GetHomeworkAt(2));
        }

        [TestMethod]
        public void TestAddTurnInHomeworkCombinationCountsCorrect()
        {
            Organizer organizer = new Organizer();

            Homework homeworkLoalPokedex = new Homework(128111, "LOAL", "Prolog-Pokedex", new DateTime(2022, 3, 22, 10, 50, 0));
            organizer.AddHomework(homeworkLoalPokedex);
            Homework homeworkSewRpn = new Homework(141520, "SEW", "RPN-Calculator", new DateTime(2022, 3, 13, 23, 55, 0));
            organizer.AddHomework(homeworkSewRpn);
            Homework homeworkKidsWater = new Homework(140929, "KIDS", "Water Potability", new DateTime(2022, 3, 1, 8, 00, 0));
            organizer.AddHomework(homeworkKidsWater);
            Homework homeworkSewNecklace = new Homework(140708, "SEW", "Necklace", new DateTime(2022, 3, 6, 23, 55, 0));
            organizer.AddHomework(homeworkSewNecklace);

            Assert.AreEqual(4, organizer.HomeworkCount);

            Assert.AreEqual(2, organizer.GetHomeworkCountByCourse("SEW"));
            Assert.AreEqual(1, organizer.GetHomeworkCountByCourse("KIDS"));
            Assert.AreEqual(1, organizer.GetHomeworkCountByCourse("LOAL"));
            Assert.AreEqual(0, organizer.GetHomeworkCountByCourse("LINZ"));

            Assert.AreEqual(2, organizer.GetHomeworkCountBetweenDates(new DateTime(2022, 2, 14, 12, 0, 0), new DateTime(2022, 3, 10, 12, 0, 0)));
            Assert.AreEqual(0, organizer.GetHomeworkCountBetweenDates(new DateTime(2022, 1, 1, 8, 0, 0), new DateTime(2022, 1, 11, 7, 59, 0)));
            Assert.AreEqual(4, organizer.GetHomeworkCountBetweenDates(new DateTime(2022, 1, 11, 12, 0, 0), new DateTime(2022, 4, 1, 12, 0, 0)));
            Assert.AreEqual(4, organizer.GetHomeworkCountBetweenDates(new DateTime(2022, 3, 1, 7, 0, 0), new DateTime(2022, 3, 31, 23, 59, 0)));

            organizer.TurnInHomework(128111); //LOAL - Prolog-Pokedex

            Assert.AreEqual(3, organizer.HomeworkCount);

            Assert.AreEqual(2, organizer.GetHomeworkCountByCourse("SEW"));
            Assert.AreEqual(1, organizer.GetHomeworkCountByCourse("KIDS"));
            Assert.AreEqual(0, organizer.GetHomeworkCountByCourse("LOAL"));
            Assert.AreEqual(0, organizer.GetHomeworkCountByCourse("LINZ"));

            Assert.AreEqual(2, organizer.GetHomeworkCountBetweenDates(new DateTime(2022, 2, 14, 12, 0, 0), new DateTime(2022, 3, 10, 12, 0, 0)));
            Assert.AreEqual(0, organizer.GetHomeworkCountBetweenDates(new DateTime(2022, 1, 1, 8, 0, 0), new DateTime(2022, 1, 11, 7, 59, 0)));
            Assert.AreEqual(3, organizer.GetHomeworkCountBetweenDates(new DateTime(2022, 1, 11, 12, 0, 0), new DateTime(2022, 4, 1, 12, 0, 0)));
            Assert.AreEqual(3, organizer.GetHomeworkCountBetweenDates(new DateTime(2022, 3, 1, 7, 0, 0), new DateTime(2022, 3, 31, 23, 59, 0)));

            Homework homeworkSewStudentMgmt = new Homework(139686, "SEW", "Student Management", new DateTime(2022, 2, 13, 23, 55, 0));
            organizer.AddHomework(homeworkSewStudentMgmt);
            Homework homeworkKidsHeart = new Homework(141617, "KIDS", "Heart Failures", new DateTime(2022, 3, 22, 8, 00, 0));
            organizer.AddHomework(homeworkKidsHeart);

            Assert.AreEqual(5, organizer.HomeworkCount);

            Assert.AreEqual(3, organizer.GetHomeworkCountByCourse("SEW"));
            Assert.AreEqual(2, organizer.GetHomeworkCountByCourse("KIDS"));
            Assert.AreEqual(0, organizer.GetHomeworkCountByCourse("LOAL"));
            Assert.AreEqual(0, organizer.GetHomeworkCountByCourse("LINZ"));

            Assert.AreEqual(2, organizer.GetHomeworkCountBetweenDates(new DateTime(2022, 2, 14, 12, 0, 0), new DateTime(2022, 3, 10, 12, 0, 0)));
            Assert.AreEqual(0, organizer.GetHomeworkCountBetweenDates(new DateTime(2022, 1, 1, 8, 0, 0), new DateTime(2022, 1, 11, 7, 59, 0)));
            Assert.AreEqual(5, organizer.GetHomeworkCountBetweenDates(new DateTime(2022, 1, 11, 12, 0, 0), new DateTime(2022, 4, 1, 12, 0, 0)));
            Assert.AreEqual(4, organizer.GetHomeworkCountBetweenDates(new DateTime(2022, 3, 1, 7, 0, 0), new DateTime(2022, 3, 31, 23, 59, 0)));

            organizer.TurnInHomework(139686);
            organizer.TurnInHomework(140708);
            organizer.TurnInHomework(141617);
            organizer.TurnInHomework(140929);
            organizer.TurnInHomework(141520);

            Assert.AreEqual(0, organizer.HomeworkCount);

            Assert.AreEqual(0, organizer.GetHomeworkCountByCourse("SEW"));
            Assert.AreEqual(0, organizer.GetHomeworkCountByCourse("KIDS"));
            Assert.AreEqual(0, organizer.GetHomeworkCountByCourse("LOAL"));
            Assert.AreEqual(0, organizer.GetHomeworkCountByCourse("LINZ"));

            Assert.AreEqual(0, organizer.GetHomeworkCountBetweenDates(new DateTime(2022, 2, 14, 12, 0, 0), new DateTime(2022, 3, 10, 12, 0, 0)));
            Assert.AreEqual(0, organizer.GetHomeworkCountBetweenDates(new DateTime(2022, 1, 1, 8, 0, 0), new DateTime(2022, 1, 11, 7, 59, 0)));
            Assert.AreEqual(0, organizer.GetHomeworkCountBetweenDates(new DateTime(2022, 1, 11, 12, 0, 0), new DateTime(2022, 4, 1, 12, 0, 0)));
            Assert.AreEqual(0, organizer.GetHomeworkCountBetweenDates(new DateTime(2022, 3, 1, 7, 0, 0), new DateTime(2022, 3, 31, 23, 59, 0)));

            Homework homeworkSewParty = new Homework(138665, "SEW", "Party Calendar", new DateTime(2022, 1, 16, 23, 55, 0));
            organizer.AddHomework(homeworkSewParty);
            Homework homeworkKidsPenguins = new Homework(137694, "KIDS", "Penguin Visualization", new DateTime(2022, 1, 11, 8, 00, 0));
            organizer.AddHomework(homeworkKidsPenguins);
            Homework homeworkLoalPredicates = new Homework(128101, "LOAL", "Predicate Logic", new DateTime(2022, 3, 1, 10, 50, 0));
            organizer.AddHomework(homeworkLoalPredicates);

            Assert.AreEqual(3, organizer.HomeworkCount);

            Assert.AreEqual(1, organizer.GetHomeworkCountByCourse("SEW"));
            Assert.AreEqual(1, organizer.GetHomeworkCountByCourse("KIDS"));
            Assert.AreEqual(1, organizer.GetHomeworkCountByCourse("LOAL"));
            Assert.AreEqual(0, organizer.GetHomeworkCountByCourse("LINZ"));

            Assert.AreEqual(1, organizer.GetHomeworkCountBetweenDates(new DateTime(2022, 2, 14, 12, 0, 0), new DateTime(2022, 3, 10, 12, 0, 0)));
            Assert.AreEqual(0, organizer.GetHomeworkCountBetweenDates(new DateTime(2022, 1, 1, 8, 0, 0), new DateTime(2022, 1, 11, 7, 59, 0)));
            Assert.AreEqual(2, organizer.GetHomeworkCountBetweenDates(new DateTime(2022, 1, 11, 12, 0, 0), new DateTime(2022, 4, 1, 12, 0, 0)));
            Assert.AreEqual(1, organizer.GetHomeworkCountBetweenDates(new DateTime(2022, 3, 1, 7, 0, 0), new DateTime(2022, 3, 31, 23, 59, 0)));

            organizer.TurnInHomework(137694); //KIDS - Penguin Visualization

            Assert.AreEqual(2, organizer.HomeworkCount);

            Assert.AreEqual(1, organizer.GetHomeworkCountByCourse("SEW"));
            Assert.AreEqual(0, organizer.GetHomeworkCountByCourse("KIDS"));
            Assert.AreEqual(1, organizer.GetHomeworkCountByCourse("LOAL"));
            Assert.AreEqual(0, organizer.GetHomeworkCountByCourse("LINZ"));

            Assert.AreEqual(1, organizer.GetHomeworkCountBetweenDates(new DateTime(2022, 2, 14, 12, 0, 0), new DateTime(2022, 3, 10, 12, 0, 0)));
            Assert.AreEqual(0, organizer.GetHomeworkCountBetweenDates(new DateTime(2022, 1, 1, 8, 0, 0), new DateTime(2022, 1, 11, 7, 59, 0)));
            Assert.AreEqual(2, organizer.GetHomeworkCountBetweenDates(new DateTime(2022, 1, 11, 12, 0, 0), new DateTime(2022, 4, 1, 12, 0, 0)));
            Assert.AreEqual(1, organizer.GetHomeworkCountBetweenDates(new DateTime(2022, 3, 1, 7, 0, 0), new DateTime(2022, 3, 31, 23, 59, 0)));
        }
    }
}
