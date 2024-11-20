using MaxCinema.Data;
using MaxCinema.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace MaxCinema.Services
{
    public class OrderService : IOrderService
    {
        private readonly MCinemaContext _db;



        public OrderService(MCinemaContext db)
        {
            _db = db;
        }
        public void Create(Order order)
        {
            _db.Orders.Add(order);
            _db.SaveChanges();
        }


        public List<Order> GetAll()
        {
            var orderList = _db.Orders.OrderBy(x => x.Id).ToList();
            return orderList;
        }

        public Order GetBigestOrder()
        {
            return _db.Orders
                .OrderByDescending(o => o.ListOrderRow.Sum(or => or.Price))
                .Include(o => o.Customer)
                .FirstOrDefault();
        }

        public List<Order> GetOrdersByEmail(string email)
        {
            List<Order> ListOrder = _db.Orders.Where(x => x.Customer.EmailAddress == email).OrderByDescending(o => o.OrderDate)
                .Include(o => o.ListOrderRow).Include(o => o.Customer).ToList();

            return ListOrder;
        }
    }
}