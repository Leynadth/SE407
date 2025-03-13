using BlockBuster.Models;
using Microsoft.EntityFrameworkCore;

namespace BlockBuster
{
    public static class BasicFunctions
    {
        public static Movie? GetMovieById(int movieId)
        {
            using(var context = new Se407BlockBusterContext())
            {
                return context.Movies.Find(movieId);
            }
        }


        public static Movie? GetMovieWithDetailsById(int id)
        {
            using (var context = new Se407BlockBusterContext())
            {
                var movie = context.Movies
                    .Include(m => m.Director)
                    .Include(m => m.Genre)
                    .Where(m => m.MovieId == id)
                    .FirstOrDefault();
                return movie;
            }
        }


        public static List<Genre> GetAllGenres()
        {
            using (var context = new Se407BlockBusterContext())
            {
                return
                    context.Genres.ToList();
            }
        }


        public static List<Director> GetAllDirectors()
        {
            using (var context = new Se407BlockBusterContext())
            {
                return
                    context.Directors.ToList();
            }
        }


        public static Genre? GetGenreById(int genreId)
        {
            using (var context = new Se407BlockBusterContext())
            {
                return
                    context.Genres.FirstOrDefault(genre => genre.GenreId == genreId);
            }
        }


        public static Director? GetDirectorById(int directorId)
        {
            using (var context = new Se407BlockBusterContext())
            {
                return
                    context.Directors.FirstOrDefault(dir => dir.DirectorId == directorId);
            }
        }



        public static List<Movie> GetAllMovies()
        {
            using (var context = new Se407BlockBusterContext())
            {
                return context.Movies.ToList();
            }
        }


        public static List<Movie> GetAllMoviesWithDetails()
        {
            using(var context = new Se407BlockBusterContext())
            {
                return
                    context
                        .Movies
                        .Include(movie => movie.Director)
                        .Include(Movie => Movie.Genre)
                        .ToList();

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


        public static void UpdateMovie
        (
            int movieId,
            string updatedTitle,
            int updatedReleaseYear,
            Director updatedDirector,
            Genre updatedGenre
        )
        {
            using (var context = new Se407BlockBusterContext())
            {
                var movieToUpdate = GetMovieById(movieId);
                
                if(movieToUpdate != null)
                {
                    movieToUpdate.Title = updatedTitle;
                    movieToUpdate.ReleaseYear = updatedReleaseYear;
                    movieToUpdate.Director = updatedDirector;
                    movieToUpdate.Genre = updatedGenre;
                }

                context.Update(movieToUpdate);

                context.SaveChanges();
            }
        }

		public static void AddMovie(Movie movie)
		{
			try
			{
				using (var db = new Se407BlockBusterContext())
				{
					db.Movies.Add(movie);
					db.SaveChanges();
				}
			}
			catch (Exception e)
			{
			}
		}
		public static void DeleteMovie(int id)
		{
			try
			{
				using (var db = new Se407BlockBusterContext())
				{
					var movieToDelete = db.Movies.Find(id);
					db.Movies.Remove(movieToDelete);
					db.SaveChanges();
				}
			}
			catch (Exception e)
			{
			}
		}

		public static void AddGenre(Genre genre)
		{
			try
			{
				using (var db = new Se407BlockBusterContext())
				{
					db.Genres.Add(genre);
					db.SaveChanges();
				}
			}
			catch (Exception e)
			{
			}
		}

		public static void AddDirector(Director director)
		{
			try
			{
				using (var db = new Se407BlockBusterContext())
				{
					db.Directors.Add(director);
					db.SaveChanges();
				}
			}
			catch (Exception e)
			{
			}
		}

		public static void EditGenre(Genre genre)
		{
			try
			{
				using (var context = new Se407BlockBusterContext())
				{
					context.Genres.Update(genre);
					context.SaveChanges();
				}
			}
			catch (Exception e)
			{

			}
		}

		public static void EditDirector(Director director)
		{
			try
			{
				using (var context = new Se407BlockBusterContext())
				{
					context.Directors.Update(director);
					context.SaveChanges();
				}
			}
			catch (Exception e)
			{

			}
		}

		public static void DeleteGenre(int id)
		{
			try
			{
				using (var db = new Se407BlockBusterContext())
				{
					var genreToDelete = db.Genres.Find(id);
					db.Genres.Remove(genreToDelete);
					db.SaveChanges();
				}
			}
			catch (Exception e)
			{
			}
		}


		public static void DeleteDirector(int id)
		{
			try
			{
				using (var db = new Se407BlockBusterContext())
				{
					var directorToDelete = db.Directors.Find(id);
					db.Directors.Remove(directorToDelete);
					db.SaveChanges();
				}
			}
			catch (Exception e)
			{
			}
		}
	}
}
