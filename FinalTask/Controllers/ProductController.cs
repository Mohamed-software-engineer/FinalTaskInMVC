using FinalTask.Context;
using FinalTask.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace FinalTask.Controllers
{
    public class ProductController : Controller
    {
        FinalTaskContext context = new FinalTaskContext();

        [HttpGet]
        public IActionResult Index()
        {
            var products = context.Products.Include(p => p.Category);
            return View(products);
        }

        [HttpGet]
        public IActionResult ViewDetails(int id)
        {
            var product = context.Products.Include(p => p.Category).FirstOrDefault(p => p.ProductId == id);
            return View(product);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(context.Categories, "CategoryId", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            ModelState.Remove("Category");
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "All Fields Is Reqired");
                ViewBag.Categories = new SelectList(context.Categories, "CategoryId", "Name");
                return View();
            }

            context.Products.Add(product);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = context.Products.Include(p => p.Category).FirstOrDefault(p => p.ProductId == id);
            if (product == null)
            {
                return RedirectToAction("Index");
            }
            ViewBag.Categories = new SelectList(context.Categories, "CategoryId", "Name");
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            ModelState.Remove("Category");
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "All Fields Is Reqired");
                ViewBag.Categories = new SelectList(context.Categories, "CategoryId", "Name");
                return View();
            }

            context.Products.Update(product);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return RedirectToAction("Index");
            }
            var product = context.Products.Include(p => p.Category).FirstOrDefault(p => p.ProductId == id);
            if (product == null)
            {
                return RedirectToAction("Index");
            }
            return View(product);
        }
        [HttpPost]
        public IActionResult Delete(int id, string confirm)
        {
            if (confirm == "Yes")
            {
                var product = context.Products.Include(p => p.Category).FirstOrDefault(p => p.ProductId == id);
                if (product == null)
                {
                    return RedirectToAction("Index");
                }
                context.Products.Remove(product);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
