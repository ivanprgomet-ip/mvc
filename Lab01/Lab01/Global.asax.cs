using Lab01.Controllers;
using Lab01.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;

namespace Lab01
{
    public class MvcApplication : System.Web.HttpApplication
    {
        /// <summary>
        /// runs first
        /// </summary>
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            InitializePhotos();
            InitializeUsers();
            InitializeAlbums();
        }

        protected void Application_End()
        {

        }

        /// <summary>
        /// runs directly after application_start
        /// </summary>
        protected void Session_Start()
        {

        }

        protected void Session_End()
        {

        }

        protected void Application_Error()
        {

        }

        private void InitializePhotos()
        {
            string imagesPath = Server.MapPath("~/Content/images/");
            List<string> ImagePaths = Directory.GetFiles(imagesPath).ToList();
            //List<string> ImagePaths = Directory.GetFiles(imagesPath, "*.jpg").ToList();
            foreach (var imgPath in ImagePaths)
            {
                PhotoController._photos.Add(
                    new Photo()
                    {
                        Id = Guid.NewGuid(),
                        Name = Path.GetFileNameWithoutExtension(imgPath),
                        DateUploaded = DateTime.Now,
                        Description = "[no description set]",
                        Path = string.Format("~/Content/images/" + @Path.GetFileName(imgPath))
                    });
            };
        }
        private void InitializeUsers()
        {
            User u1 = new User()
            {
                Id = Guid.NewGuid(),
                Firstname = "Alan",
                Lastname = "Walker",
                Country = "Spain",
                City = "Barcelona",
                Username = "alanwalker",
                Password = "alan123",
                DateRegistered = DateTime.Now,
                Email = "alanwalker@gmail.com"
            };

            User u2 = new User()
            {
                Id = Guid.NewGuid(),
                Firstname = "Lea",
                Lastname = "Winchester",
                Country = "Great Britain",
                City = "London",
                Username = "leawinchester",
                Password = "lealea",
                DateRegistered = DateTime.Now,
                Email = "leawinchester@gmail.com"
            };

            AccountController._users.AddRange(new List<User> { u1, u2 });
        }
        private void InitializeAlbums()
        {
            Album a1 = new Album()
            {
                Id = Guid.NewGuid(),
                Name = "Code Is Love",
                DateCreated = DateTime.Now,
                Photos = PhotoController._photos,//taking all the images from the Photocontroller
            };

            AlbumController._albums.Add(a1);
        }
    }
}
