using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoDB2.DTOs;
using ProyectoDB2.Entityes;

namespace ProyectoDB2.Controllers
{
    [Authorize(Roles = "1")]
	public class Administrador : Controller
	{
		private readonly ApplicationDbContext _context;

		public Administrador(ApplicationDbContext context)
		{
			_context = context;
		}
		// GET: Administrador
		public ActionResult Index()
		{
			var Admins = _context.Set<AdministradorDTO>().FromSqlRaw("exec sp_ConsultarAdministradores").ToList();
			return View(Admins);
		}

		// GET: Administrador/Details/5
		public ActionResult Details(int id)
		{
			var producto = GetAdministrador(id);
			return View(producto);
		}

		// GET: Administrador/Create
		public ActionResult Create()
		{
			ViewBag.TiposUsuario = TiposUsuario();
			return View();
		}

		// POST: Administrador/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(AdministradorModel administrador)
        {
            try
			{
                _context.Database.ExecuteSqlRaw("exec sp_AgregarAdmin @p0, @p1", administrador.Nombre, administrador.IdUsuario );
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ViewBag.TiposUsuario = TiposUsuario();
                return View();
            }
        }

        // GET: Administrador/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Administrador/Edit/5
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

        // GET: Administrador/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Administrador/Delete/5
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
        private AdministradorDTO GetAdministrador(int id)
        {
            var admin = _context.Set<AdministradorDTO>().FromSqlRaw("exec sp_ConsultarAdministradores @p0", id).ToList();
            return admin[0];
        }
        private List<UsuarioDTO> TiposUsuario()
        {
            var query = _context.Set<UsuarioDTO>().FromSqlRaw("exec sp_ConsultarUsuarios 1").ToList(); //el 1 es para que traiga los usuarios
                                                                                                       // que son de Rol administradores																								
            return query;
        }
    }
}
