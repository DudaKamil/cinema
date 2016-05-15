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

    public class OrderDetailsModel
    {
        public int? OrderID { get; set; }

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

        [DisplayName("Typ")]
        public string Type { get; set; }

        [DisplayName("Data Seansu")]
        public DateTime ShowDate { get; set; }

        [DisplayName("Data Zamówienia")]
        public DateTime OrderDate { get; set; }

        [DisplayName("Bilety Ulgowe")]
        public int ReducedTicket { get; set; }

        [DisplayName("Bilety Normalne")]
        public int NormalTicket { get; set; }

        [DisplayName("Koszt Biletów")]
        public int Cost { get; set; }

        [DisplayName("Kod Biletu")]
        public string TicketCode { get; set; }
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

        public int GetTicketsCost(int amountNormalTickets, int amountreducedTickets, string type)
        {
            int cost = 0;
            if (type == "2D")
            {
                cost += amountNormalTickets * 15;
                cost += amountreducedTickets * 10;
            }
            else
            {
                cost += amountNormalTickets * 20;
                cost += amountreducedTickets * 16;
            }
            return cost;
        }
    }
}