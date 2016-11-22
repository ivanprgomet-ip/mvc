using MVCPhotoAlbums.Models;
using MVCPhotoAlbums.Repositories;
using System;
using System.Web.Mvc;

namespace MVCPhotoAlbums.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View(UserRepository._users);
        }

        // GET: User/Details/5
        public ActionResult Details(UserModel user)
        {
            UserRepository repo = new UserRepository();

            var userToShow = repo.ReturnUser(user.Id);

            return View(userToShow);
        }

        // GET: User/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View("Create");
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(UserModel userToBeRegistered)
        {
            try
            {
                // TODO: Add insert logic here

                if (userToBeRegistered != null)
                {
                    UserRepository._users.Add(userToBeRegistered);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View("Create");
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
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

            bool userExists = new Func<bool>(() =>
            {
                var user = repo.ReturnUser(userToBeLoggedIn.Id);

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
                    repo.AddUser(userToBeRegistered);
                    return RedirectToAction("Index", "Home");
                }
            }

            // If we got this far, something failed, redisplay form
            return View(userToBeRegistered);
        }
    }
}
