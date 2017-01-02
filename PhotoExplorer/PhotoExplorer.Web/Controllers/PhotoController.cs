using PhotoExplorer.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using PhotoExplorer.Web.Models;
using System.Security.Claims;
using PhotoExplorer.Web.helpers;
using PhotoExplorer.Data.Repositories;

namespace PhotoExplorer.Web.Controllers
{
    public class PhotoController : Controller
    {
        PhotoRepository photoRepo;
        public PhotoController()
        {
            photoRepo = new PhotoRepository();
        }

        [HttpGet]
        public ActionResult Details(int Id)
        {
            PhotoDetailsViewModel model = EFMapper.EntityToModel(photoRepo.GetPhoto(Id));

            using (PhotoExplorerEntities cx = new PhotoExplorerEntities())
            {
                foreach (var user in cx.Users)
                {
                    foreach (var album in user.Albums)
                    {
                        foreach (var photo in album.Photos)
                        {
                            if (photo.Id == Id)
                            {
                                model.User = user;
                                break;
                            }
                        }
                    }
                }
            }

            #region notused
            ////todo: retrieve this photos uploader
            //#region retrieve photo to show
            //PhotoDetailsViewModel model = null;

            //using (PhotoExplorerEntities cx = new PhotoExplorerEntities())
            //{
            //    PhotoEntityModel entity = cx.Photos
            //        .Where(p => p.Id == Id)
            //        .FirstOrDefault();

            //    ///todo: make this more effective..
            //    #region retrieve uploader of photoentity
            //    UserEntityModel photoOwnerEntity = null;
            //    foreach (var user in cx.Users)
            //    {
            //        foreach (var album in user.Albums)
            //        {
            //            foreach (var photo in album.Photos)
            //            {
            //                if (photo.Id == Id)
            //                {
            //                    photoOwnerEntity = user;
            //                    break;
            //                }
            //            }
            //        }
            //    } 
            //    #endregion


            //    model = new PhotoDetailsViewModel()
            //    {
            //        Id = entity.Id,
            //        Name = entity.Name,
            //        FileName = entity.FileName,
            //        DateCreated = entity.DateCreated,
            //        DateChanged = entity.DateChanged,
            //        Album = entity.Album,
            //        Comments = entity.Comments, //due to us already having the model collection initialized in the photodetailsviewmodel class, we only have to transfer the collection VALUES from the entity collection to the model collection.
            //        Description = entity.Description,
            //        User = photoOwnerEntity,
            //    };
            //}
            //#endregion 
            #endregion

            return View("Details", model);
        }

        [HttpPost]
        public ActionResult Comment(int id, string txt_comment)
        {

            PhotoDetailsViewModel model = null;

            using (PhotoExplorerEntities cx = new PhotoExplorerEntities())
            {

                // retrieve currently logged in user
                ClaimsIdentity currentIdentity = User.Identity as ClaimsIdentity;
                int userid = int.Parse(currentIdentity.Claims.FirstOrDefault(u => u.Type == ClaimTypes.NameIdentifier).Value);
                UserEntityModel loggedInEntity = cx.Users.FirstOrDefault(u => u.Id == userid);

                // initialize new comment entity 
                CommentEntityModel commentModel = new CommentEntityModel()
                {
                    DateCreated = DateTime.Now,
                    Comment = txt_comment,
                    Commenter = loggedInEntity.Username,
                };

                // retrieve the photo entity commented on
                PhotoEntityModel entity = cx.Photos
                    .Where(p => p.Id == id)
                    .FirstOrDefault();

                entity.Comments.Add(commentModel);

                cx.SaveChanges();

                //mapping
                model = new PhotoDetailsViewModel()
                {
                    Name = entity.Name,
                    Album = entity.Album,
                    DateCreated = entity.DateCreated,
                    FileName = entity.FileName,
                    Description = entity.Description,
                    Id = entity.Id,
                    User = loggedInEntity,
                    Comments = entity.Comments,
                };

            }

            /*
                note: only updating portion of the page by using partial view (with the NEW model)            
            */
            return PartialView("_PhotoComments", model);
        }
    }
}