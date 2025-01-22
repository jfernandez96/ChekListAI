using Microsoft.AspNetCore.Mvc;

namespace CheckListAI.Web.Areas.Configuracion.Controllers
{
    [Area("Configuracion")]
    public class UsuarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
