using DataAccess;
using DataAccess.Models;
using System.Linq;
using System.Web.Mvc;

namespace DemoApp.Controllers
{
    public class PersonController : Controller
    {
        public ActionResult Index()
        {
            DataAccessService da = new DataAccessService();
            return View(da.AllPerson());
        }

        public ActionResult Person(int id = 0)
        {

            Person p;
            if (id == 0)
            {
                p = new Person
                {
                //    BusinessEntityID = 0,
                //    FirstName = string.Empty,
                //    LastName = string.Empty,
                //    Title = string.Empty
                };
            }
            else
            {
                DataAccessService da = new DataAccessService();
                //p = da.GetPerson(id).FirstOrDefault();
                p = da.suffixPerson().FirstOrDefault();
            }
            return View(p);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Person(Person p)
        {
            if (ModelState.IsValid)
            {
                //code for db insert
                DataAccessService da = new DataAccessService();
                da.InsertPerson(p);
                return RedirectToAction("Index");
            }
            return View(p);
        }

    //    [HttpDelete]
        public ActionResult Delete(int id)
        {
           
                //code for db insert
                DataAccessService da = new DataAccessService();
                da.DeletePerson(id);
                return RedirectToAction("Index");

        }

        /*[HttpPost]
        public ActionResult Save(Person newPerson)
        {
            return JavaScript("alert('Email sent successfully');");

            if (ModelState.IsValid)
            {
               // db.AddToMovies(newPerson);
               // db.SaveChanges();

                return RedirectToAction("Person");
            }
            else
            {
                return View(newPerson);
            }
        }


        /*[HttpPost]
        public ActionResult Person(Person person)
        {
            DataAccessService da = new DataAccessService();
            int id = da.InsertPerson(person);
            return View();
        }

        public ActionResult ActionName(Person model, string whichButton)
        {
            switch (whichButton)
            {
                case "Save": //do stuff and redirect to the list of records
                    break;
                case "SaveAndAdd": //do stuff and redirect to create
                    break;
            }
        }*/
    }
}