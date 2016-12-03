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
        public AlbumRepository AlbumRepo { get; set; }
        public CommentRepository CommentRepo { get; set; }

        public AlbumController()
        {
            AlbumRepo = new AlbumRepository();
            CommentRepo = new CommentRepository();
        }

        /// <summary>
        /// most recent albums
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index()
        {
            List<AlbumEntity> albumEntities = AlbumRepo.GetAll();

            List<AlbumModel> albumModels = new List<AlbumModel>();

            foreach (var albumEntity in albumEntities)
            {
                albumModels.Add(EntityModelMapper.EntityToModel(albumEntity));
            }

            return View(albumModels);
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

            CommentRepo.NewAlbumComment(album.AlbumModelId, commentEntity);

            return View(AlbumRepo.GetAll());
        }

        [HttpGet]
        public ActionResult Details(AlbumModel album)
        {
            var albumDetails = AlbumRepo.Get(album.AlbumModelId);

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
                int userId = albumModel.AlbumModelId; //TODO: userid and albumid the same? why?

                var albumEntity = EntityModelMapper.ModelToEntity(albumModel);

                //albumEntity.User = UserRepo.GetUser(userId);

                AlbumRepo.Add(albumEntity, userId);//adds new album to dbset(database)

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