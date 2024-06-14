using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using ProyectoDB2.Models;
using ProyectoDB2.Services;
using System.Security.Claims;

namespace ProyectoDB2.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly RegisterService _registerService;
        private readonly LoginService _loginService;

        public RegisterController(RegisterService registerService, IHttpContextAccessor httpContextAccessor, LoginService loginService)
        {
            _registerService = registerService;
            _httpContextAccessor = httpContextAccessor;
            _loginService = loginService;
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterModel model)
        {
            try
            {
                _registerService.RegisterUser(model.NumeroDocumento, model.TipoDocumento, model.NombreCompleto, model.TelefonoResidencia, model.TelefonoCelular, model.Direccion, model.CiudadResidencia, model.Departamento, model.Pais, model.Profesion, model.Email, model.IdTipoCliente, model.Username, model.Password, 2);
                var (success, roleId) = _loginService.LoginUser(model.Username, model.Password);

                if (success)
                {
                    if (roleId.HasValue)
                    {
                        var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name, model.Username),
                            new Claim(ClaimTypes.Role, roleId.ToString())
                        };
                        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                        if (roleId == 1)
                        {
                            _httpContextAccessor.HttpContext.Session.SetString("UsernameAdmin", model.Username);
                            return RedirectToAction("Index", "Admin");
                        }
                        else if (roleId == 2)
                        {
                            _httpContextAccessor.HttpContext.Session.SetString("UsernameClient", model.Username);
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            ModelState.AddModelError(string.Empty, "Rol no válido");
                        } 
                    }
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                
            }
            return View(model);
        }
    }
}
