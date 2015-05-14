using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using Restaurant.Data;

namespace Restaurant.DataAccess.Services
{
    public interface IReservationService
    {
        Reservation GetByGuest(Guest guest);

        IEnumerable<Reservation> GetAll();

        IEnumerable<Reservation> GetAllByDate(DateTime date);

        IEnumerable<Reservation> GetAllByTable(int id); 

        bool Create(Reservation reservation);

        bool Update(Reservation reservation);

        bool Delete(int id);
    }

    public class ReservationService : IReservationService
    {
        public Reservation GetByGuest(Guest guest)
        {
            using (var context = new RestaurantDbContext())
            {
                throw new NotImplementedException();
            }
        }

        public IEnumerable<Reservation> GetAll()
        {
            using (var context = new RestaurantDbContext())
            {
                return context.Reservations.ToList();
            }
        }

        public IEnumerable<Reservation> GetAllByDate(DateTime date)
        {
            using (var context = new RestaurantDbContext())
            {
                return context.Reservations.Where(r => r.Arrive.Date.Equals(date.Date)).ToList();
            }
        }

        public IEnumerable<Reservation> GetAllByTable(int id)
        {
            using (var context = new RestaurantDbContext())
            {
                return context.Reservations.Where(r => r.Table.TableID == id).ToList();
            }
        }

        public bool Create(Reservation reservation)
        {
            using (var context = new RestaurantDbContext())
            {
                context.Reservations.Add(reservation);
                return context.SaveChanges() > 0;
            }
        }

        public bool Update(Reservation reservation)
        {
            using (var context = new RestaurantDbContext())
            {
                context.Reservations.Attach(reservation);
                context.Entry(reservation).State = EntityState.Modified;
                return context.SaveChanges() > 0;
            }
        }

        public bool Delete(int id)
        {
            using (var context = new RestaurantDbContext())
            {
                Reservation reservation = context.Reservations.Find(id);
                context.Reservations.Remove(reservation);
                return context.SaveChanges() > 0;
            }
        }
    }
}
