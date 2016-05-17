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
    }
}