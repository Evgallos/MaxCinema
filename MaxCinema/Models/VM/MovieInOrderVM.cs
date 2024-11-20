namespace MaxCinema.Models.VM
{
    public class MovieInOrderVM
    {
        public int MovieId { get; set; }
        public string Title { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
