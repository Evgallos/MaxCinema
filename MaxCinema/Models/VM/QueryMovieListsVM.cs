
namespace MaxCinema.Models.VM
{
    public class QueryMovieListsVM
    {
        public List<Movie> Mostpop {  get; set; }
        public List<Movie> Newest {  get; set; }
        public List<Movie> Oldest {  get; set; }
        public List<Movie> Cheapest {  get; set; }
        public Order Expenorder {  get; set; }
        public Customer BigestOrder { get; set; }
    }
}
