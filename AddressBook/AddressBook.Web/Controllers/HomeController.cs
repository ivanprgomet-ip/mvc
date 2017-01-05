using AddressBook.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AddressBook.Web.Controllers
{
    public class HomeController : Controller
    {
        public static List<ContactViewModel> Contacts = new List<ContactViewModel>();

        [HttpGet]
        public ActionResult Index()
        {
            return View(Contacts);
        }




    }
}