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
            var retrievedPhoto = new PhotoModel();

            using (PhotoExplorerContext cx = new PhotoExplorerContext())
            {
                retrievedPhoto = cx.Photos
                    .Where(p => p.Id == Id)
                    .Include(p => p.Comments)
                    .FirstOrDefault();
            }

            return View("Details", retrievedPhoto);
        }

        [HttpPost]
        public ActionResult Comment(int id, string txt_comment)
        {
            #region retrieve photo commented on
            var retrievedPhoto = new PhotoModel();

            using (PhotoExplorerContext cx = new PhotoExplorerContext())
            {
                retrievedPhoto = cx.Photos
                    .Where(p => p.Id == id)
                    .Include(p => p.Comments)
                    .FirstOrDefault();
            }
            #endregion

            #region prepare a new comment for the photo
            CommentModel commentModel = new CommentModel()
            {
                DateCreated = DateTime.Now,
                Comment = txt_comment,
            };
            #endregion

            using (PhotoExplorerContext cx = new PhotoExplorerContext())
            {
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