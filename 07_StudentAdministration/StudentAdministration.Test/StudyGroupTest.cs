using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using StudentAdministration;

namespace StudyGroups.Test
{
    [TestClass]
    public class StudyGroupTest
    {
        [TestMethod]
        public void TestGetStudentAtInvalidIndex()
        {
            StudyGroup studyGroup = new StudyGroup();

            Assert.AreEqual(null, studyGroup.GetStudentAt(-1));
            Assert.AreEqual(null, studyGroup.GetStudentAt(99));
        }

        [TestMethod]
        public void TestAddStudentWithoutResizing()
        {
            StudyGroup studyGroup = new StudyGroup();

            Student studentA = new Student("John Doe");
            Student studentB = new Student("Eva Novakova");
            Student studentC = new Student("Sally Sixpack");

            Assert.AreEqual(3, studyGroup.CapacityFree);
            Assert.AreEqual(3, studyGroup.CapacityTotal);
            Assert.AreEqual(0, studyGroup.StudentsCount);
            Assert.AreEqual(null, studyGroup.GetStudentAt(0));
            Assert.AreEqual(null, studyGroup.GetStudentAt(1));
            Assert.AreEqual(null, studyGroup.GetStudentAt(2));
            Assert.AreEqual(false, studyGroup.HasStudent(studentA.MatriculationId));
            Assert.AreEqual(false, studyGroup.HasStudent(studentB.MatriculationId));
            Assert.AreEqual(false, studyGroup.HasStudent(studentC.MatriculationId));

            studyGroup.AddStudent(studentA);

            Assert.AreEqual(2, studyGroup.CapacityFree);
            Assert.AreEqual(3, studyGroup.CapacityTotal);
            Assert.AreEqual(1, studyGroup.StudentsCount);
            Assert.AreEqual(studentA, studyGroup.GetStudentAt(0));
            Assert.AreEqual(null, studyGroup.GetStudentAt(1));
            Assert.AreEqual(null, studyGroup.GetStudentAt(2));
            Assert.AreEqual(true, studyGroup.HasStudent(studentA.MatriculationId));
            Assert.AreEqual(false, studyGroup.HasStudent(studentB.MatriculationId));
            Assert.AreEqual(false, studyGroup.HasStudent(studentC.MatriculationId));

            studyGroup.AddStudent(studentB);

            Assert.AreEqual(1, studyGroup.CapacityFree);
            Assert.AreEqual(3, studyGroup.CapacityTotal);
            Assert.AreEqual(2, studyGroup.StudentsCount);
            Assert.AreEqual(studentA, studyGroup.GetStudentAt(0));
            Assert.AreEqual(studentB, studyGroup.GetStudentAt(1));
            Assert.AreEqual(null, studyGroup.GetStudentAt(2));
            Assert.AreEqual(true, studyGroup.HasStudent(studentA.MatriculationId));
            Assert.AreEqual(true, studyGroup.HasStudent(studentB.MatriculationId));
            Assert.AreEqual(false, studyGroup.HasStudent(studentC.MatriculationId));

            studyGroup.AddStudent(studentC);

            Assert.AreEqual(0, studyGroup.CapacityFree);
            Assert.AreEqual(3, studyGroup.CapacityTotal);
            Assert.AreEqual(3, studyGroup.StudentsCount);
            Assert.AreEqual(studentA, studyGroup.GetStudentAt(0));
            Assert.AreEqual(studentB, studyGroup.GetStudentAt(1));
            Assert.AreEqual(studentC, studyGroup.GetStudentAt(2));
            Assert.AreEqual(true, studyGroup.HasStudent(studentA.MatriculationId));
            Assert.AreEqual(true, studyGroup.HasStudent(studentB.MatriculationId));
            Assert.AreEqual(true, studyGroup.HasStudent(studentC.MatriculationId));
        }

