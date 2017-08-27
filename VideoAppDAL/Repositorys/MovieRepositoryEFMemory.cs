using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSVideoMenu;
using VideoAppDAL.Context;

namespace VideoAppDAL.Repositorys
{
    class MovieRepositoryEFMemory : IRepository<Movie>
    {
        private InMemoryContext context;

        public MovieRepositoryEFMemory(InMemoryContext context)
        {
            this.context = context;
        }


        public Movie Add(Movie movie)
        {
            context.Movies.Add(movie);
            context.SaveChanges();
            return movie;
        }

        public List<Movie> ListAll()
        {
            return context.Movies.ToList();
        }

        public Movie FindById(int movieId)
        {
            return context.Movies.FirstOrDefault(movie => movie.Id == movieId);
        }

        public bool Delete(int movieId)
        {
            var movie = FindById(movieId);
            context.Movies.Remove(movie);
            context.SaveChanges();
            return movie != null;
        }
    }
}
