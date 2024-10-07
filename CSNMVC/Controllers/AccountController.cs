using Microsoft.AspNetCore.Mvc;

namespace CSNMVC.Controllers
{
    public class AccountController : Controller
    {

        public IActionResult Enroll()
        {
            return View();
        }

        public IActionResult History()
        {
            return View();
        }

        public IActionResult Request()
        {
            return View();
        }

        public IActionResult Edit()
        {
            return View();
        }
    }
}
