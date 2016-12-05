using PhotoExplorer.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhotoExplorer.Web.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var users = new List<UserModel>();

            using (PhotoExplorerContext cx = new PhotoExplorerContext())
            {
                users = cx.Users.ToList();
            }

            return View(users);
        }
    }
}