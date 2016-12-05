using PhotoExplorer.Web.Entities;
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
            PhotoEntityModel p1 = new PhotoEntityModel()
            {
                FileName = "event1.jpg",
                Name = "first event",
                DateCreated = DateTime.Now,
                Description = "no description",
            };
            PhotoEntityModel p2 = new PhotoEntityModel()
            {
                FileName = "event2.jpg",
                Name = "second event",
                DateCreated = DateTime.Now,
                Description = "no description",
            };
            PhotoEntityModel p3 = new PhotoEntityModel()
            {
                FileName = "event3.jpg",
                Name = "third event",
                DateCreated = DateTime.Now,
                Description = "no description",
            };

            AlbumEntityModel a1 = new AlbumEntityModel()
            {
                Name = "my coding events",
                Description = "coding events that i have attended",
                DateCreated = DateTime.Now,
                Comments = new List<CommentEntityModel>(),
                Photos = new List<PhotoEntityModel>() { p1, p2, p3 },
            };

            UserEntityModel u1 = new UserEntityModel()
            {
                Fullname = "Ivan Prgomet",
                Username = "ivanprgomet",
                Email = "ivanprgomet@gmail.com",
                Password = "ivan123",
                DateRegistered = DateTime.Now,
                Albums = new List<AlbumEntityModel>() { a1 },
            };
            #endregion

            #region user 2
            PhotoEntityModel p4 = new PhotoEntityModel()
            {
                FileName = "code1.jpg",
                Name = "some code",
                DateCreated = DateTime.Now,
                Description = "no description",
            };
            AlbumEntityModel a2 = new AlbumEntityModel()
            {
                Name = "random coding photos",
                Description = "just some coding casual coding photos",
                DateCreated = DateTime.Now,
                Comments = new List<CommentEntityModel>(),
                Photos = new List<PhotoEntityModel>() { p4 },
            };

            UserEntityModel u2 = new UserEntityModel()
            {
                Fullname = "lea winchester",
                Username = "leawinchester",
                Email = "leawinchester@gmail.com",
                Password = "lealea",
                DateRegistered = DateTime.Now,
                Albums = new List<AlbumEntityModel>() { a2 },
            };
            #endregion

            #region user 3
            PhotoEntityModel p5 = new PhotoEntityModel()
            {
                FileName = "mockerie1.jpg",
                Name = "mock one",
                DateCreated = DateTime.Now,
                Description = "no description",
            };
            PhotoEntityModel p6 = new PhotoEntityModel()
            {
                FileName = "mockerie2.jpg",
                Name = "mock two",
                DateCreated = DateTime.Now,
                Description = "no description",
            };
            PhotoEntityModel p7 = new PhotoEntityModel()
            {
                FileName = "mockerie3.jpg",
                Name = "mock three",
                DateCreated = DateTime.Now,
                Description = "no description",
            };
            PhotoEntityModel p8 = new PhotoEntityModel()
            {
                FileName = "mockerie4.jpg",
                Name = "mock four",
                DateCreated = DateTime.Now,
                Description = "no description",
            };
            AlbumEntityModel a3 = new AlbumEntityModel()
            {
                Name = "mockups",
                Description = "some of my experimental mockups",
                DateCreated = DateTime.Now,
                Comments = new List<CommentEntityModel>(),
                Photos = new List<PhotoEntityModel>() { p5, p6, p7, p8 },
            };

            UserEntityModel u3 = new UserEntityModel()
            {
                Fullname = "jason bourne",
                Username = "jasonbourne",
                Email = "jasonbourne@gmail.com",
                Password = "whatsmyname",
                DateRegistered = DateTime.Now,
                Albums = new List<AlbumEntityModel>() { a3 },
            };
            #endregion
            using (PhotoExplorerContext context = new PhotoExplorerContext())
            {
                context.Users.AddRange(new List<UserEntityModel> { u1, u2,u3 });

                context.SaveChanges();
            }
        }
    }
}
