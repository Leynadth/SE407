using LeynadthBookstore.Models;
using Microsoft.EntityFrameworkCore;
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

		public static List<Book> GetAllBooksFull()
		{
			using (var context = new LeynadthBookstoreContext())
			{
				var books = context.Books
					.Include(books => books.Author)
					.Include(books => books.Genre)
					.ToList();

				return books;
							
			}
		}

		public static Book GetFullBookById(int id)
		{
			using (var context = new LeynadthBookstoreContext())
			{
				var books = context.Books
					.Include(books => books.Author)
					.Include(books => books.Genre)
					.Where(books => books.BookId == id)
					.FirstOrDefault();
				return books;

			}
		}

		public static Genre GetGenreById(int id)
		{
			using (var context = new LeynadthBookstoreContext())
			{
				return context.Genres.FirstOrDefault(g => g.GenreId == id);
			}
		}

		public static Author GetAuthorById(int id)
		{
			using (var context = new LeynadthBookstoreContext())
			{
				return context.Authors.FirstOrDefault(a => a.AuthorId == id);
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



		public static List<Author> GetAllAuthors()
		{
			using (var context = new LeynadthBookstoreContext())
			{
				return context.Authors.ToList();
			}
		}

		public static List<Genre> GetAllGenres()
		{
			using (var context = new LeynadthBookstoreContext())
			{
				return context.Genres.ToList();
			}
		}

		public static void AddBook(Book book)
		{
			try
			{
				using (var context = new LeynadthBookstoreContext())
				{
					context.Books.Add(book);
					context.SaveChanges();
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
				using (var context = new LeynadthBookstoreContext())
				{
					context.Genres.Add(genre);
					context.SaveChanges();
				}
			}
			catch (Exception e)
			{

			}
		}

		public static void AddAuthor(Author author)
		{
			try
			{
				using (var context = new LeynadthBookstoreContext())
				{
					context.Authors.Add(author);
					context.SaveChanges();
				}
			}
			catch (Exception e)
			{

			}
		}

		public static void DeleteBook(int id)
		{
			try
			{
				using (var context = new LeynadthBookstoreContext())
				{
					var bookToDelete = context.Books.Find(id);
					context.Books.Remove(bookToDelete);
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
				using (var context = new LeynadthBookstoreContext())
				{
					var genreToDelete = context.Genres.Find(id);
					context.Genres.Remove(genreToDelete);
					context.SaveChanges();
				}
			}
			catch (Exception e)
			{

			}
		}

		public static void DeleteAuthor(int id)
		{
			try
			{
				using (var context = new LeynadthBookstoreContext())
				{
					var authorToDelete = context.Authors.Find(id);
					context.Authors.Remove(authorToDelete);
					context.SaveChanges();
				}
			}
			catch (Exception e)
			{

			}
		}

		public static void EditBook(Book book)
		{
			try
			{
				using (var context = new LeynadthBookstoreContext())
				{
					context.Books.Update(book);
					context.SaveChanges();
				}
			}
			catch (Exception e)
			{

			}
		}


		public static void EditAuthor(Author author)
		{
			try
			{
				using (var context = new LeynadthBookstoreContext())
				{
					context.Authors.Update(author);
					context.SaveChanges();
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
				using (var context = new LeynadthBookstoreContext())
				{
					context.Genres.Update(genre);
					context.SaveChanges();
				}
			}
			catch (Exception e)
			{

			}
		}
	}
}
