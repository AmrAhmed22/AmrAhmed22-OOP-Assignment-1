using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part2_HotelReservationSystem
{
    public class Guest
    {

        public int GuestId { get; }
        public string FullName { get; }
        public string PhoneNumber { get; }

      

        private readonly List<Reservation> _reservations = new List<Reservation>();


        public IReadOnlyList<Reservation> Reservations => _reservations;

        public Guest(int guestId, string fullName, string phoneNumber)
        {
            if (guestId <= 0)
                throw new ArgumentException("Guest id must be positive.");
            if (string.IsNullOrEmpty(fullName))
                throw new ArgumentException("Full name is mandatory.");
            if (string.IsNullOrEmpty(phoneNumber))
                throw new ArgumentException("Phone number is mandatory.");


            GuestId = guestId;
            FullName = fullName;
            PhoneNumber = phoneNumber;
        }

        public Reservation MakeReservation(int reservationId, Room room, DateOnly checkIn, DateOnly checkOut)
        {
            var reservation = new Reservation(reservationId, room, checkIn, checkOut);
            _reservations.Add(reservation);

            return reservation;
        }
    }
}
