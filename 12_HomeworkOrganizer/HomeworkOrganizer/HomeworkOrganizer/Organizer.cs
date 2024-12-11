using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkOrganizer
{
    public class Organizer
    {
        private HomeworkNode head;

        public int HomeworkCount
        {
            get
            {
                int count = 0;

                HomeworkNode searcher = this.head;

                while(searcher != null)
                {
                    count++;
                    searcher = searcher.Next;
                }

                return count;
            }
        }

        public int GetHomeworkCountByCourse(string course)
        {
            int countByCourse = 0;

            HomeworkNode searcher = this.head;

            while (searcher != null)
            {
                if (searcher.Homework.Course.Equals(course))
                {
                    countByCourse++;
                }
                
                searcher = searcher.Next;
            }

            return countByCourse;
        }

        public int GetHomeworkCountBetweenDates(DateTime from, DateTime to)
        {
            if(to < from)
            {
                throw new ArgumentException("From-Date must be before To-Date!");
            }

            int countBetweenDates = 0;
            HomeworkNode searcher = this.head;

            while (searcher != null)
            {
                if(from < searcher.Homework.Deadline && searcher.Homework.Deadline < to)
                {
                    countBetweenDates++;
                }

                searcher = searcher.Next;
            }

            return countBetweenDates;
        }

        public Homework GetHomeworkAt(int idx)
        {
            Homework result = null;

            int count = 0;
            HomeworkNode searcher = this.head;

            while(result == null && searcher != null)
            {
                if(idx == count)
                {
                    result = searcher.Homework;
                }

                searcher = searcher.Next;
                count++;
            }

            return result;
        }

        public void AddHomework(Homework homework)
        {
            HomeworkNode homeworkToAdd = new HomeworkNode(homework);

            if(this.head == null || homeworkToAdd.Homework.Deadline < this.head.Homework.Deadline)
            {
                homeworkToAdd.Next = this.head;
                this.head = homeworkToAdd;
            }
            else
            {
                HomeworkNode searcher = head;

                while(searcher.Next != null && searcher.Next.Homework.Deadline <= homeworkToAdd.Homework.Deadline)
                {
                    searcher = searcher.Next;
                }

                homeworkToAdd.Next = searcher.Next;
                searcher.Next = homeworkToAdd;
            }
        }

        public bool TurnInHomework(int moodleId)
        {
            bool turnedIn = false;

            if(this.head != null)
            {
                HomeworkNode searcher = this.head;

                if(searcher.Homework.MoodleId == moodleId)
                {
                    this.head = this.head.Next;
                }
                else
                {
                    while (searcher.Next != null && searcher.Next.Homework.MoodleId != moodleId)
                    {
                        searcher = searcher.Next;
                    }

                    if (searcher.Next != null)
                    {
                        searcher.Next = searcher.Next.Next;
                        turnedIn = true;
                    }
                }
            }

            return turnedIn;
        }

        public Homework this[int index]
        {
            get
            {
                return GetHomeworkAt(index);
            }
        }
    }
}
