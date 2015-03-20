using Announcements.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Announcements.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Message()
        {
            ViewBag.Message = "Below is a list of all current announcements.";

            var result = Enumerable.Empty<MessageModel>();
            result = new MessageModel[] {
                new MessageModel { Time = DateTime.Now, Message = "Hello World"}
            };
            ViewBag.Announcements = result;

            return View();
        }
    }
}