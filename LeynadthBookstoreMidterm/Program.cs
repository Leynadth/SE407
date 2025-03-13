using System;
using System.Collections.Generic;
using LeynadthBookstore.Models;

namespace LeynadthBookstore
{
	class Program
	{
		static void Main(string[] args)
		{
			if (args.Length < 2)
			{
				Console.WriteLine("Usage: <OutputType> <Function> [Parameter]");
				Console.WriteLine("Example: Console GetBookByTitle 'abc'");
				Console.WriteLine("Example: CSV GetBooksByAuthorLastName 'Chaucer'");
				return;
			}

			string outputType = args[0];  // "Console" or "CSV"
			string functionName = args[1]; // The function name (GetAllBooks, GetBookByTitle, etc.)
			string parameter = args.Length > 2 ? args[2] : null;

			List<Book> books = new List<Book>();

			// Determine which function to call
			switch (functionName)
			{
				case "GetAllBooks":
					books = BasicFunctions.GetAllBooks();
					break;

				case "GetBookByTitle":
					if (string.IsNullOrEmpty(parameter))
					{
						Console.WriteLine("Error: Missing book title.");
						return;
					}
					var book = BasicFunctions.GetBookByTitle(parameter);
					if (book != null) books.Add(book);
					break;

				case "GetBooksByAuthorLastName":
					if (string.IsNullOrEmpty(parameter))
					{
						Console.WriteLine("Error: Missing author last name.");
						return;
					}
					books = BasicFunctions.GetBooksByAuthorLastName(parameter);
					break;

				default:
					Console.WriteLine($"Error: Unknown function '{functionName}'.");
					return;
			}

			// Output the results (to Console or CSV)
			if (outputType.Equals("CSV", StringComparison.OrdinalIgnoreCase))
			{
				ConsoleUtils.WriteBooksToCsv(books);
				Console.WriteLine("Data successfully written to Books.csv.");
			}
			else
			{
				ConsoleUtils.ListBooks(books);
			}
		}
	}
}
