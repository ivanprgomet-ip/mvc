using PhotoExplorer.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhotoExplorer.Web.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            List<UserModel> usersFromDB = new List<UserModel>();

            using (PhotoExplorerContext cx = new PhotoExplorerContext())
            {
                usersFromDB = cx.Users.ToList(); 
            }

            return View("Index",usersFromDB);
        }
        [HttpGet]
        public ActionResult AboutUs()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Contact()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Error()
        {
            return View();
        }
    }
}