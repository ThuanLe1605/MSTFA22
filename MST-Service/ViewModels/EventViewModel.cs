using MST_Service.Entities;

namespace MST_Service.ViewModels
{
    public class EventViewModel
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }

        public string? Thumbnail { get; set; }

        public string? Description { get; set; }

        public DateTime? CreateDate { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public PromotionViewModel? Promotion { get; set; }

    }
}
