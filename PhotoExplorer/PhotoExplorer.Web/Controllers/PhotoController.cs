using MvcLab.Web.Repositories;
using PhotoExplorer.Web.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using PhotoExplorer.Web.Models;
using System.Security.Claims;

namespace PhotoExplorer.Web.Controllers
{
    public class PhotoController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            List<PhotoListedViewModel> model = new List<PhotoListedViewModel>();

            using (PhotoExplorerEntities cx = new PhotoExplorerEntities())
            {
                var entities = cx.Photos.ToList();

                foreach (var entity in entities)
                {
                    PhotoListedViewModel photoModel = new PhotoListedViewModel()
                    {
                        Id = entity.Id,
                        FileName = entity.FileName,
                    };

                    model.Add(photoModel);
                }
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Details(int Id)
        {
            #region retrieve photo to show
            PhotoDetailsViewModel model = null;

            using (PhotoExplorerEntities cx = new PhotoExplorerEntities())
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
            #region get id of currently logged in user
            ClaimsIdentity currentIdentity = User.Identity as ClaimsIdentity;
            int userid = int.Parse(currentIdentity.Claims.FirstOrDefault(u => u.Type == ClaimTypes.NameIdentifier).Value); 
            #endregion

            PhotoDetailsViewModel model = null;

            using (PhotoExplorerEntities cx = new PhotoExplorerEntities())
            {

                UserEntityModel loggedInEntity = cx.Users.FirstOrDefault(u => u.Id == userid);

                #region get the photoentity commented on
                PhotoEntityModel entity = cx.Photos
                    .Where(p => p.Id == id)
                    .Include(p => p.Comments)
                    .FirstOrDefault();
                #endregion

                #region prepare a new comment for the photo and include important related data
                //todo: get the commenter of the comment (user)
                CommentEntityModel commentModel = new CommentEntityModel()
                {
                    DateCreated = DateTime.Now,
                    Comment = txt_comment,
                    User = loggedInEntity,
                };
                #endregion

                entity.Comments.Add(commentModel);

                cx.SaveChanges();

                #region mapping entity to model
                model = new PhotoDetailsViewModel()
                {
                    Name = entity.Name,
                    Comments = entity.Comments,
                    Album = entity.Album,
                    DateCreated = entity.DateCreated,
                    FileName = entity.FileName,
                    Description = entity.Description,
                    Id = entity.Id,
                    User = loggedInEntity,
                }; 
                #endregion
            }

            /*
                note: only updating portion of the page by using partial view (with the NEW model)            
            */
            return PartialView("_PhotoComments", model);
        }
        [HttpPost]
        public ActionResult Upload(PhotoEntityModel photo, HttpPostedFileBase[] photofiles)
        {
            using (PhotoExplorerEntities cx = new PhotoExplorerEntities())
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