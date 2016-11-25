using MvcLab.Data.Models;
using MvcLab.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcLab.Web.Controllers
{
    public class PhotoController : Controller
    {
        public AlbumRepository AlbumRepository { get; set; }
        public PhotoController()
        {
            AlbumRepository = new AlbumRepository();
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
            var photosAlbum = albumRepo.ReturnAlbum(albumId);

            //set important properties of every photo and save to album directory
            foreach (var file in filesToBeUploaded)
            {
                PhotoModel currentPhoto = new PhotoModel()
                {
                    Id = Guid.NewGuid(),
                    Name = photo.Name,
                    FileName = file.FileName,
                    DateCreated = DateTime.Now,
                    Description = "[no description set]",
                    UploadedBy = photosAlbum.User.Username,
                    Comments = new List<CommentModel>(),
                };
                file.SaveAs(Server.MapPath("~/UsersData/" + photosAlbum.User.Username + "/" + photosAlbum.Name + "/" + file.FileName));//physically saves copie(s) of the photos to the path specified
                photosAlbum.Photos.Add(currentPhoto);//saves the photo object to the album object
            };

            return RedirectToAction("Index", "Home");
        }
    }
}