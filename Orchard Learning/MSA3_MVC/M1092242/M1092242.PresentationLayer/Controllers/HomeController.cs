using M1092242.BusinessLogicLayer;
using M1092242.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace M1092242.PresentationLayer.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(User user)
        {
            try
            {
                int status = UserOperationsBLL.RegisterUserBLL(user);
                if (status == 1)
                {
                    ViewBag.Success = "Registration successfull";
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            return View();
        }



        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ServiceCenter()
        {
            List<ServiceCenter> serviceCenters = new List<ServiceCenter>();
            try
            {

                serviceCenters = UserOperationsBLL.GetAllServiceCenters();

            }
            catch (Exception)
            {


            }
            return View(serviceCenters);
        }




    }
}