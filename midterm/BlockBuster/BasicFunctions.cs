using Bookstore.Models;
using System.Collections.Generic;
using System.Linq;

namespace Bookstore
{
	public static class BasicFunctions
	{
		public static Book? GetBookByTitle(string title)
		{
			using (var context = new Se407BookstoreContext())
			{
				return context.Books.FirstOrDefault(b => b.Title == title);
			}
		}

		public static List<Book> GetAllBooks()
		{
			using (var context = new Se407BookstoreContext())
			{
				return context.Books.ToList();
			}
		}

		public static List<Book> GetBooksByAuthorLastName(string lastName)
		{
			using (var context = new Se407BookstoreContext())
			{
				return
					context
						.Authors
						.Where(a => a.LastName == lastName)
						.Join
						(
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
