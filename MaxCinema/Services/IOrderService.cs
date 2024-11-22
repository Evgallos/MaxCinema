using MaxCinema.Models;
using MaxCinema.Models.VM;

namespace MaxCinema.Services
{
    public interface IOrderService
    {
        public void Create(Order order);

        public List<Order> GetAll();

        public Order GetBigestOrder();
        public List<CustomerOrderVM> GetOrdersByEmail(string email);

        public List<CustomerOrderVM> GetOrderListAll();
    }
}
