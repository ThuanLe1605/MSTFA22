namespace MST_Service.RequestModels.Create
{
    public class PromotionCreateModel
    {
        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public DateTime? CreateDate { get; set; }

        public double Ratio { get; set; }
    }
}
