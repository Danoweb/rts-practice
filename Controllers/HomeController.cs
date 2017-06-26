using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PracticeCarriers.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            //THIS IS CURRENTLY UNUSED FOR THE SCOPE OF THIS PROJECT
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            //THIS IS CURRENTLY UNUSED FOR THE SCOPE OF THIS PROJECT
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}