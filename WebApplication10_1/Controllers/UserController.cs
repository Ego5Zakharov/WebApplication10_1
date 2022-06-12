using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication10_1.Data;
using WebApplication10_1.Models;

namespace WebApplication10_1.Controllers
{
    public class UserController : Controller
    {
        private readonly UserContext _db;

        public UserController(UserContext context)
        {
            _db = context;
        }

        public IActionResult Index()
        {
            var users = _db.Users.ToList();
            return View(users);
        }

        [HttpGet]
        public ActionResult UpdateUser(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            User user = _db.Users.Find(id);
            if (user != null)
            {
                return View(user);
            }
            return HttpNotFound();
        }

        private ActionResult HttpNotFound()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public ActionResult UpdateUser(User user)
        {
            _db.Entry(user).State = EntityState.Modified;
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
        public ActionResult Create(User user)
        {
            _db.Users.Add(user);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id, double nullable)
        {
            ViewBag.Id = id;
            return View();
        }


        [HttpPost, ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            User u = _db.Users.Find(id);
            if (u == null)
            {
                return null;
            }
            _db.Users.Remove(u);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
