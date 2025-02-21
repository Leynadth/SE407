using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Design;
using Bookstore.Models;
using CsvHelper;
using System.IO;

namespace Bookstore.ConsoleApp
{
	public class ConsoleUtils
	{
		public static void ListBooks(IEnumerable<Book> books)
		{
			Console.WriteLine("List of Books:");

			foreach (Book book in books)
			{
				Console.WriteLine($"Book Title: {book.Title}, Author: {book.Author?.LastName ?? "Unknown"}, Release Year: {book.ReleaseYear}");
			}
		}

		public static void WriteBooksToCsv(IEnumerable<Book> books)
		{
			using (var streamWriter = new StreamWriter("..\\Books.csv"))
			{
				using (var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture))
				{
					csvWriter.WriteRecords(books);
				}
			}
		}

		public static void ListObjects<TOutputObj>(IEnumerable<TOutputObj> objectsToShow)
			where TOutputObj : class
		{
			PropertyInfo[] props = typeof(TOutputObj).GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
			StringBuilder objectStringBuilder = new StringBuilder();

			foreach (TOutputObj obj in objectsToShow)
			{
				foreach (PropertyInfo property in props)
				{
					objectStringBuilder.Append($"{property.Name}: {property.GetValue(obj)}, ");
				}

				Console.WriteLine(objectStringBuilder.ToString().Trim(',', ' '));
			}
		}
	}
}
