using Contacts.Data;
using Contacts.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Contacts.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            InitializeContacts();
        }

        private void InitializeContacts()
        {
            HomeController.Contacts = new List<ContactViewModel>()
            {
                new ContactViewModel()
                {
                    Id = Guid.NewGuid(),
                    Firstname = "ivan",
                    Lastname = "prgomet",
                    Phone = "38752865",
                    Address="långgatan 74",
                    Added = DateTime.Now,
                },
                new ContactViewModel()
                {
                    Id = Guid.NewGuid(),
                    Firstname = "lea",
                    Lastname = "winchester",
                    Phone = "9832745",
                    Address="5th avenue",
                    Added = DateTime.Now,
                },
                new ContactViewModel()
                {
                    Id = Guid.NewGuid(),
                    Firstname = "Troy",
                    Lastname = "Hunt",
                    Phone = "823465238",
                    Address="hutn street",
                    Added = DateTime.Now,
                },
            };
        }
    }
}
