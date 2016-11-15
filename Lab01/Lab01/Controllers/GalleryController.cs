using Lab01.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace Lab01.Controllers
{
    //Controller & Actions för ditt bildgalleri – Visa Galleri, Visa Bild, Ladda Upp, Ta Bort 
    public class GalleryController:Controller
    {
        public ActionResult Show()
        {
            var model = new Gallery("Coding Wallpapers","Ivan Prgoemt");

            string imagesPath = Server.MapPath("~/Content/images/");//return absolute path to folder containing images
            model.ImagePaths = Directory.GetFiles(imagesPath).ToList();//return list of absolute imagepaths of all images

            return View(model);
        }

        [HttpPost]
        public ActionResult UploadImage()
        {
            return View();
        }
    }
}