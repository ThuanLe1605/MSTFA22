using System;
using System.Collections.Generic;

namespace MST_Service.Entities;

public partial class LectureSubject
{
    public Guid LectureId { get; set; }

    public Guid SubjectId { get; set; }

    public string? Description { get; set; }

    public virtual Lecture Lecture { get; set; } = null!;

    public virtual Subject Subject { get; set; } = null!;
}
