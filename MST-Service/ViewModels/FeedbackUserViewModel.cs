namespace MST_Service.ViewModels
{
    public class FeedbackUserViewModel
    {
        public Guid Id { get; set; }
        public string Email { get; set; } = null!;

        public string? AvatarUrl { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }
    }
}
