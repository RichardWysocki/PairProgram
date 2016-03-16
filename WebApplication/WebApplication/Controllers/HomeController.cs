using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using WebApplication.Library;
using WebApplication.Library.Interface;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var x1 = new Observer("Item 1");
            var x2 = new Observer("Item 2");
            var x3 = new Observer("Item 3");

            var observermanager = new Subject();
            observermanager.Add(x1);
            observermanager.Add(x2);
            observermanager.Add(x3);

            observermanager.NotifyObserver();

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your RRW -3 application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your RRW -4 contact page.";

            return View();
        }

        //
        // POST: /Manage/AddPhoneNumber
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<ActionResult> AddEmail(string model)
        //public async Task<ActionResult> AddEmail(string EmailAddress)
        public ActionResult AddEmail(string EmailAddress)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            //// Generate the token and send it
            //var code = await UserManager<>.GenerateChangePhoneNumberTokenAsync(User.Identity.GetUserId(), model.Number);
            //if (UserManager.SmsService != null)
            //{
            //    var message = new IdentityMessage
            //    {
            //        Destination = model.Number,
            //        Body = "Your security code is: " + code
            //    };
            //    await UserManager.SmsService.SendAsync(message);
            //}
            //return RedirectToAction("VerifyPhoneNumber", new { PhoneNumber = model.Number });
            if (EmailAddress.Length > 0)
                EMail.Send("Richard", "Tom", "TEst", "test Message", EmailAddress);

            return RedirectToAction("Index");
        }
    }
}