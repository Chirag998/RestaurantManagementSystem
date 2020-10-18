using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.IService
{
    public interface IBooking
    {
        bool SaveBooking(Booking model);
        bool Save();

        bool CheckBooking(int TId,DateTime date);

        ICollection<Booking> GetBookings();
    }
}
