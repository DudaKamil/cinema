using System.Collections.Generic;
using Cinema.DAL;
using Cinema.Models;
using Cinema.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Cinema.Tests
{
    [TestClass]
    public class MovieRepositoryTest
    {
        private Mock<AbstractCinemaContext> _mockCinemaContext;
        private MovieRepository _repository;

        [TestInitialize]
        public void SetUp()
        {
            _mockCinemaContext = new Mock<AbstractCinemaContext>();
            _repository = new MovieRepository(_mockCinemaContext.Object);
        }

        [TestCleanup]
        public void CleanUp()
        {
            _mockCinemaContext = null;
            _repository = null;
        }

        [TestMethod]
        public void ShouldFindAMovieTitle()
        {
            var toBeReturned = new Movie {Title = "tytuł"};

            const int id = 10;
            _mockCinemaContext.Setup(o => o.GetMovieById(id))
                .Returns(toBeReturned);


            var expected = "tytuł";
            var actual = _repository.GetMovieName(10);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ShouldNotFindAMovieTitle()
        {
            const int id = 10;
            _mockCinemaContext.Setup(o => o.GetMovieById(id))
                .Returns((Movie) null);

            var expected = "błąd";
            var actual = _repository.GetMovieName(10);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ShouldReturnMovie()
        {
            const int id = 10;
            var toBeReturned = new Movie {Title = "test"};
            _mockCinemaContext.Setup(o => o.GetMovieById(id))
                .Returns(toBeReturned);

            var expected = "test";
            var actual = _repository.GetMovie(10).Title;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SouldReturnListOfMovies()
        {
            var movies = new List<Movie>();
            movies.Add(new Movie());
            movies.Add(new Movie());
            movies.Add(new Movie());

            _mockCinemaContext.Setup(o => o.GetMovies())
                .Returns(movies);

            var expectedSize = 3;
            var actualSize = _repository.GetMovieList().Count;

            Assert.AreEqual(expectedSize, actualSize);
        }
    }
}