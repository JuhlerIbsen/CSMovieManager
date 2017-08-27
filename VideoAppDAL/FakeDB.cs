
using System.Collections.Generic;
using CSVideoMenu;

namespace VideoAppDAL
{
    public class FakeDB
    {
        public static List<Movie> movies = new List<Movie>();

        public List<Movie> movieDb { get { return movies; } }
    }
}
