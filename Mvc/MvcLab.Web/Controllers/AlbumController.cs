using MvcLab.Data.Models;
using MvcLab.Data.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcLab.Web.Controllers
{
    public class AlbumController : Controller
    {
        public AlbumRepository AlbumRepository { get; set; }
        public AlbumController()
        {
            AlbumRepository = new AlbumRepository();
        }

        /// <summary>
        /// when the album details page is requested
        /// </summary>
        /// <param name="album"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Details(AlbumModel album)
        {
            var albumDetails = AlbumRepository.ReturnAlbum(album.Id);

            return View(albumDetails);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public ActionResult Create(AlbumModel albumToBeCreated)
        {
            try
            {
                Guid userId = albumToBeCreated.Id;//TODO: userid and albumid the same? why?

                AlbumModel newAlbum = AlbumRepository.CreateAlbum(albumToBeCreated, userId);

                //create directory for net album
                string newAlbumPath = Server.MapPath("~/UsersData/" + newAlbum.User.Username + "/" + newAlbum.Name);
                Directory.CreateDirectory(newAlbumPath);

                return RedirectToAction("Index", "User");
            }
            catch
            {
                return View();
            }
        }
    }
}