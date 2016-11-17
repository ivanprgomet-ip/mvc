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
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            PhotosInitializer();
        }
        protected void Application_End()
        {

        }
        protected void Session_Start()
        {

        }
        protected void Session_End()
        {

        }
        protected void Application_Error()
        {

        }
        private void PhotosInitializer()
        {
            string imagesPath = Server.MapPath("~/Content/images/");
            List<string> ImagePaths = Directory.GetFiles(imagesPath).ToList();
            //List<string> ImagePaths = Directory.GetFiles(imagesPath, "*.jpg").ToList();
            foreach (var imgPath in ImagePaths)
            {
                PhotoController.ImagesDB.Add(
                    new Photo()
                    {
                        Id = Guid.NewGuid(),
                        Description = "[no description set]",
                        Path = string.Format("~/Content/images/" + @Path.GetFileName(imgPath))
                    });
            };
        }
    }
}
