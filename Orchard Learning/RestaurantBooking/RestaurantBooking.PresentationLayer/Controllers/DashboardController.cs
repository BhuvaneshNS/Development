using RestaurantBooking.BusinessLogicLayer;
using RestaurantBooking.Entities;
using System;
using System.Collections.Generic;

using System.Web.Mvc;

namespace RestaurantBooking.PresentationLayer.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Dashboard()
        {
            List<Restaurant> restaurants = new List<Restaurant>();
            try
            {
                isLoggedUser();
                restaurants = UserDashboardBLL.GetAllRestaurantsBLL();
            }
            catch (Exception)
            {
                throw;
            }
            return View(restaurants);
        }
        public ActionResult Book(int id)
        {
            isLoggedUser();
            ViewBag.RestaurantId = id;
            return View();
        }
        [HttpPost]
        public ActionResult Book(Booking booking)
        {
            try
            {
                isLoggedUser();
                booking.UserId = Convert.ToInt32(Session["UserID"]);
                int status = UserDashboardBLL.BookAMealBLL(booking);
                if (status == 1)
                {
                    ViewBag.Success = "Booking successfull";
                }
                else
                {
                    ViewBag.Error = "Booking Failed";
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                throw;
            }
            return View();
        }

        public ActionResult Bookings()
        {
            List<BookingDetail> bookingDetails = null;
            try
            {
                isLoggedUser();
                bookingDetails = UserDashboardBLL.GetAllBookingsBLL(Convert.ToInt32(Session["UserID"]));

            }
            catch (Exception)
            {

                throw;
            }
            return View(bookingDetails);
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Login", "UserAuthentication");
        }
        private void isLoggedUser()
        {
            if (Session["UserId"] == null)
            {
                RedirectToAction("Login", "UserAuthentication");
            }
        }
    }
}