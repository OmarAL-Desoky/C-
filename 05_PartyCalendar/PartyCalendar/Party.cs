using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyCalendar
{
    public class Party
    {
        private string title;
        private DateTime date;
        private Person organizer;
        private bool isCancelled;
        private Person[] participants;

        public string Title
        {
            get
            {
                return this.title;
            }
            set
            {
                this.title = value;
            }
        }

        public DateTime Date
        {
            get
            {
                return this.date;
            }
            set
            {
                this.date = value;
            }
        }

        public Person Organizer
        {
            get
            {
                return this.organizer;
            }
            private set
            {
                this.organizer = value;
            }
        }

        public bool IsCancelled
        {
            get
            {
                return this.isCancelled;
            }
            private set
            {
                this.isCancelled = value;
            }
        }

        public int MaxParticipantCount
        {
            get
            {
                return this.participants.Length;
            }
        }

        public int ParticipantCount
        {
            get
            {
                int participantCount = 0;

                for (int i = 0; i < this.participants.Length; i++)
                {
                    if (participants[i] != null)
                    {
                        participantCount++;
                    }
                }

                return participantCount;
            }
        }

        public Party(string title, DateTime date, Person organizer, int maxParticipantCount)
        {
            this.Title = title;
            this.Date = date;
            this.Organizer = organizer;
            participants = new Person[maxParticipantCount];
        }

        public void Cancel()
        {
            this.IsCancelled = true;

            for(int i = 0; i < this.participants.Length; i++)
            {
                if (participants[i] != null)
                {
                    participants[i].UnvisitParty();
                }
            }
        }

        public int FindRegistration(int participantId)
        {
            int registration = -1;
            bool found = false;

            for(int i = 0; i < participants.Length && !found; i++)
            {
                if (participants[i] != null && (participants[i].Id == participantId))
                {
                    registration = i;
                    found = true;
                }
            }

            return registration;
        }

        public bool IsRegistered(int participantId)
        {
            return (FindRegistration(participantId) != -1);
        }

        public bool Register(Person participant)
        {
            bool registered = false;

            if(!IsRegistered(participant.Id))
            {
                for (int i = 0; i < participants.Length && !registered; i++)
                {
                    if (participants[i] == null && !this.isCancelled)
                    {
                        if (participant.VisitParty())
                        {
                            participants[i] = participant;
                            registered = true;
                        }
                    }
                }
            }

            return registered;
        }

        public bool Unregister(Person participant)
        {
            bool unRegistered = false;

            for (int i = 0; i < participants.Length; i++)
            {
                if (participants[i] != null && (this.participants[i].Id == participant.Id))
                {
                    participant.UnvisitParty();
                    participants[i] = null;
                    unRegistered = true;
                }
            }

            return unRegistered;
        }

        public override string ToString()
        {
            string datePretty = date.ToString("d.M.yyyy");
            string result = $"{datePretty} - {this.title} ({this.ParticipantCount}/{this.MaxParticipantCount})";
            return result;
        }
    }
}
