using MVCPhotoAlbums.Models;
using MVCPhotoAlbums.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCPhotoAlbums.Controllers
{
    public class PhotoController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(PhotoModel photo, HttpPostedFileBase[] filesToBeUploaded)
        {
            //retrieving the album id through the photo id, and then the username through album property 'user'
            AlbumRepository albumRepo = new AlbumRepository();
            Guid albumId = photo.Id; //why is the photo id and album id is the same?
            var album = albumRepo.ReturnAlbum(albumId);

            //create the photo
            PhotoRepository repo = new PhotoRepository();
            repo.CreatePhoto(photo);

            foreach (var file in filesToBeUploaded)
            {
                file.SaveAs(Server.MapPath("~/Content/Albums/"+ album.User.Username + "/"+album.Name+"/"+file.FileName));
            };

            return RedirectToAction("Index", "Home");
        }
    }
}