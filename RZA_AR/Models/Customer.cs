using System;
using System.Collections.Generic;

namespace RZA_AR.Models;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public string? Firstname { get; set; }

    public string? Lastname { get; set; }

    public string? Email { get; set; }

    public string? Postcode { get; set; }

    public string? Phonenumber { get; set; }

    public DateOnly? Dob { get; set; }

    public int? Loyaltypoints { get; set; }

    public virtual ICollection<Roombooking> Roombookings { get; set; } = new List<Roombooking>();
}
