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

        public Customer GetCustomerByEmail(string email)
        {
            Customer customer = _db.Customers.Where(x => x.EmailAddress == email).FirstOrDefault();
            return customer;
        }

        public Customer GetCustomerWithBiggestOrder()
        {
            OrderService orderService = new OrderService(_db);

            Order bigOrder = orderService.GetBigestOrder();

            return bigOrder.Customer;
        }

        public Customer GetById(int id)
        {
            return _db.Customers.SingleOrDefault(c => c.Id==id);
        }

        public void Edit(Customer customer)
        {
            _db.Customers.Update(customer);
            _db.SaveChanges();
        }
    }
}
