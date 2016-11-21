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
        public static List<User> _users = new List<User>();

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
            //todo: the usertobeloggedin is null
            if (ModelState.IsValid)
            {
                var user = _users
               .Where(u => u.Username == userToBeLoggedIn.Username && u.Password == userToBeLoggedIn.Password)
               .FirstOrDefault();

                if (user == null)
                    return Content("Login Failed");
                else
                    return Content("Login succeeded");
            }
            return View();//validation fails

            //immediately checks if the entered credentials match a user 
            //bool userExists = new Func<bool>(() =>
            //{
            //    var user = _users
            //   .Where(u => u.Username == userToBeLoggedIn.Username && u.Password == userToBeLoggedIn.Password)
            //   .FirstOrDefault();

            //    if (user == null)
            //        return false;
            //    else
            //        return true;
            //})();

            //if (userExists)
            //    return Content("Successfull Login");
            //else
            //    return Content("Login failed");

        }

        public ActionResult Logout()
        {
            return View();
        }

        //get the register page
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        //register a new user
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User userToBeRegistered)
        {
            if (ModelState.IsValid)
            {
                if(userToBeRegistered!=null)
                {
                    userToBeRegistered.Id = Guid.NewGuid();
                    userToBeRegistered.DateRegistered = DateTime.Now;

                    _users.Add(userToBeRegistered);
                    return RedirectToAction("Index", "Home");
                }
            }

            // If we got this far, something failed, redisplay form
            return View(userToBeRegistered);
        }
    }
}