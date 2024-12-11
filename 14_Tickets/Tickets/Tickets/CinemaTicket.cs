using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickets
{
    public class CinemaTicket : Ticket
    {
        private int minutes;

        public CinemaTicket(string name, string place, double price, int minutes)
            : base(name, place, price)
        {
            this.minutes = minutes;
        }

        public override double CalculatePrice()
        {
            return this.minutes > 120 ? this.Price + 3 : this.Price;
        }

        public override void PrintTicket()
        {
            base.PrintTicket();
            Console.WriteLine($"|        . Spielzeit: {this.minutes} Minuten");
            Console.WriteLine("|        .");
            Console.WriteLine("+ --------------------------------------------------");
        }
    }
}
