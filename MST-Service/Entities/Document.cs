using System;
using System.Collections.Generic;

namespace MST_Service.Entities;

public partial class Document
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string Url { get; set; } = null!;

    public bool? Status { get; set; }

    public virtual ICollection<LectureDocument> LectureDocuments { get; } = new List<LectureDocument>();
}
