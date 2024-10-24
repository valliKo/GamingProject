using System.ComponentModel;

namespace GamingProject.Model
{
    /// <summary>
    /// Game Model
    /// </summary>
    public class Game
    {
        /// <summary>
        /// Game Release Date 
        /// </summary>
        public DateOnly ReleaseDate { get; set; }
        /// <summary>
        /// Game ID Unique Identifier
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// Title of the Game
        /// </summary>
        public string? Title { get; set; }
        /// <summary>
        /// Game catagerory
        /// </summary>
        public string? Genre { get; set; }
        /// <summary>
        /// Game Description
        /// </summary>
        public string? Description { get; set; }
        /// <summary>
        /// Price of the Game
        /// </summary>
        public int Price { get; set; }
        /// <summary>
        /// Available Stock Quantity
        /// </summary>
        public int StockQuantity { get; set; }
    }
}
