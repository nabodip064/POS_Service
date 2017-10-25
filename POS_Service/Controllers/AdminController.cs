using POS_Service;
using POS_Service.Context;
using POS_Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace POS_Service.Controllers
{
    public class AdminController : Controller
    {
        MyDbContext1 dbCntxt;
        // GET: Admin
        public ActionResult AdminIndex(LogInData data)
        {
            dbCntxt = new MyDbContext1();
            var check = dbCntxt.login.Where(m => m.username.Equals(data.username) && m.password.Equals(data.password)).FirstOrDefault();
            if (check == null)
                return RedirectToAction("Admin", "Home");

            Session["userName"] = data.username;
            return RedirectToAction("LogIn");
        }
        public ActionResult LogIn()
        {
            dbCntxt = new MyDbContext1();
            var datas = dbCntxt.stocks.ToList();
            return View(datas);
        }
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult AddProduct(StockData data)
        {
            dbCntxt = new MyDbContext1();
            data.ProductImage = "~/Images/" + data.ProductImage;
            dbCntxt.stocks.Add(data);
            var check = dbCntxt.SaveChanges();
            return RedirectToAction("Admin", "Home");
        }

        public ActionResult UpdatePrice(int id, decimal price)
        {
            dbCntxt = new MyDbContext1();
            var stockObj = GetObj(id);
            stockObj.ProductPrice = price;
            dbCntxt.SaveChanges();
            return RedirectToAction("Admin", "Home");
        }
        
        public ActionResult UpdateQnty(int id, int quantity)
        {
            dbCntxt = new MyDbContext1();
            var stockObj = GetObj(id);
            stockObj.ProductQuantity += quantity;
            dbCntxt.SaveChanges();
            return RedirectToAction("Admin", "Home");
        }
        
        public ActionResult UpdtImg(int id, string imgPath)
        {
            dbCntxt = new MyDbContext1();
            var stockObj = GetObj(id);
            stockObj.ProductImage = "~/Images/" + imgPath;
            return RedirectToAction("Admin", "Home");
        }
        
        public ActionResult DeleteProduct(int id)
        {
            dbCntxt = new MyDbContext1();
            var stockObj = GetObj(id);
            dbCntxt.stocks.Remove(stockObj);
            dbCntxt.SaveChanges();
            return RedirectToAction("Admin", "Home");
        }

        private StockData GetObj(int id)
        {
            dbCntxt = new MyDbContext1();
            var stockObj = dbCntxt.stocks.Where(m => m.Id.Equals(id)).FirstOrDefault();
            return stockObj;
        }
    }
}