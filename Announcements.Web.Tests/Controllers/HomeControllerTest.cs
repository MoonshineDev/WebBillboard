using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Announcements.Web;
using Announcements.Web.Controllers;

namespace Announcements.Web.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        private HomeController _homeController = null;
        public HomeController homeController { get {
            if (_homeController == null)
                _homeController = new HomeController();
            return homeController;
        } }

        [TestMethod]
        public void Index()
        {
            AssertControllerAction(controller => controller.Index());
        }

        [TestMethod]
        public void About()
        {
            AssertControllerAction(controller => controller.About());
        }

        [TestMethod]
        public void Contact()
        {
            AssertControllerAction(controller => controller.Contact());
        }

        [TestMethod]
        public void Message()
        {
            AssertControllerAction(controller => controller.Message());
        }

        private void AssertControllerAction(Func<HomeController, ActionResult> action)
        {
            // Arrange
            var controller = homeController;

            // Act
            var result = action(controller) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
