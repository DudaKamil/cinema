using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cinema.Models
{
    public class MovieModel
    {
        [Required]
        [Display(Name = "Tytuł")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Długość")]
        public int Length { get; set; }

        [Required]
        [Display(Name = "Gatunek")]
        public string Genre { get; set; }

        [Required]
        [Display(Name = "URL Obrazka")]
        public string ImageURL { get; set; }

        [Required]
        [Display(Name = "Opis")]
        public string Description { get; set; }

    }
}