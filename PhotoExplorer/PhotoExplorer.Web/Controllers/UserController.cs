using PhotoExplorer.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace PhotoExplorer.Web.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var users = new List<UserViewModel>();

            using (PhotoExplorerContext cx = new PhotoExplorerContext())
            {
                users = cx.Users.ToList();
            }

            return View(users);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var userToShow = new UserViewModel();

            using (PhotoExplorerContext cx = new PhotoExplorerContext())
            {
                userToShow = cx.Users
                    .Include(u=>u.Albums)
                    .FirstOrDefault(u => u.Id == id);
            }

            return View("Details", userToShow);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var userToDelete = new UserViewModel();

            using (PhotoExplorerContext cx = new PhotoExplorerContext())
            {
                userToDelete = cx.Users
                    .Include(u => u.Albums)
                    .FirstOrDefault(u => u.Id == id);

                cx.Users.Remove(userToDelete);

                cx.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}