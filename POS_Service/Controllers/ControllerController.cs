using POS_Service.Context;
using POS_Service.Models;
using POS_Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace POS_Service.Controllers
{
    public class ControllerController : Controller
    {
        MyDbContext1 dbContext;
        // GET: Controller
        public ActionResult ControllerLogIn(LogInData data)
        {
            dbContext = new MyDbContext1();
            var check = dbContext.login.Where(m => m.username.Equals(data.username) &&
                m.password.Equals(data.password)).FirstOrDefault();

            if (check == null)
                return RedirectToAction("Controller", "Home");

            Session["userNameForController"] = data.username;
            return RedirectToAction("ControllerIndex");
        }
        public ActionResult ControllerIndex()
        {
            dbContext = new MyDbContext1();
            var query = dbContext.customers.ToList<CustomerData>();
            return View(query);
        }

        public ActionResult Details(string guid)
        {
            dbContext = new MyDbContext1();
            var customerObj = dbContext.customers.Where(m => m.guid.Equals(guid)).FirstOrDefault();

            var choseObj = dbContext.chosenProducts.Where(m => m.guid.Equals(guid)).ToList();

            var viewModel = new ControllerCustomer
            {
                customerdata = customerObj,
                choseList = choseObj
            };

            return View(viewModel);
        }

        public ActionResult CompleteDelivery(int id)
        {
            dbContext = new MyDbContext1();
            var customerObj = dbContext.customers.Where(m => m.Id.Equals(id)).FirstOrDefault();
            customerObj.IsDeliveried = true;
            dbContext.SaveChanges();
            return RedirectToAction("Controller", "Home");
        }

        public ActionResult ClearDelivery()
        {
            dbContext = new MyDbContext1();
            var qury = dbContext.customers.Where(m => m.IsDeliveried == true).ToList();
            
            foreach(var it in qury)
            {
                if(it.IsDeliveried == true)
                {
                    ClearProduct(it.guid);
                    dbContext.customers.Attach(it);
                    dbContext.customers.Remove(it);
                }
            }
            dbContext.SaveChanges();
            return RedirectToAction("Controller", "Home");
        }
        
        private void ClearProduct(string guid)
        {
            dbContext = new MyDbContext1();
            foreach(var itm in dbContext.chosenProducts)
            {
                if(itm.guid == guid)
                    dbContext.chosenProducts.Remove(itm);
            }
            dbContext.SaveChanges();
        }
    }
}