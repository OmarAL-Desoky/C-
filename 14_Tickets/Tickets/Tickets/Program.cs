namespace Tickets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConcertTicket concert = new ConcertTicket("Jan Garbarek Group", "Musiktheater Linz", 52.5, 3);
            SoccerTicket soccer = new SoccerTicket("FC Blau Weiss Linz", "Donauparkstadion", 30, PlaceCategory.Standing);
            CinemaTicket cinema = new CinemaTicket("Fight Club", "City Kino", 9.5, 139);
            DriveInCinemaTicket driveInCinema = new DriveInCinemaTicket("Mad Max: Fury Road", "Autokino Urfahr", 15, 120, 2);
            
            List<Ticket> tickets = new List<Ticket>();
            tickets.Add(concert);
            tickets.Add(soccer);
            tickets.Add(cinema);
            tickets.Add(driveInCinema);

            foreach(Ticket currTicket in tickets)
            {
                currTicket.PrintTicket();
            }
        }
    }
}