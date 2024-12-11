using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAdministration
{
    public class Student
    {
        private const int MAX_STUDY_HOURS = 5;
        private const int MIN_STUDY_HOURS = 0;

        private static int idCounter = 1;

        private readonly int matriculationId;
        private string name;
        private int hoursStudied;

        public int MatriculationId
        {
            get
            {
                return this.matriculationId;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
        }

        public int HoursStudied
        {
            get
            {
                return this.hoursStudied;
            }
        }

        public Student(string name)
        {
            this.name = name;
            this.matriculationId = (idCounter++); 
        }

        public override string ToString()
        {
            string result = $"#{this.matriculationId} {this.name} ({this.hoursStudied} hours)";
            return result;
        }

        public int Study(int hours)
        {
            if (hours > MAX_STUDY_HOURS)
            {
                hours = MAX_STUDY_HOURS;
            }
            else if (hours < MIN_STUDY_HOURS)
            {
                hours = MIN_STUDY_HOURS;
            }

            if (MIN_STUDY_HOURS < hours)
            {
                this.hoursStudied += hours;
            }

            return hours;
        }
    }
}
