using Bookstore.Models;
using Xunit;
using System.Collections.Generic;

namespace Bookstore.Test
{
	public class BasicFunctionsTest
	{
		[Fact]
		public void TestGetBookByTitle()
		{
			Book? testBook = BasicFunctions.GetBookByTitle("Wheres Waldo");
			Assert.Equal("Wheres Waldo", testBook?.Title);
		}

		[Fact]
		public void TestGetAllBooks()
		{
			int bookCount = BasicFunctions.GetAllBooks().Count;
			Assert.True(bookCount > 0);
		}

		[Fact]
		public void TestGetBooksByAuthorLastName()
		{
			List<Book> books = BasicFunctions.GetBooksByAuthorLastName("Johnson");
			Assert.NotEmpty(books);
		}
	}
}
