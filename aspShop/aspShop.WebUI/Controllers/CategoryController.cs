using aspShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using aspShop.DataAccess.InMemory;
using System.Web.Mvc;
using aspShop.Interfaces;

namespace aspShop.WebUI.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        IRepository<Category> context;
        public CategoryController(IRepository<Category> context)
        {
            this.context = context;
        }

        // GET: Product
        public ActionResult Index()
        {
            List<Category> categories = context.Collection().ToList();
            return View(categories);
        }

        public ActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateCategory(Category c)
        {
            if (!ModelState.IsValid)
            {
                return View(c);
            }
            context.Insert(c);
            context.Commit();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(string id)
        {
            Category c = context.Find(id);
            if (c == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(c);
            }
        }

        [HttpPost]
        public ActionResult Edit(Category c, string id)
        {
            Category cToEdit = context.Find(id);

            if (c == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(c);
                }
                else
                {
                    cToEdit.Name = c.Name;
                    context.Commit();
                    return RedirectToAction("Index");
                }
            }
        }
        public ActionResult Delete(string id)
        {
            Category c = context.Find(id);
            if (c == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(c);
            }
        }
        [HttpPost]
        public ActionResult Delete(Category c, string id)
        {
            context.Delete(id);
            context.Commit();
            return RedirectToAction("Index");
        }
    }
}