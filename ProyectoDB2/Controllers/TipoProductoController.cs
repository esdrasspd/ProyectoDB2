using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ProyectoDB2.DTOs;
using System.Data;

namespace ProyectoDB2.Controllers
{
    public class TipoProductoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TipoProductoController(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        // GET: TipoProductoController
        public ActionResult Index()
        {
            var query = _context.Set<TipoProductoDTO>().FromSqlRaw("exec sp_ConsultarTipoProducto").ToList();
            return View(query);
        }

        // GET: TipoProductoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TipoProductoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoProductoController/Create
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

        // GET: TipoProductoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TipoProductoController/Edit/5
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

        // GET: TipoProductoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TipoProductoController/Delete/5
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
