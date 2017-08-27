using System;
using System.Collections.Generic;
using System.Text;

namespace VideoAppDAL
{
    interface IRepository<T>
    {
        T Add(T type);
        List<T> ListAll();
        T FindById(int id);
        bool Delete(int id);
    }
}
