using PhotoExplorer.Web.Entities;
using PhotoExplorer.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace PhotoExplorer.Web.Areas.User.Controllers
{
    /// <summary>
    /// only actions that are specific for a user when he/she is managing account content, 
    /// for example uploading new photo, creating new album, changing password etc.
    /// general actions that are available for anonymous users like for example photodetails and 
    /// albumdetails should be available in the main controllers.
    /// </summary>z
    [Authorize]
    public class ManagementController : Controller
    {
        [HttpGet]
        public ActionResult Dashboard()
        {
            #region retrieving the claim values for the currently logged in user (to retrieve him using his/her id)
            ClaimsIdentity currentIdentity = User.Identity as ClaimsIdentity;
            string modelfullname = (currentIdentity.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)).ToString();//not used
            string modelusername = (currentIdentity.Claims.FirstOrDefault(c => c.Type == ClaimTypes.GivenName)).ToString();//not used
            var modelid = int.Parse((currentIdentity.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)).Value);
            #endregion

            UserDetailsViewModel model = null;

            using (PhotoExplorerEntities cx = new PhotoExplorerEntities())
            {
                UserEntityModel entity = cx.Users.FirstOrDefault(u => u.Id == modelid);

                #region mapping necessary properties from entitymodel to the viewmodel 
                model = new UserDetailsViewModel()
                {
                    Id = entity.Id,
                    Username = entity.Username,
                    Fullname = entity.Fullname,
                    Albums = entity.Albums,
                    DateRegistered = entity.DateRegistered,
                    Email = entity.Email,
                };
                #endregion
            }

            return View("Dashboard", model);
        }

        [HttpGet]
        public ActionResult AlbumDetails(int id)
        {
            AlbumDetailsViewModel model = null;

            using (PhotoExplorerEntities cx = new PhotoExplorerEntities())
            {
                var entity = cx.Albums
                    .Include(a => a.Photos)
                    .Include(a => a.Comments)
                    .FirstOrDefault(a => a.Id == id);

                model = new AlbumDetailsViewModel()
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    Comments = entity.Comments,
                    DateCreated = entity.DateCreated,
                    Description = entity.Description,
                    Photos = entity.Photos,
                    User = entity.User,
                };
            }

            return View(model);
        }
        [HttpGet]
        public ActionResult AlbumCreate()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AlbumCreate(AlbumCreateViewModel model)
        {
            ClaimsIdentity currentIdentity = User.Identity as ClaimsIdentity;
            int userid = int.Parse(currentIdentity.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);

            using (PhotoExplorerEntities cx = new PhotoExplorerEntities())
            {

                AlbumEntityModel newEntityAlbum = new AlbumEntityModel()
                {
                    Name = model.Name,
                    Description = model.Name,
                };

                var userEntity = cx.Users.FirstOrDefault(u => u.Id == userid);

                userEntity.Albums.Add(newEntityAlbum);

                cx.SaveChanges();
            }

            return RedirectToAction("Dashboard", "Management");
        }

        [HttpGet]
        public ActionResult PhotoCreate()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PhotoCreate(PhotoUploadViewModel model, HttpPostedFileBase[] photofiles, int id /*albumid*/)
        {
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

            return RedirectToAction("Dashboard", "Management");
        }
        [HttpPost]
        public ActionResult CommentOnPhoto(int id, string txt_comment)
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
            return PartialView("_PhotoCommentsPartial", model);
        }
        public ActionResult PhotoDetails(PhotoDetailsViewModel model)
        {
            #region retrieve photo to show

            using (PhotoExplorerEntities cx = new PhotoExplorerEntities())
            {
                PhotoEntityModel entity = cx.Photos
                    .Where(p => p.Id == model.Id)
                    .Include(p => p.Comments)
                    .FirstOrDefault();

                model = new PhotoDetailsViewModel() 
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    FileName = entity.FileName,
                    DateCreated = entity.DateCreated,
                    Album = entity.Album,
                    Description = entity.Description,
                    User = entity.User,
                };
            }
            #endregion

            return View(model);
        }
    }
}