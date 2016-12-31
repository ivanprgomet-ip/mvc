using PhotoExplorer.Data.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using PhotoExplorer.Web.Models;

namespace PhotoExplorer.Web.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// in this particular action, the only importatn property of the UserDetailsViewModel 
        /// will be the albums, because thats the only thing that is used in the index view, the 
        /// rest of the properties are ommitted for this view, but used in other views.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index()
        {
            List<UserEntityModel> usersFromDB = new List<UserEntityModel>();

            UserDetailsViewModel model = new UserDetailsViewModel();

            using (PhotoExplorerEntities cx = new PhotoExplorerEntities())
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