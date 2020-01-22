using aspShop.DataAccess.InMemory;
using aspShop.Interfaces;
using aspShop.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace aspShop.WebUI.Controllers
{
    public class ProductController : Controller
    {
        IRepository<Product> context;
        List<Category> categories;
        public ProductController(IRepository<Product> context, IRepository<Category> categories)
        {
           this.context = context;
           this.categories = categories.Collection().ToList();
        }
        
        // GET: Product
        public ActionResult Index()
        {
            List<Product> products = context.Collection().ToList();
            return View(products);
        }

        public ActionResult CreateProduct()
        {
            var viewModel = new ProductManager();
            viewModel.Categories = categories;
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult CreateProduct(Product product, HttpPostedFileBase image)
        {
            if(!ModelState.IsValid)
            {
                return View(product);
            }
           if (image != null)
            {
                product.Image = product.Id + Path.GetExtension(image.FileName);
                image.SaveAs(Server.MapPath("//Content//ProductImages//") + product.Image);
            }
           context.Insert(product);
           context.Commit();
           return RedirectToAction("Index");
        }

        public ActionResult Edit(string id)
        {
            Product product = context.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            } else
            {
                return View(product);
            }
        }

        [HttpPost]
        public ActionResult Edit(Product p, string id, HttpPostedFileBase image)
        {
            Product productToEdit = context.Find(id);
            
            if (productToEdit == null)
            {
                return HttpNotFound();
            } else
            {
                if(!ModelState.IsValid)
                {
                    return View(p);
                } else
                {
                    if (image != null)
                    {
                        productToEdit.Image = productToEdit.Id + Path.GetExtension(image.FileName);
                        image.SaveAs(Server.MapPath("//Content//ProductImages//") + productToEdit.Image);
                    }
                    productToEdit.Category = p.Category;
                    productToEdit.Description = p.Description;
                    productToEdit.Name = p.Name;
                    productToEdit.Price = p.Price;
                    context.Commit();
                    return RedirectToAction("Index");
                }
            }
        }
        public ActionResult Delete(string id)
        {
            Product product = context.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(product);
            }
        }
        [HttpPost]
        public ActionResult Delete(Product p, string id)
        {
            context.Delete(id);
            context.Commit();
            return RedirectToAction("Index");
        }
    }
}