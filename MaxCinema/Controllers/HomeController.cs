using MaxCinema.Models;
using MaxCinema.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MaxCinema.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMovieService _movieService;
        private readonly IOrderService _orderService;
        private readonly ICustomerService _customerService;


        public HomeController(ILogger<HomeController> logger, IMovieService movieService, IOrderService orderService, ICustomerService customerService)
        {
            _logger = logger;
            _movieService = movieService;
            _orderService = orderService;
            _customerService = customerService;

        }

        public IActionResult Index()
        {
            var queryLists = new QueryMovieListsVM();

            List<Order> orders = _orderService.GetAll();
            List<Movie> movies = _movieService.GetListAll();
            var mostpop = movies.OrderBy(m => m.Id).ThenBy(m => m.Title).ToList();
            queryLists.MostPop = mostpop;

            var newest = movies.OrderByDescending(n => n.ReleaseYear).Take(5).ToList();
            queryLists.Newest = newest;

            var oldest = movies.OrderByDescending(o => o.ReleaseYear).Take(5).ToList();
            queryLists.Oldest = oldest;

            var cheapest = movies.OrderBy(c => c.Price).Take(5).ToList();
            queryLists.Cheapest = cheapest;

            var expenorder = _orderService.GetBigestOrder();//   OrderRow.OrderId = Order.(orderId)
            queryLists.ExpenOrder = expenorder;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }