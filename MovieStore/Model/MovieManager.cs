using MovieStore.Exceptions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Model
{
    internal class MovieManager
    {
        private List<Movie> movies = new List<Movie>();

        public List<Movie> Movies => movies;
        private DataSerialization dataSerialization;

        public MovieManager()
        {
            dataSerialization = new DataSerialization();
            movies = dataSerialization.Deserialize();
        }

        public void AddMovie(Movie movie)
        {
            if (movies.Count >= 5)
            {
                throw new ListFullException("List is full. Maximum 5 movies.");
            }
            movies.Add(movie);
            dataSerialization.Serialize(movies);
        }

        public void ClearMovies()
        {
            movies.Clear();
            dataSerialization.Serialize(movies);
        }
        public List<Movie> GetMoviesByYear(int year)
        {
            return movies.Where(movie => movie.Year == year).ToList();
        }
        public void RemoveMovieByName(string name)
        {
            movies.RemoveAll(movie => movie.Name == name);
            dataSerialization.Serialize(movies);
        }
        public Movie CreateMovie(int id, string name, int year, string genre)
        {
           if(movies.Count >= 5)
            {
                throw new ListFullException("List is full. Maximum 5 movies.");
            }
            Movie movie = new Movie() { Id = id, Name = name, Year = year, Genre = genre };
            AddMovie(movie);
            return movie;
        }
        public List<Movie> GetAllMovies()
        {
            if (movies.Count == 0)
            {
                throw new NoMovieException("No movies found.");
            }
            return movies;
        }
    }
}
