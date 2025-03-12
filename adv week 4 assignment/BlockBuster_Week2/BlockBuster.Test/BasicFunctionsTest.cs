using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;
using System.Linq;
using BlockBuster.Models;

namespace BlockBuster.Test
{
    public class BasicFunctionsTest
    {

		private readonly ITestOutputHelper _output;

		public BasicFunctionsTest(ITestOutputHelper output)
		{
			_output = output;
		}
		[Fact]
        public void TestGetMovieById()
        {
  
            var testMovie = BasicFunctions.GetMovieById(11);
            Assert.Equal("Vertigo", testMovie?.Title);
			Assert.Equal(1958, testMovie?.ReleaseYear);

		}


		[Fact]
		public void TestGetAllMovies()
		{
			var result = BasicFunctions.GetAllMovies();

			// Print the actual count in xUnit output
			_output.WriteLine($"Expected: 50, Actual: {result.Count}");

			Assert.Equal(52, result.Count);
		}



		[Fact]
        public void TestGetCheckedOutMovies()
        {
            int checkedOutMoviesCount = 
                BasicFunctions.GetCheckedOutMovies().Count;

            Assert.Equal(2, checkedOutMoviesCount);
        }
    }
}