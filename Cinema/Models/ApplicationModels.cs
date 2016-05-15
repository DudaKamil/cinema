using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Cinema.Models
{
    public class MovieDetailsModel
    {        
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

        public IEnumerable<Seance> SeancesList { get; set; }
    }

    public class BuyTicketModel
    {
        public int SeanceID { get; set; }

        [Required]
        [DisplayName("Bilety Ulgowe")]
        public int ReducedTicket { get; set; }

        [Required]
        [DisplayName("Bilety Normalne")]
        public int NormalTicket { get; set; }
    }
}