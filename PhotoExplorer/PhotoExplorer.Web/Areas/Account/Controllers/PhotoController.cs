using PhotoExplorer.Web.Entities;
using PhotoExplorer.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhotoExplorer.Web.Areas.Account.Controllers
{
    public class PhotoController : Controller
    {
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PhotoUploadViewModel model, HttpPostedFileBase[] photofiles, int id /*albumid*/)
        {
            //todo: make it save the images to the album we are inside of

            using (PhotoExplorerEntities cx = new PhotoExplorerEntities())
            {
                AlbumEntityModel entity = cx.Albums.FirstOrDefault(a => a.Id == id);

                foreach (var file in photofiles)
                {
                    //Create new photo entity foreach file that gets uploaded through the UI
                    PhotoEntityModel uploadedPhoto = new PhotoEntityModel()
                    {
                        Name = model.Name,
                        FileName = file.FileName,
                        Description = model.Description,
                    };


                    //save physical file representation of photo 
                    file.SaveAs(Server.MapPath($"~/photos/{uploadedPhoto.FileName}"));

                    //save class object representation of photo into album we are currently in
                    entity.Photos.Add(uploadedPhoto);

                    //persist/save to database
                    cx.SaveChanges();
                }
            }

            return RedirectToAction("Index","Home");//redirects to the home index inside account area
        }
        [HttpPost]
        public ActionResult Comment(int id, string txt_comment)
        {
            PhotoDetailsViewModel model = null;

            using (PhotoExplorerEntities cx = new PhotoExplorerEntities())
            {
                #region get the photoentity commented on
                PhotoEntityModel entity = cx.Photos
                    .Where(p => p.Id == id)
                    .Include(p => p.Comments)
                    .FirstOrDefault();
                #endregion

                #region prepare a new comment for the photo
                CommentEntityModel commentModel = new CommentEntityModel()
                {
                    DateCreated = DateTime.Now,
                    Comment = txt_comment,
                };
                #endregion

                entity.Comments.Add(commentModel);

                cx.SaveChanges();

                #region mapping entity to model
                model = new PhotoDetailsViewModel()
                {
                    Name = entity.Name,
                    //Comments = entity.Comments,
                    Album = entity.Album,
                    DateCreated = entity.DateCreated,
                    FileName = entity.FileName,
                    Description = entity.Description,
                    Id = entity.Id,
                    User = entity.User,
                };
                #endregion
            }

            /*
                note: only updating portion of the page by using partial view (with the NEW model)            
            */
            return PartialView("_PhotoComments", model);
        }
        public ActionResult Details(PhotoDetailsViewModel model)
        {
            #region retrieve photo to show

            using (PhotoExplorerEntities cx = new PhotoExplorerEntities())
            {
                PhotoEntityModel entity = cx.Photos
                    .Where(p => p.Id == model.Id)
                    .Include(p => p.Comments)
                    .FirstOrDefault();

                model = new PhotoDetailsViewModel() //todo: object reference not set to an instance of an object?
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    FileName = entity.FileName,
                    DateCreated = entity.DateCreated,
                    Album = entity.Album,
                    //Comments = entity.Comments,
                    Description = entity.Description,
                    User = entity.User,
                };
            }
            #endregion

            return View("Details", model);
        }
    }
}