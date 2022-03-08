using System.ComponentModel.DataAnnotations;

namespace StarWars.Models
{
    public class Player
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Description required")]
        public string Description { get; set; }
        [Display(Name = "Player type")]
        public int PlayerTypeId { get; set; }
        //private int Id { get; set; }
        //private string Name { get; set; }
        //private string Description { get; set; }
        //public Player(int Id, string Name, string Description)
        //{
        //    this.Id = Id;
        //    this.Name = Name;
        //    this.Description = Description;
        //}
    }
}
