using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication10_1.Data;
using WebApplication10_1.Models;

namespace WebApplication10_1.Controllers
{
    public class LibraryController : Controller
    {
        private readonly LibraryContext _db;

        public LibraryController(LibraryContext context)
        {
            _db = context;
        }

        public IActionResult Index()
        {
            var books = _db.Books.ToList();
            return View(books);
        }

        [HttpGet]
        public IActionResult Buy(int id)
        {
            ViewBag.BookId = id;
            return View();
        }

        [HttpPost]
        public string Buy(Order order)
        {
            _db.Orders.Add(order);
            _db.SaveChanges();
            return $"Thanks for purchasing {order.User}";
        }

        [HttpGet]
        public ActionResult UpdateBook(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Book book = _db.Books.Find(id);
            if (book != null)
            {
                return View(book);
            }
            return HttpNotFound();
        }

        private ActionResult HttpNotFound()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public ActionResult UpdateBook(Book book)
        {
            _db.Entry(book).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Create(int id)
        {
            ViewBag.Id = id;
            return View();
        }

        [HttpPost]
        public ActionResult Create(Book book)
        {
            _db.Books.Add(book);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id, double nullable)
        {
            ViewBag.BookId = id;
            return View();
        }


        [HttpPost, ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            Book b = _db.Books.Find(id);
            if (b == null)
            {
                return null;
            }
            _db.Books.Remove(b);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
