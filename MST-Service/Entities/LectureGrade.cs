using System;
using System.Collections.Generic;

namespace MST_Service.Entities;

public partial class LectureGrade
{
    public Guid LectureId { get; set; }

    public Guid GradeId { get; set; }

    public string? Description { get; set; }

    public virtual Grade Grade { get; set; } = null!;

    public virtual Lecture Lecture { get; set; } = null!;
}
