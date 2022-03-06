using Microsoft.AspNetCore.Mvc;
using StarWars.Models;
using System.Diagnostics;

namespace StarWars.Controllers
{
    public class PlayerController : Controller
    {
        public StarWarsDb ctx { get; set; }
        public PlayerController(StarWarsDb ctx)
        {
            this.ctx = ctx;
        }
        public IActionResult PlayerList(string name)
        {
            var model = new PlayersListModel();
            model.PlayersList = ctx.Players.ToList();
            return View(model);
        }
        [HttpPost]
        public IActionResult Update(Player player)
        {
            ctx.Attach(player);
            ctx.Entry(player).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            ctx.SaveChanges();
            var model = ctx.Players.Find(player.Id);
            return View(player);
        }
        public IActionResult Update(string id)
        {
            int Id = 0;
            int.TryParse(id, out Id);
            var model = ctx.Players.Find(Id);
            return View(model);
        }
        public IActionResult Index(string id, string name, string description)
        {
            if (!string.IsNullOrEmpty(id))
            {
                int Id = 0;
                if (int.TryParse(id, out Id))
                {
                    ctx.Players.Add(new Player { Id = Id, Name = name, Description = description });
                    ctx.SaveChanges();
                }
            }
            return View();
        }

    }
}
