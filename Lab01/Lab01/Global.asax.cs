﻿using Lab01.Models;
using System.Collections.Generic;
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
    }
}
