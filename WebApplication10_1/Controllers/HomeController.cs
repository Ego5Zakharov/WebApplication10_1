using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication10_1.Models;
using WebApplication10_1.Data;

namespace WebApplication10_1.Controllers
{
    public class HomeController : Controller
    {
        private readonly LibraryContext _db;
        private readonly UserContext __db;

        public HomeController(LibraryContext libraryContext)
        {
            _db = libraryContext;
        }

        //public HomeController(UserContext userContext)
        //{
        //    __db = userContext;
        //}

        //public IActionResult Index(int a)
        //{
        //    var users = __db.Users.ToList();
        //    return View(users);
        //}


        public IActionResult Index()
        {
            var books = _db.Books.ToList();
            return View(books);
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