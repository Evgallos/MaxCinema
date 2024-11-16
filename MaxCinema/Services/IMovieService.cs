using MaxCinema.Models;

namespace MaxCinema.Services
{
    public interface IMovieService 
    {
        public void Create(Movie movie);
        public void Delete(Movie movie);
        public List<Movie> GetListAll();
            
    }
}
