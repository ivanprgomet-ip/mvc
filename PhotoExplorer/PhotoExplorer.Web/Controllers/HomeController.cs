using PhotoExplorer.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace PhotoExplorer.Web.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            List<UserViewModel> usersFromDB = new List<UserViewModel>();

            using (PhotoExplorerContext cx = new PhotoExplorerContext())
            {
                /*
                    must include related properties because lazy loading is enabled for all 
                    navigation properties, which means i load related properties only when they 
                    are needed, which makes the application ultimately faster
                */
                usersFromDB = cx.Users
                    .Include(u=>u.Albums
                        .Select(a=>a.Photos))
                    .ToList(); 
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