using System;
using System.Collections.Generic;

namespace LeynadthBookstore.Models;

public partial class Book
{
    public int BookId { get; set; }

    public string BookTitle { get; set; } = null!;

    public int GenreId { get; set; }

    public int AuthorId { get; set; }

    public short YearOfRelease { get; set; }

    public virtual Author Author { get; set; } = null!;

    public virtual Genre Genre { get; set; } = null!;

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
