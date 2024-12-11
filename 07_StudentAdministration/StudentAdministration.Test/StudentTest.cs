using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentAdministration;

namespace StudyGroups.Test
{
    [TestClass]
    public class StudentTest
    {
        [TestMethod]
        public void TestConstructorIncreasesMatriculationId()
        {
            Student studentA = new Student("Jan Kowalski");
            int matriculationId = studentA.MatriculationId;

            Assert.AreEqual(matriculationId, studentA.MatriculationId);

            Student studentB = new Student("Erika Musterfrau");

            Assert.AreEqual(matriculationId, studentA.MatriculationId);
            Assert.AreEqual(matriculationId + 1, studentB.MatriculationId);

            Student studentC = new Student("Eva Novakova");

            Assert.AreEqual(matriculationId, studentA.MatriculationId);
            Assert.AreEqual(matriculationId + 1, studentB.MatriculationId);
            Assert.AreEqual(matriculationId + 2, studentC.MatriculationId);

            Student studentD = new Student("John Doe");

            Assert.AreEqual(matriculationId, studentA.MatriculationId);
            Assert.AreEqual(matriculationId + 1, studentB.MatriculationId);
            Assert.AreEqual(matriculationId + 2, studentC.MatriculationId);
            Assert.AreEqual(matriculationId + 3, studentD.MatriculationId);
        }

        [TestMethod]
        public void TestConstructor()
        {
            Student student = new Student("Max Mustermann");

            Assert.AreEqual("Max Mustermann", student.Name);
        }

        [TestMethod]
        public void TestToString()
        {
            Student student = new Student("Erika Musterfrau");
            int matriculationId = student.MatriculationId;

            Assert.AreEqual($"#{matriculationId} Erika Musterfrau (0 hours)", student.ToString());
        }

        [TestMethod]
        public void TestStudyChangesToString()
        {
            Student student = new Student("Jane Doe");
            int matriculationId = student.MatriculationId;

            student.Study(3);

            Assert.AreEqual($"#{matriculationId} Jane Doe (3 hours)", student.ToString());
        }

        [TestMethod]
        public void TestStudyIncreasesHoursStudied()
        {
            Student student = new Student("Sally Sixpack");

            Assert.AreEqual(0, student.HoursStudied);

            student.Study(2);

            Assert.AreEqual(2, student.HoursStudied);

            student.Study(5);

            Assert.AreEqual(7, student.HoursStudied);

            student.Study(1);

            Assert.AreEqual(8, student.HoursStudied);

            student.Study(4);

            Assert.AreEqual(12, student.HoursStudied);
        }

        [TestMethod]
        public void TestStudyTooLongIsCapped()
        {
            Student student = new Student("Tom Taxpayer");

            Assert.AreEqual(0, student.HoursStudied);

            student.Study(6);

            Assert.AreEqual(5, student.HoursStudied);

            student.Study(13);

            Assert.AreEqual(10, student.HoursStudied);
        }

        [TestMethod]
        public void TestStudyNegativeHoursIsIgnored()
        {
            Student student = new Student("Jan Kowalski");

            Assert.AreEqual(0, student.HoursStudied);

            student.Study(-1);

            Assert.AreEqual(0, student.HoursStudied);

            student.Study(-999);

            Assert.AreEqual(0, student.HoursStudied);
        }

        [TestMethod]
        public void TestStudyReturnsHoursActuallyStudied()
        {
            Student student = new Student("John Doe");

            int hoursActuallyStudied = student.Study(4);

            Assert.AreEqual(4, hoursActuallyStudied);

            hoursActuallyStudied = student.Study(2);

            Assert.AreEqual(2, hoursActuallyStudied);

            hoursActuallyStudied = student.Study(7);

            Assert.AreEqual(5, hoursActuallyStudied);

            hoursActuallyStudied = student.Study(1);

            Assert.AreEqual(1, hoursActuallyStudied);

            hoursActuallyStudied = student.Study(-5);

            Assert.AreEqual(0, hoursActuallyStudied);

            hoursActuallyStudied = student.Study(3);

            Assert.AreEqual(3, hoursActuallyStudied);

            hoursActuallyStudied = student.Study(0);

            Assert.AreEqual(0, hoursActuallyStudied);
        }
    }
}
