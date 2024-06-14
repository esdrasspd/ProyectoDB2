using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoDB2.DTOs;

namespace ProyectoDB2.Controllers
{
    [Authorize(Roles = "1")]
    public class ReporteProductoMasVendidoController : Controller
    {
       
            private readonly ApplicationDbContext _context;

            public ReporteProductoMasVendidoController(ApplicationDbContext dbContext)
            {
                _context = dbContext;
            }
            // GET: ReporteProductoMasVendidoController
            public ActionResult Index()
            {
                return View();
            }

            // GET: ReporteProductoMasVendidoController/Details/5
            public ActionResult Details(DateTime inicio, DateTime fin)
            {
                var Reporte = _context.Set<ReporteProductoMasVendidoDTO>().FromSqlRaw("exec sp_ReporteProdcutoMasVendido @p0, @p1", inicio, fin).ToList();
                if (Reporte == null || !Reporte.Any())
                {
                    // Si no hay resultados, redirigir a otra acción o mostrar un mensaje
                    TempData["ErrorMessage"] = "No se encontraron resultados para las fechas seleccionadas.";
                    return RedirectToAction("Index");// Redirige a la acción Index o la que consideres adecuada
                }

                // Si hay resultados, enviar los datos a la vista
                return View(Reporte);
            }

            // GET: ReporteProductoMasVendidoController/Create
            public ActionResult Create()
            {
                return View();
            }

            // POST: ReporteProductoMasVendidoController/Create
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

            // GET: ReporteProductoMasVendidoController/Edit/5
            public ActionResult Edit(int id)
            {
                return View();
            }

            // POST: ReporteProductoMasVendidoController/Edit/5
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

            // GET: ReporteProductoMasVendidoController/Delete/5
            public ActionResult Delete(int id)
            {
                return View();
            }

            // POST: ReporteProductoMasVendidoController/Delete/5
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
