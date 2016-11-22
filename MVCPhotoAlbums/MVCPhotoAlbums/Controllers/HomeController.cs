﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCPhotoAlbums.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View("Index");
        }
        [HttpGet]
        public ActionResult Info()
        {
            return View("Info");
        }
        [HttpGet]
        public ActionResult Contact()
        {
            return View("Contact");
        }

        public ActionResult Error()
        {
            return View();
        }

    }
}