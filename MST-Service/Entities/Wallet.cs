using System;
using System.Collections.Generic;

namespace MST_Service.Entities;

public partial class Wallet
{
    public Guid Id { get; set; }

    public Guid? UserId { get; set; }

    public double Balance { get; set; }

    public virtual ICollection<Transaction> Transactions { get; } = new List<Transaction>();

    public virtual User? User { get; set; }
}
