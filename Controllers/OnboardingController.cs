using Microsoft.AspNetCore.Mvc;

namespace Flora.Controllers
{
    public class OnboardingController : Controller
    {

        // STEP 1
        [HttpGet]
        public IActionResult AgeGroup()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AgeGroup(string ageGroup)
        {
            TempData["AgeGroup"] = ageGroup;
            return RedirectToAction("LastPeriod");
        }


        // STEP 2
        [HttpGet]
        public IActionResult LastPeriod()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LastPeriod(DateTime lastPeriod)
        {
            TempData["LastPeriod"] = lastPeriod;
            return RedirectToAction("CycleLength");
        }


        // STEP 3
        [HttpGet]
        public IActionResult CycleLength()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CycleLength(int cycleLength)
        {
            TempData["CycleLength"] = cycleLength;

            return RedirectToAction("Dashboard", "User");
        }
    }
}
