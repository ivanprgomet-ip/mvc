using PhotoExplorer.Data.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using PhotoExplorer.Web.Models;
using PhotoExplorer.Data.Repositories;

namespace PhotoExplorer.Web.Controllers
{
    public class HomeController : Controller
    {
        UserRepository userRepo;
        public HomeController()
        {
            userRepo = new UserRepository();
        }

        /// <summary>
        /// in this particular action, the only importatn property of the UserDetailsViewModel 
        /// will be the albums, because thats the only thing that is used in the index view, the 
        /// rest of the properties are ommitted for this view, but used in other views.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index()
        {
            List<UserEntityModel> entities = userRepo.RetrieveAllUsers();

            UserDetailsViewModel model = new UserDetailsViewModel();

            foreach (var user in entities)
            {
                foreach (var album in user.Albums)
                {
                    model.Albums.Add(album);
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