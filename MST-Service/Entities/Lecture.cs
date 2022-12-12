using System;
using System.Collections.Generic;

namespace MST_Service.Entities;

public partial class Lecture
{
    public Guid Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? AvatarUrl { get; set; }

    public Guid? GenderId { get; set; }

    public string? Bio { get; set; }

    public double Price { get; set; }

    public bool? Status { get; set; }

    public virtual ICollection<Booking> Bookings { get; } = new List<Booking>();

    public virtual ICollection<Feedback> Feedbacks { get; } = new List<Feedback>();

    public virtual Gender? Gender { get; set; }

    public virtual ICollection<LectureDocument> LectureDocuments { get; } = new List<LectureDocument>();

    public virtual ICollection<LectureGrade> LectureGrades { get; } = new List<LectureGrade>();

    public virtual ICollection<LectureSubject> LectureSubjects { get; } = new List<LectureSubject>();

    public virtual ICollection<Schedule> Schedules { get; } = new List<Schedule>();
}
