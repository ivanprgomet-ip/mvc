using MvcLab.Data.Models;
using MvcLab.Data.Repositories;
using MvcLab.Web.Mapper;
using MvcLab.Web.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcLab.Web.Controllers
{
    public class AlbumController : Controller
    {
        
        public UserRepository UserRepo { get; set; }

        public AlbumController()
        {
            UserRepo = new UserRepository();
        }

        /// <summary>
        /// most recent albums
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index()
        {
            return View(UserRepo.GetAllAlbums());
        }

        /// <summary>
        /// when a post happens on the album index page, which means
        /// someone has submittet a comment on an album.
        /// </summary>
        /// <param name="album"></param>
        /// <param name="albumComment"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Index(AlbumModel album, string albumComment)
        {
            CommentModel commentModel = new CommentModel()
            {
                Comment = albumComment,
                DateCreated = DateTime.Now,
                Album = album,
            };

            var commentEntity = EntityModelMapper.ModelToEntity(commentModel);

            UserRepo.CreateAlbumComment(album.Id, commentEntity);

            return View(UserRepo.GetAllAlbums());
        }

        [HttpGet]
        public ActionResult Details(AlbumModel album)
        {
            var albumDetails = UserRepo.GetAlbum(album.Id);

            return View(albumDetails);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View("Create");
        }

        /// <summary>
        /// todo: create album
        /// 1. recieve an album model
        /// 2. turn the album model into an album entity using mapper
        /// 3. pass the album entity into the createalbum repository method (because it only acceppts entities)
        /// </summary>
        /// <param name="albumModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(AlbumModel albumModel)
        {
            try
            {
                Guid userId = albumModel.Id; //TODO: userid and albumid the same? why?

                var albumEntity = EntityModelMapper.ModelToEntity(albumModel);

                //albumEntity.User = UserRepo.GetUser(userId);

                UserRepo.Add(albumEntity, userId);//adds new album to dbset(database)

                //create directory for new albums photos
                string newAlbumPath = Server.MapPath("~/UsersData/" + albumEntity.User.Username + "/" + albumEntity.Name);

                Directory.CreateDirectory(newAlbumPath);

                return RedirectToAction("Index", "User");
            }
            catch
            {
                return View();
            }
        }
    }
}