using System;
using System.Collections.Generic;
using Com.Framework.Common.Extensions;
using Com.Framework.Data.Restaurants.Tables;

namespace Com.Framework.Hubs.Restaurants.Tables
{
    public interface IReservationHub
    {
        Reservation GetReservation(int premiseID, int id);

        IEnumerable<Reservation> GetReservationsByPremiseBetweenTimes(int premiseID, TimeSpan start, TimeSpan end);

        IEnumerable<Reservation> GetReservationByPremiseByDate(int premiseID, DateTime date);

        bool UpdateReservations(string name, params Reservation[] reservations);
    }

    public interface IReservationContract
    {
        void UpdateReservations(params Reservation[] reservations);
    }

    public class ReservationHub : ServiceHub<IReservationContract>, IReservationHub
    {
        public Reservation GetReservation(int premiseID, int id)
        {
            return Service.Get<Reservation>(r => r.PremiseID == premiseID && r.Id == id);
        }

        public IEnumerable<Reservation> GetReservationsByPremiseBetweenTimes(int premiseID, TimeSpan start, TimeSpan end)
        {
            return Service.All<Reservation>(r => r.PremiseID == premiseID && r.Date.TimeOfDay.IsBetween(start, end));
        }

        public IEnumerable<Reservation> GetReservationByPremiseByDate(int premiseID, DateTime date)
        {
            return Service.All<Reservation>(r => r.PremiseID == premiseID && r.Date.Date == date.Date);
        }

        public bool UpdateReservations(string name, params Reservation[] reservations)
        {
            if (reservations.Length == 0) return false;

            Clients.Group(name).UpdateReservations(reservations);

            return Service.Update(reservations);
        }
    }
}
