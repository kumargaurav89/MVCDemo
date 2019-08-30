using DataAccess;
using DataAccess.Models;
using System.Linq;
using System.Web.Mvc;

namespace DemoApp.Controllers
{
    public class PersonController : Controller
    {
        private readonly IDataAccessService _dataAccessService;

        public PersonController(IDataAccessService dataAccessService)
        {
            _dataAccessService = dataAccessService;
        }
        public ActionResult Index()
        {
            return View(_dataAccessService.AllPerson());
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
                //p = _dataAccessService.GetPerson(id).FirstOrDefault();
                p = _dataAccessService.suffixPerson().FirstOrDefault();
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
                _dataAccessService.InsertPerson(p);
                return RedirectToAction("Index");
            }
            return View(p);
        }

    //    [HttpDelete]
        public ActionResult Delete(int id)
        {
                //code for db insert
                _dataAccessService.DeletePerson(id);
                return RedirectToAction("Index");

        }
    }
}