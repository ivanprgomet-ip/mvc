using Lab01.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab01.Controllers
{
    public class PhotoController : Controller
    {
        public static List<Photo> ImagesDB = new List<Photo>();

        /// <summary>
        /// list all images using static instance of list<photo> for fake db
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            //TODO: this content reloads every time the index page runs, so we get duplicates!
            string imagesPath = Server.MapPath("~/Content/images/");//return absolute path to folder containing images
            List<string> ImagePaths = Directory.GetFiles(imagesPath).ToList();//return list of absolute imagepaths of all images

            #region adding unique Guid Id and imagepath property to every image in the gallery
            foreach (var imgPath in ImagePaths)
            {
                ImagesDB.Add(
                    new Photo()
                    {
                        Id = Guid.NewGuid(),
                        Path = string.Format("~/Content/images/" + @Path.GetFileName(imgPath))
                    });
            };
            #endregion

            return View(ImagesDB);
        }

        /// <summary>
        /// preview an image
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Details(Guid id)
        {
            var photo = ImagesDB.Where(i => i.Id == id).FirstOrDefault();
            return View(photo);
        }

        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// uploads an image
        /// </summary>
        /// <param name="photo"></param>
        /// <param name="fileToBeUploaded"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(Photo photo, HttpPostedFileBase fileToBeUploaded)//the path you get when adding image is wrong
        {
            try
            {
                fileToBeUploaded.SaveAs(Path.Combine(Server.MapPath("~/Content/images"), fileToBeUploaded.FileName));

                ImagesDB.Add(new Photo{Id = Guid.NewGuid(), Path= $"~/Content/images/{fileToBeUploaded.FileName}" });

                return RedirectToAction("Index","Photo");//returns to photo index page after image is added
            }
            catch(Exception e)
            {
                return Content(e.Message);
            }
        }

        /// <summary>
        /// delete an existing image
        /// </summary>
        /// <returns></returns>
        public ActionResult Delete(Guid id)
        {
            var photo = ImagesDB.Where(i => i.Id == id).FirstOrDefault();
            ImagesDB.Remove(photo);//todo: remove the image from the static list
            return View(photo);
        }
    }
}