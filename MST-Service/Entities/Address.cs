using System;
using System.Collections.Generic;

namespace MST_Service.Entities;

public partial class Address
{
    public Guid Id { get; set; }

    public string City { get; set; } = null!;

    public string District { get; set; } = null!;

    public string Street { get; set; } = null!;

    public string? ApartmentNumber { get; set; }

    public virtual ICollection<User> Users { get; } = new List<User>();
}
