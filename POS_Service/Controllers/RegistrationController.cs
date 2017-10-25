using POS_Service.Context;
using POS_Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace POS_Service.Controllers
{
    public class RegistrationController : Controller
    {
        MyDbContext1 dbCntxt;
        // GET: Registration
        public ActionResult Index(LogInData data)
        {
            dbCntxt = new MyDbContext1();
            var check = dbCntxt.login.Where(m => m.username.Equals(data.username) && m.password.Equals(data.password)).FirstOrDefault();
            if (check == null)
                return RedirectToAction("Registration", "Home");

            Session["userNameforRegitration"] = data.username;
            return RedirectToAction("LogIn");
        }
        
        public ActionResult LogIn()
        {
            return View();
        }

        public ActionResult AddMe(LogInData data)
        {
            dbCntxt = new MyDbContext1();
            dbCntxt.login.Add(data);
            var check = dbCntxt.SaveChanges();
            if(check == 0)
                return RedirectToAction("Registration", "Home");
            return RedirectToAction("Index", "Home");
        }
    }
}