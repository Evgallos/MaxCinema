using MaxCinema.Helper;
using MaxCinema.Models;
using MaxCinema.Models.VM;
using MaxCinema.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System;

namespace MaxCinema.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService; 
        private readonly ICustomerService _customerService;
        private readonly IMovieService _movieService;

        public OrderController(IOrderService orderService, IMovieService movieService, ICustomerService customerSerivice)
        {
            _orderService = orderService;
            _customerService = customerSerivice;
            _movieService = movieService;            
        }
        public IActionResult Index()
        {
            List<Order> orderList = _orderService.GetOrderListFor(0);
            return View(orderList);
        }

        public IActionResult OrderToConfirm() 
        {
            string email = HttpContext.Session.Get<string>("CustomerEmail");
            var customer = _customerService.GetCustomerByEmail(email);
            
            return View(customer);
        }
        
        public IActionResult OrderConfirmed()
        {
            string email = HttpContext.Session.Get<string>("CustomerEmail");
            var customer = _customerService.GetCustomerByEmail(email);
            var cartList = HttpContext.Session.Get<List<int>>("ShoppingCart");
            Order newOrder = new Order()
            {
                Customer = customer,
                OrderDate = DateTime.Now,
            };
            foreach (int movieId in cartList)
            {
                OrderRow row = new OrderRow()
                {
                    MovieId = movieId,
                    OrderId = newOrder.Id,
                    Price = _movieService.GetPrice(movieId),
                };
                newOrder.ListOrderRow.Add(row);
            }
            _orderService.Create(newOrder);

            customer.Orders.Add(newOrder);

            HttpContext.Session.Clear();

            return RedirectToAction("OrderCompleted");
        }

        public IActionResult OrderCompleted()
        {
            return View();
        }

        public IActionResult CustomerOrderDisplay()
        {
            string email = (string)TempData["CustomerEmail"];

            var orders = _orderService.GetOrdersByEmail(email); //include orderRow and customer

            var result = orders.Select(x => new CustomerOrderVM()
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
                .Join(_movieService.GetListAll(),
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

            return View(result);
        }

    }
}
