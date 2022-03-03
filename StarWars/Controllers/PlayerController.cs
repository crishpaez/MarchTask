using Microsoft.AspNetCore.Mvc;
using StarWars.Models;

namespace StarWars.Controllers
{
    public class PlayerController : Controller
    {        
        public IActionResult Index()
        {
            var db = new StarWarsDb();
            var players = db.Players.ToList();
            return View();
        }
    }
}
