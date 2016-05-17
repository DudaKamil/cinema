using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cinema.DAL;
using Cinema.Models;

namespace Cinema.Services
{
    public class OrderRepository
    {
        private CinemaContext db = new CinemaContext();

        public List<Order> GetUserOrdersList(int? userId)
        {
            return db.Orders.Where(order => order.UserID == userId).ToList();
        }

        public Order GetOrder(int? orderId)
        {
            return db.Orders.FirstOrDefault(order => order.OrderID == orderId);
        }
    }
}