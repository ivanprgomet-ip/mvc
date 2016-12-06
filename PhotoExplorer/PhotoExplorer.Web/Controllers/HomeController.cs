using PhotoExplorer.Web.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using PhotoExplorer.Web.Models;

namespace PhotoExplorer.Web.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            List<UserEntityModel> usersFromDB = new List<UserEntityModel>();

            ListUsersAlbumsViewModel model = new ListUsersAlbumsViewModel();

            using (PhotoExplorerContext cx = new PhotoExplorerContext())
            {
                usersFromDB = cx.Users
                    .Include(u=>u.Albums
                        .Select(a=>a.Photos))
                    .ToList();

                foreach (var user in usersFromDB)
                {
                    foreach (var album in user.Albums)
                    {
                        model.Albums.Add(album);
                    }
                }
            }

            return View("Index",model);
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