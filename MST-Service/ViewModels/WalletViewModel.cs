using MST_Service.Entities;

namespace MST_Service.ViewModels
{
    public class WalletViewModel
    {
        public Guid Id { get; set; }

        public double Balance { get; set; }

        public TransactionViewModel? Transaction { get; set; }
        public UserViewModel? User { get; set; }

    }
}
