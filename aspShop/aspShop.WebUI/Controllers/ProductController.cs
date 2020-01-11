﻿using aspShop.DataAccess.InMemory;
using aspShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace aspShop.WebUI.Controllers
{
    public class ProductController : Controller
    {
        ProductRepository context;
        public ProductController()
        {
           context = new ProductRepository();
        }
        
        // GET: Product
        public ActionResult Index()
        {
            List<Product> products = context.Collection().ToList();
            return View(products);
        }

        public ActionResult CreateProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateProduct(Product product)
        {
            if(!ModelState.IsValid)
            {
                return View(product);
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
        public ActionResult Edit(Product p, string id)
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
                    productToEdit.Category = p.Category;
                    productToEdit.Description = p.Description;
                    productToEdit.Image = p.Image;
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