        [TestMethod]
        public void TestAddStudentWithResizing()
        {
            StudyGroup studyGroup = new StudyGroup();

            Student studentA = new Student("Erika Musterfrau");
            Student studentB = new Student("Tom Taxpayer");
            Student studentC = new Student("Jan Kowalski");
            Student studentD = new Student("Max Mustermann");
            Student studentE = new Student("Jean Dupont");
            Student studentF = new Student("Yamada Tado");
            Student studentG = new Student("Janina Joniene");
            Student studentH = new Student("Kari Nordmann");
            Student studentI = new Student("Janez Kranjski");
            Student studentJ = new Student("Volodymyr Shevchenko");

            Assert.AreEqual(3, studyGroup.CapacityFree);
            Assert.AreEqual(3, studyGroup.CapacityTotal);
            Assert.AreEqual(0, studyGroup.StudentsCount);
            Assert.AreEqual(null, studyGroup.GetStudentAt(0));
            Assert.AreEqual(null, studyGroup.GetStudentAt(1));
            Assert.AreEqual(null, studyGroup.GetStudentAt(2));
            Assert.AreEqual(null, studyGroup.GetStudentAt(3));
            Assert.AreEqual(null, studyGroup.GetStudentAt(4));
            Assert.AreEqual(null, studyGroup.GetStudentAt(5));
            Assert.AreEqual(null, studyGroup.GetStudentAt(6));
            Assert.AreEqual(null, studyGroup.GetStudentAt(7));
            Assert.AreEqual(null, studyGroup.GetStudentAt(8));
            Assert.AreEqual(null, studyGroup.GetStudentAt(9));
            Assert.AreEqual(false, studyGroup.HasStudent(studentA.MatriculationId));
            Assert.AreEqual(false, studyGroup.HasStudent(studentB.MatriculationId));
            Assert.AreEqual(false, studyGroup.HasStudent(studentC.MatriculationId));
            Assert.AreEqual(false, studyGroup.HasStudent(studentD.MatriculationId));
            Assert.AreEqual(false, studyGroup.HasStudent(studentE.MatriculationId));
            Assert.AreEqual(false, studyGroup.HasStudent(studentF.MatriculationId));
            Assert.AreEqual(false, studyGroup.HasStudent(studentG.MatriculationId));
            Assert.AreEqual(false, studyGroup.HasStudent(studentH.MatriculationId));
            Assert.AreEqual(false, studyGroup.HasStudent(studentI.MatriculationId));
            Assert.AreEqual(false, studyGroup.HasStudent(studentJ.MatriculationId));

            studyGroup.AddStudent(studentA);
            studyGroup.AddStudent(studentB);
            studyGroup.AddStudent(studentC);
            studyGroup.AddStudent(studentD);

            Assert.AreEqual(2, studyGroup.CapacityFree);
            Assert.AreEqual(6, studyGroup.CapacityTotal);
            Assert.AreEqual(4, studyGroup.StudentsCount);
            Assert.AreEqual(studentA, studyGroup.GetStudentAt(0));
            Assert.AreEqual(studentB, studyGroup.GetStudentAt(1));
            Assert.AreEqual(studentC, studyGroup.GetStudentAt(2));
            Assert.AreEqual(studentD, studyGroup.GetStudentAt(3));
            Assert.AreEqual(null, studyGroup.GetStudentAt(4));
            Assert.AreEqual(null, studyGroup.GetStudentAt(5));
            Assert.AreEqual(null, studyGroup.GetStudentAt(6));
            Assert.AreEqual(null, studyGroup.GetStudentAt(7));
            Assert.AreEqual(null, studyGroup.GetStudentAt(8));
            Assert.AreEqual(null, studyGroup.GetStudentAt(9));
            Assert.AreEqual(true, studyGroup.HasStudent(studentA.MatriculationId));
            Assert.AreEqual(true, studyGroup.HasStudent(studentB.MatriculationId));
            Assert.AreEqual(true, studyGroup.HasStudent(studentC.MatriculationId));
            Assert.AreEqual(true, studyGroup.HasStudent(studentD.MatriculationId));
            Assert.AreEqual(false, studyGroup.HasStudent(studentE.MatriculationId));
            Assert.AreEqual(false, studyGroup.HasStudent(studentF.MatriculationId));
            Assert.AreEqual(false, studyGroup.HasStudent(studentG.MatriculationId));
            Assert.AreEqual(false, studyGroup.HasStudent(studentH.MatriculationId));
            Assert.AreEqual(false, studyGroup.HasStudent(studentI.MatriculationId));
            Assert.AreEqual(false, studyGroup.HasStudent(studentJ.MatriculationId));

            studyGroup.AddStudent(studentE);
            studyGroup.AddStudent(studentF);

            Assert.AreEqual(0, studyGroup.CapacityFree);
            Assert.AreEqual(6, studyGroup.CapacityTotal);
            Assert.AreEqual(6, studyGroup.StudentsCount);
            Assert.AreEqual(studentA, studyGroup.GetStudentAt(0));
            Assert.AreEqual(studentB, studyGroup.GetStudentAt(1));
            Assert.AreEqual(studentC, studyGroup.GetStudentAt(2));
            Assert.AreEqual(studentD, studyGroup.GetStudentAt(3));
            Assert.AreEqual(studentE, studyGroup.GetStudentAt(4));
            Assert.AreEqual(studentF, studyGroup.GetStudentAt(5));
            Assert.AreEqual(null, studyGroup.GetStudentAt(6));
            Assert.AreEqual(null, studyGroup.GetStudentAt(7));
            Assert.AreEqual(null, studyGroup.GetStudentAt(8));
            Assert.AreEqual(null, studyGroup.GetStudentAt(9));
            Assert.AreEqual(true, studyGroup.HasStudent(studentA.MatriculationId));
            Assert.AreEqual(true, studyGroup.HasStudent(studentB.MatriculationId));
            Assert.AreEqual(true, studyGroup.HasStudent(studentC.MatriculationId));
            Assert.AreEqual(true, studyGroup.HasStudent(studentD.MatriculationId));
            Assert.AreEqual(true, studyGroup.HasStudent(studentE.MatriculationId));
            Assert.AreEqual(true, studyGroup.HasStudent(studentF.MatriculationId));
            Assert.AreEqual(false, studyGroup.HasStudent(studentG.MatriculationId));
            Assert.AreEqual(false, studyGroup.HasStudent(studentH.MatriculationId));
            Assert.AreEqual(false, studyGroup.HasStudent(studentI.MatriculationId));
            Assert.AreEqual(false, studyGroup.HasStudent(studentJ.MatriculationId));

            studyGroup.AddStudent(studentG);
            studyGroup.AddStudent(studentH);

            Assert.AreEqual(1, studyGroup.CapacityFree);
            Assert.AreEqual(9, studyGroup.CapacityTotal);
            Assert.AreEqual(8, studyGroup.StudentsCount);
            Assert.AreEqual(studentA, studyGroup.GetStudentAt(0));
            Assert.AreEqual(studentB, studyGroup.GetStudentAt(1));
            Assert.AreEqual(studentC, studyGroup.GetStudentAt(2));
            Assert.AreEqual(studentD, studyGroup.GetStudentAt(3));
            Assert.AreEqual(studentE, studyGroup.GetStudentAt(4));
            Assert.AreEqual(studentF, studyGroup.GetStudentAt(5));
            Assert.AreEqual(studentG, studyGroup.GetStudentAt(6));
            Assert.AreEqual(studentH, studyGroup.GetStudentAt(7));
            Assert.AreEqual(null, studyGroup.GetStudentAt(8));
            Assert.AreEqual(null, studyGroup.GetStudentAt(9));
            Assert.AreEqual(true, studyGroup.HasStudent(studentA.MatriculationId));
            Assert.AreEqual(true, studyGroup.HasStudent(studentB.MatriculationId));
            Assert.AreEqual(true, studyGroup.HasStudent(studentC.MatriculationId));
            Assert.AreEqual(true, studyGroup.HasStudent(studentD.MatriculationId));
            Assert.AreEqual(true, studyGroup.HasStudent(studentE.MatriculationId));
            Assert.AreEqual(true, studyGroup.HasStudent(studentF.MatriculationId));
            Assert.AreEqual(true, studyGroup.HasStudent(studentG.MatriculationId));
            Assert.AreEqual(true, studyGroup.HasStudent(studentH.MatriculationId));
            Assert.AreEqual(false, studyGroup.HasStudent(studentI.MatriculationId));
            Assert.AreEqual(false, studyGroup.HasStudent(studentJ.MatriculationId));

            studyGroup.AddStudent(studentI);

            Assert.AreEqual(0, studyGroup.CapacityFree);
            Assert.AreEqual(9, studyGroup.CapacityTotal);
            Assert.AreEqual(9, studyGroup.StudentsCount);
            Assert.AreEqual(studentA, studyGroup.GetStudentAt(0));
            Assert.AreEqual(studentB, studyGroup.GetStudentAt(1));
            Assert.AreEqual(studentC, studyGroup.GetStudentAt(2));
            Assert.AreEqual(studentD, studyGroup.GetStudentAt(3));
            Assert.AreEqual(studentE, studyGroup.GetStudentAt(4));
            Assert.AreEqual(studentF, studyGroup.GetStudentAt(5));
            Assert.AreEqual(studentG, studyGroup.GetStudentAt(6));
            Assert.AreEqual(studentH, studyGroup.GetStudentAt(7));
            Assert.AreEqual(studentI, studyGroup.GetStudentAt(8));
            Assert.AreEqual(null, studyGroup.GetStudentAt(9));
            Assert.AreEqual(true, studyGroup.HasStudent(studentA.MatriculationId));
            Assert.AreEqual(true, studyGroup.HasStudent(studentB.MatriculationId));
            Assert.AreEqual(true, studyGroup.HasStudent(studentC.MatriculationId));
            Assert.AreEqual(true, studyGroup.HasStudent(studentD.MatriculationId));
            Assert.AreEqual(true, studyGroup.HasStudent(studentE.MatriculationId));
            Assert.AreEqual(true, studyGroup.HasStudent(studentF.MatriculationId));
            Assert.AreEqual(true, studyGroup.HasStudent(studentG.MatriculationId));
            Assert.AreEqual(true, studyGroup.HasStudent(studentH.MatriculationId));
            Assert.AreEqual(true, studyGroup.HasStudent(studentI.MatriculationId));
            Assert.AreEqual(false, studyGroup.HasStudent(studentJ.MatriculationId));

            studyGroup.AddStudent(studentJ);

            Assert.AreEqual(2, studyGroup.CapacityFree);
            Assert.AreEqual(12, studyGroup.CapacityTotal);
            Assert.AreEqual(10, studyGroup.StudentsCount);
            Assert.AreEqual(studentA, studyGroup.GetStudentAt(0));
            Assert.AreEqual(studentB, studyGroup.GetStudentAt(1));
            Assert.AreEqual(studentC, studyGroup.GetStudentAt(2));
            Assert.AreEqual(studentD, studyGroup.GetStudentAt(3));
            Assert.AreEqual(studentE, studyGroup.GetStudentAt(4));
            Assert.AreEqual(studentF, studyGroup.GetStudentAt(5));
            Assert.AreEqual(studentG, studyGroup.GetStudentAt(6));
            Assert.AreEqual(studentH, studyGroup.GetStudentAt(7));
            Assert.AreEqual(studentI, studyGroup.GetStudentAt(8));
            Assert.AreEqual(studentJ, studyGroup.GetStudentAt(9));
            Assert.AreEqual(true, studyGroup.HasStudent(studentA.MatriculationId));
            Assert.AreEqual(true, studyGroup.HasStudent(studentB.MatriculationId));
            Assert.AreEqual(true, studyGroup.HasStudent(studentC.MatriculationId));
            Assert.AreEqual(true, studyGroup.HasStudent(studentD.MatriculationId));
            Assert.AreEqual(true, studyGroup.HasStudent(studentE.MatriculationId));
            Assert.AreEqual(true, studyGroup.HasStudent(studentF.MatriculationId));
            Assert.AreEqual(true, studyGroup.HasStudent(studentG.MatriculationId));
            Assert.AreEqual(true, studyGroup.HasStudent(studentH.MatriculationId));
            Assert.AreEqual(true, studyGroup.HasStudent(studentI.MatriculationId));
            Assert.AreEqual(true, studyGroup.HasStudent(studentJ.MatriculationId));
        }

