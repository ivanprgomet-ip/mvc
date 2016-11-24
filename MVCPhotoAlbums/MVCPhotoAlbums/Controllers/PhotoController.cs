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
        /// <summary>
        /// most recent photos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index()
        {
            return View(PhotoRepository.GetAllPhotos());
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

        [HttpGet]
        public ActionResult Delete()
        {
            return View();
        }

        /// <summary>
        /// removes a photo from an album. the photo should also be removed 
        /// from the users folder also. mvc auto maps the id's that get sent 
        /// when clicking the small delete button for the photo
        /// </summary>
        /// <param name="photo"></param>
        /// <returns></returns>
        public ActionResult Delete(Guid photoid, Guid albumid)
        {
            //remove photo object from the album list of photos
            AlbumRepository albumRepo = new AlbumRepository();

            var album = albumRepo.ReturnAlbum(albumid);

            album.Photos
                .Remove(album.Photos
                    .FirstOrDefault(p => p.Id == photoid));

            //remove the file from the folder where it lays

            return RedirectToAction("Index", "User");
        }

        /// <summary>
        /// when we are accessing the Details page for a specific photo
        /// </summary>
        /// <param name="photo"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Details(PhotoModel photo)
        {
            PhotoRepository repo = new PhotoRepository();
            PhotoModel photoToDisplay = repo.ReturnPhoto(photo.Id);
            return View(photoToDisplay);
        }

        /// <summary>
        /// when we make a post (comment) on a specific
        /// photos details page.
        /// </summary>
        /// <param name="photo"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Details(PhotoModel photo, string comment)
        {
            PhotoRepository repo = new PhotoRepository();
            PhotoModel photoToDisplay = repo.ReturnPhoto(photo.Id);

            CommentModel newComment = new CommentModel()
            {
                Comment = comment,
                DateCreated = DateTime.Now,
                Photo = photo
            };
            photoToDisplay.Comments.Add(newComment);

            return View(photoToDisplay);
        }
    }
}