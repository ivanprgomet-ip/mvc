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
        
        public UserRepository UserRepo { get; set; }

        public AlbumController()
        {
            UserRepo = new UserRepository();
        }

        /// <summary>
        /// most recent albums
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index()
        {
            return View(UserRepo.GetAllAlbums());
        }

        /// <summary>
        /// when a post happens on the album index page, which means
        /// someone has submittet a comment on an album.
        /// </summary>
        /// <param name="album"></param>
        /// <param name="albumComment"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Index(AlbumModel album, string albumComment)
        {
            CommentModel newAlbumComment = new CommentModel()
            {
                Comment = albumComment,
                DateCreated = DateTime.Now,
                Album = album,
            };
            UserRepo.CreateAlbumComment(album.Id, newAlbumComment);

            return View(UserRepo.GetAllAlbums());
        }

        [HttpGet]
        public ActionResult Details(AlbumModel album)
        {
            var albumDetails = UserRepo.GetAlbum(album.Id);

            return View(albumDetails);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public ActionResult Create(AlbumModel album)
        {
            try
            {
                Guid userId = album.Id;//TODO: userid and albumid the same? why?

                AlbumModel newAlbum = UserRepo.CreateAlbum(album, userId);//add new album to repo so that we can comment on it!

                //create directory for new albums photos
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