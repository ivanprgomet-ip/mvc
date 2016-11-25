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
    }
}