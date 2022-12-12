using System;
using System.Collections.Generic;

namespace MST_Service.Entities;

public partial class GradeSyllabus
{
    public Guid GradeId { get; set; }

    public Guid SyllabusId { get; set; }

    public double Ratio { get; set; }

    public virtual Grade Grade { get; set; } = null!;

    public virtual Syllabus Syllabus { get; set; } = null!;
}