        [TestMethod]
        public void TestAddStudentDuplicate()
        {
            StudyGroup studyGroup = new StudyGroup();

            Student studentA = new Student("Sally Sixpack");
            Student studentB = new Student("Jane Doe");
            Student studentC = new Student("Kari Nordmann");
            Student studentD = new Student("Janez Kranjski");

            bool isAddSuccess = studyGroup.AddStudent(studentA);

            Assert.AreEqual(true, isAddSuccess);
            Assert.AreEqual(2, studyGroup.CapacityFree);
            Assert.AreEqual(3, studyGroup.CapacityTotal);
            Assert.AreEqual(1, studyGroup.StudentsCount);
            Assert.AreEqual(studentA, studyGroup.GetStudentAt(0));
            Assert.AreEqual(null, studyGroup.GetStudentAt(1));
            Assert.AreEqual(null, studyGroup.GetStudentAt(2));
            Assert.AreEqual(null, studyGroup.GetStudentAt(3));
            Assert.AreEqual(null, studyGroup.GetStudentAt(4));
            Assert.AreEqual(true, studyGroup.HasStudent(studentA.MatriculationId));
            Assert.AreEqual(false, studyGroup.HasStudent(studentB.MatriculationId));
            Assert.AreEqual(false, studyGroup.HasStudent(studentC.MatriculationId));
            Assert.AreEqual(false, studyGroup.HasStudent(studentD.MatriculationId));

            isAddSuccess = studyGroup.AddStudent(studentB);

            Assert.AreEqual(true, isAddSuccess);
            Assert.AreEqual(1, studyGroup.CapacityFree);
            Assert.AreEqual(3, studyGroup.CapacityTotal);
            Assert.AreEqual(2, studyGroup.StudentsCount);
            Assert.AreEqual(studentA, studyGroup.GetStudentAt(0));
            Assert.AreEqual(studentB, studyGroup.GetStudentAt(1));
            Assert.AreEqual(null, studyGroup.GetStudentAt(2));
            Assert.AreEqual(null, studyGroup.GetStudentAt(3));
            Assert.AreEqual(null, studyGroup.GetStudentAt(4));
            Assert.AreEqual(true, studyGroup.HasStudent(studentA.MatriculationId));
            Assert.AreEqual(true, studyGroup.HasStudent(studentB.MatriculationId));
            Assert.AreEqual(false, studyGroup.HasStudent(studentC.MatriculationId));
            Assert.AreEqual(false, studyGroup.HasStudent(studentD.MatriculationId));

            isAddSuccess = studyGroup.AddStudent(studentA);

            Assert.AreEqual(false, isAddSuccess);
            Assert.AreEqual(1, studyGroup.CapacityFree);
            Assert.AreEqual(3, studyGroup.CapacityTotal);
            Assert.AreEqual(2, studyGroup.StudentsCount);
            Assert.AreEqual(studentA, studyGroup.GetStudentAt(0));
            Assert.AreEqual(studentB, studyGroup.GetStudentAt(1));
            Assert.AreEqual(null, studyGroup.GetStudentAt(2));
            Assert.AreEqual(null, studyGroup.GetStudentAt(3));
            Assert.AreEqual(null, studyGroup.GetStudentAt(4));
            Assert.AreEqual(true, studyGroup.HasStudent(studentA.MatriculationId));
            Assert.AreEqual(true, studyGroup.HasStudent(studentB.MatriculationId));
            Assert.AreEqual(false, studyGroup.HasStudent(studentC.MatriculationId));
            Assert.AreEqual(false, studyGroup.HasStudent(studentD.MatriculationId));

            isAddSuccess = studyGroup.AddStudent(studentC);

            Assert.AreEqual(true, isAddSuccess);
            Assert.AreEqual(0, studyGroup.CapacityFree);
            Assert.AreEqual(3, studyGroup.CapacityTotal);
            Assert.AreEqual(3, studyGroup.StudentsCount);
            Assert.AreEqual(studentA, studyGroup.GetStudentAt(0));
            Assert.AreEqual(studentB, studyGroup.GetStudentAt(1));
            Assert.AreEqual(studentC, studyGroup.GetStudentAt(2));
            Assert.AreEqual(null, studyGroup.GetStudentAt(3));
            Assert.AreEqual(null, studyGroup.GetStudentAt(4));
            Assert.AreEqual(true, studyGroup.HasStudent(studentA.MatriculationId));
            Assert.AreEqual(true, studyGroup.HasStudent(studentB.MatriculationId));
            Assert.AreEqual(true, studyGroup.HasStudent(studentC.MatriculationId));
            Assert.AreEqual(false, studyGroup.HasStudent(studentD.MatriculationId));

            isAddSuccess = studyGroup.AddStudent(studentC);

            Assert.AreEqual(false, isAddSuccess);
            Assert.AreEqual(0, studyGroup.CapacityFree);
            Assert.AreEqual(3, studyGroup.CapacityTotal);
            Assert.AreEqual(3, studyGroup.StudentsCount);
            Assert.AreEqual(studentA, studyGroup.GetStudentAt(0));
            Assert.AreEqual(studentB, studyGroup.GetStudentAt(1));
            Assert.AreEqual(studentC, studyGroup.GetStudentAt(2));
            Assert.AreEqual(null, studyGroup.GetStudentAt(3));
            Assert.AreEqual(null, studyGroup.GetStudentAt(4));
            Assert.AreEqual(true, studyGroup.HasStudent(studentA.MatriculationId));
            Assert.AreEqual(true, studyGroup.HasStudent(studentB.MatriculationId));
            Assert.AreEqual(true, studyGroup.HasStudent(studentC.MatriculationId));
            Assert.AreEqual(false, studyGroup.HasStudent(studentD.MatriculationId));

            isAddSuccess = studyGroup.AddStudent(studentA);

            Assert.AreEqual(false, isAddSuccess);
            Assert.AreEqual(0, studyGroup.CapacityFree);
            Assert.AreEqual(3, studyGroup.CapacityTotal);
            Assert.AreEqual(3, studyGroup.StudentsCount);
            Assert.AreEqual(studentA, studyGroup.GetStudentAt(0));
            Assert.AreEqual(studentB, studyGroup.GetStudentAt(1));
            Assert.AreEqual(studentC, studyGroup.GetStudentAt(2));
            Assert.AreEqual(null, studyGroup.GetStudentAt(3));
            Assert.AreEqual(null, studyGroup.GetStudentAt(4));
            Assert.AreEqual(true, studyGroup.HasStudent(studentA.MatriculationId));
            Assert.AreEqual(true, studyGroup.HasStudent(studentB.MatriculationId));
            Assert.AreEqual(true, studyGroup.HasStudent(studentC.MatriculationId));
            Assert.AreEqual(false, studyGroup.HasStudent(studentD.MatriculationId));

            isAddSuccess = studyGroup.AddStudent(studentD);

            Assert.AreEqual(true, isAddSuccess);
            Assert.AreEqual(2, studyGroup.CapacityFree);
            Assert.AreEqual(6, studyGroup.CapacityTotal);
            Assert.AreEqual(4, studyGroup.StudentsCount);
            Assert.AreEqual(studentA, studyGroup.GetStudentAt(0));
            Assert.AreEqual(studentB, studyGroup.GetStudentAt(1));
            Assert.AreEqual(studentC, studyGroup.GetStudentAt(2));
            Assert.AreEqual(studentD, studyGroup.GetStudentAt(3));
            Assert.AreEqual(null, studyGroup.GetStudentAt(4));
            Assert.AreEqual(true, studyGroup.HasStudent(studentA.MatriculationId));
            Assert.AreEqual(true, studyGroup.HasStudent(studentB.MatriculationId));
            Assert.AreEqual(true, studyGroup.HasStudent(studentC.MatriculationId));
            Assert.AreEqual(true, studyGroup.HasStudent(studentD.MatriculationId));

            isAddSuccess = studyGroup.AddStudent(studentB);

            Assert.AreEqual(false, isAddSuccess);
            Assert.AreEqual(2, studyGroup.CapacityFree);
            Assert.AreEqual(6, studyGroup.CapacityTotal);
            Assert.AreEqual(4, studyGroup.StudentsCount);
            Assert.AreEqual(studentA, studyGroup.GetStudentAt(0));
            Assert.AreEqual(studentB, studyGroup.GetStudentAt(1));
            Assert.AreEqual(studentC, studyGroup.GetStudentAt(2));
            Assert.AreEqual(studentD, studyGroup.GetStudentAt(3));
            Assert.AreEqual(null, studyGroup.GetStudentAt(4));
            Assert.AreEqual(true, studyGroup.HasStudent(studentA.MatriculationId));
            Assert.AreEqual(true, studyGroup.HasStudent(studentB.MatriculationId));
            Assert.AreEqual(true, studyGroup.HasStudent(studentC.MatriculationId));
            Assert.AreEqual(true, studyGroup.HasStudent(studentD.MatriculationId));
        }

