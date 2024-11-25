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
            var orderList = _orderService.GetOrderListAll();
            return View(orderList);
        }

        public IActionResult OrderToConfirm() 
        {// pass email via session
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

            //clear session after order is saved
            HttpContext.Session.Clear();

            return RedirectToAction("OrderCompleted");
        }

        public IActionResult OrderCompleted()
        {
            return View();
        }

        public IActionResult CustomerOrderDisplay(string email)
        {
            var orders = _orderService.GetOrdersByEmail(email); 
            int orderCount = orders.Count();
            ViewBag.OrderCount = orderCount;
            ViewBag.Name = orders.FirstOrDefault().CustomerName;

            return View(orders);
        }

    }
}
