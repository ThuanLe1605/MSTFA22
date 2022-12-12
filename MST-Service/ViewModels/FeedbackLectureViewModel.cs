namespace MST_Service.ViewModels
{
    public class FeedbackLectureViewModel
    {
        public Guid Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? AvatarUrl { get; set; }

        public GenderViewModel? Gender { get; set; }
    }
}
