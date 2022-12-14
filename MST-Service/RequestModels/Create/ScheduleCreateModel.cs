namespace MST_Service.RequestModels.Create
{
    public class ScheduleCreateModel
    {
        public Guid SlotId { get; set; }

        public Guid SubjectId { get; set; }

        public Guid UserId { get; set; }

        public Guid LectureId { get; set; }
    }
}
