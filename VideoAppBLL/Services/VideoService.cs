using System;
using System.Collections.Generic;
using System.Linq;
using CSVideoMenu;
using VideoAppDAL;

namespace VideoAppBLL.Services
{
    class VideoService : IService<Movie>
    {
        private IRepository<Movie> repository;

        public VideoService(IRepository<Movie> repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Add a movie to the database.
        /// </summary>
        /// <param name="movie">movie to add into the database.</param>
        /// <returns>the movie that has been added to the database.</returns>
        public Movie Add(Movie movie)
        {
            return repository.Add(movie);
        }

        /// <summary>
        /// Return a list of all movies.
        /// </summary>
        /// <returns>All movies in the database.</returns>
        public List<Movie> ListAll()
        {
            return repository.ListAll();
        }

        /// <summary>
        /// Return a movie by id.
        /// </summary>
        /// <param name="id">id of the movie we want to find.</param>
        /// <returns>movie that was found.</returns>
        public Movie FindById(int movieId)
        {
            return repository.FindById(movieId);
        }

        /// <summary>
        /// Update the movie we pass in the parameter.
        /// </summary>
        /// <param name="movie">The movie to update.</param>
        /// <returns>Updated version of movie.</returns>
        public Movie Update(Movie movie)
        {
            var movieFromDb = FindById(movie.Id);

            if (movieFromDb != null)
            {
                movieFromDb.Title = movie.Title;
                movieFromDb.Duration = movie.Duration;
                movieFromDb.Extention = movie.Extention;
                movieFromDb.MovieGenre = movie.MovieGenre;
            }
            else
            {
                throw new InvalidOperationException("Movie not found.");
            }

            return movieFromDb;

        }

        /// <summary>
        /// Delete a movie by id.
        /// </summary>
        /// <param name="movieId">the id of the movie to delete.</param>
        /// <returns>checks if the movie was deleted succesfully</returns>
        public bool Delete(int movieId)
        {
            return repository.Delete(movieId);
        }
    }
}
