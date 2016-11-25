using MvcLab.Data.Models;
using MvcLab.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcLab.Web.Controllers
{
    public class AlbumController : Controller
    {
        public AlbumRepository AlbumRepository { get; set; }
        public AlbumController()
        {
            AlbumRepository = new AlbumRepository();
        }

        /// <summary>
        /// when the album details page is requested
        /// </summary>
        /// <param name="album"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Details(AlbumModel album)
        {
            var albumDetails = AlbumRepository.ReturnAlbum(album.Id);

            return View(albumDetails);
        }
    }
}