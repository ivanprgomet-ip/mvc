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
            List<UserModel> usersFromDB = new List<UserModel>();

            using (PhotoExplorerDbContext cx = new PhotoExplorerDbContext())
            {
                /*
                    must include related properties because lazy loading is enabled for all 
                    navigation properties, which means i load related properties only when they 
                    are needed, which makes the application ultimately faster
                */
                usersFromDB = cx.Users
                    .Include(u => u.Albums
                        .Select(a => a.Photos))
                    .ToList();
            }

            return View("Index", usersFromDB);
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
    }
}