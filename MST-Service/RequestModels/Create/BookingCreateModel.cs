using MST_Service.Entities;

namespace MST_Service.RequestModels.Create
{
    public class BookingCreateModel
    {
        public Guid? LectureId { get; set; }

        public Guid? UserId { get; set; }

        public Guid? BookingStatusId { get; set; }

    }
}
