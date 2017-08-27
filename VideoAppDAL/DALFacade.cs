using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace VideoAppDAL
{
    public class DALFacade
    {
        public FakeDB FakeDb { get => (new FakeDB()); }
    }
}
