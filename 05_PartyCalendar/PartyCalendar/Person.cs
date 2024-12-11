using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyCalendar
{
    public class Person
    {
        private const string EMPYT_EMAIL_ADDRESS = "";
        private const int MAX_PARTY_COUNT = 5;
        private const int MAX_ATS_COUNT = 1;

        private static int idCounter = -1;
        private int id;
        private string firstName;
        private string lastName;
        private string emailAddress;
        private int partyCount = 0;

        public int Id
        {
            get
            {
                return this.id;
            }
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            private set
            {
                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }
            private set
            {
                this.lastName = value;
            }
        }

        public string EmailAddress
        {
            get
            {
                return this.emailAddress;
            }
            set
            {
                if(string.IsNullOrEmpty(value) || HasInvalidpoints(value) || HasInvalidAt(value) || HasInvalidChar(value) || value[0] == '@' || value[0] == '.')
                {
                    value = EMPYT_EMAIL_ADDRESS;
                }

                this.emailAddress = value;
            }
        }

        private bool HasInvalidChar(string value)
        {
            bool hasInvalid = false;

            for (int i = 0; i < value.Length && !hasInvalid; i++)
            {
                char letter = value[i];

                if (!IsBigLetter(letter) && !IsSmallLetter(letter) && !IsDash(letter) && !IsUnderscore(letter) && !IsNumber(letter) && letter != '@' && letter != '.') 
                {
                    hasInvalid = true;
                }
            }

            return hasInvalid;
        }

        private bool IsNumber(char letter)
        {
            return ('0' <= letter && letter <= '9');
        }

        private bool IsDash(char letter)
        {
            return (letter == '-');
        }

        private bool IsUnderscore(char letter)
        {
            return (letter == '_');
        }

        private bool IsBigLetter(char letter)
        {
            return ('A' <= letter && letter <= 'Z');
        }

        private bool IsSmallLetter(char letter)
        {
            return ('a' <= letter && letter <= 'z');
        }

        private bool HasInvalidpoints(string value)
        {
            bool invalidPoints = false;

            for (int i = 0; i < value.Length && !invalidPoints; i++)
            {
                if (i+1 < value.Length)
                {
                    if (value[i] == '.' && value[i + 1] == '.' || value[i] == '@' && value[i + 1] == '.')
                    {
                        invalidPoints = true;
                    }
                }
            }

            if(value[value.Length - 1] == '.')
            {
                invalidPoints = true;
            }

            return invalidPoints;
        }

        private bool HasInvalidAt(string value)
        {
            int howManyAts = 0;
            bool moreThanOne = false;

            for (int i = 0; i < value.Length; i++)
            {
                if (value[i] == '@')
                {
                    howManyAts++;
                }
            }

            if (howManyAts != MAX_ATS_COUNT || value[value.Length - 1] == '@')
            {
                moreThanOne = true;
            }

            return moreThanOne;
        }

        public int PartyCount
        {
            get
            {
                return this.partyCount;
            }
            private set
            {
                this.partyCount = value;
            }
        }

        public Person(string firstName, string lastName)
            :this(firstName, lastName, EMPYT_EMAIL_ADDRESS)
        {
        }

        public Person(string firstName, string lastName, string emailAddress)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.EmailAddress = emailAddress;
            this.id = idCounter++;
        }

        public bool VisitParty()
        {
            bool isVisitSuccessful = false;

            if(this.partyCount < MAX_PARTY_COUNT)
            {
                this.PartyCount = this.partyCount + 1;
                isVisitSuccessful = true;
            }

            return isVisitSuccessful;
        }

        public void UnvisitParty()
        {
            if(this.partyCount > 0)
            {
                this.PartyCount = this.partyCount - 1;
            }
        }

        public override string ToString()
        {
            string result = "";

            if(!(string.IsNullOrEmpty(this.firstName) || string.IsNullOrEmpty(this.lastName)))
            {
                result = $"{this.firstName} {this.lastName}";

                if(!(string.IsNullOrEmpty(this.emailAddress)))
                {
                    result += $" ({this.emailAddress})";
                }
            }

            return result;
        }
    }
}
