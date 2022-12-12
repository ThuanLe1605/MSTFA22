using System;
using System.Collections.Generic;

namespace MST_Service.Entities;

public partial class Feedback
{
    public Guid Id { get; set; }

    public Guid? UserId { get; set; }

    public Guid? LectureId { get; set; }

    public string? Content { get; set; }

    public double Star { get; set; }

    public virtual Lecture? Lecture { get; set; }

    public virtual User? User { get; set; }
}
