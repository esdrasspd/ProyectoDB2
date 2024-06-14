using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoDB2.DTOs;

namespace ProyectoDB2.Controllers
{
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
			var ReporteVentaDiaria = _context.Set< ReporteVentaDiariaDTO>().FromSqlRaw("exec sp_ReporteVentasDiarias").ToList();
			return View(ReporteVentaDiaria);


		}

		// GET: ReporteVentaDiariaController/Details/5
		public ActionResult Details(int id)
		{
			return View();
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
	}
}
