using System;
using System.Collections.Generic;

namespace LeynadthBookstore.Models;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string CustomerFirst { get; set; } = null!;

    public string CustomerLast { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string City { get; set; } = null!;

    public string State { get; set; } = null!;

    public string Zip { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
