using Lab01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab01.Controllers
{
    public class AuthorizationController : Controller
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
        public ActionResult Login(User user)//could also pass in user object, mvc smart enough to place username and password into object
        {
            //retrieve the user if he exists
            if (UserExists(user))
                return Content("Successfull Login");
            else
                return Content("Login failed");
        }


        public ActionResult Logout()
        {
            return View();
        }

        private bool UserExists(User userToBeLoggedIn)
        {
            foreach (var existingUser in _usersDB)
            {
                if (existingUser.Username == userToBeLoggedIn.Username && existingUser.Password == userToBeLoggedIn.Password)
                    return true;
            }
            return false;
        }
    }
}