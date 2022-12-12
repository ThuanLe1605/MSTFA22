namespace MST_Service.ViewModels
{
    public class PaymentViewModel
    {
        public Guid Id { get; set; }

        public double Fee { get; set; }

        public bool? IsPayment { get; set; }

        public string? Description { get; set; }

    }
}
