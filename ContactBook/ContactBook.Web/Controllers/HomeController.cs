using ContactBook.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ContactBook.Web.Controllers
{
    public class HomeController : Controller
    {
        public static List<ContactViewModel> contactsDB = new List<ContactViewModel>();

        public ActionResult Index()
        {
            return View(contactsDB);
        }

        /// <summary>
        /// create a new contact using ajax
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(ContactViewModel newContact)
        {
            newContact.Id = Guid.NewGuid();
            newContact.Address = "default";
            newContact.Phone = "xxx-xxx-xx-xx";
            contactsDB.Add(newContact);

            return PartialView("List", contactsDB);
        }

        /// <summary>
        /// returns a partial view only to a page, not a complete view.
        /// now you dont need a corresponding view!
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult List()
        {
            return PartialView(contactsDB);
        }

        [HttpPost]
        public ActionResult Delete(Guid id)
        {
            var contactToRemove = contactsDB.Where(c => c.Id == id).FirstOrDefault();

            contactsDB.Remove(contactToRemove);

            return PartialView("List",contactsDB);
        }

        [HttpGet]
        public ActionResult Details(Guid id)
        {
            ContactViewModel model = contactsDB.Where(c => c.Id == id).FirstOrDefault();

            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            ContactViewModel retrievedModel = contactsDB.Where(c => c.Id == id).FirstOrDefault();

            ContactEditViewModel model = new ContactEditViewModel()
            {
                Id = retrievedModel.Id,
                Address = retrievedModel.Address,
                Name = retrievedModel.Name,
                Phone = retrievedModel.Phone,
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(ContactEditViewModel model)
        {
            ContactViewModel updateModel = contactsDB.Where(c => c.Id == model.Id).FirstOrDefault();

            updateModel.Address = model.Address;
            updateModel.Name = model.Name;
            updateModel.Phone = model.Phone;
            updateModel.Changed = DateTime.Now;

            return RedirectToAction("Details",updateModel);
        }
    }
}