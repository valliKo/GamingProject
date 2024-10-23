namespace GamingProject.Model
{
    public class Game
    {
        public DateOnly ReleaseDate { get; set; }

        public int ID { get; set; }

        public string? Title { get; set; }

        public string? Genre { get; set; }
        public string? Description { get; set; }

        public int Price { get; set; }
        public int StockQuantity { get; set; }
    }
}
