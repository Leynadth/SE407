using BlockBuster.Models;

namespace BlockBuster.Test
{
	public class BasicFunctionsTest
	{
		[Fact]
		public void TestGetMovieById()
		{
			Movie? testMovie = BasicFunctions.GetMovieById(14);
			Assert.Equal("The Godfather: Part II", testMovie?.Title);
		}

		[Fact]
		public void TestGetAllMovies()
		{
			int movieCount = BasicFunctions.GetAllMovies().Count;
			Assert.Equal(51, movieCount);
		}

		[Fact]
		public void TestGetCheckedOutMovies()
		{
			int checkedOutMoviesCount =
				BasicFunctions.GetCheckedOutMovies().Count;

			Assert.Equal(3, checkedOutMoviesCount);
		}

		[Fact]
		public void TestGetMoviesByGenre()
		{
			List<Movie> movies = BasicFunctions.GetMoviesByGenre("Action");
			Assert.NotEmpty(movies);
		}

		[Fact]
		public void TestGetMoviesByDirectorLastName()
		{
			List<Movie> movies = BasicFunctions.GetMoviesByDirectorLastName("Scorsese");
			Assert.NotEmpty(movies);
		}
	}
}