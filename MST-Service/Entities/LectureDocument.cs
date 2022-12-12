using System;
using System.Collections.Generic;

namespace MST_Service.Entities;

public partial class LectureDocument
{
    public Guid LectureId { get; set; }

    public Guid DocumentId { get; set; }

    public string? Description { get; set; }

    public virtual Document Document { get; set; } = null!;

    public virtual Lecture Lecture { get; set; } = null!;
}
