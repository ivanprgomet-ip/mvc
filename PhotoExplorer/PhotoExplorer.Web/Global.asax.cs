using PhotoExplorer.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PhotoExplorer.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            Seed();
        }

        private void Seed()
        {
            #region user 1
            PhotoModel p1 = new PhotoModel()
            {
                FileName = "event1.jpg",
                DateCreated = DateTime.Now,
                Description = "no description",
            };
            PhotoModel p2 = new PhotoModel()
            {
                FileName = "event2.jpg",
                DateCreated = DateTime.Now,
                Description = "no description",
            };
            PhotoModel p3 = new PhotoModel()
            {
                FileName = "event3.jpg",
                DateCreated = DateTime.Now,
                Description = "no description",
            };

            AlbumModel a1 = new AlbumModel()
            {
                Name = "my coding events",
                Description = "coding events that i have attended",
                DateCreated = DateTime.Now,
                Comments = new List<CommentModel>(),
                Photos = new List<PhotoModel>() { p1, p2, p3 },
            };

            UserModel u1 = new UserModel()
            {
                Fullname = "Ivan Prgomet",
                Username = "ivanprgomet",
                Password = "ivan123",
                DateRegistered = DateTime.Now,
                Albums = new List<AlbumModel>() { a1 },
            };
            #endregion

            #region user 2
            PhotoModel p4 = new PhotoModel()
            {
                FileName = "code1.jpg",
                DateCreated = DateTime.Now,
                Description = "no description",
            };
            AlbumModel a2 = new AlbumModel()
            {
                Name = "random coding photos",
                Description = "just some coding casual coding photos",
                DateCreated = DateTime.Now,
                Comments = new List<CommentModel>(),
                Photos = new List<PhotoModel>() { p4 },
            };

            UserModel u2 = new UserModel()
            {
                Fullname = "lea winchester",
                Username = "leawinchester",
                Password = "lealea",
                DateRegistered = DateTime.Now,
                Albums = new List<AlbumModel>() { a2 },
            };
            #endregion

            using (PhotoExplorerContext context = new PhotoExplorerContext())
            {
                context.Users.AddRange(new List<UserModel> { u1, u2 });

                context.SaveChanges();
            }
        }
    }
}
