using PhotoExplorer.Web.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using PhotoExplorer.Web.Models;

namespace PhotoExplorer.Web.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            List<UserEntityModel> entities = new List<UserEntityModel>();

            List<UserSimplifiedViewModel> model = new List<UserSimplifiedViewModel>();

            using (PhotoExplorerEntities cx = new PhotoExplorerEntities())
            {
                entities = cx.Users.ToList();

                foreach (var entity in entities)
                {
                    UserSimplifiedViewModel userModel = new UserSimplifiedViewModel()
                    {
                        Id = entity.Id,
                        Username = entity.Username,
                        DateRegistered = entity.DateRegistered,
                    };

                    model.Add(userModel);
                }
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            UserEntityModel entity = new UserEntityModel();

            UserDetailsViewModel model = null;

            using (PhotoExplorerEntities cx = new PhotoExplorerEntities())
            {
                entity = cx.Users
                    .Include(u=>u.Albums)
                    .FirstOrDefault(u => u.Id == id);

                model = new UserDetailsViewModel()
                {
                    Fullname = entity.Fullname,
                    Username = entity.Username,
                    Email = entity.Email,
                    DateRegistered = entity.DateRegistered,
                    Albums = entity.Albums,
                };
            }

            return View("Details", model);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var userToDelete = new UserEntityModel();

            using (PhotoExplorerEntities cx = new PhotoExplorerEntities())
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