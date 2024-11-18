using System;
using System.Collections.Generic;

namespace RZA_AR.Models;

public partial class Attraction1
{
    public int AttractionId { get; set; }

    public string? AttractionName { get; set; }

    public string? AttractionDescription { get; set; }

    public float? Price { get; set; }
}
