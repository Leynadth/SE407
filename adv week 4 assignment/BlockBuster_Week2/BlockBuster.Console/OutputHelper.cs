using BlockBuster.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockBuster.ConsoleApp
{
	internal class OutputHelper
	{
		public void WriteToConsole(List<Movie> movies)
		{
			Console.WriteLine("List of Movies");
			foreach (var m in movies)
			{
				Console.WriteLine($"MovieID: {m.MovieId}    Title: {m.Title}    Release Year: {m.ReleaseYear}");
			}
		}
	}
}
