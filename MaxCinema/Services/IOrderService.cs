using MaxCinema.Models;

namespace MaxCinema.Services
{
    public interface IOrderService
    {
        public void Create(Order order);

        public List<Order> GetAll();

        public Order GetBigestOrder();


    }
}
