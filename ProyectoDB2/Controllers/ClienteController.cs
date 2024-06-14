using MessagePack;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoDB2.DTOs;
using System.Runtime.ConstrainedExecution;
using System.Security.Principal;

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
			ViewBag.TiposCliente = ObtieneTiposCliente();
			ViewBag.Usuarios = Usuarios();
			return View();
		}

		// POST: Cliente/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(ClienteDTO cliente)
		{
			try
			{
				_context.Database.ExecuteSqlRaw("exec SP_AgregarCliente @p0, @p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8, @p9, @p10, @p11, @p12, @p13",
										cliente.TipoDocumento, cliente.NumeroDocumento, cliente.NombreCompleto, cliente.TelefonoResidencia, cliente.TelefonoCelular, cliente.Direccion, cliente.CiudadResidencia, cliente.Departamento, cliente.Pais, cliente.Profesion, cliente.Email, cliente.IdTipoCliente, cliente.IdUsuario, cliente.Nit);

				return RedirectToAction(nameof(Index));
			}
			catch (Exception ex)
			{
				TempData["Error"] = ex.Message;
				ViewBag.TiposCliente = ObtieneTiposCliente();
				ViewBag.Usuarios = Usuarios();
				return View();
			}
		}

		// GET: Cliente/Edit/5
		public ActionResult Edit(int id)
		{
			var cliente = GetCliente(id);
			if (cliente is null) return NotFound();
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
			var cliente = GetCliente(id);
			if (cliente is null) return NotFound();
			return View(cliente);
		}

		// POST: Cliente/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, IFormCollection collection)
		{
			try
			{
				_context.Database.ExecuteSqlRaw("exec SP_EliminarCliente @p0", id);
				return RedirectToAction(nameof(Index));
			}
			catch (Exception ex)
			{
				TempData["Error"] = ex.Message;
				var cliente = GetCliente(id);
				return View(cliente);
			}
		}

		private List<TipoClienteDTO> ObtieneTiposCliente()
		{
			var query = _context.Set<TipoClienteDTO>().FromSqlRaw("exec sp_ConsultarTipoCliente").ToList();
			return query;
		}

		private List<UsuarioDTO> Usuarios()
		{
			var query = _context.Set<UsuarioDTO>().FromSqlRaw("exec sp_ConsultarUsuarios @p0", 3).ToList();
			return query;
		}

		private ClienteDTO? GetCliente(int numeroIdentificacion)
		{
			var cliente = _context.Set<ClienteDTO>().FromSqlRaw("EXEC SP_ConsultarCliente @p0", numeroIdentificacion).ToList().FirstOrDefault();
			return cliente;
		}
	}
}
