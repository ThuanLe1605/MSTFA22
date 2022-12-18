using MST_Service.Entities;
using MST_Service.ViewModels;

namespace MST_Service.RequestModels.Create
{
    public class EventCreateModel
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public string? Thumbnail { get; set; }

        public string? Description { get; set; }

        public DateTime? CreateDate { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime EndDate { get; set; }

        //public PromotionViewModel? Promotion { get; set; }

    }
}
