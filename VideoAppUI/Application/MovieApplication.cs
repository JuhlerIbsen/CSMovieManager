using System;
using System.Collections.Generic;
using System.Linq;
using VideoAppBLL;

namespace CSVideoMenu
{
    public class MovieApplication
    {

        private static BLLFacade bllFacade = new BLLFacade();

        /// <summary>
        /// Start the application.
        /// </summary>
        public static void RunApplication()
        {
            Console.WriteLine("###################################");
            Console.WriteLine("### WELCOME TO MY MOVIE MANAGER ###");
            Console.WriteLine("###################################");

            // List of presetup movies (Comment if you don't want to use it).
            GenerateMockMovies();

            var bildeMenuRunning = true;

            string[] menuItems =
            {
                "List All Movies",
                "Find Movie By Id",
                "Add Movie",
                "Delete Movie",
                "Edit Movie",
                "Exit"
            };

            while (bildeMenuRunning)
            { 
                bildeMenuRunning = UseSelection(ShowMenu(menuItems));
            }

        }

        /// <summary>
        /// Like seen in the movie.
        /// </summary>
        /// <param name="menuItems">Menu list</param>
        /// <returns>selection</returns>
        private static int ShowMenu(string[] menuItems)
        {

            var menuItemsLength = menuItems.Length;

            for (int i = 0; i < menuItemsLength; i++)
            {
                Console.WriteLine($"{1 + i}:{menuItems[i]}");
            }

            int selection;

            while (!int.TryParse(Console.ReadLine(), out selection) || selection < 1
                   || selection > menuItemsLength)
            {
                Console.WriteLine($"You must select a number between 1 - { menuItemsLength }");
            }

            return selection;

        }

        /// <summary>
        /// Define what to do on either selection.
        /// </summary>
        /// <param name="selection">Selection input by user.</param>
        /// <returns>boolean to determine if the program should stop.</returns>
        private static bool UseSelection(int selection)
        {
            switch (selection)
            {
                case 1:
                    ListAllMovies();
                    return true;

                case 2:
                    FindMovieById();
                    return true;

                case 3:
                    AddMovie();
                    return true;

                case 4:
                    DeleteMovieById();
                    return true;

                case 5:
                    EditMovieById();
                    return true;

                case 6:
                    // Shutdown the application.
                    return false;

                default:
                    return false;
            }
        }

        /// <summary>
        /// List all movies in our database.
        /// </summary>
        private static void ListAllMovies()
        {

            var allMovies = bllFacade.VideoService.ListAll();

            if (allMovies.Count <= 0)
                return;

            foreach (var video in allMovies)
            {
                Console.WriteLine($"Id: {video.Id} " +
                                  $"Title: {video.Title} " +
                                  $"Genre: {video.MovieGenre.ToString()} " +
                                  $"Duration: {GetMovieDuration(video.Duration)} " +
                                  $"FileType: {video.Extention.ToString()}");
            }

            // Make a small line between the movies listed and the menu.
            Console.Write("------------------ \n");
        }

        /// <summary>
        /// Add a movie to the database.
        /// </summary>
        private static void AddMovie()
        {

            bool nextMovie = true;

            List<Movie> movies = new List<Movie> {InitializeMovie()};

            do
            {
                Console.WriteLine("Do you want to add more? Yes : No");
                switch (Console.ReadLine().ToUpper())
                {
                    case "YES":
                        movies.Add(InitializeMovie());
                        break;

                    case "NO":
                        AddMovies(movies);
                        nextMovie = false;
                        break;

                    default:
                        Console.WriteLine("I only understand yes and no.");
                        break;
                }
            } while (nextMovie);

        }

        /// <summary>
        /// Initialize movie.
        /// </summary>
        /// <returns>Initialized movie.</returns>
        private static Movie InitializeMovie()
        {
            Movie movie = new Movie();   

            Console.WriteLine("Movie Title");
            movie.Title = Console.ReadLine();

            ChooseGenre(movie);
            ChooseFileType(movie);
            ChooseDuration(movie);

            return movie;
        }

        /// <summary>
        /// Save a list of movies in the database.
        /// </summary>
        /// <param name="movies">List of movies to save.</param>
        private static void AddMovies(List<Movie> movies)
        {
            foreach (var movie in movies)
            {
                bllFacade.VideoService.Add(movie);
            }    

            Console.WriteLine($"{movies.Count} movies have been saved to the database.");
        }

        /// <summary>
        /// Remove a movie by id.
        /// </summary>
        private static void DeleteMovieById()
        {
            // Show all movies so user can see the available id's.
            ListAllMovies();

            if (bllFacade.VideoService.ListAll().Count <= 0)
            {
                Console.WriteLine("There are no movies...\n");
                return;
            }

            Console.WriteLine("Write id of movie to remove");
            var movieId = int.Parse(Console.ReadLine());

            if (bllFacade.VideoService.Delete(movieId))
            {
                Console.WriteLine("Movie deleted.");
            }
            else
            {
                Console.WriteLine("There's no movie with that id.\n");
            }
          

        }

