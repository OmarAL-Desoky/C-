using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace HomeworkOrganizer.Test
{
    [TestClass]
    public class HomeworkTest
    {
        [TestMethod]
        public void TestConstructorAndGetters()
        {
            Homework homework = new Homework(141520, "SEW", "RPN-Calculator", new DateTime(2022, 3, 13, 23, 55, 0));

            Assert.AreEqual(141520, homework.MoodleId);
            Assert.AreEqual("SEW", homework.Course);
            Assert.AreEqual("RPN-Calculator", homework.Task);
            Assert.AreEqual("2022-03-13 23:55:00", homework.Deadline.ToString("yyyy-MM-dd HH:mm:ss"));

            homework = new Homework(137694, "KIDS", "Penguin Visualization", new DateTime(2022, 1, 11, 8, 0, 0));

            Assert.AreEqual(137694, homework.MoodleId);
            Assert.AreEqual("KIDS", homework.Course);
            Assert.AreEqual("Penguin Visualization", homework.Task);
            Assert.AreEqual("2022-01-11 08:00:00", homework.Deadline.ToString("yyyy-MM-dd HH:mm:ss"));
        }

        [TestMethod]
        public void TestConstructorNegativeMoodleIdThrowsException()
        {
            ArgumentException ex = Assert.ThrowsException<ArgumentException>(() => {
                Homework homework = new Homework(-123, "SEW", "First Steps With Exceptions", new DateTime(2022, 4, 15, 23, 55, 0));
            });

            Assert.AreEqual("Moodle Id must not be smaller than 1!", ex.Message);
        }

        [TestMethod]
        public void TestConstructorZeroMoodleIdThrowsException()
        {
            ArgumentException ex = Assert.ThrowsException<ArgumentException>(()=> {
                Homework homework = new Homework(0, "SEW", "Exceptions For Experts", new DateTime(2022, 4, 22, 23, 55, 0));
            });

            Assert.AreEqual("Moodle Id must not be smaller than 1!", ex.Message);
        }

        [TestMethod]
        public void TestConstructorCourseNameUppered()
        {
            Homework homework = new Homework(123456, "sew", "String Operations Deep Dive", new DateTime(2021, 3, 10, 20, 0, 0));

            Assert.AreEqual(123456, homework.MoodleId);
            Assert.AreEqual("SEW", homework.Course);
            Assert.AreEqual("String Operations Deep Dive", homework.Task);
            Assert.AreEqual("2021-03-10 20:00:00", homework.Deadline.ToString("yyyy-MM-dd HH:mm:ss"));

            homework = new Homework(789321, "lOaL", "Regular Expressions", new DateTime(2022, 6, 17, 10, 50, 0));

            Assert.AreEqual(789321, homework.MoodleId);
            Assert.AreEqual("LOAL", homework.Course);
            Assert.AreEqual("Regular Expressions", homework.Task);
            Assert.AreEqual("2022-06-17 10:50:00", homework.Deadline.ToString("yyyy-MM-dd HH:mm:ss"));
        }

        [TestMethod]
        public void TestConstructorShortCourseNameThrowsException()
        {
            ArgumentException ex = Assert.ThrowsException<ArgumentException>(() =>
            {
                Homework homework = new Homework(123456, "", "String Operations Deep Dive", new DateTime(2021, 3, 10, 20, 0, 0));
            });

            Assert.AreEqual("Course name must be between 1 and 4 characters long!", ex.Message);
        }

        [TestMethod]
        public void TestConstructorLongCourseNameThrowsException()
        {
            ArgumentException ex = Assert.ThrowsException<ArgumentException>(() =>
            {
                Homework homework = new Homework(789321, "LOGIC", "Regular Expressions", new DateTime(2022, 6, 17, 10, 50, 0));
            });

            Assert.AreEqual("Course name must be between 1 and 4 characters long!", ex.Message);
        }

        [TestMethod]
        public void TestConstructorDigitsInCourseNameThrowsException()
        {
            ArgumentException ex = Assert.ThrowsException<ArgumentException>(() =>
            {
                Homework homework = new Homework(445566, "S3W", "Detecting Digits", new DateTime(2022, 6, 16, 8, 55, 0));
            });

            Assert.AreEqual("Course name must only contain letters!", ex.Message);
        }

        [TestMethod]
        public void TestConstructorSpecialSymbolsInCourseNameThrowsException()
        {
            ArgumentException ex = Assert.ThrowsException<ArgumentException>(() =>
            {
                Homework homework = new Homework(112233, "$EW", "Special Symbols For Dummies", new DateTime(2022, 6, 17, 10, 50, 0));
            });
            Assert.AreEqual("Course name must only contain letters!", ex.Message);

            ex = Assert.ThrowsException<ArgumentException>(() =>
            {
                Homework homework = new Homework(121212, "SE?", "Special Symbols For Experts", new DateTime(2022, 6, 17, 10, 50, 0));
            });
            Assert.AreEqual("Course name must only contain letters!", ex.Message);
        }
    }
}
