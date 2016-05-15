using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Cinema.Models
{
    public class Seance
    {
        [Key]
        public int SeanceID { get; set; }

        [DisplayName("Film")]
        public int MovieID { get; set; }

        [DisplayName("Typ")]
        public string Type { get; set; }

        [DisplayName("Data Seansu")]
        public DateTime ShowDate { get; set; }
    }
}