        [TestMethod]
        public void TestStudy()
        {
            StudyGroup studyGroup = new StudyGroup();

            Student studentA = new Student("Sally Sixpack");
            Student studentB = new Student("Jane Doe");
            Student studentC = new Student("Kari Nordmann");
            Student studentD = new Student("Janez Kranjski");
            Student studentE = new Student("Erika Musterfrau");

            studyGroup.AddStudent(studentA);
            studyGroup.AddStudent(studentB);

            studyGroup.Study(3);

            Assert.AreEqual(3, studentA.HoursStudied);
            Assert.AreEqual(3, studentB.HoursStudied);
            Assert.AreEqual(0, studentC.HoursStudied);
            Assert.AreEqual(0, studentD.HoursStudied);
            Assert.AreEqual(0, studentE.HoursStudied);

            studyGroup.AddStudent(studentC);
            studyGroup.AddStudent(studentD);
            studyGroup.AddStudent(studentE);

            studyGroup.Study(1);

            Assert.AreEqual(4, studentA.HoursStudied);
            Assert.AreEqual(4, studentB.HoursStudied);
            Assert.AreEqual(1, studentC.HoursStudied);
            Assert.AreEqual(1, studentD.HoursStudied);
            Assert.AreEqual(1, studentE.HoursStudied);

            studyGroup.Study(6);

            Assert.AreEqual(9, studentA.HoursStudied);
            Assert.AreEqual(9, studentB.HoursStudied);
            Assert.AreEqual(6, studentC.HoursStudied);
            Assert.AreEqual(6, studentD.HoursStudied);
            Assert.AreEqual(6, studentE.HoursStudied);

            studyGroup.Study(-1);

            Assert.AreEqual(9, studentA.HoursStudied);
            Assert.AreEqual(9, studentB.HoursStudied);
            Assert.AreEqual(6, studentC.HoursStudied);
            Assert.AreEqual(6, studentD.HoursStudied);
            Assert.AreEqual(6, studentE.HoursStudied);

            studyGroup.Study(2);

            Assert.AreEqual(11, studentA.HoursStudied);
            Assert.AreEqual(11, studentB.HoursStudied);
            Assert.AreEqual(8, studentC.HoursStudied);
            Assert.AreEqual(8, studentD.HoursStudied);
            Assert.AreEqual(8, studentE.HoursStudied);

            studyGroup.Study(12);

            Assert.AreEqual(16, studentA.HoursStudied);
            Assert.AreEqual(16, studentB.HoursStudied);
            Assert.AreEqual(13, studentC.HoursStudied);
            Assert.AreEqual(13, studentD.HoursStudied);
            Assert.AreEqual(13, studentE.HoursStudied);
        }

        [TestMethod]
        public void TestRemoveAndAdd()
        {
            StudyGroup studyGroup = new StudyGroup();

            Student studentA = new Student("Jean Dupont");
            Student studentB = new Student("Yamada Tado");
            Student studentC = new Student("Billy Nomates");

            studyGroup.AddStudent(studentA);
            studyGroup.AddStudent(studentB);
            studyGroup.AddStudent(studentC);

            Assert.AreEqual(0, studyGroup.CapacityFree);
            Assert.AreEqual(3, studyGroup.CapacityTotal);
            Assert.AreEqual(3, studyGroup.StudentsCount);
            Assert.AreEqual(studentA, studyGroup.GetStudentAt(0));
            Assert.AreEqual(studentB, studyGroup.GetStudentAt(1));
            Assert.AreEqual(studentC, studyGroup.GetStudentAt(2));
            Assert.AreEqual(null, studyGroup.GetStudentAt(3));
            Assert.AreEqual(true, studyGroup.HasStudent(studentA.MatriculationId));
            Assert.AreEqual(true, studyGroup.HasStudent(studentB.MatriculationId));
            Assert.AreEqual(true, studyGroup.HasStudent(studentC.MatriculationId));

            studyGroup.RemoveStudent(studentB.MatriculationId);

            Assert.AreEqual(1, studyGroup.CapacityFree);
            Assert.AreEqual(3, studyGroup.CapacityTotal);
            Assert.AreEqual(2, studyGroup.StudentsCount);
            Assert.AreEqual(studentA, studyGroup.GetStudentAt(0));
            Assert.AreEqual(studentC, studyGroup.GetStudentAt(1));
            Assert.AreEqual(null, studyGroup.GetStudentAt(2));
            Assert.AreEqual(null, studyGroup.GetStudentAt(3));
            Assert.AreEqual(true, studyGroup.HasStudent(studentA.MatriculationId));
            Assert.AreEqual(false, studyGroup.HasStudent(studentB.MatriculationId));
            Assert.AreEqual(true, studyGroup.HasStudent(studentC.MatriculationId));

            studyGroup.RemoveStudent(studentA.MatriculationId);

            Assert.AreEqual(2, studyGroup.CapacityFree);
            Assert.AreEqual(3, studyGroup.CapacityTotal);
            Assert.AreEqual(1, studyGroup.StudentsCount);
            Assert.AreEqual(studentC, studyGroup.GetStudentAt(0));
            Assert.AreEqual(null, studyGroup.GetStudentAt(1));
            Assert.AreEqual(null, studyGroup.GetStudentAt(2));
            Assert.AreEqual(null, studyGroup.GetStudentAt(3));
            Assert.AreEqual(false, studyGroup.HasStudent(studentA.MatriculationId));
            Assert.AreEqual(false, studyGroup.HasStudent(studentB.MatriculationId));
            Assert.AreEqual(true, studyGroup.HasStudent(studentC.MatriculationId));

            studyGroup.AddStudent(studentB);

            Assert.AreEqual(1, studyGroup.CapacityFree);
            Assert.AreEqual(3, studyGroup.CapacityTotal);
            Assert.AreEqual(2, studyGroup.StudentsCount);
            Assert.AreEqual(studentC, studyGroup.GetStudentAt(0));
            Assert.AreEqual(studentB, studyGroup.GetStudentAt(1));
            Assert.AreEqual(null, studyGroup.GetStudentAt(2));
            Assert.AreEqual(null, studyGroup.GetStudentAt(3));
            Assert.AreEqual(false, studyGroup.HasStudent(studentA.MatriculationId));
            Assert.AreEqual(true, studyGroup.HasStudent(studentB.MatriculationId));
            Assert.AreEqual(true, studyGroup.HasStudent(studentC.MatriculationId));

            studyGroup.AddStudent(studentA);

            Assert.AreEqual(0, studyGroup.CapacityFree);
            Assert.AreEqual(3, studyGroup.CapacityTotal);
            Assert.AreEqual(3, studyGroup.StudentsCount);
            Assert.AreEqual(studentC, studyGroup.GetStudentAt(0));
            Assert.AreEqual(studentB, studyGroup.GetStudentAt(1));
            Assert.AreEqual(studentA, studyGroup.GetStudentAt(2));
            Assert.AreEqual(null, studyGroup.GetStudentAt(3));
            Assert.AreEqual(true, studyGroup.HasStudent(studentA.MatriculationId));
            Assert.AreEqual(true, studyGroup.HasStudent(studentB.MatriculationId));
            Assert.AreEqual(true, studyGroup.HasStudent(studentC.MatriculationId));

            studyGroup.RemoveStudent(studentA.MatriculationId);

            Assert.AreEqual(1, studyGroup.CapacityFree);
            Assert.AreEqual(3, studyGroup.CapacityTotal);
            Assert.AreEqual(2, studyGroup.StudentsCount);
            Assert.AreEqual(studentC, studyGroup.GetStudentAt(0));
            Assert.AreEqual(studentB, studyGroup.GetStudentAt(1));
            Assert.AreEqual(null, studyGroup.GetStudentAt(2));
            Assert.AreEqual(null, studyGroup.GetStudentAt(3));
            Assert.AreEqual(false, studyGroup.HasStudent(studentA.MatriculationId));
            Assert.AreEqual(true, studyGroup.HasStudent(studentB.MatriculationId));
            Assert.AreEqual(true, studyGroup.HasStudent(studentC.MatriculationId));

            studyGroup.RemoveStudent(studentB.MatriculationId);

            Assert.AreEqual(2, studyGroup.CapacityFree);
            Assert.AreEqual(3, studyGroup.CapacityTotal);
            Assert.AreEqual(1, studyGroup.StudentsCount);
            Assert.AreEqual(studentC, studyGroup.GetStudentAt(0));
            Assert.AreEqual(null, studyGroup.GetStudentAt(1));
            Assert.AreEqual(null, studyGroup.GetStudentAt(2));
            Assert.AreEqual(null, studyGroup.GetStudentAt(3));
            Assert.AreEqual(false, studyGroup.HasStudent(studentA.MatriculationId));
            Assert.AreEqual(false, studyGroup.HasStudent(studentB.MatriculationId));
            Assert.AreEqual(true, studyGroup.HasStudent(studentC.MatriculationId));

            studyGroup.RemoveStudent(studentC.MatriculationId);

            Assert.AreEqual(3, studyGroup.CapacityFree);
            Assert.AreEqual(3, studyGroup.CapacityTotal);
            Assert.AreEqual(0, studyGroup.StudentsCount);
            Assert.AreEqual(null, studyGroup.GetStudentAt(0));
            Assert.AreEqual(null, studyGroup.GetStudentAt(1));
            Assert.AreEqual(null, studyGroup.GetStudentAt(2));
            Assert.AreEqual(null, studyGroup.GetStudentAt(3));
            Assert.AreEqual(false, studyGroup.HasStudent(studentA.MatriculationId));
            Assert.AreEqual(false, studyGroup.HasStudent(studentB.MatriculationId));
            Assert.AreEqual(false, studyGroup.HasStudent(studentC.MatriculationId));
        }

