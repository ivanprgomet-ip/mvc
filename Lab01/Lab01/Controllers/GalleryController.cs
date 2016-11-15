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
        public ActionResult ShowGallery()
        {
            //.......two ways of sending info into view.......
            //ViewBag.GalleryName = "vacation images gallery";
            //ViewBag.GalleryOwner = "ivan prgoemt";

            var model = new GalleryModel();
            model.GalleryName = "Coding Images Gallery";
            model.GalleryOwner = "Google";

            string imagesPath = Server.MapPath("~/Content/images/");//return absolute path to folder containing images
            model.ImagePaths = Directory.GetFiles(imagesPath).ToList();//return list of absolute imagepaths of all images

            return View(model);
        }
        public ActionResult ShowImage(int id)
        {
            //var model = new GalleryModel();
            //string imgName = "code" + id;
            return View(/*imgName*/);
        }

        [HttpPost]
        public ActionResult UploadImage()
        {
            return View();
        }
        public ActionResult RemoveImage()
        {
            return View();
        }
    }
}