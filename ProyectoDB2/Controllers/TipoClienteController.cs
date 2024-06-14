using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoDB2.DTOs;
using System.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ProyectoDB2.Controllers
{
    [Authorize(Roles = "1")]
    public class TipoClienteController : Controller
    {
        private readonly ApplicationDbContext _context;
        public TipoClienteController(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        // GET: TipoClienteController
        public ActionResult Index()
        {
            var query = _context.Set<TipoClienteDTO>().FromSqlRaw("exec sp_ConsultarTipoCliente").ToList();

            return View(query);
        }

        // GET: TipoClienteController/Details/5
        public ActionResult Details(int id)
        {
            var query = _context.Set<TipoClienteDTO>().FromSqlRaw("exec sp_ConsultarTipoCliente @p0", id).ToList();
            return View(query[0]);
        }

        // GET: TipoClienteController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoClienteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            var Nombre = collection["Nombre"];
            try
            {
                _context.Database.ExecuteSqlRaw("exec SP_AgregarTipoCliente @p0", Nombre);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TipoClienteController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TipoClienteController/Edit/5
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

        // GET: TipoClienteController/Delete/5
        public ActionResult Delete(int id)
        {
            var query = _context.Set<TipoClienteDTO>().FromSqlRaw("exec sp_ConsultarTipoCliente @p0", id).ToList();
            return View(query[0]);
        }

        // POST: TipoClienteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            var ids = collection["Id"];
            try
            {
                _context.Database.ExecuteSqlRaw("exec SP_EliminarTipoCliente @p0", id);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex) 
            {
                TempData["Error"] = ex.Message;
                var tipoCliente = _context.Set<TipoClienteDTO>().FromSqlRaw("exec sp_ConsultarTipoCliente @p0", id).ToList();
                return View(tipoCliente);
            }
        }
    }
}
