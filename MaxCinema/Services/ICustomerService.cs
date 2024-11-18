using MaxCinema.Models;

namespace MaxCinema.Services
{
    public interface ICustomerService
    {
        public void Create(Customer customer);
        public List<Customer> GetAll();

        public Customer GetCustomerByEmail(string email);
    }
}
