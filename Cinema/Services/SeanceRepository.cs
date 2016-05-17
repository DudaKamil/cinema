using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Cinema.DAL;
using Cinema.Models;

namespace Cinema.Services
{
    public class SeanceRepository
    {
        private readonly AbstractCinemaContext _cinemaContext;

        public SeanceRepository(AbstractCinemaContext cinemaContext)
        {
            _cinemaContext = cinemaContext;
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

        public List<Seance> GetAllSeances()
        {
            return _cinemaContext.Seances.ToList();
        }

        public void Add(Seance seance)
        {
            _cinemaContext.Seances.Add(seance);
            _cinemaContext.SaveChanges();
        }

        public void EditSeance(Seance seance)
        {
            _cinemaContext.Entry(seance).State = EntityState.Modified;
            _cinemaContext.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var seance = _cinemaContext.Seances.Find(id);
            _cinemaContext.Seances.Remove(seance);
            _cinemaContext.SaveChanges();
        }
    }
}