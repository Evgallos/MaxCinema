using MaxCinema.Models;

namespace MaxCinema.Services
{
    public interface IMovieService 
    {
        public void Create(Movies movie);
        public void Delete(Movies movie);
        public List<Movies> GetListAll();
        

            
    }
}
