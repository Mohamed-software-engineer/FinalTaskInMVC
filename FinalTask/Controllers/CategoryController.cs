using FinalTask.Context;
using FinalTask.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FinalTask.Controllers
{
    public class CategoryController : Controller
    {
        FinalTaskContext context = new FinalTaskContext();

        [HttpGet]
        public IActionResult Index()
        {
            var categories = context.Categories;
            return View(categories);
        }

        [HttpGet]
        public IActionResult ViewDetails(int id)
        {
            var categories = context.Categories.FirstOrDefault(c => c.CategoryId == id);
            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "All Fields Is Reqired");
                return View();
            }

            context.Categories.Add(category);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var category = context.Categories.FirstOrDefault(c => c.CategoryId == id);
            if (category == null)
            {
                return RedirectToAction("Index");
            }
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "All Fields Is Reqired");
                return View();
            }

            context.Categories.Update(category);
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
            var category = context.Categories.FirstOrDefault(c => c.CategoryId == id);
            if (category == null)
            {
                return RedirectToAction("Index");
            }
            return View(category);
        }
        [HttpPost]
        public IActionResult Delete(int id, string confirm)
        {
            if (confirm == "Yes")
            {
                var category = context.Categories.FirstOrDefault(c => c.CategoryId == id);
                if (category == null)
                {
                    return RedirectToAction("Index");
                }
                context.Categories.Remove(category);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
