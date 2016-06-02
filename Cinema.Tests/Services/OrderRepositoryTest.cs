using System.Collections.Generic;
using Cinema.DAL;
using Cinema.Models;
using Cinema.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Cinema.Tests
{
    [TestClass]
    public class OrderRepositoryTest
    {
        private Mock<AbstractCinemaContext> _mockCinemaContext;
        private OrderRepository _repository;

        [TestInitialize]
        public void SetUp()
        {
            _mockCinemaContext = new Mock<AbstractCinemaContext>();
            _repository = new OrderRepository(_mockCinemaContext.Object);
        }

        [TestCleanup]
        public void CleanUp()
        {
            _mockCinemaContext = null;
            _repository = null;
        }

        [TestMethod]
        public void ShouldReturnOrdersList()
        {
            var orders = new List<Order>();
            orders.Add(new Order());
            orders.Add(new Order());
            orders.Add(new Order());

            _mockCinemaContext.Setup(o => o.GetOrdersByUserId(1))
                .Returns(orders);

            var expectedSize = 3;
            var actualSize = _repository.GetUserOrdersList(1).Count;

            Assert.AreEqual(expectedSize, actualSize);
        }

        [TestMethod]
        public void SouldReturnAllOrders()
        {
            var orders = new List<Order>();
            orders.Add(new Order());
            orders.Add(new Order());
            orders.Add(new Order());

            _mockCinemaContext.Setup(o => o.GetAllOrders())
                .Returns(orders);

            var expectedSize = 3;
            var actualSize = _repository.GetAllOrders().Count;

            Assert.AreEqual(expectedSize, actualSize);
        }

        [TestMethod]
        public void ShouldReturnAnOrder()
        {
            var order = new Order();

            _mockCinemaContext.Setup(o => o.GetOrderById(1))
                .Returns(order);

            var actual = _repository.GetOrder(1);

            Assert.IsNotNull(actual);
        }
    }
}