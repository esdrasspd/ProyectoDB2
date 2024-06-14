using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoDB2.DTOs;

namespace ProyectoDB2.Controllers
{
    [Authorize(Roles = "1")]
    public class ReporteVentaDiariaController : Controller
	{
		private readonly ApplicationDbContext _context;

		public ReporteVentaDiariaController(ApplicationDbContext dbContext)
		{
			_context = dbContext;
		}
		// GET: ReporteVentaDiariaController
		public ActionResult Index()
		{
            ViewBag.TiposProductos = TiposProductos();
            return View();
		}

		// GET: ReporteVentaDiariaController/Details/5
		public ActionResult Details(DateTime inicio,DateTime fin, int tipoProducto)
		{
            var ReporteVentaDiaria = _context.Set<ReporteVentaDiariaDTO>().FromSqlRaw("exec sp_ReporteVentasDiarias @p0, @p1,@p2, ''",inicio,fin,tipoProducto).ToList();
            if (ReporteVentaDiaria == null || !ReporteVentaDiaria.Any())
            {
                // Si no hay resultados, redirigir a otra acción o mostrar un mensaje
                TempData["ErrorMessage"] = "No se encontraron resultados para las fechas y tipo de producto seleccionados.";
                return RedirectToAction("Index");// Redirige a la acción Index o la que consideres adecuada
            }

            // Si hay resultados, enviar los datos a la vista
            return View(ReporteVentaDiaria);
        }

		// GET: ReporteVentaDiariaController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: ReporteVentaDiariaController/Create
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

		// GET: ReporteVentaDiariaController/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: ReporteVentaDiariaController/Edit/5
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

		// GET: ReporteVentaDiariaController/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: ReporteVentaDiariaController/Delete/5
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
        private List<TipoProductoDTO> TiposProductos()
        {
            var query = _context.Set<TipoProductoDTO>().FromSqlRaw("exec sp_ConsultarTipoProducto").ToList();
            return query;
        }
    }

}
