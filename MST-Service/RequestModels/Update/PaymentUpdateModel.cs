namespace MST_Service.RequestModels.Update
{
    public class PaymentUpdateModel
    {
        public double Fee { get; set; }

        public bool? IsPayment { get; set; }

        public string? Description { get; set; }
    }
}
