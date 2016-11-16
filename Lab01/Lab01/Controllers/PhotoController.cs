using Lab01.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace Lab01.Controllers
{
    public class PhotoController:Controller
    {
        public static List<Photo> ImagesDB = new List<Photo>();//for retrieval in the ImageController

        /// <summary>
        /// list all images using static instance of list<photo> for fake db
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            string imagesPath = Server.MapPath("~/Content/images/");//return absolute path to folder containing images
            List<string> ImagePaths = Directory.GetFiles(imagesPath).ToList();//return list of absolute imagepaths of all images

            #region adding unique Guid Id and imagepath property to every image in the gallery
            foreach (var imgPath in ImagePaths)
            {
                ImagesDB.Add(
                    new Photo()
                    {
                        ImageId = Guid.NewGuid(),
                        ImagePath = string.Format("~/Content/images/" + @Path.GetFileName(imgPath))
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
            var photo = ImagesDB.Where(i => i.ImageId == id).FirstOrDefault();
            return View(photo);
        }

        /// <summary>
        /// upload an image
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {

            return View();
        }

        /// <summary>
        /// delete an existing image
        /// </summary>
        /// <returns></returns>
        public ActionResult Delete(Guid id)
        {
            var photo = ImagesDB.Where(i => i.ImageId == id).FirstOrDefault();
            return View(photo);
        }
    }
}