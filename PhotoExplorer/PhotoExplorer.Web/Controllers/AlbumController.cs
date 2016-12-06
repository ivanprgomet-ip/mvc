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
    public class AlbumController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            List<AlbumListedViewModel> model = new List<AlbumListedViewModel>();

            using (PhotoExplorerContext cx = new PhotoExplorerContext())
            {
                var entities = cx.Albums.ToList();

                foreach (var entity in entities)
                {
                    AlbumListedViewModel albumModel = new AlbumListedViewModel()
                    {
                        Id = entity.Id,
                        Name = entity.Name,
                        DateCreated = entity.DateCreated,
                        User = entity.User,
                    };

                    model.Add(albumModel);
                }

            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            AlbumDetailsViewModel model = null;

            using (PhotoExplorerContext cx = new PhotoExplorerContext())
            {
                var entity= cx.Albums
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
    }
}