using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Contacts.Data;

namespace Contacts.Web.Controllers
{
    public class HomeController : Controller
    {
        public static List<ContactViewModel> Contacts { get; set; } = new List<ContactViewModel>();

        public ActionResult Index()
        {
            return View(Contacts);
        }

        /// <summary>
        /// create a new contact using ajax
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(ContactViewModel newContact)
        {
            newContact.Id = Guid.NewGuid();
            newContact.Added = DateTime.Now;
            newContact.Address = "default";
            newContact.Phone = "xxx-xxx-xx-xx";
            Contacts.Add(newContact);

            return PartialView("List", Contacts);
        }

        /// <summary>
        /// returns a partial view only to a page, not a complete view
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult List()
        {
            if (!Request.IsAjaxRequest())
            {
                return View(Contacts);
            }
            return PartialView(Contacts);

            //return PartialView("List", Contacts); samma som ovan?
        }

        [HttpPost]
        public ActionResult Delete(Guid id)
        {
            var contactToRemove = Contacts.Where(c => c.Id == id).FirstOrDefault();

            Contacts.Remove(contactToRemove);

            return PartialView("List",Contacts);
        }
    }
}