using Microsoft.AspNetCore.Mvc;

namespace Flora.Controllers
{
    public class AuthController : Controller
    {
        // Login Page
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // Login Submit
        [HttpPost]
        public IActionResult Login(string Email, string Password)
        {
            // Temporary login validation
            if (Email == "test@gmail.com" && Password == "123456")
            {
                return RedirectToAction("AgeGroup", "Onboarding");
            }

            ViewBag.Error = "Invalid Email or Password";
            return View();
        }

        // Register Page
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // Register Submit
        [HttpPost]
        public IActionResult Register(string Name, string Email, string Password)
        {
            // Normally database save hota hai
            return RedirectToAction("Login");
        }

        // Logout
        public IActionResult Logout()
        {
            return RedirectToAction("Login");
        }
    }
}