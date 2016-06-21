using System.Web.Mvc;
using log4net;
using WebApplication.Library;
using WebApplication.Library.Interface;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private ISubject _isubject;
        private static readonly ILog log = LogManager.GetLogger(typeof(HomeController));

        public HomeController(ISubject subject)
        {
            _isubject = subject;
        }
        public ActionResult Index()
        {
            
            log.Debug("thishe first log message");

            var x1 = new Observer("Item 1");
            var x2 = new Observer("Item 2");
            var x3 = new Observer("Item 3");

            var observermanager = _isubject; //new Subject();
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

        // POST: 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddEmail(string emailAddress)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            if (emailAddress.Length > 0)
                EMail.Send("Richard", "Tom", "TEst", "test Message", emailAddress);

            return RedirectToAction("Index");
        }
    }
}