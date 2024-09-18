using FinalTask.Context;
using FinalTask.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FinalTask.Controllers
{
    public class UserController : Controller
    {
        FinalTaskContext context = new FinalTaskContext();

        [HttpGet]
        public IActionResult Index()
        {
            var users = context.Users;
            return View(users);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "All Fields Is Reqired");
                return View();
            }

            context.Users.Add(user);
            context.SaveChanges();

            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var user = context.Users.FirstOrDefault(u => u.Email == email && u.Password == password);

            if (user != null)
            {
                return RedirectToAction("Index", "Product");
            }

            ModelState.AddModelError("Email", "Invalid Email or Password.");
            ModelState.AddModelError("Password", "Invalid Email or Password.");

            return View();
        }
    }

}
