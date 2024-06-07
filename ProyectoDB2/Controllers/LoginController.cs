using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoDB2.Models;
using ProyectoDB2.Services;

namespace ProyectoDB2.Controllers
{
    public class LoginController : Controller
    {
        private readonly LoginService _loginService;

        public LoginController(LoginService loginService)
        {
            _loginService = loginService;
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
                        if (roleId == 1)
                        {
                            HttpContext.Session.SetString("Username", model.Username);
                            return RedirectToAction("Index", "Home");
                        }
                        else if (roleId == 2)
                        {
                            HttpContext.Session.SetString("Username", model.Username);
                            return RedirectToAction("Index", "Vendedor");
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

    }
}
