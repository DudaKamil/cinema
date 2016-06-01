using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Cinema.Models
{
    public class Seats
    {
        [Key]
        public int SeatID { get; set; }

        public int SeanceID { get; set; }

        public int OrderID { get; set; }

        [DisplayName("Rząd")]
        public int RowNumber { get; set; }

        [DisplayName("Miejsce")]
        public int SeatNumber { get; set; }
    }
}