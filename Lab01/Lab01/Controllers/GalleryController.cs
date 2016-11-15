using Lab01.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using System;

namespace Lab01.Controllers
{
    //Controller & Actions för ditt bildgalleri – Visa Galleri, Visa Bild, Ladda Upp, Ta Bort 
    public class GalleryController : Controller
    {
        public ActionResult ShowGallery()
        {
            var model = new Gallery("Coding Wallpapers", "Ivan Prgoemt");

            string imagesPath = Server.MapPath("~/Content/images/");//return absolute path to folder containing images
            List<string> ImagePaths = Directory.GetFiles(imagesPath).ToList();//return list of absolute imagepaths of all images

            #region adding unique Guid Id and imagepath property to every image in the gallery
            foreach (var imgPath in ImagePaths)
            {
                model.Images.Add(
                    new Image()
                    {
                        ImageId = new Guid(),
                        ImagePath = string.Format("~/Content/images/" + @Path.GetFileName(imgPath))
                    });
            }; 
            #endregion

            return View(model);
        }

        [HttpPost]
        public ActionResult UploadImage()
        {
            return View();
        }
    }
}