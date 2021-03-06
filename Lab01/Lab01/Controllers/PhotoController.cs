﻿using Lab01.Models;
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
        public static List<Photo> _photos = new List<Photo>();

        /// <summary>
        /// list all images using static instance of list<photo> for fake db
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View(_photos);
        }

        /// <summary>
        /// preview an image
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Details(Guid id)
        {
            var photo = _photos.Where(i => i.Id == id).FirstOrDefault();
            return View(photo);
        }

        /// <summary>
        /// this runs the first time the Create is clicked on from the index view. 
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// this action runs the second time (when the create form is submitted)
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

                _photos.Add(new Photo
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
            var photo = _photos.Where(i => i.Id == id).FirstOrDefault();
            _photos.Remove(photo);
            return RedirectToAction("Index", "Photo");
        }


        /// <summary>
        /// runs the FIRST time immediately when i press edit inside details view. at this point the photo is null. 
        /// 
        /// runs the SECOND time when i press save inside the edit view, but this time the photo properties 
        /// are set by user, and passed into the arguments of the action Edit. 
        /// </summary>
        /// <param name="photo"></param>
        /// <returns></returns>
        public ActionResult Edit(Photo photo)
        {
            var photoToBeUpdated = _photos.Where(p => p.Id == photo.Id).FirstOrDefault();

            photoToBeUpdated.Description = photo.Description;
            photoToBeUpdated.Name = photo.Name;
            

            return View(photoToBeUpdated);
        }
    }
}