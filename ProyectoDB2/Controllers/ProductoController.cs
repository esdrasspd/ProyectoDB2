using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoDB2.DTOs;
using ProyectoDB2.Entityes;
using System.Data;
using System.Drawing;

namespace ProyectoDB2.Controllers
{
    [Authorize(Roles = "1")]
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
				_context.Database.ExecuteSqlRaw("exec sp_AgregarProducto @p0, @p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8, @p9, @p10, @p11, @p12", producto.Referencia,
										producto.Nombre, producto.Descripcion, producto.IdTipoProducto, producto.Material, producto.Alto, producto.Ancho, producto.Profundidad, producto.Color, producto.Peso, producto.Foto, producto.Stock, producto.Precio);

				return RedirectToAction(nameof(Index));
			}
			catch (Exception ex)
			{
                TempData["Error"] = ex.Message;
                ViewBag.TiposProductos = TiposProductos();
				return View();

            }
		}

		// GET: Producto/Edit/{ref}
		public ActionResult Edit(string id)
		{
			var producto = GetProducto(id);
			if (producto is null) return NotFound();
			ViewBag.TiposProductos = TiposProductos();
			return View(new Producto
			{
				Referencia = producto.Referencia,
				Nombre = producto.Nombre,
				Descripcion = producto.Descripcion,
				IdTipoProducto = producto.IdTipoProducto,
				Material = producto.Material,
				Alto = producto.Alto,
				Ancho = producto.Ancho,
				Profundidad = producto.Profundidad,
				Color = producto.Color,
				Peso = producto.Peso,
				Precio = producto.Precio,
				Stock = producto.Stock,
			});
		}

		// POST: Producto/Edit/{ref}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(string referencia, Producto producto)
		{
			try
			{
				_context.Database.ExecuteSqlRaw("exec sp_ActualizarProducto @p0, @p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8, @p9, @p10, @p11, @p12", referencia, producto.Nombre, producto.Descripcion, producto.IdTipoProducto, producto.Material, producto.Alto, producto.Ancho, producto.Profundidad, producto.Color, producto.Peso, producto.Foto, producto.Stock, producto.Precio);
				return RedirectToAction(nameof(Index));
			}
			catch(Exception ex)
			{
				ViewBag.TiposProductos = TiposProductos();
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
		public ActionResult Delete(string referencia, IFormCollection collection)
		{
			try
			{
				_context.Database.ExecuteSqlRaw("exec sp_EliminarProducto @p0", referencia);
				return RedirectToAction(nameof(Index));
			}
			catch (Exception ex)
			{
				TempData["Error"] = ex.Message;
				var producto = GetProducto(referencia);
				return View(producto);
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

		private Producto? GetModeloProducto(string id)
		{
			var query = _context.Set<Producto>().FromSqlRaw("SELECT * FROM PRODUCTO WHERE REFERENCIA = @p0", id).ToList();

			return query.FirstOrDefault();
		}
	}
}
