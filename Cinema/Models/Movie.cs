using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace Cinema.Models
{
    public class Movie
    {
        [Key]
        public int MovieID { get; set; }

        public string Title { get; set; }
        public int Length { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }

        // TODO: sprawdzic typ obrazkow w bazie ms sql
        public Image Poster { get; set; }
    }
}