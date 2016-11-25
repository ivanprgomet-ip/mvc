using MvcLab.Data.Repositories;
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

            SetupInitialUserFolders();
        }

        /// <summary>
        /// Create folders based on existing users
        /// </summary>
        protected void SetupInitialUserFolders()
        {
            //where all data files will be for the users of the application
            string destination = Server.MapPath("~/UsersData/");

            //create the destination folder if it doesnt exist
            if (!Directory.Exists(destination))
            {
                Directory.CreateDirectory(destination);
            }

            foreach (var user in UserRepository.Users)
            {
                string individualUserDir = Path.Combine(destination, user.Username);
                Directory.CreateDirectory(individualUserDir);

                foreach (var album in user.Albums)
                {
                    string IndividualUserAlbumDir = Path.Combine(individualUserDir, album.Name);
                    Directory.CreateDirectory(IndividualUserAlbumDir);
                }
            }
        }
    }
}
