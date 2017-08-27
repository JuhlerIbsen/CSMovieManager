using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using VideoAppDAL.Repositorys;

namespace VideoAppDAL
{
    public class DALFacade
    {
        public MovieRepositoryFakeDB MovieRepositoryFakeDb { get { return (new MovieRepositoryFakeDB()); } }
    }
}
