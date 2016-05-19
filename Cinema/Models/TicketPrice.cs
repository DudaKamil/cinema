using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Cinema.Models
{
    public class TicketPrice
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Ulgowy 2D")]
        public int reduced2D { get; set; }

        [DisplayName("Ulgowy 3D")]
        public int reduced3D { get; set; }

        [DisplayName("Normalny 2D")]
        public int normal2D { get; set; }

        [DisplayName("Normalny 3D")]
        public int normal3D { get; set; }

    }
}