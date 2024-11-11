using MaxCinema.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace MaxCinema.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        public IActionResult Index()
            {
                  return View();
            }
          
        
    }
}
