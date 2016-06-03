using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Cinema.DAL;
using Cinema.Models;

namespace Cinema.Services
{
    public class SeatsRepository
    {
        private readonly AbstractCinemaContext _cinemaContext;

        public SeatsRepository(AbstractCinemaContext cinemaContext)
        {
            _cinemaContext = cinemaContext;
        }

        public Seats GetSeat(int id)
        {
            return _cinemaContext.Seats.FirstOrDefault(u => u.SeatID == id);
        }

        public List<Seats> GetAllSeats()
        {
            return _cinemaContext.Seats.ToList();
        }
        public void Add(Seats seat)
        {
            _cinemaContext.Seats.Add(seat);
            _cinemaContext.SaveChanges();
        }
    }
}