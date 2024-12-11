using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickets
{
    public class SoccerTicket : Ticket 
    {
        private PlaceCategory placeCategory;

        public PlaceCategory PlaceCategory
        {
            get
            {
                return this.placeCategory;
            }
        }

        public SoccerTicket(string name, string place, double price, PlaceCategory placeCategory)
            : base(name, place, price)
        {
            this.placeCategory = placeCategory;
        }

        public override double CalculatePrice()
        {
            double result = this.Price;

            if(this.placeCategory == PlaceCategory.Standing)
            {
                result /= 2;
            } 
            else if (this.placeCategory == PlaceCategory.VIP)
            {
                result *= 5;
            }

            return result;
        }

        public override void PrintTicket()
        {
            base.PrintTicket();
            Console.WriteLine($"|        . {this.placeCategory}");
            Console.WriteLine("|        .");
            Console.WriteLine("+ --------------------------------------------------");
        }
    }
}
