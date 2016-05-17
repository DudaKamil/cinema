using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Cinema.Models
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }

        [DisplayName("Seans")]
        public int SeanceID { get; set; }

        [DisplayName("Użytkownik")]
        public int UserID { get; set; }

        [DisplayName("Bilet Normalny")]
        public int ReducedTicket { get; set; }

        [DisplayName("Bilet Ulgowy")]
        public int NormalTicket { get; set; }

        [DisplayName("Kod Biletu")]
        public string TicketCode { get; set; }

        [DisplayName("Data Zamówienia")]
        public DateTime OrderDate { get; set; }
    }
}