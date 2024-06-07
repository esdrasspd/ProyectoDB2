using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoDB2.Models;

namespace ProyectoDB2.Controllers
{
    public class AdminController : Controller
    {
        private static List<AdminModel> admins = new List<AdminModel>
        {
            new AdminModel { Id = 1, Name = "Admin1" },
            new AdminModel { Id = 2, Name = "Admin2" }
        };

        // GET: AdminController
        public ActionResult Index()
        {
            return View(admins);
        }

        // GET: AdminController/Details/5
        public ActionResult Details(int id)
        {
            var admin = admins.Find(a => a.Id == id);
            return View(admin);
        }

        // GET: AdminController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AdminModel admin)
        {
            try
            {
                admin.Id = admins.Count + 1; // Simple Id assignment for demonstration
                admins.Add(admin);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminController/Edit/5
        public ActionResult Edit(int id)
        {
            var admin = admins.Find(a => a.Id == id);
            return View(admin);
        }

        // POST: AdminController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AdminModel admin)
        {
            try
            {
                var existingAdmin = admins.Find(a => a.Id == id);
                existingAdmin.Name = admin.Name;
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminController/Delete/5
        public ActionResult Delete(int id)
        {
            var admin = admins.Find(a => a.Id == id);
            return View(admin);
        }

        // POST: AdminController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]



        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var admin = admins.Find(a => a.Id == id);
                bool v = admins.Remove(item: admin);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

