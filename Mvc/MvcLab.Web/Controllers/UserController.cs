using System.Web.Mvc;
using MvcLab.Data.Repositories;
using MvcLab.Data.Models;
using MvcLab.Web.Mapper;
using System.Collections.Generic;
using MvcLab.Web.Models;

namespace MvcLab.Web.Controllers
{
    /// <summary>
    /// the controllers are communicating with the Data repositories to get data
    /// from the database. at the same time, they use the viewmodel classes and then to make the viewmodel classes entitymodel classes (they are pretty much the same class objects with the same properties) we use mappings of the values.
    /// </summary>
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
            List<UserEntity> userEntities = UserRepository.GetAllUsers();

            List<UserModel> userModels = new List<UserModel>();

            foreach (var userEntity in userEntities)
            {
                userModels.Add(EntityModelMapper.EntityToModel(userEntity));
            }

            return View(UserRepository.Users);
        }

        /// <summary>
        /// details about a specific user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public ActionResult Details(UserModel user)
        {
            UserModel userToShow = EntityModelMapper.EntityToModel(UserRepository.GetUser(user.Id));

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
        public ActionResult Login(UserModel userModel)
        {
            UserModel authenticatedUser = EntityModelMapper.EntityToModel(
                UserRepository.GetLoggedInUser(
                    userModel.Username, userModel.Password));

            if (authenticatedUser != null)
            {
                return Content("Successfull Login");
            }
            else
            {
                return Content("Login failed");
            }

        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(UserModel userModel)
        {
            if (ModelState.IsValid)
            {
                if (userModel != null)
                {
                    //todo: create growl when user gets registered

                    UserRepository.Add(EntityModelMapper.ModelToEntity(userModel));

                    return RedirectToAction("Index", "Home");
                }
            }

            // If we got this far, something failed, redisplay form
            return View(userModel);
        }
    }
}