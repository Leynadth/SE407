using LeynadthBookstore.Models;
using System.Collections.Generic;
using System.Linq;

namespace LeynadthBookstore
{
	public static class BasicFunctions
	{
		// Get book by title
		public static Book? GetBookByTitle(string title)
		{
			using (var context = new LeynadthBookstoreContext())
			{
				return context.Books.FirstOrDefault(b => b.BookTitle == title);
			}
		}

		// Get all books
		public static List<Book> GetAllBooks()
		{
			using (var context = new LeynadthBookstoreContext())
			{
				return context.Books.ToList();
			}
		}

		// Get books by author last name
		public static List<Book> GetBooksByAuthorLastName(string lastName)
		{
			using (var context = new LeynadthBookstoreContext())
			{
				return context.Authors
					.Where(a => a.AuthorLast == lastName)
					.Join(
						context.Books,
						a => a.AuthorId,
						b => b.AuthorId,
						(a, b) => b
					)
					.ToList();
			}
		}
	}
}
