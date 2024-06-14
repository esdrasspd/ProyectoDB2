using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoDB2.DTOs;

namespace ProyectoDB2.Controllers
{
	public class ClienteController : Controller
	{
		private readonly ApplicationDbContext _context;

		public ClienteController(ApplicationDbContext context)
		{
			_context = context;
		}

		// GET: Cliente
		public ActionResult Index()
		{
			var clientes = _context.Set<ClienteDTO>().FromSqlRaw("EXEC SP_ConsultarCliente").ToList();
			return View(clientes);
		}

		// GET: Cliente/Details/5
		public ActionResult Details(int id)
		{
            var cliente = _context.Set<ClienteDTO>().FromSqlRaw("EXEC SP_ConsultarCliente @p0", id).ToList().FirstOrDefault();
			if (cliente == null) return NotFound();
            return View(cliente);
		}

		// GET: Cliente/Create
		public ActionResult Create()
		{
			// 3 obtiene todos los tipos de usuarios de clientes
			return View();
		}

		// POST: Cliente/Create
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

		// GET: Cliente/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: Cliente/Edit/5
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

		// GET: Cliente/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: Cliente/Delete/5
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
