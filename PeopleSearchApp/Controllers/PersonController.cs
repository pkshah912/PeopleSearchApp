using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PeopleSearchApp.DAL;
using PeopleSearchApp.Models;

namespace PeopleSearchApp.Controllers
{
    public class PersonController : Controller
    {
        PeopleContext db = new PeopleContext();

        public ActionResult Index()
        {
            return View(db.People.OrderBy(p => p.FirstName).ThenBy(n => n.LastName).ToList());
        }

        public JsonResult SearchPeopleByString(string searchValue)
        {
            var people = from p in db.People
                         select p;
            if (!String.IsNullOrEmpty(searchValue))
            {
                people = people.Where(p => p.FirstName.ToUpper().Equals(searchValue.ToUpper())
                    || p.LastName.ToUpper().Equals(searchValue.ToUpper()));
            }

            people = people.OrderBy(p => p.FirstName);

            List<Person> peopleDetails = people.ToList();
            ViewBag.NoResults = peopleDetails.Count == 0 ? true : false;

            return Json(peopleDetails, JsonRequestBehavior.AllowGet);
        }
    }
}