        [TestMethod]
        public void TestRemoveStudentNotExists()
        {
            StudyGroup studyGroup = new StudyGroup();

            Student studentA = new Student("Jane Doe");
            Student studentB = new Student("Kari Nordmann");
            Student studentC = new Student("Janez Kranjski");

            bool isRemoveSuccesful = studyGroup.RemoveStudent(studentA.MatriculationId);

            Assert.AreEqual(false, isRemoveSuccesful);

            studyGroup.AddStudent(studentA);
            studyGroup.AddStudent(studentB);
            studyGroup.AddStudent(studentC);

            isRemoveSuccesful = studyGroup.RemoveStudent(studentB.MatriculationId);

            Assert.AreEqual(true, isRemoveSuccesful);

            isRemoveSuccesful = studyGroup.RemoveStudent(studentA.MatriculationId);

            Assert.AreEqual(true, isRemoveSuccesful);

            isRemoveSuccesful = studyGroup.RemoveStudent(studentB.MatriculationId);

            Assert.AreEqual(false, isRemoveSuccesful);

            isRemoveSuccesful = studyGroup.RemoveStudent(studentC.MatriculationId);

            Assert.AreEqual(true, isRemoveSuccesful);

            studyGroup.AddStudent(studentA);

            isRemoveSuccesful = studyGroup.RemoveStudent(studentA.MatriculationId);

            Assert.AreEqual(true, isRemoveSuccesful);
        }

        [TestMethod]
        public void TestStudyReturnsTotalHours()
        {
            StudyGroup studyGroup = new StudyGroup();

            Student studentA = new Student("Kari Nordmann");
            Student studentB = new Student("Volodymyr Shevchenko");
            Student studentC = new Student("Sally Sixpack");
            Student studentD = new Student("Billy Nomates");

            studyGroup.AddStudent(studentA);
            studyGroup.AddStudent(studentB);

            int hoursStudied = studyGroup.Study(3);

            Assert.AreEqual(6, hoursStudied);

            studyGroup.AddStudent(studentC);
            studyGroup.AddStudent(studentD);

            hoursStudied = studyGroup.Study(2);

            Assert.AreEqual(8, hoursStudied);

            hoursStudied = studyGroup.Study(13);

            Assert.AreEqual(20, hoursStudied);

            hoursStudied = studyGroup.Study(1);

            Assert.AreEqual(4, hoursStudied);

            hoursStudied = studyGroup.Study(-20);

            Assert.AreEqual(0, hoursStudied);
        }

        [TestMethod]
        public void TestStudyAfterRemove()
        {
            StudyGroup studyGroup = new StudyGroup();

            Student studentA = new Student("Yamada Tado");
            Student studentB = new Student("Billy Nomates");
            Student studentC = new Student("Kari Nordmann");

            studyGroup.Study(4);

            Assert.AreEqual(0, studentA.HoursStudied);
            Assert.AreEqual(0, studentB.HoursStudied);
            Assert.AreEqual(0, studentC.HoursStudied);

            studyGroup.AddStudent(studentA);
            studyGroup.AddStudent(studentB);
            studyGroup.AddStudent(studentC);

            studyGroup.Study(3);

            Assert.AreEqual(3, studentA.HoursStudied);
            Assert.AreEqual(3, studentB.HoursStudied);
            Assert.AreEqual(3, studentC.HoursStudied);

            studyGroup.RemoveStudent(studentA.MatriculationId);

            studyGroup.Study(2);

            Assert.AreEqual(3, studentA.HoursStudied);
            Assert.AreEqual(5, studentB.HoursStudied);
            Assert.AreEqual(5, studentC.HoursStudied);

            studyGroup.RemoveStudent(studentC.MatriculationId);

            studyGroup.Study(5);

            Assert.AreEqual(3, studentA.HoursStudied);
            Assert.AreEqual(10, studentB.HoursStudied);
            Assert.AreEqual(5, studentC.HoursStudied);

            studyGroup.AddStudent(studentA);

            studyGroup.Study(4);

            Assert.AreEqual(7, studentA.HoursStudied);
            Assert.AreEqual(14, studentB.HoursStudied);
            Assert.AreEqual(5, studentC.HoursStudied);
        }

