using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoDB2.Models;
using ProyectoDB2.Services;
using System.Security.Claims;

namespace ProyectoDB2.Controllers
{
    public class LoginController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly LoginService _loginService;

        public LoginController(LoginService loginService, IHttpContextAccessor httpContextAccessor)
        {
            _loginService = loginService;
            _httpContextAccessor = httpContextAccessor;
        }

        // GET: LoginController
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            try
            {
                var (success, roleId) = _loginService.LoginUser(model.Username, model.Password);

                if(success)
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
                } else
                {
                    ModelState.AddModelError(string.Empty, "Usuario o contraseña incorrectos");
                }

                
            } catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, "Error al intentar iniciar sesión" + e.Message);
                return View(model);
            }
            return View(model);
            
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            _httpContextAccessor.HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

    }
}
