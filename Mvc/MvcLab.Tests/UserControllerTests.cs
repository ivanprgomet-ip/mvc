using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcLab.Web.Controllers;
using System.Web;
using System.Web.Routing;
using System.Web.Mvc;

namespace MvcLab.Tests
{
    [TestClass]
    public class UserControllerTests
    {
        public void SomeTest()
        {
            // ARRANGE
            var controller = new UserController();
            var httpRequest = new HttpRequest("", "http://localhost/User/", "");
            var httpContext = new HttpContext(httpRequest, new HttpResponse(null));
            var requestContext = new RequestContext(new HttpContextWrapper(httpContext), new RouteData());
            controller.ControllerContext = new ControllerContext(requestContext, controller);

            // ACT
            var index = controller.Index() as ViewResult;

            // ASSERT
            Assert.IsNotNull(index);
            Assert.AreEqual("/User/", index.ViewBag.RawUrl);
        }
    }
}
