using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoDB2.Helpers;
using ProyectoDB2.Models;
using ProyectoDB2.Services;
using System.Data;
using System.Diagnostics;

namespace ProyectoDB2.Controllers
{
    public class HomeController : Controller
    {
        private readonly HomeService _homeService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HomeController(HomeService homeService, IHttpContextAccessor httpContextAccessor)
        {
            _homeService = homeService;
            _httpContextAccessor = httpContextAccessor;
        }


        public IActionResult Index()
        {
            var products = _homeService.GetProducts();
            return View(products);
        }
        [Authorize(Roles = "2")]
        [HttpPost]
        public IActionResult OnPostAddToCart(string referencia, string nombre, decimal precio, int cantidad)
        {
            var cart = HttpContext.Session.Get<ShoppingService>("Items") ?? new ShoppingService();
            cart.AddItem(new CartItem
            {
                Referencia = referencia,
                Nombre = nombre,
                Precio = precio,
                Cantidad = cantidad
            });
            HttpContext.Session.Set("Items", cart);
            return RedirectToAction("CartShopping");
        }
        [Authorize(Roles = "2")]
        public IActionResult CartShopping()
        {
            var username = _httpContextAccessor.HttpContext.Session.GetString("UsernameClient");
            if (string.IsNullOrEmpty(username))
            {
                return RedirectToAction("Login", "Login");
            }
            var cart = HttpContext.Session.Get<ShoppingService>("Items") ?? new ShoppingService();
            var buyModel = new BuyModel
            {
                NumeroDocumentoCliente = 987654321,
                Items = cart.Items
            };
            return View(buyModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}