using System;
using System.Collections.Generic;

namespace MST_Service.Entities;

public partial class Demand
{
    public Guid Id { get; set; }
    public string Status { get; set; }

    public Guid GradeId { get; set; }

    public Guid SubjectId { get; set; }

    public Guid SyllabusId { get; set; }

    public Guid? GenderId { get; set; }

    public virtual Gender? Gender { get; set; }

    public virtual Grade Grade { get; set; } = null!;

    public virtual Subject Subject { get; set; } = null!;

    public virtual Syllabus Syllabus { get; set; } = null!;
}
