using MvcLab.Data.Models;
using MvcLab.Data.Repositories;
using MvcLab.Web.Mapper;
using MvcLab.Web.Models;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace MvcLab.Web.Controllers
{
    public class PhotoController : Controller
    {
        public PhotoRepository PhotoRepo { get; set; }
        public AlbumRepository AlbumRepo { get; set; }

        public PhotoController()
        {
            PhotoRepo = new PhotoRepository();
            AlbumRepo = new AlbumRepository();
        }

        [HttpGet]
        public ActionResult Index()
        {
            List<PhotoEntity> photoEntities = PhotoRepo.RetrieveAll();

            List<PhotoModel> photoModels = new List<PhotoModel>();

            foreach (var photoEntity in photoEntities)
            {
                photoModels.Add(EntityModelMapper.EntityToModel(photoEntity));
            }

            return View(photoModels);
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
            Guid albumId = photo.PhotoId; 

            AlbumModel album = EntityModelMapper.EntityToModel(AlbumRepo.Get(albumId));

            foreach (var file in filesToBeUploaded)
            {
                //set important properties of the new photo object
                PhotoModel currentPhoto = new PhotoModel()
                {
                    PhotoId = Guid.NewGuid(),
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
            PhotoRepo.DeletePhoto(PhotoRepo.GetPhoto(photoid));

            //TODO: remove the file from the folder where it lays

            return RedirectToAction("Index", "User");
        }

        [HttpGet]
        public ActionResult Details(PhotoModel photo)
        {
            PhotoModel photoToDisplay = EntityModelMapper.EntityToModel(PhotoRepo.GetPhoto(photo.PhotoId));
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
            PhotoModel photoToCommentOn = EntityModelMapper.EntityToModel(PhotoRepo.GetPhoto(photo.PhotoId));

            CommentModel newComment = new CommentModel()
            {
                CommentId = Guid.NewGuid(),
                Comment = comment,
                DateCreated = DateTime.Now,
                //Photo = photo,
            };

            photoToCommentOn.Comments.Add(newComment);

            return View(photoToCommentOn);
        }
    }
}