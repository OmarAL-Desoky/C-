using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soccer
{
    public class SoccerPlayer
    {
        private const int MAX_JERSEY_NUMBER = 99;
        private const int MIN_JERSEY_NUMBER = 1;

        private int jerseyNumber;
        private string name;
        private SoccerPosition position;

        public int JerseyNumber
        {
            get
            {
                return this.jerseyNumber;
            }
            private set
            {
                if(value > MAX_JERSEY_NUMBER || value < MIN_JERSEY_NUMBER)
                {
                    throw new ArgumentException("Jersey number must be between 1 and 99!");
                }

                this.jerseyNumber = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
        }

        public SoccerPosition Position
        {
            get
            {
                return this.position;
            }
        }

        public SoccerPlayer(int jerseyNumber, string name, SoccerPosition position)
        {
            this.JerseyNumber = jerseyNumber;
            this.name = name;
            this.position = position;
        }

        public char GetFirstLetterOfPosition
        {
            get
            {
                return this.position.ToString()[0];
            }
        }

        public override string ToString()
        {
            string result = $"#{this.jerseyNumber} {this.name} ({this.GetFirstLetterOfPosition})";
            return result;
        }

        public override bool Equals(object? obj)
        {
            return obj is SoccerPlayer player &&
                   jerseyNumber == player.jerseyNumber;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(jerseyNumber);
        }
    }
}
