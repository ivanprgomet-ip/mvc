using Lab01.Models;
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

            var model  = new GalleryModel();
            model.GalleryName = "vacation images gallery";
            model.GalleryOwner = "ivan prgomet";

            return View(model);
        }
        public ActionResult ShowImage()
        {
            return View();
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