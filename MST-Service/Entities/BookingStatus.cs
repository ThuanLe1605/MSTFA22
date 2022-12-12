using System;
using System.Collections.Generic;

namespace MST_Service.Entities;

public partial class BookingStatus
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<Booking> Bookings { get; } = new List<Booking>();
}
