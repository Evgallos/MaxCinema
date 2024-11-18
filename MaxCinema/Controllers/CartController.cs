using MaxCinema.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MaxCinema.Helper;
using MaxCinema.Models.VM;
using MaxCinema.Models;

namespace MaxCinema.Controllers
{
    public class CartController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly IMovieService _movieService;
        private readonly IOrderService _orderService;

        public IActionResult RedirecToAction { get; private set; }

        public CartController(ICustomerService customerService, IMovieService movieService, IOrderService orderSerivice)
        {
            _customerService = customerService;
            _movieService = movieService;
            _orderService = orderSerivice;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddToCart(int movieId)
        {
            var cartList = HttpContext.Session.Get<List<int>>("ShoppingCart") ?? new List<int>();
            cartList.Add(movieId);
            HttpContext.Session.Set<List<int>>("ShoppingCart", cartList);

            var numberOfListItems = cartList.Count;
            HttpContext.Session.Set<int>("itemCount", numberOfListItems);

            return Json(new { count = numberOfListItems, msg = "item added to cart" });

        }

        public IActionResult CartDisplay()
        {
            var cartList = HttpContext.Session.Get<List<int>>("ShoppingCart");
            if (HttpContext.Session.Get<List<int>>("ShoppingCart") == null||cartList.Count()==0)
            {
                return RedirectToAction("EmptyCart");
            }
            
            var movieCounts = cartList.GroupBy(x => x).
                Select(g => new { Id = g.Key, MCount = g.Count() }).ToList();
            var obj = movieCounts.Select(x => new MovieInCartViewModel()
            {
                Movie = _movieService.Get(x.Id),
                Quantity = x.MCount
            });
            return View(obj);
        }

        public IActionResult EmptyCart()
        {
            return View();
        }

        public IActionResult Plus1(int movieId)
        {
            var cartList = HttpContext.Session.Get<List<int>>("ShoppingCart");
            cartList.Add(movieId);
            HttpContext.Session.Set<List<int>>("ShoppingCart", cartList);

            var numberOfListItems = cartList.Count;
            HttpContext.Session.Set<int>("itemCount", numberOfListItems);

            var numberOfId = cartList.Where(x => x == movieId).Count();
            return Json(new { count = numberOfListItems, countId = numberOfId, msg = "item +1 to cart" });
        }

        public IActionResult Minus1(int movieId)
        {
            var cartList = HttpContext.Session.Get<List<int>>("ShoppingCart");
            cartList.Remove(movieId);
            HttpContext.Session.Set<List<int>>("ShoppingCart", cartList);

            var numberOfListItems = cartList.Count;
            HttpContext.Session.Set<int>("itemCount", numberOfListItems);

            var numberOfId = cartList.Where(x => x == movieId).Count();
            return Json(new { count = numberOfListItems, countId = numberOfId, msg = "item -1 to cart" });
        }

        public IActionResult CheckOutEmail()
        {
            var cartList = HttpContext.Session.Get<List<int>>("ShoppingCart");
            if (HttpContext.Session.Get<List<int>>("ShoppingCart") == null || cartList.Count() == 0)
            {
                return RedirectToAction("EmptyCart");
            }
            return View();
        }
        [HttpPost]
        public IActionResult CheckOutEmail(string inputEmail)
        {
            var customer = _customerService.GetCustomerByEmail(inputEmail);
            if ( customer == null ) 
            {
                TempData["EmailCheck"] = "This email is not registered. Become our member now!";
                return RedirectToAction("CreateCustomer", "Customer");
            }
            else 
            {
                HttpContext.Session.Set<string>("CustomerEmail", inputEmail);
                return RedirectToAction("OrderToConfirm","Order");
            }
        }


    }
}
