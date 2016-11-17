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
            return View(ImagesDB);
        }

        /// <summary>
        /// preview an image
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Details(Guid id)
        {
            //be able to update iamge
            var photo = ImagesDB.Where(i => i.Id == id).FirstOrDefault();
            return View(photo);
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
                fileToBeUploaded.SaveAs(
                    Path.Combine(
                        Server.MapPath("~/Content/images"),
                        fileToBeUploaded.FileName));

                ImagesDB.Add(new Photo
                {
                    Id = Guid.NewGuid(),
                    Path = $"~/Content/images/{fileToBeUploaded.FileName}"
                });

                return RedirectToAction("Index", "Photo");
            }
            catch (Exception e)
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
            return RedirectToAction("Index", "Photo");
            //return View(photo);
        }

        public ActionResult Edit(Photo photo)
        {
            return View(photo);
        }
    }
}