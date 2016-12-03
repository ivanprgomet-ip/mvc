using MvcLab.Data;
using MvcLab.Data.Repositories;
using MvcLab.Web.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MvcLab.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            Seed();
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
            //tip: think about specifying the URL as arguments, not the path..
            //Response.Redirect("/Home/Error");
        }

        private void Seed()
        {
            #region user 1
            PhotoModel p1 = new PhotoModel()
            {
                Name = "event1",
                FileName = "event1.jpg",
                DateCreated = DateTime.Now,
                Description = "no description",
            };
            PhotoModel p2 = new PhotoModel()
            {
                Name = "event2",
                FileName = "event2.jpg",
                DateCreated = DateTime.Now,
                Description = "no description",
            };
            PhotoModel p3 = new PhotoModel()
            {
                Name = "event3",
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
                Firstname = "ivan",
                Lastname = "prgomet",
                Country = "sweden",
                City = "lund",
                DateRegistered = DateTime.Now,
                Email = "ivanprgomet_ip@hotmail.com",
                Street = "lundstreet 3",
                Phone = "9423587495",
                Username = "ivanprgomet",
                Password = "ivan123",
                Albums = new List<AlbumModel>() { a1 },
            };
            #endregion

            #region user 2
            PhotoModel p4 = new PhotoModel()
            {
                Name = "code1",
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
                Firstname = "lea",
                Lastname = "winchester",
                Country = "great brittain",
                City = "london",
                DateRegistered = DateTime.Now,
                Email = "leawinchester@hotmail.com",
                Street = "london street 4 C",
                Phone = "9345793493",
                Username = "leawinchester",
                Password = "lealea",
                Albums = new List<AlbumModel>() { a2 },
            };
            #endregion

            UserRepository userRepo = new UserRepository();

            userRepo.Add(Mapper.EntityModelMapper.ModelToEntity(u1));

            userRepo.Add(Mapper.EntityModelMapper.ModelToEntity(u2));
        }
    }
}
