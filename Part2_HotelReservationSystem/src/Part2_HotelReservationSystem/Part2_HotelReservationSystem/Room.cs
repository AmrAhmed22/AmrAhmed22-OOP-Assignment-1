using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part2_HotelReservationSystem
{
    public class Room
    {
        private readonly List<Reservation> _reservations = new();

        public enum RoomType
        {
            Single,
            Double,
            Suite
        }

        public int RoomNumber { get; }
        public RoomType roomtype { get; }
        public decimal NightlyRate { get; private set; }
        public bool IsUnderMaintenance { get; private set; }



        public Room(int roomNumber, RoomType roomType, decimal nightlyRate)
        {
            if (roomNumber <= 0)
                throw new ArgumentException("Room number must be positive.");

            RoomNumber = roomNumber;
            this.roomtype = roomType;
            SetNightlyRate(nightlyRate);
        }





        public void SetNightlyRate(decimal newRate)
        {
            if (newRate <= 0)
                throw new ArgumentException("Nightly rate must be positive.");

            NightlyRate = newRate;
        }

        public void StartMaintenance()
        {
            if (IsUnderMaintenance)
                throw new InvalidOperationException($"Room {RoomNumber} is already under maintenance.");

            IsUnderMaintenance = true;
        }

        public void EndMaintenance()
        {
            if (!IsUnderMaintenance)
                throw new InvalidOperationException($"Room {RoomNumber} is not under maintenance.");

            IsUnderMaintenance = false;
        }

        public void AddReservation(Reservation newReservation)
        {
            if (IsUnderMaintenance)
                throw new InvalidOperationException($"Room {RoomNumber} is under maintenance.");

            foreach (var existing in _reservations)
            {
                bool overlaps = existing.IsActive
                    && newReservation.CheckInDate < existing.CheckOutDate
                    && newReservation.CheckOutDate > existing.CheckInDate;

                if (overlaps)
                    throw new InvalidOperationException($"Room {RoomNumber} is already booked for those dates.");
            }

            _reservations.Add(newReservation);
        }
    }
}
