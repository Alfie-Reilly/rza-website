using System;
using System.Collections.Generic;

namespace RZA_AR.Models;

public partial class Room
{
    public int Roomnumber { get; set; }

    public int? Capacity { get; set; }

    public string? RoomType { get; set; }

    public virtual ICollection<Roombooking> Roombookings { get; set; } = new List<Roombooking>();
}
