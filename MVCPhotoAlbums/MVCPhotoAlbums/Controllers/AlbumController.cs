using MVCPhotoAlbums.Models;
using MVCPhotoAlbums.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;

namespace MVCPhotoAlbums.Controllers
{
    public class AlbumController : Controller
    {
        

        /// <summary>
        /// most recent albums
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index()
        {
            return View(AlbumRepository._albums);
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
            //todo: fix commenting on albums
            CommentModel newAlbumComment = new CommentModel()
            {
                Comment = albumComment,
                DateCreated = DateTime.Now,
                Album = album,
            };

            AlbumRepository.AddCommentToAlbum(album.Id, newAlbumComment);

            return View(AlbumRepository._albums);
        }


        /// <summary>
        /// when the album details page is requested. only get.
        /// </summary>
        /// <param name="album"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Details(AlbumModel album)
        {
            AlbumRepository repo = new AlbumRepository();
            
            var albumToShow = repo.ReturnAlbum(album.Id);

            albumToShow.AlbumPath = Server.MapPath("~/Content/Albums/" + albumToShow.User.Username + "/" + albumToShow.Name);//setting albumpath here because server is not available in repository class...

            return View(albumToShow);
        }

        // GET: Album/Create
        public ActionResult Create()
        {
            return View("Create");
        }

        // POST: Album/Create
        [HttpPost]
        public ActionResult Create(AlbumModel albumToBeCreated)
        {
            try
            {
                Guid userId = albumToBeCreated.Id;//todo: why are the userid and the album id the same?

                AlbumRepository repo = new AlbumRepository();

                AlbumModel createdAlbum = repo.CreateAlbum(albumToBeCreated, userId);

                //create a folder for the album in the users specific albums folder
                Directory.CreateDirectory(Server.MapPath("~/Content/Albums/"
                    + createdAlbum.User.Username + "/" + createdAlbum.Name));

                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }

        // GET: Album/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Album/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Album/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Album/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
