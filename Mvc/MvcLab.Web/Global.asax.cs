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
            Response.Redirect("/Home/Error");
        }
    }
}
