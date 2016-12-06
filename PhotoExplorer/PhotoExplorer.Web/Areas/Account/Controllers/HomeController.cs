using PhotoExplorer.Web.Entities;
using PhotoExplorer.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace PhotoExplorer.Web.Areas.Account.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            #region retrieving the claim values for the currently logged in user (to retrieve him using his/her id)
            ClaimsIdentity currentIdentity = User.Identity as ClaimsIdentity;
            string modelfullname = (currentIdentity.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)).ToString();//not used
            string modelusername = (currentIdentity.Claims.FirstOrDefault(c => c.Type == ClaimTypes.GivenName)).ToString();//not used
            var modelid = int.Parse((currentIdentity.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)).Value);
            #endregion

            UserDetailsViewModel model = null;

            using (PhotoExplorerContext cx = new PhotoExplorerContext())
            {
                UserEntityModel entity = cx.Users.FirstOrDefault(u => u.Id == modelid);

                #region mapping necessary properties from entitymodel to the viewmodel 
                model = new UserDetailsViewModel()
                {
                    Id = entity.Id,
                    Username = entity.Username,
                    Fullname = entity.Fullname,
                    Albums = entity.Albums,
                    DateRegistered = entity.DateRegistered,
                    Email = entity.Email,
                }; 
                #endregion
            }

            return View("Index",model);
        }

    }
}