using PhotoExplorer.Web.Entities;
using PhotoExplorer.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Security.Claims;

namespace PhotoExplorer.Web.Areas.Account.Controllers
{
    [Authorize]
    public class AlbumController : Controller
    {
        [HttpGet]
        public ActionResult Details(int id)
        {
            AlbumDetailsViewModel model = null;

            using (PhotoExplorerContext cx = new PhotoExplorerContext())
            {
                var entity = cx.Albums
                    .Include(a => a.Photos)
                    .Include(a => a.Comments)
                    .FirstOrDefault(a => a.Id == id);

                model = new AlbumDetailsViewModel()
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    Comments = entity.Comments,
                    DateCreated = entity.DateCreated,
                    Description = entity.Description,
                    Photos = entity.Photos,
                    User = entity.User,
                };
            }

            return View("Details", model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AlbumCreateViewModel model)
        {
            #region prepare new album for user
            AlbumEntityModel entityToCreate = new AlbumEntityModel()
            {
                Name = model.Name,
                Description = model.Description,
            };
            #endregion

            #region retrieve user id from claimsidentity so that we can find user in databse
            ClaimsIdentity currentIdentity = User.Identity as ClaimsIdentity;

            var modelid = int.Parse((currentIdentity.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)).Value);
            #endregion

            #region retrieve user in database using id and save new album to his/her collection
            using (PhotoExplorerContext cx = new PhotoExplorerContext())
            {
                UserEntityModel userEntity = cx.Users
                    //.Include(u=>u.Albums)
                    .FirstOrDefault(u => u.Id == modelid);

                userEntity.Albums.Add(entityToCreate);

                cx.SaveChanges();
            }
            #endregion

            return RedirectToAction("Index", "Home");
        }
    }
}