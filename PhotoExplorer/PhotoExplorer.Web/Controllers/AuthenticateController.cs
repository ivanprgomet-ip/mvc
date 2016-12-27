using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using PhotoExplorer.Web.Entities;
using PhotoExplorer.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace PhotoExplorer.Web.Controllers
{
    [Authorize]
    public class AuthenticateController : Controller
    {
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserLoginViewModel model)
        {

            if (ModelState.IsValid)
            {
                var userToLogin = new UserEntityModel();

                #region get user to login
                using (PhotoExplorerEntities cx = new PhotoExplorerEntities())
                {
                    userToLogin = cx.Users
                        .FirstOrDefault(u => u.Username == model.Username &&
                        u.Password == model.Password);
                }
                #endregion

                if (userToLogin != null)
                {
                    #region when user is found, set the necessary userloginviewmodel properties
                    model.Id = userToLogin.Id;
                    model.Fullname = userToLogin.Fullname;
                    model.Username = userToLogin.Username;
                    model.Password = userToLogin.Password;
                    #endregion

                    var identity = new ClaimsIdentity(new[]
                    {
                        //A claim is a statement that one subject makes about itself or another subject.
                        new Claim(ClaimTypes.Name, model.Fullname),
                        new Claim(ClaimTypes.GivenName, model.Username),
                        new Claim(ClaimTypes.NameIdentifier, model.Id.ToString()),
                    }, "ApplicationCookie");

                    // IOwinContext wraps OWIN environment dictionary and provides strongly typed accessors.
                    IOwinContext owinCtx = HttpContext.GetOwinContext();

                    // IAuthenticationManager is used to interact with authentication middleware that have been chained in the pipeline.
                    IAuthenticationManager authManager = owinCtx.Authentication;

                    authManager.SignIn(identity);

                    return RedirectToAction("Index", "Home");
                }
            }
            return View();//we stay on the login page if login fails
        }

        [HttpGet]
        public ActionResult Logout()
        {
            IOwinContext owinCtx = HttpContext.GetOwinContext();

            IAuthenticationManager authManager = owinCtx.Authentication;

            authManager.SignOut("ApplicationCookie");

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(UserRegisterViewModel model)
        {
            ViewBag.Message = "";

            using (PhotoExplorerEntities cx = new PhotoExplorerEntities())
            {
                UserEntityModel entity = new UserEntityModel()
                {
                    Fullname = model.Fullname,
                    Username = model.Username,
                    Password = model.Password,
                    Email = model.Email,
                };


                cx.Users.Add(entity);

                cx.SaveChanges();

                System.Threading.Thread.Sleep(800); //simulate loading time for wait

                //ViewBag.Message = entity.Username + " successfully registered";

            }

            return View();
        }
    }
}