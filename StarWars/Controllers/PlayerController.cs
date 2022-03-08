using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            //if (ModelState.IsValid)
            //{
            /*Correr la validación del lado del servidor*/
            //}
            if (player.Id == 0)
            {
                ctx.Players.Add(player);
            }
            else
            {
                ctx.Attach(player);
                ctx.Entry(player).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            ctx.SaveChanges();
            return RedirectToAction("PlayerList");
        }
        public IActionResult Update(string id)
        {
            Player model;
            int Id = 0;
            int.TryParse(id, out Id);
            if (Id == 0)
            {
                model = new();
            }
            else
            {
                model = ctx.Players.Find(Id);
            }
            List<KeyValuePair<int, string>> types = new();
            types.Add(new KeyValuePair<int, string>(1, "Jedi"));
            types.Add(new KeyValuePair<int, string>(2, "Sith"));
            SelectList items = new(types, "Key", "Value");
            ViewBag.Types = items;
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
