using System.Collections.Generic;
using System.Linq;
using Cinema.DAL;
using Cinema.Models;

namespace Cinema.Services
{
    public class OrderRepository
    {
        private readonly AbstractCinemaContext _cinemaContext;

        public OrderRepository(AbstractCinemaContext cinemaContext)
        {
            _cinemaContext = cinemaContext;
        }

        public List<Order> GetUserOrdersList(int? userId)
        {
            return _cinemaContext.Orders.Where(order => order.UserID == userId).ToList();
        }

        public Order GetOrder(int? orderId)
        {
            return _cinemaContext.Orders.FirstOrDefault(order => order.OrderID == orderId);
        }

        public void Remove(int id)
        {
            var order = GetOrder(id);
            _cinemaContext.Orders.Remove(order);
            _cinemaContext.SaveChanges();
        }

        public void Add(Order order)
        {
            _cinemaContext.Orders.Add(order);
            _cinemaContext.SaveChanges();
        }

        public List<Order> GetAllOrders()
        {
            return _cinemaContext.Orders.ToList();
        }
    }
}