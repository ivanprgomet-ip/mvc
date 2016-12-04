using PhotoExplorer.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhotoExplorer.Web.Controllers
{
    public class PhotoController : Controller
    {
        [HttpGet]
        public ActionResult Details(int Id)
        {
            var retrievedPhoto = new PhotoModel();

            using (PhotoExplorerDbContext cx = new PhotoExplorerDbContext())
            {
                retrievedPhoto = cx.Photos.FirstOrDefault(p => p.Id == Id);
            }

            return View("Details", retrievedPhoto);
        }
    }
}