using Microsoft.AspNetCore.Mvc;
using StarWars.Models;
using System.Diagnostics;

namespace StarWars.Controllers
{
    public class PlayerController : Controller
    {
        public StarWarsDb Ctx { get; set; }
        public PlayerController(StarWarsDb ctx)
        {
            this.Ctx = ctx;
        }
        public IActionResult Index(string id, string name, string description)
        {
            if (!string.IsNullOrEmpty(id))
            {
                int Id = 0;
                if (int.TryParse(id, out Id))
                {
                    Ctx.Players.Add(new Player { Id = Id, Name = name, Description = description });
                    Ctx.SaveChanges();
                }
            }
            return View();
        }
        
    }
}
