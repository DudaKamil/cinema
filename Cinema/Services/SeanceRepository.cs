using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cinema.DAL;
using Cinema.Models;

namespace Cinema.Services
{
    public class SeanceRepository
    {
        private CinemaContext db = new CinemaContext();

        public List<Seance> GetSeancesList(int? movieId)
        {
            return db.Seances.Where(seance => seance.MovieID == movieId).ToList();
        }

        public Seance GetSeance(int id)
        {
            return db.Seances.FirstOrDefault(u => u.SeanceID == id);
        }

        public string GetSeanceType(int id)
        {
            return db.Seances.FirstOrDefault(u => u.SeanceID == id).Type;
        }

        public int GetMovieId(int id)
        {
            return db.Seances.FirstOrDefault(u => u.SeanceID == id).MovieID;
        }

        public DateTime GetSeanceDate(int id)
        {
            return db.Seances.FirstOrDefault(u => u.SeanceID == id).ShowDate;
        }
    }
}