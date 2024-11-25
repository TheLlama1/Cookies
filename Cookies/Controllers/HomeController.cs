using Cookies.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Cookies.Controllers
{
    public class HomeController : Controller
    {
        // Method to set the user name in session
        [HttpPost]
        public IActionResult SetUserName(string userName)
        {
            HttpContext.Session.SetString("UserName", userName);
            return RedirectToAction("Index");
        }

        // Method to set user preference in cookies
        [HttpPost]
        public IActionResult SetUserPreference(string preference)
        {
            Response.Cookies.Append("UserPreference", preference, new CookieOptions
            {
                Expires = DateTimeOffset.Now.AddMonths(1)
            });
            return RedirectToAction("Index");
        }

        // Method to check for session and cookie values
        public IActionResult Index()
        {
            var userName = HttpContext.Session.GetString("UserName");
            var userPreference = Request.Cookies["UserPreference"];

            ViewBag.UserName = userName;
            ViewBag.UserPreference = userPreference;

            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}