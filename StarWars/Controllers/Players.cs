using Microsoft.AspNetCore.Mvc;

namespace StarWars.Controllers
{
    public class Players : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
