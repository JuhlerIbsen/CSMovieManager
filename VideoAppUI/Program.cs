using System;
using CSVideoMenu;
using VideoAppBLL;

namespace VideoAppUI
{
    class Program
    {
       
       static BLLFacade bllFacade = new BLLFacade();

        /// <summary>
        /// All magic starts here.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
           
          // Run console application.
          MovieApplication.RunApplication();
        }

    }
}
