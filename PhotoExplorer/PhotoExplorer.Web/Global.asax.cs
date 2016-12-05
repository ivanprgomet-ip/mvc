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
            PhotoViewModel p1 = new PhotoViewModel()
            {
                FileName = "event1.jpg",
                DateCreated = DateTime.Now,
                Description = "no description",
            };
            PhotoViewModel p2 = new PhotoViewModel()
            {
                FileName = "event2.jpg",
                DateCreated = DateTime.Now,
                Description = "no description",
            };
            PhotoViewModel p3 = new PhotoViewModel()
            {
                FileName = "event3.jpg",
                DateCreated = DateTime.Now,
                Description = "no description",
            };

            AlbumViewModel a1 = new AlbumViewModel()
            {
                Name = "my coding events",
                Description = "coding events that i have attended",
                DateCreated = DateTime.Now,
                Comments = new List<CommentViewModel>(),
                Photos = new List<PhotoViewModel>() { p1, p2, p3 },
            };

            UserViewModel u1 = new UserViewModel()
            {
                Fullname = "Ivan Prgomet",
                Username = "ivanprgomet",
                Password = "ivan123",
                DateRegistered = DateTime.Now,
                Albums = new List<AlbumViewModel>() { a1 },
            };
            #endregion

            #region user 2
            PhotoViewModel p4 = new PhotoViewModel()
            {
                FileName = "code1.jpg",
                DateCreated = DateTime.Now,
                Description = "no description",
            };
            AlbumViewModel a2 = new AlbumViewModel()
            {
                Name = "random coding photos",
                Description = "just some coding casual coding photos",
                DateCreated = DateTime.Now,
                Comments = new List<CommentViewModel>(),
                Photos = new List<PhotoViewModel>() { p4 },
            };

            UserViewModel u2 = new UserViewModel()
            {
                Fullname = "lea winchester",
                Username = "leawinchester",
                Password = "lealea",
                DateRegistered = DateTime.Now,
                Albums = new List<AlbumViewModel>() { a2 },
            };
            #endregion

            #region user 3
            PhotoViewModel p5 = new PhotoViewModel()
            {
                FileName = "mockerie1.jpg",
                DateCreated = DateTime.Now,
                Description = "no description",
            };
            PhotoViewModel p6 = new PhotoViewModel()
            {
                FileName = "mockerie2.jpg",
                DateCreated = DateTime.Now,
                Description = "no description",
            };
            PhotoViewModel p7 = new PhotoViewModel()
            {
                FileName = "mockerie3.jpg",
                DateCreated = DateTime.Now,
                Description = "no description",
            };
            PhotoViewModel p8 = new PhotoViewModel()
            {
                FileName = "mockerie4.jpg",
                DateCreated = DateTime.Now,
                Description = "no description",
            };
            AlbumViewModel a3 = new AlbumViewModel()
            {
                Name = "mockups",
                Description = "some of my experimental mockups",
                DateCreated = DateTime.Now,
                Comments = new List<CommentViewModel>(),
                Photos = new List<PhotoViewModel>() { p5, p6, p7, p8 },
            };

            UserViewModel u3 = new UserViewModel()
            {
                Fullname = "jason bourne",
                Username = "jasonbourne",
                Password = "whatsmyname",
                DateRegistered = DateTime.Now,
                Albums = new List<AlbumViewModel>() { a3 },
            };
            #endregion
            using (PhotoExplorerContext context = new PhotoExplorerContext())
            {
                context.Users.AddRange(new List<UserViewModel> { u1, u2,u3 });

                context.SaveChanges();
            }
        }
    }
}
