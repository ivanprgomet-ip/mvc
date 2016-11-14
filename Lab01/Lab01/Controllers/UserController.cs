using Lab01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab01.Controllers
{
    public class UserController:Controller
    {
        public ActionResult UserDetails()
        {
            var model = new UserModel("ivan prgomet", "höganäs", new DateTime(1992, 03, 20));
            return View(model);
        }
    }
}