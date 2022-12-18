using MST_Service.Entities;

namespace MST_Service.ViewModels
{
    public class FeedbackViewModel
    {
        public Guid Id { get; set; }

        //public Guid? UserId { get; set; }

        //public Guid? LectureId { get; set; }

        public string? Content { get; set; }

        public double Star { get; set; }

        public LectureViewModel? Lecture { get; set; }

        public UserViewModel? User { get; set; }
    }
}
