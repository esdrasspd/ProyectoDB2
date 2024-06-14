using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoDB2.DTOs;

namespace ProyectoDB2.Controllers
{
    [Authorize(Roles = "1")]
    public class ReporteCompraPorClienteController : Controller
    {
        private readonly ReportsDbContext _context;

        public ReporteCompraPorClienteController(ReportsDbContext dbContext)
        {
            _context = dbContext;
        }
        // GET: ReporteCompraPorClienteController
        public ActionResult Index()
        {
            ViewBag.ListadoClientes = ListadoClientes();
            return View();
        }

        // GET: ReporteCompraPorClienteController/Details/5
        public ActionResult Details(int id)
        {
            var Reporte = _context.Set<ReporteCompraPorClienteDTO>().FromSqlRaw("exec sp_ReporteComprasRealizadasPorCliente @p0", id).ToList();
            if (Reporte == null || !Reporte.Any())
            {
                // Si no hay resultados, redirigir a otra acción o mostrar un mensaje
                TempData["ErrorMessage"] = "No se encontraron resultados para las fechas y tipo de producto seleccionados.";
                return RedirectToAction("Index");// Redirige a la acción Index o la que consideres adecuada
            }

            // Si hay resultados, enviar los datos a la vista
            return View(Reporte);
        }

        // GET: ReporteCompraPorClienteController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ReporteCompraPorClienteController/Create
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

        // GET: ReporteCompraPorClienteController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ReporteCompraPorClienteController/Edit/5
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

        // GET: ReporteCompraPorClienteController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ReporteCompraPorClienteController/Delete/5
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
        private List<ClienteDTO> ListadoClientes()
        {
            var query = _context.Set<ClienteDTO>().FromSqlRaw("exec sp_ConsultarCliente").ToList();
            return query;
        }
    }
}
