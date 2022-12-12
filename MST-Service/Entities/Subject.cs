using System;
using System.Collections.Generic;

namespace MST_Service.Entities;

public partial class Subject
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<Demand> Demands { get; } = new List<Demand>();

    public virtual ICollection<LectureSubject> LectureSubjects { get; } = new List<LectureSubject>();

    public virtual ICollection<Schedule> Schedules { get; } = new List<Schedule>();
}
