using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your RRW -2 application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your RRW contact page.";

            return View();
        }
    }
}