using System;
using System.Collections.Generic;

namespace MST_Service.Entities;

public partial class Booking
{
    public Guid Id { get; set; }

    public Guid? LectureId { get; set; }

    public Guid? UserId { get; set; }

    public Guid? PaymentId { get; set; }

    public DateTime? BookingAt { get; set; }

    public Guid? BookingStatusId { get; set; }

    public virtual BookingStatus? BookingStatus { get; set; }

    public virtual Lecture? Lecture { get; set; }

    public virtual Payment? Payment { get; set; }

    public virtual User? User { get; set; }
}
