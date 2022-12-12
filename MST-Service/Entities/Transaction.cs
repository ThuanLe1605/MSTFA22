using System;
using System.Collections.Generic;

namespace MST_Service.Entities;

public partial class Transaction
{
    public Guid Id { get; set; }

    public Guid? WalletId { get; set; }

    public string Description { get; set; } = null!;

    public double Transform { get; set; }

    public virtual Wallet? Wallet { get; set; }
}
