using System;
using System.Collections.Generic;

namespace MST_Service.Entities;

public partial class Payment
{
    public Guid Id { get; set; }

    public double Fee { get; set; }

    public bool? IsPayment { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Booking> Bookings { get; } = new List<Booking>();
}
