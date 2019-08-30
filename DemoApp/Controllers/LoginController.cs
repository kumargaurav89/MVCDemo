using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Windows;
using System.Windows.Forms;

namespace DemoApp.Controllers
{
    public class LoginController : Controller
    {
        private readonly IDataAccessService _dataAccessService;

        public LoginController(IDataAccessService dataAccessService)
        {
            _dataAccessService = dataAccessService;
        }
        public ActionResult Login()
        {
            return View();
        }

        //code for login user
        public ActionResult LoginUser(int id)
        {
            _dataAccessService.LoginUser(id);
            return RedirectToAction("Login");
        }

        //Code for new user
        public ActionResult SignUpUser()
        {
            //MessageBox.Show("SignUpUser");
            //return RedirectToAction("SignUp");
            return View("SignUp");
        }
    }
}