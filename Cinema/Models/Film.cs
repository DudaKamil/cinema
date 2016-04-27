using System.ComponentModel.DataAnnotations;

namespace Cinema.Models
{
    public class Film
    {
        [Key]
        public int FilmID { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public int Year { get; set; }
        public int Length { get; set; }
    }
}