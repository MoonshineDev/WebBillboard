using Announcements.Business.Contract;
using Announcements.Web.IoC;
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

            var messageService = MyContainer.GetInstance<IMessageService>();
            var announcements = messageService.GetAnnoucements();
            var result = announcements.Select(x => new MessageViewModel {
                Time = x.Time,
                Message = x.Message,
            });
            ViewBag.Announcements = result;

            return View();
        }
    }
}