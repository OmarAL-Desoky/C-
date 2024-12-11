using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkOrganizer
{
    public class Homework
    {
        private const int MAX_LENGTH = 4;

        private int moodleId;
        private string course;
        private string task;
        private DateTime deadline;

        public int MoodleId
        {
            get
            {
                return this.moodleId;
            }
            private set
            {
                if(value < 1)
                {
                    throw new ArgumentException("Moodle Id must not be smaller than 1!");
                }

                this.moodleId = value;
            }
        }

        public string Course
        {
            get
            {
                return this.course;
            }
            private set
            {
                if(string.IsNullOrEmpty(value) || value.Length > MAX_LENGTH)
                {
                    throw new ArgumentException("Course name must be between 1 and 4 characters long!");
                }

                value = value.ToUpper();

                if (!ContainsOnlyLetters(value))
                {
                    throw new ArgumentException("Course name must only contain letters!");
                }

                this.course = value;
            }
        }

        public bool ContainsOnlyLetters(string course)
        {
            bool containsOnlyLetters = true;

            for(int i = 0; i < course.Length; i++)
            {
                if (!('A' <= course[i] && course[i] <= 'Z'))
                {
                    containsOnlyLetters = false;
                }
            }

            return containsOnlyLetters;
        }

        public string Task
        {
            get
            {
                return this.task;
            }
        }

        public DateTime Deadline
        {
            get
            {
                return this.deadline;
            }
        }

        public Homework(int moodleId, string course, string task, DateTime deadline)
        {
            this.MoodleId = moodleId;
            this.Course = course;
            this.task = task;
            this.deadline = deadline;
        }
    }
}
