using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab01.Controllers
{
    public class ImageController:Controller
    {
        public ActionResult ShowImage(Guid id)
        {
            //retrieve the image
            var image = GalleryController.allImages.Where(i => i.ImageId == id).FirstOrDefault();
            return View(image);
        }
    }
}