using DataLayer;
using ServiceLayer.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class BookingService : IBooking
    {
        private RestaurantEntities _db;

        public BookingService(RestaurantEntities db)
        {
            _db = db;
        }

        public bool Save()
        {
            return _db.SaveChanges() >= 0 ? true : false;
        }

        public bool SaveBooking(Booking model)
        {
            _db.Bookings.Add(model);
            return Save();
        }

        public bool CheckBooking(int TId, DateTime date)
        {
            var data = _db.Bookings.Where(x => x.TId == TId && x.BookingDate == date).FirstOrDefault();
            if (data != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public ICollection<Booking> GetBookings()
        {
            return _db.Bookings.OrderByDescending(x => x.BookingDate).ToList();
        }
    }
}
