using MvcLab.Web.Repositories;
using PhotoExplorer.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace PhotoExplorer.Web.Controllers
{
    public class PhotoController : Controller
    {
        [HttpGet]
        public ActionResult Details(int Id)
        {
            #region retrieve photo to show
            var retrievedPhoto = new PhotoModel();

            using (PhotoExplorerContext cx = new PhotoExplorerContext())
            {
                retrievedPhoto = cx.Photos
                    .Where(p => p.Id == Id)
                    .Include(p => p.Comments)
                    .FirstOrDefault();
            }
            #endregion

            return View("Details", retrievedPhoto);
        }

        [HttpPost]
        public ActionResult Comment(int id, string txt_comment)
        {
            var retrievedPhoto = new PhotoModel();

            using (PhotoExplorerContext cx = new PhotoExplorerContext())
            {
                retrievedPhoto = cx.Photos
                    .Where(p => p.Id == id)
                    .Include(p => p.Comments)
                    .FirstOrDefault();

                #region prepare a new comment for the photo
                CommentModel commentModel = new CommentModel()
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
    }
}