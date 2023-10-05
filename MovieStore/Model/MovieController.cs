using MovieStore.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Model
{
    internal class MovieController
    {

        private MovieManager manager;
        public MovieController()
        {
            manager = new  MovieManager();
        }

        public void Start()
        {
            DisplayMenu();
        }

        private void DisplayMenu()
        {
            while (true)
            {
                Console.WriteLine("1. Add Movie");
                Console.WriteLine("2. Clear Movies");
                Console.WriteLine("3. Display Movies by Year");
                Console.WriteLine("4. Remove movies by Name");
                Console.WriteLine("5. Display all movies:");
                Console.WriteLine("6. Exit");

                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());
                try
                {
                    switch (choice)
                    {
                        case 1:
                            SetMovieDetails();
                            break;

                        case 2:
                            manager.ClearMovies();
                            Console.WriteLine("All movies cleared.");
                            break;
                        case 3:
                            Console.Write("Enter year to search for: ");
                            int year = int.Parse(Console.ReadLine());
                            List<Movie> moviesByYear = manager.GetMoviesByYear(year);
                            DisplayMovies(moviesByYear);
                            break;

                        case 4:
                            RemoveMovieByName();
                            break;

                        case 5:
                            List<Movie> allMovies = manager.GetAllMovies();
                            DisplayMovies(allMovies);
                            break;
                        case 6:
                            Console.WriteLine("Exiting...");
                            return;
                        default:
                            Console.WriteLine("Invalid choice");
                            break;
                    }
                }
                catch (ListFullException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (NoMovieException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }
        }

        private void SetMovieDetails()
        {
            if (manager.Movies.Count >= 5)
            {
                Console.WriteLine("List is full. Maximum 5 movies.");
                return; 
            }
            Console.Write("Enter movie ID: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Enter movie name: ");
            string name = Console.ReadLine();

            Console.Write("Enter movie year: ");
            int year = int.Parse(Console.ReadLine());

            Console.Write("Enter movie genre: ");
            string genre = Console.ReadLine();

            Movie movie = manager.CreateMovie(id, name, year, genre);
            Console.WriteLine("Movie added successfully!");
        }
         
        private void RemoveMovieByName()
        {
            Console.WriteLine("Enter the name to remove");
            string movieToRemove = Console.ReadLine();
            manager.RemoveMovieByName(movieToRemove);
            Console.WriteLine("Movie with name "+ movieToRemove + "Removed");
        }
        private void DisplayMovies(List<Movie> movies)
        {
            if (movies.Count == 0)
            {
                Console.WriteLine("No movies found.");
                return;
            }

            foreach (Movie movie in movies)
            {
                Console.WriteLine($"{movie.Id} - {movie.Name} ({movie.Year}) - {movie.Genre}");
            }
        }
    }
}

