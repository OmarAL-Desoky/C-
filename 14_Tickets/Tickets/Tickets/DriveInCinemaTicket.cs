using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickets
{
    public class DriveInCinemaTicket : CinemaTicket
    {
        private int passengerCount;

        public int PassengerCount
        {
            get 
            { 
                return this.passengerCount; 
            }
        }

        public DriveInCinemaTicket(string name, string place, double price, int minutes, int passengerCount)
            : base(name, place, price, minutes)
        {
            this.passengerCount = passengerCount;
        }

        public override double CalculatePrice()
        {
            return base.CalculatePrice() * this.passengerCount;
        }

        public override void PrintTicket()
        {
            base.PrintTicket();
        }
    }
}
