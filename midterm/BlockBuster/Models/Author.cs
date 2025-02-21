using System;
using System.Collections.Generic;

namespace Bookstore.Models;

public partial class Author
{
	public int AuthorId { get; set; }

	public string FirstName { get; set; } = null!;

	public string? MiddleName { get; set; }

	public string LastName { get; set; } = null!;

	public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
