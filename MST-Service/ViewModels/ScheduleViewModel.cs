using MST_Service.Entities;

namespace MST_Service.ViewModels
{
    public class ScheduleViewModel
    {
        public Guid Id { get; set; }

        public Guid SlotId { get; set; }

        public Guid SubjectId { get; set; }

        public Guid UserId { get; set; }

        public Guid LectureId { get; set; }

        public SlotViewModel? Slot { get; set; } = null!;
        public SubjectViewModel? Subject { get; set; } = null!;
    }
}
