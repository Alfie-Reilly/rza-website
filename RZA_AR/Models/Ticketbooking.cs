﻿using System;
using System.Collections.Generic;

namespace RZA_AR.Models;

public partial class Ticketbooking
{
    public int CustomerId { get; set; }

    public int TicketId { get; set; }

    public DateOnly DateBooked { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual Ticket Ticket { get; set; } = null!;
}
