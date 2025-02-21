using BlockBuster.Models;

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

		public static List<Movie> GetAllMovies()
		{
			using (var context = new Se407BlockBusterContext())
			{
				return context.Movies.ToList();
			}
		}

		public static List<Movie> GetCheckedOutMovies()
		{
			using (var context = new Se407BlockBusterContext())
			{
				return
					context
						.Transactions
						.Where(t => t.CheckedIn.Equals("N"))
						.Join
						(
							context.Movies,
							t => t.MovieId,
							m => m.MovieId,
							(t, m) => m
						)
						.ToList();
			}
		}

		public static List<Movie> GetMoviesByGenre(string genreDescr)
		{
			using (var context = new Se407BlockBusterContext())
			{
				return
					context
						.FullMovieListGenres
						.Where(fmlg => fmlg.GenreDescr == genreDescr)
						.Join
						(
							context.Movies,
							fmlg => fmlg.Title,
							m => m.Title,
							(fmlg, m) => m
						)
						.ToList();
			}
		}

		public static List<Movie> GetMoviesByDirectorLastName(string lastName)
		{
			using (var context = new Se407BlockBusterContext())
			{
				return
					context
						.Directors
						.Where(d => d.LastName == lastName)
						.Join
						(
							context.Movies,
							d => d.DirectorId,
							m => m.DirectorId,
							(d, m) => m
						)
						.ToList();
			}
		}
	}
}