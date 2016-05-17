using System.Linq;
using Cinema.DAL;
using Cinema.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Cinema.Tests
{
    [TestClass]
    public class MovieRepositoryTest
    {
        private Mock<CinemaContext> _mockCinemaContext;
        private MovieRepository _repository;

        [TestInitialize]
        public void SetUp()
        {
            _mockCinemaContext = new Mock<CinemaContext>();
            _repository = new MovieRepository();
        }

        [TestCleanup]
        public void CleanUp()
        {
            _mockCinemaContext = null;
        }

        [Ignore]
        [TestMethod]
        public void ShouldNotFindAnyMovieName()
        {
            var expected = "błąd";
            string actual;

            const int id = 10;
            _mockCinemaContext.Setup(o => o.Movies.FirstOrDefault(u => u.MovieID == id))
                .Returns(() => null);

            actual = _repository.GetMovieName(id);

            Assert.AreEqual(expected, actual);
        }
    }
}