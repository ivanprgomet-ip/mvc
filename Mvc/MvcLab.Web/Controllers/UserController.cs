using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcLab.Data.Repositories;
using MvcLab.Data.Models;

namespace MvcLab.Web.Controllers
{
    public class UserController : Controller
    {
        /// <summary>
        /// plays along with the UserController constructor
        /// </summary>
        public UserRepository UserRepository { get; set; }
        
        /// <summary>
        /// the constructor runs every time we visit /User
        /// which means that we create an instance of the userrepository 
        /// every time and seed default users to the application if they dont
        /// already exist (see userrepository constructor)
        /// </summary>
        public UserController()
        {
            UserRepository = new UserRepository();
        }

        /// <summary>
        /// sending in all the temporary users into the view 
        /// to show them in a list
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View(UserRepository.Users);
        }

        /// <summary>
        /// details about a specific user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public ActionResult Details(UserModel user)
        {
            var userToShow = UserRepository.Return(user.Id);

            return View(userToShow);
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View("Login");
        }

        /// <summary>
        /// recieves the username and password back after
        /// user submits the form
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Login(UserModel userToBeLoggedIn)
        {
            UserRepository repo = new UserRepository();
            var authenticatedUser = repo.ReturnUserLogin(userToBeLoggedIn.Username, userToBeLoggedIn.Password);

            if (authenticatedUser != null)
            {
                return Content("Successfull Login");
            }
            else
            {
                return Content("Login failed");
            }

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
        public ActionResult Register(UserModel userToBeRegistered)
        {
            UserRepository repo = new UserRepository();

            if (ModelState.IsValid)
            {
                if (userToBeRegistered != null)
                {
                    //todo: create growl when user gets registered
                    UserRepository.Add(userToBeRegistered);
                    return RedirectToAction("Index", "Home");
                }
            }

            // If we got this far, something failed, redisplay form
            return View(userToBeRegistered);
        }
    }
}