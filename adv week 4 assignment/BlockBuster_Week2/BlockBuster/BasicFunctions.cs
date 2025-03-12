using BlockBuster.Models;
using System.Collections.Generic;
using System.Linq;

namespace BlockBuster
{
	public static class BasicFunctions
	{
		public static Movie? GetMovieById(int movieId)
		{
			using (var context = new Se407BlockBusterContext())
			{
				return context.Movies.Find(movieId);
			}
		}

		public static Movie? GetMovieByTitle(string title)
		{
			using (var context = new Se407BlockBusterContext())
			{
				return context.Movies.FirstOrDefault(m => m.Title == title);
			}
		}

		public static List<Movie> GetAllMovies()
		{
			using (var context = new Se407BlockBusterContext())
			{
				return context.Movies.ToList();
			}
		}

		public static List<Movie> GetMoviesByGenre(string genreDescription)
		{
			using (var context = new Se407BlockBusterContext())
			{
				return context.Movies
					.Where(m => m.Genre.GenreDescr == genreDescription)
					.ToList();
			}
		}

		public static List<Movie> GetMoviesByDirector(string directorLastName)
		{
			using (var context = new Se407BlockBusterContext())
			{
				return context.Movies
					.Where(m => m.Director.LastName == directorLastName)
					.ToList();
			}
		}

		//public static List<Movie> GetCheckedOutMovies()
		//{
		//	using (var context = new Se407BlockBusterContext())
		//	{
		//		return context
		//			.Transactions
		//			.Where(t => t.CheckedIn.Equals("N"))
		//			.Join(
		//				context.Movies,
		//				t => t.MovieId,
		//				m => m.MovieId,
		//				(t, m) => m
		//			)
		//			.ToList();
		//	}
		//}

		public static List<Movie> GetCheckedOutMovies()
		{
			using (var db = new Se407BlockBusterContext())
			{
				return db.Movies
					.Join(db.Transactions,
						  m => m.MovieId,
						  t => t.MovieId,
						  (m, t) => new
						  {
							  MovieId = m.MovieId,
							  Title = m.Title,
							  ReleaseYear = m.ReleaseYear,
							  GenreId = m.GenreId,
							  DirectorId = m.DirectorId,
							  CheckedIn = t.CheckedIn
						  })
					.Where(m => m.CheckedIn == "N")
					.Select(m => new Movie
					{
						MovieId = m.MovieId,
						Title = m.Title,
						ReleaseYear = m.ReleaseYear,
						GenreId = m.GenreId,
						DirectorId = m.DirectorId
					})
					.ToList();
			}
		}

	}
}
