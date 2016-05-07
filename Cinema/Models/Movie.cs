using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Cinema.Models
{
    public class Movie
    {
        [Key]
        public int MovieID { get; set; }

        [DisplayName("Tytuł")]
        public string Title { get; set; }

        [DisplayName("Długość")]
        public int Length { get; set; }

        [DisplayName("Gatunek")]
        public string Genre { get; set; }

        [DisplayName("URL Obrazka")]
        public string ImageURL { get; set; }

        [DisplayName("Opis")]
        public string Description { get; set; }
    }
}