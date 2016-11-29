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
        /// most recent albums
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index()
        {
            return View(AlbumRepository.GetAllAlbums());
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

            AlbumRepository.AddCommentToAlbum(album.Id, newAlbumComment);

            return View(AlbumRepository.GetAllAlbums());
        }

        /// <summary>
        /// when the album details page is requested
        /// </summary>
        /// <param name="album"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Details(AlbumModel album)
        {
            //retrieve the album we want to see details on:
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
            //TODO: how does it create an id for the album automagically?
            try
            {
                Guid userId = albumToBeCreated.Id;//TODO: userid and albumid the same? why?

                AlbumModel newAlbum = AlbumRepository.CreateAlbum(albumToBeCreated, userId);

                //create directory for net album
                string newAlbumPath = Server.MapPath("~/UsersData/" + newAlbum.User.Username + "/" + newAlbum.Name);
                Directory.CreateDirectory(newAlbumPath);

                AlbumRepository.Albums.Add(newAlbum);//add new album to repo so that we can comment on it!

                return RedirectToAction("Index", "User");
            }
            catch
            {
                return View();
            }
        }
    }
}