using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoDB2.DTOs;
using ProyectoDB2.Entityes;
using System.Drawing;

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
			ViewBag.TiposProductos = TiposProductos();
			return View();
		}

		// POST: Producto/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(Producto producto)
		{
			try
			{
				_context.Database.ExecuteSqlRaw("exec sp_AgregarProducto @p0, @p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8, @p9, @p10, @p11", producto.Referencia,
										producto.Nombre, producto.Descripcion, producto.IdTipoProducto, producto.Material, producto.Alto, producto.Ancho, producto.Profundidad, producto.Color, producto.Peso, producto.Foto, producto.Stock, producto.Precio);

				return RedirectToAction(nameof(Index));
			}
			catch(Exception ex)
			{
				ViewBag.TiposProductos = TiposProductos();
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

		private List<TipoProductoDTO> TiposProductos()
		{
			var query = _context.Set<TipoProductoDTO>().FromSqlRaw("exec sp_ConsultarTipoProducto").ToList();
			return query;
		}
	}
}
