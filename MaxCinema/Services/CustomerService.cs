using MaxCinema.Data;
using MaxCinema.Models;

namespace MaxCinema.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly MCinemaContext _db;
        public CustomerService(MCinemaContext db)
        {
            _db = db;
        }

        public void Create(Customer customer)
        {
            _db.Customers.Add(customer);
            _db.SaveChanges();

        }

        public List<Customer> GetAll()
        {
            var customerList = _db.Customers.OrderBy(x => x.Lastname).ToList();
            return customerList;
        }
    }
}
