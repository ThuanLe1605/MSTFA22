using MST_Service.Entities;

namespace MST_Service.ViewModels
{
    public class BookingViewModel
    {
        public Guid Id { get; set; }

        public DateTime? BookingAt { get; set; }

        public BookingStatusViewModel? BookingStatus { get; set; }

        public LectureViewModel? Lecture { get; set; }

        public PaymentViewModel? Payment { get; set; }

        public UserViewModel? User { get; set; }
    }
}
