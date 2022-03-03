namespace StarWars.Models
{
    public class Player
    {
        private int Id { get; set; }
        private string Name { get; set; }
        private string Description { get; set; }
        public Player(int Id, string Name, string Description)
        {
            this.Id = Id;
            this.Name = Name;
            this.Description = Description;
        }
    }
}
