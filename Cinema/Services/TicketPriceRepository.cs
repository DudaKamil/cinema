using Cinema.DAL;
using Cinema.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cinema.Services
{
    public class TicketPriceRepository
    {
        private readonly AbstractCinemaContext _cinemaContext;

        public TicketPriceRepository(AbstractCinemaContext cinemacontext)
        {
            _cinemaContext = cinemacontext;
        }
         public TicketPrice GetPrices(int? id)
        {
            return _cinemaContext.TicketPrices.FirstOrDefault(u => u.Id == id);
        }

        public void EditPrice(TicketPrice ticketprice)
        {
            _cinemaContext.Entry(ticketprice).State = System.Data.Entity.EntityState.Modified;
            _cinemaContext.SaveChanges();
        }
    }
}