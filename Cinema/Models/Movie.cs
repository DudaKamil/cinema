using System.ComponentModel.DataAnnotations;

namespace Cinema.Models
{
    public class Movie
    {
        [Key]
        public int MovieID { get; set; }

        public string Title { get; set; }
        public int Length { get; set; }
        public string Genre { get; set; }
        public string ImageURL { get; set; }
        public string Description { get; set; }
    }
}