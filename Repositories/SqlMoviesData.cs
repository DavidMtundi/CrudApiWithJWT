using MinimalJwt.Models;
using MinimalJwt.Services;

namespace MinimalJwt.Repositories
{
    public class SqlMoviesData : IMovieService
    {
        private MovieContext _movieContext;
        public SqlMoviesData(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }

        public Movie Create(Movie movie)
        {
            _movieContext.Movies.Add(movie);
            _movieContext.SaveChanges();
            return movie;
        }

        public bool Delete(int id)
        {
            var movie = _movieContext.Movies.Find(id);
            if (movie != null)
            {
                _movieContext.Movies.Remove(movie);
                _movieContext.SaveChanges();
                return true;
            }

            return false;
        }

        public Movie Get(int id)
        {
            var movie = _movieContext.Movies.Find(id);
            return movie;
        }

        public List<Movie> List()
        {
            return _movieContext.Movies.ToList();
        }

        public Movie Update(Movie movie)
        {
            var existingMovie = _movieContext.Movies.Find(movie.Id);
            if (existingMovie != null)
            {
                _movieContext.Movies.Update(existingMovie);
                _movieContext.SaveChanges();
            }
            return movie;

        }
    }
}
