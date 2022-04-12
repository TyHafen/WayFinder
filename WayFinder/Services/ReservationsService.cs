using System.Collections.Generic;
using WayFinder.Models;
using WayFinder.Repositories;

namespace WayFinder.Services
{
    public class ReservationsService
    {
        private readonly ReservationsRepository _rr;
        private readonly TripsRepository _tr;
        public ReservationsService(ReservationsRepository rr, TripsRepository tr)
        {
            _rr = rr;
            _tr = tr;
        }

        internal List<Reservation> GetAllByTripId(int id)
        {
            return _rr.GetAllByTripId(id);
        }

        internal Reservation Create(Reservation reservationData)
        {
            Trip trip = _tr.GetById(reservationData.TripId);
            reservationData.TripId = trip.Id;
            return _rr.Create(reservationData);
        }

        internal string Delete(int id)
        {
            return _rr.Delete(id);
        }

        internal Reservation Edit(Reservation reservationData)
        {
            Reservation original = _rr.GetById(reservationData.Id);
            original.Type = reservationData.Type ?? original.Type;
            original.Name = reservationData.Name ?? original.Name;
            original.ConfirmationNumber = reservationData.ConfirmationNumber ?? original.ConfirmationNumber;
            original.Cost = reservationData.Cost;
            original.Date = reservationData.Date;
            original.Address = reservationData.Address ?? original.Address;
            original.TripId = original.TripId;
            _rr.Edit(original);
            return original;


        }

        internal Reservation GetById(int id)
        {
            return _rr.GetById(id);
        }
    }
}