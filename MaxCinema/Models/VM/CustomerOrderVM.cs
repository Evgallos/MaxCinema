namespace MaxCinema.Models.VM
{
    public class CustomerOrderVM
    {
        public int OrderId { get; set; }

        public DateTime OrderDate { get; set; }

        public int CustomerId { get; set; }

        public string CustomerName { get; set; } = string.Empty;

        public List<MovieInOrderVM> ListMovie { get; set; } = new List<MovieInOrderVM>();
    }
}
