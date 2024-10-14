using System;
using System.Collections.Generic;

namespace RZA_AR.Models;

public partial class Roombooking
{
    public int CustomerId { get; set; }

    public int RoomNumber { get; set; }

    public DateOnly CheckinDate { get; set; }

    public DateOnly? CheckoutDate { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual Room RoomNumberNavigation { get; set; } = null!;
}
