using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcLab.Web.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View("Index");
        }
        [HttpGet]
        public ActionResult Info()
        {
            return View("Info");
        }
        [HttpGet]
        public ActionResult Contact()
        {
            return View("Contact");
        }
    }
}