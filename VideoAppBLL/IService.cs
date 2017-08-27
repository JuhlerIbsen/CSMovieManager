using System;
using System.Collections.Generic;
using System.Text;
using CSVideoMenu;

namespace VideoAppBLL
{
    public interface IService<T>
    {
        // C.R.U.D operations.
        T Add(T type);
        List<T> ListAll();
        T FindById(int id);
        T Update(T type);
        bool Delete(int id);
    }
}
