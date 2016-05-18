using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Cinema.Models
{
    public class TicketPrice
    {
        [Key]
        public int Id { get; set; }

        public int reduced2D { get; set; }

        public int reduced3D { get; set; }

        public int normal2D { get; set; }

        public int normal3D { get; set; }

    }
}