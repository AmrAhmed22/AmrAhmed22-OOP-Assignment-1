using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part2_HotelReservationSystem
{
    public class Reservation
    {
        public int ReservationId { get; }
        public DateOnly CheckInDate { get; }
        public DateOnly CheckOutDate { get; }
        public Room Room { get; }

        public enum ReservationStatus
        {
            Pending,
            Confirmed,
            CheckedIn,
            CheckedOut,
            Cancelled
        }

        public ReservationStatus Status { get; private set; }




        public bool IsActive => (Status != ReservationStatus.Cancelled && Status != ReservationStatus.CheckedOut);

        public int Nights => CheckOutDate.DayNumber - CheckInDate.DayNumber; //how many days it will be booked

        public decimal TotalCost => Nights * Room.NightlyRate;


        public Reservation(int reservationId, Room room, DateOnly checkIn, DateOnly checkOut)
        {
            if (reservationId <= 0)
                throw new ArgumentException("Reservation id must be positive.");
            if (room is null)
                throw new ArgumentException("A reservation needs a room.");
            if (checkOut <= checkIn)
                throw new ArgumentException("Check-out date must be after check-in date.");

            ReservationId = reservationId;
            Room = room;
            CheckInDate = checkIn;
            CheckOutDate = checkOut;
            Status = ReservationStatus.Pending;

            room.AddReservation(this);
        }

        public void Confirm()
        {
            if (Status != ReservationStatus.Pending)
                throw new InvalidOperationException("Only a Pending reservation can be confirmed.");

            Status = ReservationStatus.Confirmed;
        }

        public void CheckIn()
        {
            if (Status != ReservationStatus.Confirmed)
                throw new InvalidOperationException("Only a Confirmed reservation can be checked in.");

            Status = ReservationStatus.CheckedIn;
        }

        public void CheckOut()
        {
            if (Status != ReservationStatus.CheckedIn)
                throw new InvalidOperationException("Only a CheckedIn reservation can be checked out.");

            Status = ReservationStatus.CheckedOut;
        }

        public void Cancel()
        {
            if (Status != ReservationStatus.Pending && Status != ReservationStatus.Confirmed)
                throw new InvalidOperationException($"Cannot cancel a reservation that is {Status}.");

            Status = ReservationStatus.Cancelled;
        }


    }
}
