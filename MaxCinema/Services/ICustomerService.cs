using MaxCinema.Models;

namespace MaxCinema.Services
{
    public interface ICustomerService
    {
        public void Create(Customer customer);
        public List<Customer> GetAll();

        public Customer GetCustomerByEmail(string email);

        public Customer GetCustomerWithBiggestOrder();

        public Customer GetById(int id);
        void Edit(Customer customer);
    }
}
