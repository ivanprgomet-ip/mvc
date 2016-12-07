using PhotoExplorer.Web.Entities;
using PhotoExplorer.Web.Models;
using System;
using System.Collections.Generic;
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
    }
}