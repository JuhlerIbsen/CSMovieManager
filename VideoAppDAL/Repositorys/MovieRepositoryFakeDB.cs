using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSVideoMenu;

namespace VideoAppDAL.Repositorys
{
    public class MovieRepositoryFakeDB : IRepository<Movie>
    {
        #region FakeDB
        public static List<Movie> Movies = new List<Movie>();
        #endregion


        public Movie Add(Movie movie)
        {
            Movie newMovie = null;

            Movies.Add(newMovie = movie);

            return newMovie;
        }

        public List<Movie> ListAll()
        {
            return Movies;
        }

        public Movie FindById(int movieId)
        {
           return Movies.FirstOrDefault(movie => movie.Id == movieId);
        }

        public bool Delete(int movieId)
        {
            return (Movies.RemoveAll(video => video.Id == movieId) > 0);
        }
    }
}
