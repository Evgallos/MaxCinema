using MaxCinema.Models;

namespace MaxCinema.Services
{
    public interface IOrderService
    {
        public void Creat(Order ordere);

        public List<Order> GetAll();


    }
}
