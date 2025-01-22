using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
namespace CheckListAI.Web.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {

            HttpContext.Session.SetString("username", username);

            string sessionId = Guid.NewGuid().ToString();

            // Crear los claims del usuario
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, username),
                new Claim("SessionId",sessionId)
            };

            var identity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            var authProperties = new AuthenticationProperties
            {
                IsPersistent = false, // la sesion termina al cerrar el navegador
                AllowRefresh = true,
                RedirectUri = "/Home/Index"
            };

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, authProperties);

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Clear();    
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
