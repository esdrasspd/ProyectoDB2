using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoDB2.Models;
using ProyectoDB2.Services;
using System.Data;

namespace ProyectoDB2.Controllers
{
    [Authorize(Roles = "2")]
    public class BuyController : Controller
    {
        private readonly BuyServices _buyServices;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ApplicationDbContext _context;

        public BuyController(BuyServices buyServices, IHttpContextAccessor httpContextAccessor, ApplicationDbContext context)
        {
            _buyServices = buyServices;
            _httpContextAccessor = httpContextAccessor;
            _context = context;
        }

        [HttpPost]

        public IActionResult BuyProcess(BuyModel request)
        {
            var username = _httpContextAccessor.HttpContext.Session.GetString("UsernameClient");
            var user = _context.Usuario.FirstOrDefault(u => u.Username == username);
            var cliente = _context.Cliente.FirstOrDefault(c => c.IdUsuario == user.Id);
            request.NumeroDocumentoCliente = cliente.NumeroDocumento;
            bool okBuy = ProcessBuy(request);
            return Json(new { success = okBuy });

        }

        private bool ProcessBuy(BuyModel request)
        {
            foreach (var item in request.Items)
            {
                _buyServices.BuyProcess(request.NumeroDocumentoCliente, item.Referencia, item.Precio, item.Cantidad);
            }
            return true;
        }

    }
}
