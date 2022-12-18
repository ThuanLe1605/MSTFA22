namespace MST_Service.ViewModels
{
    public class TransactionViewModel
    {
        public Guid Id { get; set; }

        public string Description { get; set; } = null!;

        public double Transform { get; set; }

        public WalletViewModel? Wallet { get; set; }

    }
}
