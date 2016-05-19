using Cinema.DAL;
using Cinema.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            _cinemaContext.Entry(ticketprice).State = EntityState.Modified;;
            _cinemaContext.SaveChanges();
        }
        public List<TicketPrice> GetList()
        {
            return _cinemaContext.TicketPrices.ToList();
        }
    }
}