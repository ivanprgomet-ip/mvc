using System.Web.Mvc;
using MvcLab.Data.Repositories;
using MvcLab.Data.Models;
using MvcLab.Web.Mapper;
using System.Collections.Generic;
using MvcLab.Web.Models;

namespace MvcLab.Web.Controllers
{
    public class UserController : Controller
    {

        public UserRepository UserRepository { get; set; }

        public UserController()
        {
            UserRepository = new UserRepository();
        }

        [HttpGet]
        public ActionResult Index()
        {
            List<UserEntity> userEntities = UserRepository.RetrieveAll();

            List<UserModel> userModels = new List<UserModel>();

            foreach (var userEntity in userEntities)
            {
                userModels.Add(EntityModelMapper.EntityToModel(userEntity));
            }

            return View(userModels);
        }

        [HttpGet]
        public ActionResult Details(int id)//this id has to match the routeconfig id name!
        {
            UserModel userToShow = EntityModelMapper.EntityToModel(UserRepository.GetUser(id));

            return View(userToShow);
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View("Login");
        }

        [HttpPost]
        public ActionResult Login(UserModel userModel)
        {
            UserModel authenticatedUser = EntityModelMapper.EntityToModel(
                UserRepository.RetrieveLoggedInUser(
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