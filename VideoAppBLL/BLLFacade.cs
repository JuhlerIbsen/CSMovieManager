using System;
using System.Collections.Generic;
using System.Text;
using CSVideoMenu;
using VideoAppBLL.Services;

namespace VideoAppBLL
{
    public class BLLFacade
    {

        public IService<Movie> VideoService => (new VideoService());

    }
}
