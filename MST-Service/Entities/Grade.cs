using System;
using System.Collections.Generic;

namespace MST_Service.Entities;

public partial class Grade
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<Demand> Demands { get; } = new List<Demand>();

    public virtual ICollection<GradeSyllabus> GradeSyllabi { get; } = new List<GradeSyllabus>();

    public virtual ICollection<LectureGrade> LectureGrades { get; } = new List<LectureGrade>();
}
