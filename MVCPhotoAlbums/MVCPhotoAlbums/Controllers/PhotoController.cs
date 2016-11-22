using MVCPhotoAlbums.Models;
using MVCPhotoAlbums.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
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

            //adding paths here because the server mappath method isnt accessible in repository class
            foreach (var file in filesToBeUploaded)
            {
                PhotoModel currentPhoto = new PhotoModel()
                {
                    Id = Guid.NewGuid(),
                    Name = file.FileName,
                    DateCreated = DateTime.Now,
                    Description = "[no description set]",
                    PhotoPath = string.Format("~/Content/Albums/" + album.Name + "/" + file.FileName),
                    UploadedBy = album.User.Username,
                };
                file.SaveAs(Server.MapPath("~/Content/Albums/" + album.User.Username + "/" + album.Name + "/" + file.FileName));//physically saves copie(s) of the photos to the path specified
                album.Photos.Add(currentPhoto);//saves the photo object to the album object
            };

            return RedirectToAction("Index", "Home");
        }
    }
}