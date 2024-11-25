using MaxCinema.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Drawing.Text;
using System.Security.Cryptography;
using System.Text;

namespace MaxCinema.Controllers
{
    public class AdminController : Controller
    {
        private readonly string _passwordHash;

        public AdminController(IConfiguration configuration)
        {
            _passwordHash = configuration["AdminSettings:PasswordHash"];
        }
        public IActionResult Index()
        {
            //if (HttpContext.Session.Get<string>("IsAdmin") != "true")
            //{
            //    return RedirectToAction("Login");
            //}
            return View();
        }

        public IActionResult Login() 
        { 
            return View(); 
        }
        [HttpPost]
        public IActionResult Login(string password)
        {
            if (VerifyPassword(password, _passwordHash))
            {
                HttpContext.Session.Set<string>("IsAdmin","true");
                return RedirectToAction("Index", "Order");
            }

            ViewBag.Error = "Invalid password.";

            return View();
        }

        private bool VerifyPassword(string password, string storedHash) 
        {
            //Compute the hash of the entered password
            using (var sha256 = SHA256.Create())
            {
                var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                var hash = Convert.ToBase64String(bytes);
                return hash == storedHash;
            }
        }

    }
}
