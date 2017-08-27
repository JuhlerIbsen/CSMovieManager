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

        /// <summary>
        /// Return VideoService which can use c.r.u.d operations.
        /// </summary>
        /// <returns>VideoService</returns>
        public IService<Movie> GetVideoService()
        {
            return (new VideoService());
        }

    }
}
