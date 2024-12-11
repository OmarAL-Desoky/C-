using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkOrganizer
{
    public class HomeworkNode
    {
        private HomeworkNode next;
        private Homework homework;

        public HomeworkNode Next
        {
            get
            {
                return this.next;
            }
            set 
            {
                this.next = value; 
            }
        }

        public Homework Homework
        {
            get
            {
                return this.homework;
            }
        }

        public HomeworkNode(Homework homework)
        {
            this.homework = homework;
        }
    }
}
