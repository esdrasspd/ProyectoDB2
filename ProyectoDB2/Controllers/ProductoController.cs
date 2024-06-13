using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoDB2.DTOs;

namespace ProyectoDB2.Controllers
{
	public class ProductoController : Controller
	{
		private readonly ApplicationDbContext _context;

		public ProductoController(ApplicationDbContext context)
		{
			_context = context;
		}

		// GET: Producto
		public ActionResult Index()
		{
			var productos = _context.Set<ProductoDTO>().FromSqlRaw("exec sp_ConsultarProductos").ToList();
			return View(productos);
		}

		// GET: Producto/Details/{ref}
		public ActionResult Details(string id)
		{
			var producto = GetProducto(id);
			return View(producto);
		}

		// GET: Producto/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: Producto/Create
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

		// GET: Producto/Edit/{ref}
		public ActionResult Edit(string id)
		{
			var producto = GetProducto(id);
			return View(producto);
		}

		// POST: Producto/Edit/{ref}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(string id, IFormCollection collection)
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

		// GET: Producto/Delete/{ref}
		public ActionResult Delete(string id)
		{
			var producto = GetProducto(id);
			return View(producto);
		}

		// POST: Producto/Delete/{ref}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(string id, IFormCollection collection)
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

		private ProductoDTO GetProducto(string id)
		{
			var producto = _context.Set<ProductoDTO>().FromSqlRaw("exec sp_ConsultarProductos @p0", id).ToList();
			return producto[0];
		}
	}
}
