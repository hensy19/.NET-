using Microsoft.AspNetCore.Mvc;

namespace FLORA.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Dashboard() => View();
        public IActionResult LogPeriod() => View();
        public IActionResult LogSymptoms() => View();
        public IActionResult Calendar() => View();
        public IActionResult Tips() => View();
        public IActionResult Profile() => View();
        public IActionResult History() => View();
    }
}
