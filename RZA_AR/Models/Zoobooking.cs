using System;
using System.Collections.Generic;

namespace RZA_AR.Models;

public partial class Zoobooking
{
    public int BookingId { get; set; }

    public DateOnly? VisitDate { get; set; }

    public int? NumberofGuests { get; set; }

    public string? TicketType { get; set; }

    public int? TotalPrice { get; set; }
}
