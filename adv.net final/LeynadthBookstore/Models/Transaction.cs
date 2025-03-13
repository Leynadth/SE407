using System;
using System.Collections.Generic;

namespace LeynadthBookstore.Models;

public partial class Transaction
{
    public int TransactionId { get; set; }

    public int BookId { get; set; }

    public int CustomerId { get; set; }

    public DateOnly CheckedOutDate { get; set; }

    public DateOnly DueDate { get; set; }

    public string CheckedIn { get; set; } = null!;

    public virtual Book Book { get; set; } = null!;

    public virtual Customer Customer { get; set; } = null!;
}
