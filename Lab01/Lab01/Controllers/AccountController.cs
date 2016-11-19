using Lab01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab01.Controllers
{
    public class AccountController : Controller
    {
        public static List<User> _usersDB = new List<User>();

        /// <summary>
        /// provides the username with a login screen
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// recieves the username and password back after
        /// user submits the form
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Login(User userToBeLoggedIn)//could also pass in user object, mvc smart enough to place username and password into object
        {
            //immediately checks if the entered credentials match a user 
            bool userExists = new Func<bool>(() =>
            {
                var user = _usersDB
               .Where(u => u.Username == userToBeLoggedIn.Username && u.Password == userToBeLoggedIn.Password)
               .FirstOrDefault();

                if (user == null)
                    return false;
                else
                    return true;
            })();


            if (userExists)
                return Content("Successfull Login");
            else
                return Content("Login failed");

        }

        public ActionResult Logout()
        {
            return View();
        }
    }
}