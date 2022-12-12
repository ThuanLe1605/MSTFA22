using System;
using System.Collections.Generic;

namespace MST_Service.Entities;

public partial class Promotion
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public DateTime? CreateDate { get; set; }

    public double Ratio { get; set; }

    public virtual ICollection<Event> Events { get; } = new List<Event>();
}