        [TestMethod]
        public void TestSort()
        {
            StudyGroup studyGroup = new StudyGroup();

            Student studentA = new Student("Tom Taxpayer");
            Student studentB = new Student("Erika Musterfrau");
            Student studentC = new Student("Jan Kowalski");
            Student studentD = new Student("Max Mustermann");
            Student studentE = new Student("Jean Dupont");
            Student studentF = new Student("Yamada Tado");
            Student studentG = new Student("Billy Nomates");
            Student studentH = new Student("Kari Nordmann");
            Student studentI = new Student("Volodymyr Shevchenko");
            Student studentJ = new Student("Sally Sixpack");

            studyGroup.AddStudent(studentA);
            studyGroup.AddStudent(studentB);
            studyGroup.AddStudent(studentC);

            Assert.AreEqual("Tom Taxpayer", studyGroup.GetStudentAt(0).Name);
            Assert.AreEqual("Erika Musterfrau", studyGroup.GetStudentAt(1).Name);
            Assert.AreEqual("Jan Kowalski", studyGroup.GetStudentAt(2).Name);
            Assert.AreEqual(null, studyGroup.GetStudentAt(3));

            studyGroup.Sort();

            Assert.AreEqual("Erika Musterfrau", studyGroup.GetStudentAt(0).Name);
            Assert.AreEqual("Jan Kowalski", studyGroup.GetStudentAt(1).Name);
            Assert.AreEqual("Tom Taxpayer", studyGroup.GetStudentAt(2).Name);
            Assert.AreEqual(null, studyGroup.GetStudentAt(3));

            studyGroup.AddStudent(studentD);
            studyGroup.AddStudent(studentE);
            studyGroup.AddStudent(studentF);
            studyGroup.AddStudent(studentG);
            studyGroup.AddStudent(studentH);
            studyGroup.AddStudent(studentI);
            studyGroup.AddStudent(studentJ);

            Assert.AreEqual("Erika Musterfrau", studyGroup.GetStudentAt(0).Name);
            Assert.AreEqual("Jan Kowalski", studyGroup.GetStudentAt(1).Name);
            Assert.AreEqual("Tom Taxpayer", studyGroup.GetStudentAt(2).Name);
            Assert.AreEqual("Max Mustermann", studyGroup.GetStudentAt(3).Name);
            Assert.AreEqual("Jean Dupont", studyGroup.GetStudentAt(4).Name);
            Assert.AreEqual("Yamada Tado", studyGroup.GetStudentAt(5).Name);
            Assert.AreEqual("Billy Nomates", studyGroup.GetStudentAt(6).Name);
            Assert.AreEqual("Kari Nordmann", studyGroup.GetStudentAt(7).Name);
            Assert.AreEqual("Volodymyr Shevchenko", studyGroup.GetStudentAt(8).Name);
            Assert.AreEqual("Sally Sixpack", studyGroup.GetStudentAt(9).Name);
            Assert.AreEqual(null, studyGroup.GetStudentAt(10));

            studyGroup.Sort();

            Assert.AreEqual("Billy Nomates", studyGroup.GetStudentAt(0).Name);
            Assert.AreEqual("Erika Musterfrau", studyGroup.GetStudentAt(1).Name);
            Assert.AreEqual("Jan Kowalski", studyGroup.GetStudentAt(2).Name);
            Assert.AreEqual("Jean Dupont", studyGroup.GetStudentAt(3).Name);
            Assert.AreEqual("Kari Nordmann", studyGroup.GetStudentAt(4).Name);
            Assert.AreEqual("Max Mustermann", studyGroup.GetStudentAt(5).Name);
            Assert.AreEqual("Sally Sixpack", studyGroup.GetStudentAt(6).Name);
            Assert.AreEqual("Tom Taxpayer", studyGroup.GetStudentAt(7).Name);
            Assert.AreEqual("Volodymyr Shevchenko", studyGroup.GetStudentAt(8).Name);
            Assert.AreEqual("Yamada Tado", studyGroup.GetStudentAt(9).Name);
            Assert.AreEqual(null, studyGroup.GetStudentAt(10));
        }

