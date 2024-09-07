using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OturumAc.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            TempData["info"] = $"Tekrar Hoşgeldiniz, {DateTime.Now.ToShortTimeString()}";
            return View();
        }
    }
}
