using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Cinema.Models
{
    public class Seats
    {
        [Key]
        public int SeatID { get; set; }

        public int TotalTickets { get; set; }
    }
}