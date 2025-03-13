using System;
using System.Collections.Generic;

namespace LeynadthBookstore.Models;

public partial class Genre
{
    public int GenreId { get; set; }

    public string GenreType { get; set; } = null!;

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
