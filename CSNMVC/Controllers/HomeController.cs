using CSNMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CSNMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }


        public IActionResult Login()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        /// <summary>
        /// Created by Lowie, login server-side validations happen here
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetUserCredentials(UserEntity obj)
        {
            UserEntity result = new UserEntity();

            // logic dito na if wala sa db yung username pass, dapat di makakalogin, show ng error message sa front-end
            // if meron, tuloy sa dashboard page
            

            return Json(result); 
        }
    }
}
