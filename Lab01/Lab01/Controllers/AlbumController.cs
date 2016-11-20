using Lab01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab01.Controllers
{
    public class AlbumController : Controller
    {
        public static List<Album> _albums = new List<Album>();

        /// <summary>
        /// list all the albums
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View(_albums);
        }

        /// <summary>
        /// preview the photos in an album
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Details(Guid id)
        {
            var album = _albums.Where(i => i.Id == id).FirstOrDefault();
            return View(album);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Album albumToBeCreated)
        {
            if (ModelState.IsValid)
            {

                albumToBeCreated.Id = Guid.NewGuid();

                albumToBeCreated.DateCreated = DateTime.Now;

                _albums.Add(albumToBeCreated);

                return RedirectToAction("Index", "Album");
            }
            return View(albumToBeCreated);
        }
    }
}