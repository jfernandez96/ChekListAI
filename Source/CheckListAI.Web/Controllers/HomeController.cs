using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CheckListAI.Web.Controllers
{

    [Authorize]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            string user = HttpContext.Session.GetString("username");
            return View();
        }
    }
}
