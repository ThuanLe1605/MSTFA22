using System;
using System.Collections.Generic;

namespace MST_Service.Entities;

public partial class User
{
    public Guid Id { get; set; }

    public string Username { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;
    public string? Phone { get; set; }

    public string? AvatarUrl { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public Guid? AddressId { get; set; }

    public bool? Status { get; set; }

    public virtual Address? Address { get; set; }

    public virtual ICollection<Booking> Bookings { get; } = new List<Booking>();

    public virtual ICollection<Feedback> Feedbacks { get; } = new List<Feedback>();

    public virtual ICollection<Schedule> Schedules { get; } = new List<Schedule>();

    public virtual ICollection<UserRole> UserRoles { get; } = new List<UserRole>();

    public virtual ICollection<Wallet> Wallets { get; } = new List<Wallet>();

    public virtual ICollection<Event> Events { get; } = new List<Event>();
}
