using CSNMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Npgsql;
using System.Data;

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

        [HttpGet]
        public JsonResult GetUserCredentials(UserEntity obj)
        {
            // Check for empty credentials
            if (string.IsNullOrWhiteSpace(obj.Username) || string.IsNullOrWhiteSpace(obj.Password))
            {
                return Json(new { success = false, message = "Username and password are required." });
            }

            // Connection string to connect to your PostgreSQL database
            string connString = "Host=localhost;Port=5432;Username=postgres;Password=12345678;Database=csn_parents_portal;";
            UserEntity result = null;

            using (var connection = new NpgsqlConnection(connString))
            {
                connection.Open();

                // SQL query to fetch the user by username and password
                string query = "SELECT * FROM UserEntities WHERE Username = @username AND Password = @password";
                using (var command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("username", obj.Username);
                    command.Parameters.AddWithValue("password", obj.Password); // Note: Storing passwords in plain text is not secure!

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            result = new UserEntity
                            {
                                Username = reader["Username"].ToString(),
                                Password = reader["Password"].ToString(),
                                Status = Convert.ToBoolean(reader["Status"]),
                                IsAdmin = Convert.ToBoolean(reader["IsAdmin"])
                            };
                        }
                    }
                }
            }

            if (result != null)
            {
                // Logic to redirect based on user role
                if (result.IsAdmin)
                {
                    // Redirect to Admin Dashboard
                    return Json(new { success = true, redirectUrl = Url.Action("Admin_dashboard", "Admin") });
                }
                else
                {
                    // Redirect to Parent Portal
                    return Json(new { success = true, redirectUrl = Url.Action("Index", "Home") });
                }
            }
            else
            {
                // Return an error if credentials are invalid
                return Json(new { success = false, message = "Invalid username or password." });
            }
        }

    }
}





/* using CSNMVC.Models;
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
*/