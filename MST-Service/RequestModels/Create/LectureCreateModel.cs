namespace MST_Service.RequestModels.Create
{
    public class LectureCreateModel
    {
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string? AvatarUrl { get; set; }

        public Guid? GenderId { get; set; }

        public string? Bio { get; set; }

        public double Price { get; set; }

        public bool? Status { get; set; }
    }
}
