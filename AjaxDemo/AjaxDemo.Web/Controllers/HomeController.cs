using AjaxDemo.Web.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AjaxDemo.Web.Models;


namespace AjaxDemo.Web.Controllers
{
    public class HomeController : Controller
    {

        ImageRepository imageRepo;
        public HomeController()
        {
            imageRepo = new ImageRepository();
        }

        public ActionResult Index()
        {
            return View(ImageRepository.GetImages());
        }

        [HttpPost]
        public ActionResult Index(ImageViewModel model,HttpPostedFileBase fileupload)
        {
            var destination = Server.MapPath("~/images/");

            Directory.CreateDirectory(destination);

            fileupload.SaveAs(Path.Combine(destination, fileupload.FileName));

            ImageViewModel newImage= new ImageViewModel()
            {
                Id = Guid.NewGuid(),
                Filename = fileupload.FileName,
                Name = model.Name
            };

            ImageRepository.Add(newImage);

            return PartialView("_Image");
        }
    }
}