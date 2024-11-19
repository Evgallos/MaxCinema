using MaxCinema.Models;
using MaxCinema.Models.VM;
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

        public HomeController(ILogger<HomeController> logger,
                              IMovieService movieService,
                              ICustomerService customerService,
                              IOrderService orderService)
        {
            _logger = logger;
            _movieService = movieService;
            _customerService = customerService;
            _orderService = orderService;
        }


        public IActionResult Index()
        {
            var queryLists = new QueryMovieListsVM();

            queryLists.Mostpop = _movieService.GetTopFivePopularMovies();

            queryLists.Newest = _movieService.GetTopFiveNewMovies();

            queryLists.Oldest = _movieService.GetTopFiveOldestMovies();

            queryLists.Cheapest = _movieService.GetTopFiveCheapestMovies();

            queryLists.Expenorder = _orderService.GetBigestOrder();

            queryLists.BigestOrder = _customerService.GetCustomerWithBiggestOrder();

            return View(queryLists);
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