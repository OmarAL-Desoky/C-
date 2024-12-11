using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAdministration
{
    public class StudyGroup
    {
        private const int STUDENTS_IN_A_STUDY_GROUP = 3;

        private Student[] students;
        private int studentsCount;

        public int StudentsCount
        {
            get 
            { 
                return this.studentsCount; 
            }
        }

        public int CapacityFree
        {
            get
            {
                int count = 0;

                for(int i = 0; i < this.students.Length; i++)
                {
                    if (students[i] == null)
                    {
                        count++;
                    }
                }

                return count;
            }
        }

        public int CapacityTotal
        {
            get
            {
                return this.students.Length;
            }
        }

        public StudyGroup()
        {
            this.students = new Student[STUDENTS_IN_A_STUDY_GROUP];
        }

        public bool AddStudent(Student student)
        {
            bool addedStudent = false;

            if (!HasStudent(student.MatriculationId))
            {
                if (studentsCount == CapacityTotal)
                {
                    Student[] newGroup = new Student[this.students.Length + STUDENTS_IN_A_STUDY_GROUP];

                    for(int i = 0; i < this.students.Length; i++)
                    {
                        newGroup[i] = this.students[i];
                    }

                    this.students = newGroup;
                }

                this.students[studentsCount] = student;
                addedStudent = true;
                studentsCount++;
            }

            return addedStudent;
        }

        public Student GetStudentAt(int index)
        {
            Student student = null;

            if (0 <= index && index <= (CapacityTotal - 1))
            {
                student = this.students[index];
            }

            return student;
        }

        public bool HasStudent(int id)
        {
            bool hasStudent = false;

            for(int i = 0; i < studentsCount && !hasStudent; i++)
            {
                if (this.students[i].MatriculationId == id)
                {
                    hasStudent = true;
                }
            }

            return hasStudent;
        }

        public bool RemoveStudent(int id)
        {
            bool removedStudent = false;    

            for(int i = 0; i < studentsCount && !removedStudent; i++)
            {
                if (this.students[i] != null && this.students[i].MatriculationId == id)
                {
                    if (i != studentsCount - 1)
                    {
                        for (int j = i + 1; j < studentsCount; j++)
                        {
                            this.students[j - 1] = this.students[j];

                            if (j == (studentsCount - 1) || this.students[j+1] == null)
                            {
                                this.students[j] = null;
                            }
                        }
                    } 
                    else
                    {
                        this.students[i] = null;
                    }

                    removedStudent = true;
                    studentsCount--;
                }
            }

            return removedStudent;
        }

        public void Sort()
        {
            for(int i = 0; i < studentsCount - 1; i++)
            {
                int lowestindex = i;
                bool isFound = false;

                for(int j = i+1; j < studentsCount; j++)
                {
                    if (this.students[j].Name.CompareTo(this.students[lowestindex].Name) == -1)
                    {
                        lowestindex = j;
                        isFound = true;
                    }
                }

                if (isFound)
                {
                    Student temp = this.students[i];
                    this.students[i] = this.students[lowestindex];
                    this.students[lowestindex] = temp;
                }
            }
        }

        public int Study(int hours)
        {
            int result = 0;

            for(int i = 0; i < this.students.Length; i++)
            {
                if (this.students[i] != null)
                {
                    result += this.students[i].Study(hours);
                }
            }

            return result;
        }
    }
}
