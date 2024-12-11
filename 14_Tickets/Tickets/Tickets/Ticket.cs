using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Tickets
{
    public abstract class Ticket 
    {
        private static int idCounter = 1;
        private readonly int id;
        private string name;
        private string place;
        private double price;

        public int Id
        {
            get
            {
                return this.id;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
        }

        public string Place
        {
            get
            {
                return this.place;
            }
        }

        public double Price
        {
            get
            {
                return this.price;
            }
            private set
            {
                this.price = value;
            }
        }

        public Ticket(string name, string place, double price)
        {
            this.id = (idCounter++);
            this.name = name;
            this.place = place;
            this.Price = price;
        }

        public abstract double CalculatePrice();

        public virtual void PrintTicket()
        {
            Console.WriteLine("+--------------------------------------------------");
            Console.WriteLine("|        .");
            Console.WriteLine($"|        . Ticket - Nr: {this.id}");
            Console.WriteLine($"|        . {this.CalculatePrice():f1} Euro");
            Console.WriteLine($"|        . {this.name}");
            Console.WriteLine($"|        . {this.place}");
        }
    }
}
