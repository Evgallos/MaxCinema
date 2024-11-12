using MaxCinema.Data;
using MaxCinema.Models;

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

    }
}