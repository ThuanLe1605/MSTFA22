namespace MST_Service.RequestModels.Create
{
    public class PaymentCreateModel
    {
        public double Fee { get; set; }

        public bool? IsPayment { get; set; }

        public string? Description { get; set; }
    }
}
