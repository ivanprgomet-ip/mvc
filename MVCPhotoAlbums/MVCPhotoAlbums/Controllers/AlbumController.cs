using MVCPhotoAlbums.Models;
using MVCPhotoAlbums.Repositories;
using System;
using System.IO;
using System.Web.Mvc;

namespace MVCPhotoAlbums.Controllers
{
    public class AlbumController : Controller
    {
        // GET: Album
        public ActionResult Index()
        {
            return View();
        }

        // GET: Album/Details/5 
        public ActionResult Details(AlbumModel album)
        {
            AlbumRepository repo = new AlbumRepository();

            var albumToShow = repo.ReturnAlbum(album.Id);

            albumToShow.AlbumPath = Server.MapPath("~/Content/Albums/" + albumToShow.User.Username+ "/" + albumToShow.Name);//setting albumpath here because server is not available in repository class...

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

                AlbumModel createdAlbum = repo.CreateAlbum(albumToBeCreated,userId);

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