        /// <summary>
        /// Edit a movie by its id.
        /// </summary>
        private static void EditMovieById()
        {
            // Show all movies to give the user a overview.
            ListAllMovies();

            // TODO: This if statement are used twice, make a method.
            if (bllFacade.VideoService.ListAll().Count <= 0)
            {
                Console.WriteLine("There are no movies.");
                return;
            }

            Console.WriteLine("Write id of video you want to edit.");
            var id = int.Parse(Console.ReadLine());

            IEnumerable<Movie> foundMovies = from movie 
                                       in bllFacade.VideoService.ListAll()
                                       where movie.Id == id
                                       select movie;

            foreach (var movie in foundMovies)
            {
                Console.WriteLine($"Change the title of { movie.Title }");
                movie.Title = Console.ReadLine();

                ChooseGenre(movie);
                ChooseDuration(movie);
                ChooseFileType(movie);

                bllFacade.VideoService.Update(movie);
            }

            Console.WriteLine("Movie have been edited.");
        }


        /// <summary>
        /// Show a movie by id.
        /// </summary>
        private static void FindMovieById()
        {

            int id;

            // Show all id's to user.
            foreach (var movie in bllFacade.VideoService.ListAll())
            {
                Console.WriteLine($"Available ID: {movie.Id}");
            }

            Console.WriteLine("Select any of the id's above.");

            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine($"Only numbers allowed, and cannot be greater than {int.MaxValue}");
            }

            IEnumerable<Movie> foundMovies = from movie
                in bllFacade.VideoService.ListAll()
                where movie.Id == id
                select movie;

            foreach (var movie in foundMovies)
            {
                Console.WriteLine($"Id: {movie.Id} " +
                                  $"Title: {movie.Title} " +
                                  $"Genre: {movie.MovieGenre.ToString()} " +
                                  $"Duration: {GetMovieDuration(movie.Duration)} " +
                                  $"FileType: {movie.Extention.ToString()}");
                return;
            }

            Console.WriteLine("Movie not found.");
        }

        /// <summary>
        /// Choose genre for a movie.
        /// </summary>
        /// <param name="movie">movie to set the genre on.</param>
        private static void ChooseGenre(Movie movie)
        {
            Console.WriteLine("Movie Genre\n" +
                              "Select between: Horror, Romantique and Comedy write it as a string.");

            switch (Console.ReadLine().ToLower())
            {
                case "horror":
                    movie.MovieGenre = Movie.Genre.Horror;
                    break;
                case "romantique":
                    movie.MovieGenre = Movie.Genre.Romantique;
                    break;
                case "comedy":
                    movie.MovieGenre = Movie.Genre.Comedy;
                    break;

                default:
                    movie.MovieGenre = Movie.Genre.NoGenre;
                    break;
            }
        }

        /// <summary>
        /// Select filetype for the movie.
        /// </summary>
        /// <param name="movie">movie to set filetype on.</param>
        private static void ChooseFileType(Movie movie)
        {

            Console.WriteLine("FileType\n" +
                              "Select between: Mp4, Mkv and Avi write it as a string.");

            switch (Console.ReadLine().ToLower())
            {
                case "mp4":
                    movie.Extention = Movie.FileType.MP4;
                    break;

                case "mkv":
                    movie.Extention = Movie.FileType.MKV;
                    break;

                case "avi":
                    movie.Extention = Movie.FileType.AVI;
                    break;

                default:
                    // Default will be .mp4
                    movie.Extention = Movie.FileType.MP4;
                    break;
            }
        }

        /// <summary>
        /// Makes sure the user inputs a integer.
        /// </summary>
        /// <param name="movie">movie to set duration to.</param>
        private static void ChooseDuration(Movie movie)
        {

            Console.WriteLine("Movie duration in seconds");

            long duration;

            while (!long.TryParse(Console.ReadLine(), out duration)  || duration > long.MaxValue)
            {
                Console.WriteLine($"Must write a number and it can't be greater than {long.MaxValue }");
            }

            movie.Duration = duration;
        }

        /// <summary>
        /// Convert seconds to a line of text
        /// containing hours, minutes and seconds.
        /// </summary>
        /// <param name="duration">Seconds to convert.</param>
        /// <returns>String of hours, minutes and seconds.</returns>
        private static string GetMovieDuration(long duration)
        {
            /** Convert movie duration from seconds to a string. **/
            var second = String.Format("{0}", ((duration) % 60).ToString("00"));
            var minute = String.Format("{0}", ((duration / (60)) % 60).ToString("00"));
            var hour   = String.Format("{0}", ((duration / (60 * 60)) % 24).ToString("00"));

            return $"{hour} hours {minute} minutes {second} seconds";
        }

        /// <summary>
        /// Generate a list of movies.
        /// </summary>
        private static void GenerateMockMovies()
        {
            bllFacade.VideoService.Add(new Movie
            {
                Title = "Michael in the woods.",
                Duration = 3674 * 3,
                Extention = Movie.FileType.MP4,
                MovieGenre = Movie.Genre.Horror
            });

            bllFacade.VideoService.Add(new Movie
            {
                Title = "Dude where's Michael",
                Duration = 4213,
                Extention = Movie.FileType.MKV,
                MovieGenre = Movie.Genre.Comedy
            });

            bllFacade.VideoService.Add(new Movie
            {
                Title = "Michael rock",
                Duration = 3600 * 2,
                Extention = Movie.FileType.AVI,
                MovieGenre = Movie.Genre.Romantique
            });
        }
    }
}
