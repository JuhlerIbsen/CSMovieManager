using System;
using System.Collections.Generic;
using System.Text;
using CSVideoMenu;

namespace VideoAppDAL
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Movie> MovieRepository { get; }
        int Complete();
    }
}
