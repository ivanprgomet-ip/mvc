using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab01.Controllers
{
    public class AlbumController : Controller
    {
        // Return all albums , and when an album is clicked, we get into that albums images
        public ActionResult Index()
        {
            return View();
        }
    }
}