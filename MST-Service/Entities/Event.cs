using System;
using System.Collections.Generic;

namespace MST_Service.Entities;

public partial class Event
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public string? Thumbnail { get; set; }

    public string? Description { get; set; }

    public DateTime? CreateDate { get; set; }

    public Guid? PromotionId { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public virtual Promotion? Promotion { get; set; }

    public virtual ICollection<User> Users { get; } = new List<User>();
}
