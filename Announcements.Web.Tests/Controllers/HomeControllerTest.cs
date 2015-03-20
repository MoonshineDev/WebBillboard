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
    /// <summary>
    /// Unit test class for ASP.NET home controller.
    /// </summary>
    [TestClass]
    public class HomeControllerTest
    {
        #region singleton
        private HomeController _homeController = null;
        public HomeController homeController { get {
            if (_homeController == null)
                _homeController = new HomeController();
            return homeController;
        } }
        #endregion

        /// <summary>
        /// Unit test for Index action.
        /// </summary>
        [TestMethod]
        public void Index()
        {
            AssertControllerAction(controller => controller.Index());
        }

        /// <summary>
        /// Unit test for Message action.
        /// </summary>
        [TestMethod]
        public void Message()
        {
            AssertControllerAction(controller => controller.Message());
        }

        /// <summary>
        /// Test that the given action does not evaluate an error.
        /// </summary>
        /// <param name="action">Action to be tested.</param>
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
