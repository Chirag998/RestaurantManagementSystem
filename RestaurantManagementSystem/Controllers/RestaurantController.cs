using DataLayer;
using ServiceLayer.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModels;

namespace RestaurantManagementSystem.Controllers
{
    public class RestaurantController : Controller
    {
        public readonly IRestaurantTables restaurantTables;
        public readonly IBooking _booking;
        // GET: Restaurant

        public RestaurantController(IRestaurantTables tables,IBooking booking)
        {
            this.restaurantTables = tables;
            this._booking = booking;
        }
        public ActionResult Index()
        {
            ViewBag.data = new SelectList(restaurantTables.GetTables(), "TId", "TName");
            return View();
        }

        [HttpPost]
        public ActionResult Index(TableViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.data = new SelectList(restaurantTables.GetTables(), "TId", "TName");
                return View();
            }

            if (_booking.CheckBooking(model.tableDropdown, model.Date))
            {
                ViewBag.data = new SelectList(restaurantTables.GetTables(), "TId", "TName");
                ViewBag.message = "Table with Id: " + model.tableDropdown + " already booked";
                return View();
            }

            Booking b = new Booking();
            b.TId = model.tableDropdown;
            b.CustomerName = model.CustomerName;
            b.BookingDate = model.Date;
            b.STime = model.Stime;
            b.Etime = model.ETime;
            b.NumbOfSeats = model.seats;
            if (!_booking.SaveBooking(b))
            {
                ViewBag.data = new SelectList(restaurantTables.GetTables(), "TId", "TName");
                ViewBag.message = "Something Went wrong !";
            }
            ModelState.Clear();
            ViewBag.data = new SelectList(restaurantTables.GetTables(), "TId", "TName");
            ViewBag.message = "booking successfully";

            return View();
        }

        public ActionResult GetBookings()
        {
            var data = _booking.GetBookings();
            return View(data);
        }
    }
}