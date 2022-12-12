using System;
using System.Collections.Generic;

namespace MST_Service.Entities;

public partial class Schedule
{
    public Guid Id { get; set; }

    public Guid SlotId { get; set; }

    public Guid SubjectId { get; set; }

    public Guid UserId { get; set; }

    public Guid LectureId { get; set; }

    public virtual Lecture Lecture { get; set; } = null!;

    public virtual Slot Slot { get; set; } = null!;

    public virtual Subject Subject { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
