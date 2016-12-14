using PhotoExplorer.Web.Entities;
using PhotoExplorer.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace PhotoExplorer.Web.Controllers
{
    [Authorize]
    public class AccountController : Controller
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

            return View(model);
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
                    Description = model.Description,
                };

                var userEntity = cx.Users.FirstOrDefault(u => u.Id == userid);

                userEntity.Albums.Add(newEntityAlbum);

                cx.SaveChanges();
            }

            return RedirectToAction("Dashboard", "Account");
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

            return RedirectToAction("Dashboard", "Account");
        }

        [HttpGet]
        public ActionResult PhotoDetails(int Id)
        {
            //todo: retrieve this photos uploader
            #region retrieve photo to show
            PhotoDetailsViewModel model = null;

            using (PhotoExplorerEntities cx = new PhotoExplorerEntities())
            {
                PhotoEntityModel entity = cx.Photos
                    .Where(p => p.Id == Id)
                    .FirstOrDefault();

                ///todo: make this more effective..
                #region retrieve uploader of photoentity
                UserEntityModel photoOwnerEntity = null;
                foreach (var user in cx.Users)
                {
                    foreach (var album in user.Albums)
                    {
                        foreach (var photo in album.Photos)
                        {
                            if (photo.Id == Id)
                            {
                                photoOwnerEntity = user;
                                break;
                            }
                        }
                    }
                }
                #endregion


                model = new PhotoDetailsViewModel()
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    FileName = entity.FileName,
                    DateCreated = entity.DateCreated,
                    DateChanged = entity.DateChanged,
                    Album = entity.Album,
                    Comments = entity.Comments, //due to us already having the model collection initialized in the photodetailsviewmodel class, we only have to transfer the collection VALUES from the entity collection to the model collection.
                    Description = entity.Description,
                    User = photoOwnerEntity,
                };
            }
            #endregion

            return View(model);
        }

        [HttpGet]
        public ActionResult PhotoEdit()
        {
            return View();
        }

        [HttpGet]
        public ActionResult PhotoDelete(int Id)
        {
            using (PhotoExplorerEntities cx = new PhotoExplorerEntities())
            {
                //delete photo with mathcing id
                cx.Photos.Remove(cx.Photos.FirstOrDefault(p => p.Id == Id));
                cx.SaveChanges();
            }

            return RedirectToAction("index", "Home");
        }
        [HttpPost]
        public ActionResult PhotoEdit(PhotoEditViewModel model, int id)
        {
            using (PhotoExplorerEntities cx = new PhotoExplorerEntities())
            {
                //retrieve photo and update with new info
                PhotoEntityModel entity = cx.Photos.FirstOrDefault(p => p.Id == id);

                entity.Name = model.Name;

                entity.Description = model.Description;

                entity.DateChanged = DateTime.Now;

                cx.SaveChanges();
            }

            return RedirectToAction("Dashboard");
        }

    }
}