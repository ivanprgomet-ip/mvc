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
        public UserRepository UserRepo { get; set; }

        public PhotoController()
        {
            UserRepo = new UserRepository();
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(UserRepo.GetAllPhotos());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(PhotoModel photo, HttpPostedFileBase[] filesToBeUploaded)
        {
            //why is the photo id and album id same?
            Guid albumId = photo.Id; 

            AlbumModel album = UserRepo.GetAlbum(albumId);

            foreach (var file in filesToBeUploaded)
            {
                //set important properties of the new photo object
                PhotoModel currentPhoto = new PhotoModel()
                {
                    Id = Guid.NewGuid(),
                    Name = photo.Name,
                    FileName = file.FileName,
                    DateCreated = DateTime.Now,
                    Description = "[no description set]",
                    UploadedBy = album.User.Username,
                    Comments = new List<CommentModel>(),
                };

                //physically saves copie(s) of the photos to the path specified
                file.SaveAs(Server.MapPath("~/UsersData/" + album.User.Username + "/" + album.Name + "/" + file.FileName));

                //saves the photo object to the album object
                //todo: should not this be saved to the static list of a users album photos immediately?
                album.Photos.Add(currentPhoto);
            };
            return RedirectToAction("Index", "Home");
            //return PartialView("_Photos",/*allphotos*/);
        }

        [HttpGet]
        public ActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(Guid photoid)
        {
            UserRepo.DeletePhoto(UserRepo.GetPhoto(photoid));

            //TODO: remove the file from the folder where it lays

            return RedirectToAction("Index", "User");
        }

        [HttpGet]
        public ActionResult Details(PhotoModel photo)
        {
            PhotoModel photoToDisplay = UserRepo.GetPhoto(photo.Id);
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
            PhotoModel photoToCommentOn = UserRepo.GetPhoto(photo.Id);

            CommentModel newComment = new CommentModel()
            {
                Id = Guid.NewGuid(),
                Comment = comment,
                DateCreated = DateTime.Now,
                //Photo = photo,
            };

            photoToCommentOn.Comments.Add(newComment);

            return View(photoToCommentOn);
        }
    }
}