        [TestMethod]
        public void TestRemoveLargeGroup()
        {
            StudyGroup studyGroup = new StudyGroup();

            Student studentA = new Student("Erika Musterfrau");
            Student studentB = new Student("Tom Taxpayer");
            Student studentC = new Student("Jan Kowalski");
            Student studentD = new Student("Max Mustermann");
            Student studentE = new Student("Jean Dupont");
            Student studentF = new Student("Yamada Tado");
            Student studentG = new Student("Janina Joniene");
            Student studentH = new Student("Kari Nordmann");
            Student studentI = new Student("Janez Kranjski");
            Student studentJ = new Student("Volodymyr Shevchenko");

            studyGroup.AddStudent(studentA);
            studyGroup.AddStudent(studentB);
            studyGroup.AddStudent(studentC);
            studyGroup.AddStudent(studentD);
            studyGroup.AddStudent(studentE);
            studyGroup.AddStudent(studentF);
            studyGroup.AddStudent(studentG);
            studyGroup.AddStudent(studentH);
            studyGroup.AddStudent(studentI);
            studyGroup.AddStudent(studentJ);

            Assert.AreEqual(2, studyGroup.CapacityFree);
            Assert.AreEqual(12, studyGroup.CapacityTotal);
            Assert.AreEqual(10, studyGroup.StudentsCount);
            Assert.AreEqual(studentA, studyGroup.GetStudentAt(0));
            Assert.AreEqual(studentB, studyGroup.GetStudentAt(1));
            Assert.AreEqual(studentC, studyGroup.GetStudentAt(2));
            Assert.AreEqual(studentD, studyGroup.GetStudentAt(3));
            Assert.AreEqual(studentE, studyGroup.GetStudentAt(4));
            Assert.AreEqual(studentF, studyGroup.GetStudentAt(5));
            Assert.AreEqual(studentG, studyGroup.GetStudentAt(6));
            Assert.AreEqual(studentH, studyGroup.GetStudentAt(7));
            Assert.AreEqual(studentI, studyGroup.GetStudentAt(8));
            Assert.AreEqual(studentJ, studyGroup.GetStudentAt(9));
            Assert.AreEqual(true, studyGroup.HasStudent(studentA.MatriculationId));
            Assert.AreEqual(true, studyGroup.HasStudent(studentB.MatriculationId));
            Assert.AreEqual(true, studyGroup.HasStudent(studentC.MatriculationId));
            Assert.AreEqual(true, studyGroup.HasStudent(studentD.MatriculationId));
            Assert.AreEqual(true, studyGroup.HasStudent(studentE.MatriculationId));
            Assert.AreEqual(true, studyGroup.HasStudent(studentF.MatriculationId));
            Assert.AreEqual(true, studyGroup.HasStudent(studentG.MatriculationId));
            Assert.AreEqual(true, studyGroup.HasStudent(studentH.MatriculationId));
            Assert.AreEqual(true, studyGroup.HasStudent(studentI.MatriculationId));
            Assert.AreEqual(true, studyGroup.HasStudent(studentJ.MatriculationId));

            studyGroup.RemoveStudent(studentJ.MatriculationId);

            Assert.AreEqual(3, studyGroup.CapacityFree);
            Assert.AreEqual(12, studyGroup.CapacityTotal);
            Assert.AreEqual(9, studyGroup.StudentsCount);
            Assert.AreEqual(studentA, studyGroup.GetStudentAt(0));
            Assert.AreEqual(studentB, studyGroup.GetStudentAt(1));
            Assert.AreEqual(studentC, studyGroup.GetStudentAt(2));
            Assert.AreEqual(studentD, studyGroup.GetStudentAt(3));
            Assert.AreEqual(studentE, studyGroup.GetStudentAt(4));
            Assert.AreEqual(studentF, studyGroup.GetStudentAt(5));
            Assert.AreEqual(studentG, studyGroup.GetStudentAt(6));
            Assert.AreEqual(studentH, studyGroup.GetStudentAt(7));
            Assert.AreEqual(studentI, studyGroup.GetStudentAt(8));
            Assert.AreEqual(null, studyGroup.GetStudentAt(9));
            Assert.AreEqual(true, studyGroup.HasStudent(studentA.MatriculationId));
            Assert.AreEqual(true, studyGroup.HasStudent(studentB.MatriculationId));
            Assert.AreEqual(true, studyGroup.HasStudent(studentC.MatriculationId));
            Assert.AreEqual(true, studyGroup.HasStudent(studentD.MatriculationId));
            Assert.AreEqual(true, studyGroup.HasStudent(studentE.MatriculationId));
            Assert.AreEqual(true, studyGroup.HasStudent(studentF.MatriculationId));
            Assert.AreEqual(true, studyGroup.HasStudent(studentG.MatriculationId));
            Assert.AreEqual(true, studyGroup.HasStudent(studentH.MatriculationId));
            Assert.AreEqual(true, studyGroup.HasStudent(studentI.MatriculationId));
            Assert.AreEqual(false, studyGroup.HasStudent(studentJ.MatriculationId));

            studyGroup.RemoveStudent(studentF.MatriculationId);

            Assert.AreEqual(4, studyGroup.CapacityFree);
            Assert.AreEqual(12, studyGroup.CapacityTotal);
            Assert.AreEqual(8, studyGroup.StudentsCount);
            Assert.AreEqual(studentA, studyGroup.GetStudentAt(0));
            Assert.AreEqual(studentB, studyGroup.GetStudentAt(1));
            Assert.AreEqual(studentC, studyGroup.GetStudentAt(2));
            Assert.AreEqual(studentD, studyGroup.GetStudentAt(3));
            Assert.AreEqual(studentE, studyGroup.GetStudentAt(4));
            Assert.AreEqual(studentG, studyGroup.GetStudentAt(5));
            Assert.AreEqual(studentH, studyGroup.GetStudentAt(6));
            Assert.AreEqual(studentI, studyGroup.GetStudentAt(7));
            Assert.AreEqual(null, studyGroup.GetStudentAt(8));
            Assert.AreEqual(null, studyGroup.GetStudentAt(9));
            Assert.AreEqual(true, studyGroup.HasStudent(studentA.MatriculationId));
            Assert.AreEqual(true, studyGroup.HasStudent(studentB.MatriculationId));
            Assert.AreEqual(true, studyGroup.HasStudent(studentC.MatriculationId));
            Assert.AreEqual(true, studyGroup.HasStudent(studentD.MatriculationId));
            Assert.AreEqual(true, studyGroup.HasStudent(studentE.MatriculationId));
            Assert.AreEqual(false, studyGroup.HasStudent(studentF.MatriculationId));
            Assert.AreEqual(true, studyGroup.HasStudent(studentG.MatriculationId));
            Assert.AreEqual(true, studyGroup.HasStudent(studentH.MatriculationId));
            Assert.AreEqual(true, studyGroup.HasStudent(studentI.MatriculationId));
            Assert.AreEqual(false, studyGroup.HasStudent(studentJ.MatriculationId));

            studyGroup.RemoveStudent(studentA.MatriculationId);

            Assert.AreEqual(5, studyGroup.CapacityFree);
            Assert.AreEqual(12, studyGroup.CapacityTotal);
            Assert.AreEqual(7, studyGroup.StudentsCount);
            Assert.AreEqual(studentB, studyGroup.GetStudentAt(0));
            Assert.AreEqual(studentC, studyGroup.GetStudentAt(1));
            Assert.AreEqual(studentD, studyGroup.GetStudentAt(2));
            Assert.AreEqual(studentE, studyGroup.GetStudentAt(3));
            Assert.AreEqual(studentG, studyGroup.GetStudentAt(4));
            Assert.AreEqual(studentH, studyGroup.GetStudentAt(5));
            Assert.AreEqual(studentI, studyGroup.GetStudentAt(6));
            Assert.AreEqual(null, studyGroup.GetStudentAt(7));
            Assert.AreEqual(null, studyGroup.GetStudentAt(8));
            Assert.AreEqual(null, studyGroup.GetStudentAt(9));
            Assert.AreEqual(false, studyGroup.HasStudent(studentA.MatriculationId));
            Assert.AreEqual(true, studyGroup.HasStudent(studentB.MatriculationId));
            Assert.AreEqual(true, studyGroup.HasStudent(studentC.MatriculationId));
            Assert.AreEqual(true, studyGroup.HasStudent(studentD.MatriculationId));
            Assert.AreEqual(true, studyGroup.HasStudent(studentE.MatriculationId));
            Assert.AreEqual(false, studyGroup.HasStudent(studentF.MatriculationId));
            Assert.AreEqual(true, studyGroup.HasStudent(studentG.MatriculationId));
            Assert.AreEqual(true, studyGroup.HasStudent(studentH.MatriculationId));
            Assert.AreEqual(true, studyGroup.HasStudent(studentI.MatriculationId));
            Assert.AreEqual(false, studyGroup.HasStudent(studentJ.MatriculationId));

            studyGroup.RemoveStudent(studentI.MatriculationId);

            Assert.AreEqual(6, studyGroup.CapacityFree);
            Assert.AreEqual(12, studyGroup.CapacityTotal);
            Assert.AreEqual(6, studyGroup.StudentsCount);
            Assert.AreEqual(studentB, studyGroup.GetStudentAt(0));
            Assert.AreEqual(studentC, studyGroup.GetStudentAt(1));
            Assert.AreEqual(studentD, studyGroup.GetStudentAt(2));
            Assert.AreEqual(studentE, studyGroup.GetStudentAt(3));
            Assert.AreEqual(studentG, studyGroup.GetStudentAt(4));
            Assert.AreEqual(studentH, studyGroup.GetStudentAt(5));
            Assert.AreEqual(null, studyGroup.GetStudentAt(6));
            Assert.AreEqual(null, studyGroup.GetStudentAt(7));
            Assert.AreEqual(null, studyGroup.GetStudentAt(8));
            Assert.AreEqual(null, studyGroup.GetStudentAt(9));
            Assert.AreEqual(false, studyGroup.HasStudent(studentA.MatriculationId));
            Assert.AreEqual(true, studyGroup.HasStudent(studentB.MatriculationId));
            Assert.AreEqual(true, studyGroup.HasStudent(studentC.MatriculationId));
            Assert.AreEqual(true, studyGroup.HasStudent(studentD.MatriculationId));
            Assert.AreEqual(true, studyGroup.HasStudent(studentE.MatriculationId));
            Assert.AreEqual(false, studyGroup.HasStudent(studentF.MatriculationId));
            Assert.AreEqual(true, studyGroup.HasStudent(studentG.MatriculationId));
            Assert.AreEqual(true, studyGroup.HasStudent(studentH.MatriculationId));
            Assert.AreEqual(false, studyGroup.HasStudent(studentI.MatriculationId));
            Assert.AreEqual(false, studyGroup.HasStudent(studentJ.MatriculationId));

            studyGroup.RemoveStudent(studentG.MatriculationId);

            Assert.AreEqual(7, studyGroup.CapacityFree);
            Assert.AreEqual(12, studyGroup.CapacityTotal);
            Assert.AreEqual(5, studyGroup.StudentsCount);
            Assert.AreEqual(studentB, studyGroup.GetStudentAt(0));
            Assert.AreEqual(studentC, studyGroup.GetStudentAt(1));
            Assert.AreEqual(studentD, studyGroup.GetStudentAt(2));
            Assert.AreEqual(studentE, studyGroup.GetStudentAt(3));
            Assert.AreEqual(studentH, studyGroup.GetStudentAt(4));
            Assert.AreEqual(null, studyGroup.GetStudentAt(5));
            Assert.AreEqual(null, studyGroup.GetStudentAt(6));
            Assert.AreEqual(null, studyGroup.GetStudentAt(7));
            Assert.AreEqual(null, studyGroup.GetStudentAt(8));
            Assert.AreEqual(null, studyGroup.GetStudentAt(9));
            Assert.AreEqual(false, studyGroup.HasStudent(studentA.MatriculationId));
            Assert.AreEqual(true, studyGroup.HasStudent(studentB.MatriculationId));
            Assert.AreEqual(true, studyGroup.HasStudent(studentC.MatriculationId));
            Assert.AreEqual(true, studyGroup.HasStudent(studentD.MatriculationId));
            Assert.AreEqual(true, studyGroup.HasStudent(studentE.MatriculationId));
            Assert.AreEqual(false, studyGroup.HasStudent(studentF.MatriculationId));
            Assert.AreEqual(false, studyGroup.HasStudent(studentG.MatriculationId));
            Assert.AreEqual(true, studyGroup.HasStudent(studentH.MatriculationId));
            Assert.AreEqual(false, studyGroup.HasStudent(studentI.MatriculationId));
            Assert.AreEqual(false, studyGroup.HasStudent(studentJ.MatriculationId));

            studyGroup.RemoveStudent(studentC.MatriculationId);

            Assert.AreEqual(8, studyGroup.CapacityFree);
            Assert.AreEqual(12, studyGroup.CapacityTotal);
            Assert.AreEqual(4, studyGroup.StudentsCount);
            Assert.AreEqual(studentB, studyGroup.GetStudentAt(0));
            Assert.AreEqual(studentD, studyGroup.GetStudentAt(1));
            Assert.AreEqual(studentE, studyGroup.GetStudentAt(2));
            Assert.AreEqual(studentH, studyGroup.GetStudentAt(3));
            Assert.AreEqual(null, studyGroup.GetStudentAt(4));
            Assert.AreEqual(null, studyGroup.GetStudentAt(5));
            Assert.AreEqual(null, studyGroup.GetStudentAt(6));
            Assert.AreEqual(null, studyGroup.GetStudentAt(7));
            Assert.AreEqual(null, studyGroup.GetStudentAt(8));
            Assert.AreEqual(null, studyGroup.GetStudentAt(9));
            Assert.AreEqual(false, studyGroup.HasStudent(studentA.MatriculationId));
            Assert.AreEqual(true, studyGroup.HasStudent(studentB.MatriculationId));
            Assert.AreEqual(false, studyGroup.HasStudent(studentC.MatriculationId));
            Assert.AreEqual(true, studyGroup.HasStudent(studentD.MatriculationId));
            Assert.AreEqual(true, studyGroup.HasStudent(studentE.MatriculationId));
            Assert.AreEqual(false, studyGroup.HasStudent(studentF.MatriculationId));
            Assert.AreEqual(false, studyGroup.HasStudent(studentG.MatriculationId));
            Assert.AreEqual(true, studyGroup.HasStudent(studentH.MatriculationId));
            Assert.AreEqual(false, studyGroup.HasStudent(studentI.MatriculationId));
            Assert.AreEqual(false, studyGroup.HasStudent(studentJ.MatriculationId));

            studyGroup.RemoveStudent(studentE.MatriculationId);

            Assert.AreEqual(9, studyGroup.CapacityFree);
            Assert.AreEqual(12, studyGroup.CapacityTotal);
            Assert.AreEqual(3, studyGroup.StudentsCount);
            Assert.AreEqual(studentB, studyGroup.GetStudentAt(0));
            Assert.AreEqual(studentD, studyGroup.GetStudentAt(1));
            Assert.AreEqual(studentH, studyGroup.GetStudentAt(2));
            Assert.AreEqual(null, studyGroup.GetStudentAt(3));
            Assert.AreEqual(null, studyGroup.GetStudentAt(4));
            Assert.AreEqual(null, studyGroup.GetStudentAt(5));
            Assert.AreEqual(null, studyGroup.GetStudentAt(6));
            Assert.AreEqual(null, studyGroup.GetStudentAt(7));
            Assert.AreEqual(null, studyGroup.GetStudentAt(8));
            Assert.AreEqual(null, studyGroup.GetStudentAt(9));
            Assert.AreEqual(false, studyGroup.HasStudent(studentA.MatriculationId));
            Assert.AreEqual(true, studyGroup.HasStudent(studentB.MatriculationId));
            Assert.AreEqual(false, studyGroup.HasStudent(studentC.MatriculationId));
            Assert.AreEqual(true, studyGroup.HasStudent(studentD.MatriculationId));
            Assert.AreEqual(false, studyGroup.HasStudent(studentE.MatriculationId));
            Assert.AreEqual(false, studyGroup.HasStudent(studentF.MatriculationId));
            Assert.AreEqual(false, studyGroup.HasStudent(studentG.MatriculationId));
            Assert.AreEqual(true, studyGroup.HasStudent(studentH.MatriculationId));
            Assert.AreEqual(false, studyGroup.HasStudent(studentI.MatriculationId));
            Assert.AreEqual(false, studyGroup.HasStudent(studentJ.MatriculationId));

            studyGroup.RemoveStudent(studentH.MatriculationId);

            Assert.AreEqual(10, studyGroup.CapacityFree);
            Assert.AreEqual(12, studyGroup.CapacityTotal);
            Assert.AreEqual(2, studyGroup.StudentsCount);
            Assert.AreEqual(studentB, studyGroup.GetStudentAt(0));
            Assert.AreEqual(studentD, studyGroup.GetStudentAt(1));
            Assert.AreEqual(null, studyGroup.GetStudentAt(2));
            Assert.AreEqual(null, studyGroup.GetStudentAt(3));
            Assert.AreEqual(null, studyGroup.GetStudentAt(4));
            Assert.AreEqual(null, studyGroup.GetStudentAt(5));
            Assert.AreEqual(null, studyGroup.GetStudentAt(6));
            Assert.AreEqual(null, studyGroup.GetStudentAt(7));
            Assert.AreEqual(null, studyGroup.GetStudentAt(8));
            Assert.AreEqual(null, studyGroup.GetStudentAt(9));
            Assert.AreEqual(false, studyGroup.HasStudent(studentA.MatriculationId));
            Assert.AreEqual(true, studyGroup.HasStudent(studentB.MatriculationId));
            Assert.AreEqual(false, studyGroup.HasStudent(studentC.MatriculationId));
            Assert.AreEqual(true, studyGroup.HasStudent(studentD.MatriculationId));
            Assert.AreEqual(false, studyGroup.HasStudent(studentE.MatriculationId));
            Assert.AreEqual(false, studyGroup.HasStudent(studentF.MatriculationId));
            Assert.AreEqual(false, studyGroup.HasStudent(studentG.MatriculationId));
            Assert.AreEqual(false, studyGroup.HasStudent(studentH.MatriculationId));
            Assert.AreEqual(false, studyGroup.HasStudent(studentI.MatriculationId));
            Assert.AreEqual(false, studyGroup.HasStudent(studentJ.MatriculationId));

            studyGroup.RemoveStudent(studentB.MatriculationId);

            Assert.AreEqual(11, studyGroup.CapacityFree);
            Assert.AreEqual(12, studyGroup.CapacityTotal);
            Assert.AreEqual(1, studyGroup.StudentsCount);
            Assert.AreEqual(studentD, studyGroup.GetStudentAt(0));
            Assert.AreEqual(null, studyGroup.GetStudentAt(1));
            Assert.AreEqual(null, studyGroup.GetStudentAt(2));
            Assert.AreEqual(null, studyGroup.GetStudentAt(3));
            Assert.AreEqual(null, studyGroup.GetStudentAt(4));
            Assert.AreEqual(null, studyGroup.GetStudentAt(5));
            Assert.AreEqual(null, studyGroup.GetStudentAt(6));
            Assert.AreEqual(null, studyGroup.GetStudentAt(7));
            Assert.AreEqual(null, studyGroup.GetStudentAt(8));
            Assert.AreEqual(null, studyGroup.GetStudentAt(9));
            Assert.AreEqual(false, studyGroup.HasStudent(studentA.MatriculationId));
            Assert.AreEqual(false, studyGroup.HasStudent(studentB.MatriculationId));
            Assert.AreEqual(false, studyGroup.HasStudent(studentC.MatriculationId));
            Assert.AreEqual(true, studyGroup.HasStudent(studentD.MatriculationId));
            Assert.AreEqual(false, studyGroup.HasStudent(studentE.MatriculationId));
            Assert.AreEqual(false, studyGroup.HasStudent(studentF.MatriculationId));
            Assert.AreEqual(false, studyGroup.HasStudent(studentG.MatriculationId));
            Assert.AreEqual(false, studyGroup.HasStudent(studentH.MatriculationId));
            Assert.AreEqual(false, studyGroup.HasStudent(studentI.MatriculationId));
            Assert.AreEqual(false, studyGroup.HasStudent(studentJ.MatriculationId));

            studyGroup.RemoveStudent(studentD.MatriculationId);

            Assert.AreEqual(12, studyGroup.CapacityFree);
            Assert.AreEqual(12, studyGroup.CapacityTotal);
            Assert.AreEqual(0, studyGroup.StudentsCount);
            Assert.AreEqual(null, studyGroup.GetStudentAt(0));
            Assert.AreEqual(null, studyGroup.GetStudentAt(1));
            Assert.AreEqual(null, studyGroup.GetStudentAt(2));
            Assert.AreEqual(null, studyGroup.GetStudentAt(3));
            Assert.AreEqual(null, studyGroup.GetStudentAt(4));
            Assert.AreEqual(null, studyGroup.GetStudentAt(5));
            Assert.AreEqual(null, studyGroup.GetStudentAt(6));
            Assert.AreEqual(null, studyGroup.GetStudentAt(7));
            Assert.AreEqual(null, studyGroup.GetStudentAt(8));
            Assert.AreEqual(null, studyGroup.GetStudentAt(9));
            Assert.AreEqual(false, studyGroup.HasStudent(studentA.MatriculationId));
            Assert.AreEqual(false, studyGroup.HasStudent(studentB.MatriculationId));
            Assert.AreEqual(false, studyGroup.HasStudent(studentC.MatriculationId));
            Assert.AreEqual(false, studyGroup.HasStudent(studentD.MatriculationId));
            Assert.AreEqual(false, studyGroup.HasStudent(studentE.MatriculationId));
            Assert.AreEqual(false, studyGroup.HasStudent(studentF.MatriculationId));
            Assert.AreEqual(false, studyGroup.HasStudent(studentG.MatriculationId));
            Assert.AreEqual(false, studyGroup.HasStudent(studentH.MatriculationId));
            Assert.AreEqual(false, studyGroup.HasStudent(studentI.MatriculationId));
            Assert.AreEqual(false, studyGroup.HasStudent(studentJ.MatriculationId));
        }
    }
}
