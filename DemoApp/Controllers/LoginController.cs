using DataAccess;
using DataAccess.Models;
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LoginUser(User user)
        {
            User test;
            test = _dataAccessService.LoginUser(user).FirstOrDefault();
            if (test == null)
            {
                MessageBox.Show("Invalid user name or password.");
            }
            else
            {
                MessageBox.Show(test.UserName);
            }
            return RedirectToAction("Login");
        }

        //Code for new user
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUpUser(User u)
        {
            if(u.Password == u.ConfirmPassword && u.Password != null)
            {
                _dataAccessService.InsertUser(u);
                MessageBox.Show("User created successfully");
                return View("Login");
            }
            else
            {
                MessageBox.Show("Please enter the details.");
                return View("SignUp");
            }
           // MessageBox.Show("SignUpUser");
            //return RedirectToAction("SignUp");
            
        }

        //call sign up page
        public ActionResult SignUpPage()
        {
            MessageBox.Show("SignUpUser");
            //return RedirectToAction("SignUp");
            return View("SignUp");
        }
    }
}