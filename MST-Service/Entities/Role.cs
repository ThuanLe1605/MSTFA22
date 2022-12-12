using System;
using System.Collections.Generic;

namespace MST_Service.Entities;

public partial class Role
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<UserRole> UserRoles { get; } = new List<UserRole>();
}
