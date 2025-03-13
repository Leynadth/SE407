using System;
using System.Collections.Generic;

namespace LeynadthBookstore.Models;

public partial class TroubleTicket
{
    public int TicketId { get; set; }

    public string TicketTitle { get; set; } = null!;

    public string? TicketDesc { get; set; }

    public string Category { get; set; } = null!;

    public string ReportingEmail { get; set; } = null!;

    public DateTime OrigDate { get; set; }

    public DateTime? CloseDate { get; set; }

    public string? ResponderEmail { get; set; }

    public string? ResponderNotes { get; set; }

    public bool Active { get; set; }
}
