using MvcLab.Web.Repositories;
using PhotoExplorer.Web.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using PhotoExplorer.Web.Models;

namespace PhotoExplorer.Web.Controllers
{
    public class PhotoController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var photos = new List<PhotoEntityModel>();

            using (PhotoExplorerContext cx = new PhotoExplorerContext())
            {
                photos = cx.Photos.ToList();
            }

            return View(photos);
        }

        [HttpGet]
        public ActionResult Details(int Id)
        {
            #region retrieve photo to show
            PhotoDetailsViewModel model = null;

            using (PhotoExplorerContext cx = new PhotoExplorerContext())
            {
                PhotoEntityModel entity = cx.Photos
                    .Where(p => p.Id == Id)
                    .Include(p => p.Comments)
                    .FirstOrDefault();

                model = new PhotoDetailsViewModel()
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    FileName = entity.FileName,
                    DateCreated = entity.DateCreated,
                    Album = entity.Album,
                    Comments = entity.Comments,
                    Description = entity.Description,
                    User = entity.User,
                };
            }
            #endregion

            return View("Details", model);
        }

        [HttpPost]
        public ActionResult Comment(int id, string txt_comment)
        {
            var retrievedPhoto = new PhotoEntityModel();

            using (PhotoExplorerContext cx = new PhotoExplorerContext())
            {
                retrievedPhoto = cx.Photos
                    .Where(p => p.Id == id)
                    .Include(p => p.Comments)
                    .FirstOrDefault();

                #region prepare a new comment for the photo
                CommentEntityModel commentModel = new CommentEntityModel()
                {
                    DateCreated = DateTime.Now,
                    Comment = txt_comment,
                };
                #endregion

                retrievedPhoto.Comments.Add(commentModel);

                cx.SaveChanges();
            }

            /*
                note: only updating portion of the page by using partial view (with the NEW model)            
            */
            return PartialView("_PhotoComments", retrievedPhoto);
        }

        [HttpPost]
        public ActionResult Upload(PhotoEntityModel photo, HttpPostedFileBase[] photofiles)
        {
            using (PhotoExplorerContext cx = new PhotoExplorerContext())
            {
                //iterate all files uploaded by user
                foreach (var file in photofiles)
                {
                    //create new class object representation of photo for every file uploaded
                    PhotoEntityModel uploadedPhoto = new PhotoEntityModel()
                    {
                        FileName = file.FileName,
                        DateCreated = DateTime.Now,
                        Description = "no description",
                    };

                    //save physical file representation of photo 
                    file.SaveAs(Server.MapPath($"~/photos/{uploadedPhoto.FileName}"));

                    //save class object representation of photo 
                    cx.Photos.Add(uploadedPhoto);

                    //persist/save to database
                    cx.SaveChanges();
                }
            }

            return RedirectToAction("Index");
        }
    }
}