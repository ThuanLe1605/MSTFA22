namespace MST_Service.ViewModels
{
    public class PromotionViewModel
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public DateTime? CreateDate { get; set; }

        public double Ratio { get; set; }
    }
}
