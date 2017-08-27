using CSVideoMenu;
using VideoAppBLL.Services;
using VideoAppDAL;

namespace VideoAppBLL
{
    public class BLLFacade
    {
        public IService<Movie> VideoService => (new VideoService(new DALFacade()));
    }
}
