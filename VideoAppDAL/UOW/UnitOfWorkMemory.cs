using System;
using System.Collections.Generic;
using System.Text;
using CSVideoMenu;
using VideoAppDAL.Context;
using VideoAppDAL.Repositorys;

namespace VideoAppDAL.UOW
{
    class UnitOfWorkMemory : IUnitOfWork
    {
        public IRepository<Movie> MovieRepository { get; internal set; }
        private InMemoryContext context;

        public UnitOfWorkMemory()
        {
        context = new InMemoryContext();
        MovieRepository = new MovieRepositoryEFMemory(context);
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public int Complete()
        {
            return context.SaveChanges();
        }
    }
}
