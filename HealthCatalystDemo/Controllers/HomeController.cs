using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using HealthCatalystDemo.Models;
using System.Web.Routing;

namespace HealthCatalystDemo.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        PersonContext personcontext = new PersonContext();
        [HttpGet]
        public ActionResult PersonSearch()
        {
            
            return View();
        }
        public ActionResult PersonSearch(Person person)
        {
            IEnumerable<Person> result = new List<Person>();
            if (ModelState.IsValid)
            {
                 result = personcontext.person.Where(per => ((per.FirstName == person.FirstName) || (per.FirstName == person.FirstName) || (per.FirstName == person.FirstName) || (per.FirstName == person.FirstName))).ToList();

            }
            if (result.Count() > 0)
            {
                TempData["person"] = person;

                return RedirectToAction("PersonDisplay");
            }
            else
            {
                return View();
            }

            
        }

        public ActionResult PersonDisplay()
        {
            Person person = TempData["person"] as Person;
            List<Person> SearchResult= new List<Person>();
            if (ModelState.IsValid)
            {
                SearchResult = personcontext.person.Where(per => ((per.FirstName == person.FirstName) || (per.FirstName == person.FirstName) || (per.FirstName == person.FirstName) || (per.FirstName == person.FirstName))).ToList();

            }
            return View (SearchResult);
        }

        
        [HttpGet]
        public ActionResult AddPerson()
        {
           
            return View();
        }
        [HttpPost]
        public ActionResult AddPerson(Person person,HttpPostedFileBase Image1)
        {
            if(Image1.ContentLength > 0)
            {
                person.Image = new byte[Image1.ContentLength];
                Image1.InputStream.Read(person.Image, 0, Image1.ContentLength);
            }
            if (ModelState.IsValid)
            {
                personcontext.person.Add(person);
                try
                {
                    personcontext.SaveChanges();
                }
                catch(System.Data.Entity.Infrastructure.DbUpdateException upEx)
                {
                    Console.WriteLine(upEx.Message);
                }
                personcontext.SaveChanges();
                return RedirectToAction("PersonSearch");
            }

            return View(person);
        }

    }
}