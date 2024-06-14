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

        public BuyController(BuyServices buyServices, IHttpContextAccessor httpContextAccessor)
        {
            _buyServices = buyServices;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpPost]

        public IActionResult BuyProcess(BuyModel request)
        {
            request.NumeroDocumentoCliente = 987654321;
            
            foreach (var item in request.Items)
            {
                _buyServices.BuyProcess(request.NumeroDocumentoCliente, item.Referencia, item.Precio, item.Cantidad);
            }
            return RedirectToAction("Index", "Home");

        }

    }
}
