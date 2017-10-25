using POS_Service.Context;
using POS_Service.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace POS_Service.Controllers
{
    public class HomeController : Controller
    {
        MyDbContext1 context;

        public ActionResult Start()
        {
            Session["guid"] = Guid.NewGuid();
            return RedirectToAction("Index");
        }

        public ActionResult Index()
        {
            if (Session["guid"] == null)
                return RedirectToAction("Start");

            context = new MyDbContext1();
            var qury = context.stocks.ToList();
            return View(qury);
        }

        // From Index View
        public ActionResult Add_Chart(int productId, int qnty)
        {
            if (Session["guid"] == null)
                return RedirectToAction("Start");

            string guid = Session["guid"].ToString();
            context = new MyDbContext1();
            var productObj = context.stocks.Where(m => m.Id.Equals(productId)).FirstOrDefault();
            var productIsExist = context.chosenProducts.Where(m => m.productId.Equals(productId) && m.guid.Equals(guid)).FirstOrDefault();
            if (productIsExist == null)
            {
                ChosenProduct item = new ChosenProduct();
                item.guid = Session["guid"].ToString();
                item.productId = productId;
                item.quantity = qnty;
                item.productName = productObj.ProductName;
                item.productPrice = productObj.ProductPrice;
                context.chosenProducts.Add(item);
            }
            else
            {
                productIsExist.quantity += qnty;
            }
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        // From Index View
        public ActionResult SelectedProduct()
        {
            if (Session["guid"] == null)
                return RedirectToAction("Start");
            string guid = Session["guid"].ToString();
            context = new MyDbContext1();
            var qury = context.chosenProducts.Where(m => m.guid.Equals(guid)).ToList();
            return View(qury);
        }

        // From SelectedProduct View
        public ActionResult EditProduct(int? id, int quantity)
        {
            if (Session["guid"] == null)
                return RedirectToAction("Start");

            string guid = Session["guid"].ToString();
            context = new MyDbContext1();
            var productObj = context.chosenProducts.Where(m => m.Id == id && m.guid.Equals(guid)).FirstOrDefault();
            productObj.quantity = quantity;
            var check = context.SaveChanges();
            return RedirectToAction("SelectedProduct");
        }

        // From SelectedProduct View
        public ActionResult DeleteProduct(int? id)
        {
            if (Session["guid"] == null)
                return RedirectToAction("Start");

            string guid = Session["guid"].ToString();
            context = new MyDbContext1();
            var productObj = context.chosenProducts.Where(m => m.Id == id && m.guid.Equals(guid)).FirstOrDefault();
            context.chosenProducts.Remove(productObj);
            context.SaveChanges();
            return RedirectToAction("SelectedProduct");
        }

        public ActionResult CustomerDetails()
        {
            if (Session["guid"] == null)
                return RedirectToAction("Start");

            return View();
        }


        public ActionResult AddCustomer(CustomerData data)
        {
            if (Session["guid"] == null)
                return RedirectToAction("Start");

            context = new MyDbContext1();
            data.guid = Session["guid"].ToString();

            context.customers.Add(data);
            context.SaveChanges();
            
            return RedirectToAction("Start");
        }

        public ActionResult Admin()
        {
            if (Session["userName"] != null)
                return RedirectToAction("LogIn", "Admin");
            return View();
        }
        public ActionResult Registration()
        {
            if (Session["userNameforRegitration"] != null)
                return RedirectToAction("Index", "Registration");
            return View();
        }
        public ActionResult Controller()
        {
            if (Session["userNameforController"] != null)
                return RedirectToAction("ControllerIndex", "Controller");
            return View();
        }
    }
}