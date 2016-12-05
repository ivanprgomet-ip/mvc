using PhotoExplorer.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace PhotoExplorer.Web.Controllers
{
    public class AlbumController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var albums = new List<AlbumModel>();

            using (PhotoExplorerContext cx = new PhotoExplorerContext())
            {
                albums = cx.Albums.ToList();
            }

            return View(albums);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var albumToShow = new AlbumModel();

            using (PhotoExplorerContext cx = new PhotoExplorerContext())
            {
                albumToShow = cx.Albums
                    .Include(a => a.Photos)
                    .Include(a => a.Comments)
                    .FirstOrDefault(a => a.Id == id);
            }

            return View("Details", albumToShow);
        }
    }
}