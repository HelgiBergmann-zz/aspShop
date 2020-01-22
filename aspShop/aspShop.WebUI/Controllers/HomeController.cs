using aspShop.Interfaces;
using aspShop.Models;
using aspShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace aspShop.WebUI.Controllers
{
    public class HomeController : Controller
    {
        IRepository<Product> context;
        List<Category> categories;
        public HomeController(IRepository<Product> context, IRepository<Category> categories)
        {
            this.context = context;
            this.categories = categories.Collection().ToList();
        }
        public ActionResult Index(string category = null)
        {
            List<Product> products;
            if (category == null)
            {
                products = context.Collection().ToList();
            } else
            {
                products = context.Collection().Where(item => item.Category == category).ToList();
            }
            var model = new ProductList();
            model.Products = products;
            model.Categories = this.categories;
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}