using Microsoft.AspNetCore.Mvc;

namespace CSNMVC.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Admin_dashboard()
        {
            return View();
        }
    }
}
