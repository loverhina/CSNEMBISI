using CSNMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Identity;

namespace CSNMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly YourDbContext _context; // Assuming you have a DbContext

        public HomeController(ILogger<HomeController> logger, YourDbContext context)
        {
            _logger = logger;
            _context = context;
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
        /// Handle login POST requests for user credentials
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult GetUserCredentials(UserEntity obj)
        {
            // Log the username for debugging purposes
            _logger.LogInformation($"Username: {obj.Username}, Password: {obj.Password}");

            // Retrieve user from the database
            var user = _context.UserEntities.FirstOrDefault(u => u.Username == obj.Username);

            if (user == null)
            {
                // User not found
                ViewBag.Message = "Invalid username or password.";
                return View("Login");
            }

            // Verify the password
            var passwordHasher = new PasswordHasher<UserEntity>();
            var result = passwordHasher.VerifyHashedPassword(user, user.Password, obj.Password);

            if (result == PasswordVerificationResult.Success)
            {
                // Check if the user is an admin
                if (user.IsAdmin)
                {
                    // Redirect to admin dashboard
                    return RedirectToAction("Admin_dashboard", "Admin");
                }
                else
                {
                    // If the user is not an admin, show validation message
                    return View("Login");
                }
            }
            else
            {
                // If credentials are invalid, return to the login page with an error message
                ViewBag.Message = "Invalid username or password.";
                return View("Login");
            }
        }
    }
}
