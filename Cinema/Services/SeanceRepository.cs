using System;
using System.Collections.Generic;
using System.Linq;
using Cinema.DAL;
using Cinema.Models;

namespace Cinema.Services
{
    public class SeanceRepository
    {
        private readonly AbstractCinemaContext _cinemaContext;

        public SeanceRepository(CinemaContext cinemaContext)
        {
            this._cinemaContext = cinemaContext;
        }

        public List<Seance> GetSeancesList(int? movieId)
        {
            return _cinemaContext.Seances.Where(seance => seance.MovieID == movieId).ToList();
        }

        public Seance GetSeance(int id)
        {
            return _cinemaContext.Seances.FirstOrDefault(u => u.SeanceID == id);
        }

        public string GetSeanceType(int id)
        {
            return _cinemaContext.Seances.FirstOrDefault(u => u.SeanceID == id).Type;
        }

        public int GetMovieId(int id)
        {
            return _cinemaContext.Seances.FirstOrDefault(u => u.SeanceID == id).MovieID;
        }

        public DateTime GetSeanceDate(int id)
        {
            return _cinemaContext.Seances.FirstOrDefault(u => u.SeanceID == id).ShowDate;
        }
    }
}