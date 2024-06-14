using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoDB2.DTOs;

namespace ProyectoDB2.Controllers
{
    [Authorize (Roles ="1")]
    public class ReporteCierreCajaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReporteCierreCajaController(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }
        // GET: ReporteCierreCajaController
        public ActionResult Index()
        {
            var Reporte = _context.Set<ReporteCierreCajaDTO>().FromSqlRaw("exec sp_ReporteCierreCaja").ToList();
            return View(Reporte);
        }

        // GET: ReporteCierreCajaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ReporteCierreCajaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ReporteCierreCajaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ReporteCierreCajaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ReporteCierreCajaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ReporteCierreCajaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ReporteCierreCajaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
