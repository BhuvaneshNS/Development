using RestaurantBooking.BusinessLogicLayer;
using RestaurantBooking.CustomException;
using RestaurantBooking.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestaurantBooking.PresentationLayer.Controllers
{
    public class UserAuthenticationController : Controller
    {
        // GET: UserAuthentication
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string mailId, string password)
        {
            try
            {
                User user = UserAuthBLL.LoginBLL(mailId, password);
                if (user.UserId != 0)
                {
                    Session["UserID"] = user.UserId.ToString();
                    Session["FirstName"] = user.FirstName.ToString();
                    return RedirectToAction("Dashboard", "Dashboard");
                }
                else
                {
                    ViewBag.Failed = "Login failed, Mail Id or password are wrong!!!";
                }
            }
            catch (Exception)
            {

                throw;
            }
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(User user)
        {
            try
            {
                int status = UserAuthBLL.UseRegistrationBLL(user);
                if (status == 1)
                {
                    ViewBag.Success = "Registration successfull";
                }
            }
            catch (DuplicateMailIdException dme)
            {
                ViewBag.Error = dme.Message;
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }

            return View();
        }
    }
}