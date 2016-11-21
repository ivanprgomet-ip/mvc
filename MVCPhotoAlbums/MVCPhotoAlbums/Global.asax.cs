using MVCPhotoAlbums.Models;
using System;
using System.Collections.Generic;
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

        private void InitUsers()
        {
            //when a new user is registered, a folder for the users future albums is also created on the server
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

            #region garbage for now
            //u2.Albums.Add(new AlbumModel()
            //{
            //    Id = Guid.NewGuid(),
            //    Name = "LeaCodeQuotes",
            //    Description = "A selection of my favourite code related quotes!",
            //    DateCreated = DateTime.Now,
            //    Comments = new List<CommentModel>(),
            //    Photos = new List<PhotoModel>()
            //        {
            //            new PhotoModel()
            //            {
            //                Id=Guid.NewGuid(),
            //                UploadedBy = u2.Username,
            //                Description = "no description yet",
            //                DateCreated = DateTime.Now,
            //                FilePath = @"C:\Users\Ivan\Desktop\ytP7U362.png",
            //                Name = Path.GetFileNameWithoutExtension(@"C:\Users\Ivan\Desktop\ytP7U362.png"),
            //            },
            //            new PhotoModel()
            //            {
            //                Id=Guid.NewGuid(),
            //                UploadedBy = u2.Username,
            //                Description = "no description yet",
            //                DateCreated = DateTime.Now,
            //                FilePath = @"C:\Users\Ivan\Desktop\ytP7U362.png",
            //                Name = Path.GetFileNameWithoutExtension(@"C:\Users\Ivan\Desktop\livecode_sound.png"),
            //            },
            //            new PhotoModel()
            //            {
            //                Id=Guid.NewGuid(),
            //                UploadedBy = u2.Username,
            //                Description = "no description yet",
            //                DateCreated = DateTime.Now,
            //                FilePath = @"C:\Users\Ivan\Desktop\ytP7U362.png",
            //                Name = Path.GetFileNameWithoutExtension(@"C:\Users\Ivan\Desktop\code4.png"),
            //            },
            //            new PhotoModel()
            //            {
            //                Id=Guid.NewGuid(),
            //                UploadedBy = u2.Username,
            //                Description = "no description yet",
            //                DateCreated = DateTime.Now,
            //                FilePath = @"C:\Users\Ivan\Desktop\ytP7U362.png",
            //                Name = Path.GetFileNameWithoutExtension(@"C:\Users\Ivan\Desktop\code2.jpg"),
            //            },
            //            new PhotoModel()
            //            {
            //                Id=Guid.NewGuid(),
            //                UploadedBy = u2.Username,
            //                Description = "no description yet",
            //                DateCreated = DateTime.Now,
            //                FilePath = @"C:\Users\Ivan\Desktop\ytP7U362.png",
            //                Name = Path.GetFileNameWithoutExtension(@"C:\Users\Ivan\Desktop\code5.jpg"),
            //            }
            //        }
            //}); 
            #endregion

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
    }
}
