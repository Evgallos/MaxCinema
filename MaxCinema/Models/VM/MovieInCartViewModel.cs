namespace MaxCinema.Models.VM
{
    public class MovieInCartViewModel
    {
        public Movie Movie { get; set; } = new Movie();

        public int Quantity { get; set; }
    }
}
