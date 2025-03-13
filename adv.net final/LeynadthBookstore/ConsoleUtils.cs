using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using CsvHelper;
using LeynadthBookstore.Models;

namespace LeynadthBookstore
{
	public static class ConsoleUtils
	{
		public static void ListBooks(IEnumerable<Book> books)
		{
			Console.WriteLine("List of Books:");

			foreach (Book book in books)
			{
				Console.WriteLine($"Title: {book.BookTitle}, Author: {book.Author?.AuthorLast ?? "Unknown"}, Genre: {book.Genre?.GenreType}, Year: {book.YearOfRelease}");
			}
		}

		public static void WriteBooksToCsv(IEnumerable<Book> books)
		{
			string filePath = "Books.csv";

			using (var streamWriter = new StreamWriter(filePath))
			using (var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture))
			{
				csvWriter.WriteRecords(books);
			}

			Console.WriteLine($"📂 CSV file saved at: {Path.GetFullPath(filePath)}");
		}
	}
}
