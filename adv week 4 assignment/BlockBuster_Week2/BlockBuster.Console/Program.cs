using System;
using System.Collections.Generic;
using BlockBuster.Models;

namespace BlockBuster.ConsoleApp
{
	internal class Program
	{
		static void Main(string[] args)
		{
			// Check if the correct number of arguments are provided
			if (args.Length < 2)
			{
				Console.WriteLine("Usage: <OutputType> <Function> [Parameter]");
				Console.WriteLine("Example: CSV GetMovieByTitle Vertigo");
				return; // Exit if not enough arguments
			}

			// Read command-line arguments
			string outputType = args[0];  // First argument: "CSV" or "Console"
			string functionName = args[1]; // Second argument: Function to call (e.g., "GetAllMovies", "GetMovieById")
			string parameter = args.Length > 2 ? args[2] : null; // Third argument (optional): Movie title or ID

			List<Movie> movies = new List<Movie>(); // List to store the retrieved movies

			// Determine which function to call based on the user's input
			switch (functionName)
			{
				case "GetAllMovies":
					// Call function to retrieve all movies
					movies = BasicFunctions.GetAllMovies();
					break;

				case "GetCheckedOutMovies":
					// Call function to retrieve only checked-out movies
					movies = BasicFunctions.GetCheckedOutMovies();
					break;

				case "GetMovieByTitle":
					// If "GetMovieByTitle" is selected, ensure a movie title was provided
					if (string.IsNullOrEmpty(parameter))
					{
						Console.WriteLine("Error: Missing movie title parameter.");
						return; // Exit if the parameter is missing
					}
					var movie = BasicFunctions.GetMovieByTitle(parameter);
					if (movie != null) movies.Add(movie); // Add movie to the list if found
					break;

				default:
					// Handle case where the function name is not recognized
					Console.WriteLine($"Error: Unknown function '{functionName}'.");
					return; // Exit if function is invalid
			}

			// Determine how to output the retrieved movies (CSV or Console)
			if (outputType.Equals("CSV", StringComparison.OrdinalIgnoreCase))
			{
				// If CSV is selected, write movies to a CSV file
				ConsoleUtils.WriteMoviesToCsv(movies);
				Console.WriteLine("Data successfully written to Movies.csv.");
			}
			else
			{
				// If Console is selected, print movies to the terminal
				var oh = new OutputHelper();
				oh.WriteToConsole(movies);
			}
		}
	}
}
