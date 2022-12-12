using System;
using System.Collections.Generic;

namespace MST_Service.Entities;

public partial class Slot
{
    internal object id;
    internal object FirstName;

    public Guid Id { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public virtual ICollection<Schedule> Schedules { get; } = new List<Schedule>();
}
