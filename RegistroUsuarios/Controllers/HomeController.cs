using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RegistroUsuarios.Models;
using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore; 

namespace RegistroUsuarios.Controllers
{
    [Authorize]

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ClaimsPrincipal claimuser = HttpContext.User;
            string nombreUsuario = "";

            if (claimuser.Identity.IsAuthenticated)
            {
                nombreUsuario= claimuser.Claims.Where(c=> c.Type == ClaimTypes.Name)
                    .Select(c => c.Value).SingleOrDefault();
            }

            ViewData["nombreUsuario"] = nombreUsuario;

            return View();

            
   
        }


        public async Task <IActionResult> CerrarSesion()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("IniciarSesion", "Inicio");
        }
    }
}