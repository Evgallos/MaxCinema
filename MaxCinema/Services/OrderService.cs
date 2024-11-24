using MaxCinema.Data;
using MaxCinema.Models;
using MaxCinema.Models.VM;
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

        public List<CustomerOrderVM> GetOrdersByEmail(string email)
        {
            List<CustomerOrderVM> ListOrder = _db.Orders.Where(x => x.Customer.EmailAddress == email).OrderByDescending(o => o.OrderDate)
                .Include(o => o.ListOrderRow).Include(o => o.Customer)
                 .Select(x => new CustomerOrderVM()
                 {
                     OrderId = x.Id,
                     CustomerId = x.Customer.Id,
                     CustomerName = x.Customer.Firstname + " " + x.Customer.Lastname,
                     OrderDate = x.OrderDate,

                     ListMovie = x.ListOrderRow
                        .GroupBy(x => x.MovieId)
                        .OrderBy(g => g.Key)
                .Select(g => new
                {
                    Quantity = g.Count(),
                    MovieId = g.Key,
                    Price = g.Select(x => x.Price).FirstOrDefault()
                })
                .Join(_db.Movies,
                qmp => qmp.MovieId,
                movie => movie.Id,
                (qmp, movie) => new MovieInOrderVM()
                {
                    MovieId = movie.Id,
                    Title = movie.Title,
                    Quantity = qmp.Quantity,
                    Price = qmp.Price
                }).ToList()
                 }).ToList();
            return ListOrder;
        }

        public List<CustomerOrderVM> GetOrderListAll()
        {
            var orders = _db.Orders.Include(o => o.ListOrderRow)
                    .Include(o => o.Customer)
                    .OrderByDescending(o => o.OrderDate)
                    .Select(x => new CustomerOrderVM()
                    {
                        OrderId = x.Id,
                        CustomerId = x.Customer.Id,
                        CustomerName = x.Customer.Firstname + " " + x.Customer.Lastname,
                        OrderDate = x.OrderDate,

                        ListMovie = x.ListOrderRow
                        .GroupBy(x => x.MovieId)
                        .OrderBy(g => g.Key)
                .Select(g => new
                {
                    Quantity = g.Count(),
                    MovieId = g.Key,
                    Price = g.Select(x => x.Price).FirstOrDefault()
                })
                .Join(_db.Movies,
                qmp => qmp.MovieId,
                movie => movie.Id,
                (qmp, movie) => new MovieInOrderVM()
                {
                    MovieId = movie.Id,
                    Title = movie.Title,
                    Quantity = qmp.Quantity,
                    Price = qmp.Price
                }).ToList()
                    }).ToList();
            return orders;
        }
    }
}