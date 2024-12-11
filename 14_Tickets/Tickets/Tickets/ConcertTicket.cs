using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickets
{
    public class ConcertTicket : Ticket
    {
        private int seatPosition;

        public int SeatPosition
        {
            get
            {
                return this.seatPosition;
            }
            set
            {
                this.seatPosition = value;

                if (value < 1)
                {
                    this.seatPosition = 1;
                }
            }
        }

        public ConcertTicket(string name, string place, double price, int seatPosition)
            :base(name, place, price)
        {
            this.SeatPosition = seatPosition;
        }

        public override double CalculatePrice()
        {
            return this.Price + (this.Price/this.seatPosition);
        }

        public override void PrintTicket()
        {
            base.PrintTicket();
            Console.WriteLine($"|        . Reihe {this.seatPosition}");
            Console.WriteLine("|        .");
            Console.WriteLine("+ --------------------------------------------------");
        }
    }
}
