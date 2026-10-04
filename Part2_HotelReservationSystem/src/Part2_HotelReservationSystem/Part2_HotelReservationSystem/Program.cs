using static Part2_HotelReservationSystem.Room;

namespace Part2_HotelReservationSystem
{
    internal class Program
    {
        static void Main()
        {
            var room101 = new Room(101, RoomType.Single, 500m);
            var room201 = new Room(201, RoomType.Suite, 1500m);
            var guest = new Guest(1, "Mohamed Abo-Trika", "01222222222");

            var r1 = guest.MakeReservation(1, room101, new DateOnly(2026, 10, 10), new DateOnly(2026, 10, 13));
            Console.WriteLine($"Reservation {r1.ReservationId} | room {r1.Room.RoomNumber} | nights {r1.Nights} | total {r1.TotalCost:F2} | {r1.Status}");


            r1.Confirm();
            r1.CheckIn();
            Console.WriteLine($"Status after check-in: {r1.Status}");

            r1.CheckOut();
            Console.WriteLine($"Status after check-out: {r1.Status}");

            var r2 = guest.MakeReservation(2, room201, new DateOnly(2026, 10, 20), new DateOnly(2026, 10, 25));
            Console.WriteLine($"Guest has {guest.Reservations.Count} reservations");

            try
            {
                guest.MakeReservation(3, room101, new DateOnly(2026, 11, 5), new DateOnly(2026, 11, 1));
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Rejected: {ex.Message}");
            }

            try
            {
                guest.MakeReservation(4, room201, new DateOnly(2026, 10, 22), new DateOnly(2026, 10, 27));
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Rejected: {ex.Message}");
            }

            var r5 = guest.MakeReservation(5, room201, new DateOnly(2026, 10, 25), new DateOnly(2026, 10, 28));
            Console.WriteLine($"Accepted: reservation {r5.ReservationId} starts on the day reservation 2 ends");

            room101.StartMaintenance();
            try
            {
                guest.MakeReservation(6, room101, new DateOnly(2026, 12, 1), new DateOnly(2026, 12, 3));
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Rejected: {ex.Message}");
            }
            room101.EndMaintenance();

            try
            {
                r2.CheckIn();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Rejected: {ex.Message}");
            }

            try
            {
                r1.Cancel();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Rejected: {ex.Message}");
            }

            try
            {
                room101.SetNightlyRate(0m);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Rejected: {ex.Message}");
            }

            try
            {
                var bad = new Guest(2, "", "0100");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Rejected: {ex.Message}");
            }

        }
    }
}


/*
 * 
 * The Output , to be more clear for you.
 * 
Reservation 1 | room 101 | nights 3 | total 1500.00 | Pending
Status after check-in: CheckedIn
Status after check-out: CheckedOut
Guest has 2 reservations
Rejected: Check-out date must be after check-in date.
Rejected: Room 201 is already booked for those dates.
Accepted: reservation 5 starts on the day reservation 2 ends
Rejected: Room 101 is under maintenance.
Rejected: Only a Confirmed reservation can be checked in.
Rejected: Cannot cancel a reservation that is CheckedOut.
Rejected: Nightly rate must be positive.
Rejected: Full name is mandatory.
 
 
 */