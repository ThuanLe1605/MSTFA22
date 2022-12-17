namespace MST_Service.RequestModels.Update
{
    public class ScheduleUpdateModel
    {
        public Guid? SlotId { get; set; }

        public Guid? SubjectId { get; set; }

        public Guid? UserId { get; set; }

        public Guid? LectureId { get; set; }
    }
}
