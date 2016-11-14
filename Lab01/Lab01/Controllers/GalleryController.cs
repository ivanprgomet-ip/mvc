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
            model.GalleryName = "vacation images gallery";
            model.GalleryOwner = "ivan prgomet";

            //string imagesPath = Server.MapPath("../App_Data/images");
            //model.ImagePaths = Directory.GetFiles(imagesPath).ToList();

            return View(model);
        }
        public ActionResult ShowImage(int id)
        {
            //var model = new GalleryModel();
            //string imgName = "code" + id;
            return View(/*imgName*/);
        }
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