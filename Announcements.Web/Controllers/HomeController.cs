using Announcements.Business.Contract;
using Announcements.Infrastructure.Repository;
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
            // Redirect to message action.
            return RedirectToAction("Message");
        }

        /// <summary>
        /// Lists all announcement messages on the billboard.
        /// </summary>
        /// <returns>Razor resource which is later parsed into HTML.</returns>
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