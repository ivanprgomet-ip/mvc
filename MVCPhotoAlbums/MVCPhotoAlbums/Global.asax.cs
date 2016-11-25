using MVCPhotoAlbums.Controllers;
using MVCPhotoAlbums.Models;
using MVCPhotoAlbums.Repositories;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVCPhotoAlbums
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

            InitUsers();
            InitAlbums();
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
            //redirect to custom error page when encountering error..
            Response.Redirect("/Home/Error");
        }

        private void InitUsers()
        {
            UserModel u1 = new UserModel()
            {
                Id = Guid.NewGuid(),
                Firstname = "Ivan",
                Lastname = "Prgomet",
                Country = "Sweden",
                City = "Lund",
                Street = "lundstreet 2",
                Email = "ip@gmail.com",
                Phone = "0735709868",
                Username = "ivanprgomet",
                Password = "ivan123",
                DateRegistered = DateTime.Now,

                Albums = new List<AlbumModel>(),
            };
            Directory.CreateDirectory(Server.MapPath("~/Content/Albums/" + u1.Username));

            UserModel u2 = new UserModel()
            {
                Id = Guid.NewGuid(),
                Firstname = "Lea",
                Lastname = "Winchester",
                Country = "England",
                City = "London",
                Street = "Grape Street",
                Email = "leawinchester@gmail.com",
                Phone = "92345873294",
                Username = "leawinchester",
                Password = "lealea",
                DateRegistered = DateTime.Now,

                Albums = new List<AlbumModel>(),
            };
            Directory.CreateDirectory(Server.MapPath("~/Content/Albums/" + u2.Username));
            CreateAlbumFor(u2, "Lea Code Quotes Album");

            UserModel u3 = new UserModel()
            {
                Id = Guid.NewGuid(),
                Firstname = "Scott",
                Lastname = "Ferryson",
                Country = "Australia",
                City = "Sydney",
                Street = "Kangaroo Alley 8",
                Email = "ImScott@gmail.com",
                Phone = "3940857",
                Username = "scottferryson",
                Password = "scott123",
                DateRegistered = DateTime.Now,

                Albums = new List<AlbumModel>(),
            };
            Directory.CreateDirectory(Server.MapPath("~/Content/Albums/" + u3.Username));

            Repositories.UserRepository._users.Add(u1);
            Repositories.UserRepository._users.Add(u2);
            Repositories.UserRepository._users.Add(u3);
        }

        private void CreateAlbumFor(UserModel user, string albumName)
        {
            //create a folder for the album in the users specific albums folder
            Directory.CreateDirectory(Server.MapPath("~/Content/Albums/" + user.Username+"/"+albumName));

            //create the album
            AlbumModel newAlbum = new AlbumModel()
            {
                Id = Guid.NewGuid(),
                AlbumPath = Server.MapPath("~/Content/Albums/" + user.Username + "/" + albumName),
                DateCreated = DateTime.Now,
                Name = albumName,
                Description = "no description yet",
                Photos = new List<PhotoModel>(),
                User = user, // the owner of the album
            };

            //ADD THE EXISTENT PHOTOS TO THE ALUBM
            //this code block is for demo purposes only.
            //the images will be added through the mvc interface in the future.
            var photosPath = Server.MapPath("~/Content/Albums/"+user.Username+"/"+albumName);

            var demoPhotos = Directory.GetFiles(photosPath).ToList();

            foreach (var photopath in demoPhotos)
            {
                newAlbum.Photos.Add(new PhotoModel()
                {
                    Id = Guid.NewGuid(),
                    Name = Path.GetFileNameWithoutExtension(photopath),
                    DateCreated = DateTime.Now,
                    Description = "[no description set]",
                    PhotoPath = string.Format("~/Content/Albums/" + @Path.GetFileName(photopath)),
                    Comments = new List<CommentModel>(),
                });
            };

            //add the album to the users album collection
            user.Albums.Add(newAlbum);
        }

        /// <summary>
        /// initialize albums at startup
        /// </summary>
        private void InitAlbums()
        {
            foreach (var user in UserRepository._users)
            {
                foreach (var userAlbum in user.Albums)
                {
                    userAlbum.Comments = new List<CommentModel>();
                    AlbumRepository._albums.Add(userAlbum);
                }
            }
        }
    }
}