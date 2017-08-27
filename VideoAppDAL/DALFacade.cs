using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using CSVideoMenu;
using VideoAppDAL.Context;
using VideoAppDAL.Repositorys;

namespace VideoAppDAL
{
    public class DALFacade
    {
        public IRepository<Movie> MovieRepository
        {
            // get { return (new MovieRepositoryFakeDB()); }
            get { return ((new MovieRepositoryEFMemory(new Context.InMemoryContext()))); }
        }
    }
}
